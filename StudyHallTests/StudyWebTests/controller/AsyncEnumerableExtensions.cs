using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace StudyHallTests.StudyWebTests.controller;

public static class AsyncEnumerableExtensions
{
    public static DbSet<T> AsAsyncDbSet<T>(this IEnumerable<T> source) where T : class
    {
        var asyncEnumerable = new TestAsyncEnumerable<T>(source);
        var dbSet = new Mock<DbSet<T>>();

        dbSet.As<IAsyncEnumerable<T>>().Setup(m => m.GetAsyncEnumerator(default)).Returns(asyncEnumerable.GetAsyncEnumerator);
        dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(asyncEnumerable.AsQueryable().Provider);
        dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(asyncEnumerable.AsQueryable().Expression);
        dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(asyncEnumerable.AsQueryable().ElementType);
        dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => asyncEnumerable.AsQueryable().GetEnumerator());

        return dbSet.Object;
    }

    private class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public TestAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }
    }

    private class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator;

        public TestAsyncEnumerator(IEnumerator<T> enumerator)
        {
            this.enumerator = enumerator;
        }

        public T Current => this.enumerator.Current;

        public ValueTask DisposeAsync()
        {
            this.enumerator.Dispose();
            return ValueTask.CompletedTask;
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return ValueTask.FromResult(this.enumerator.MoveNext());
        }
    }
}