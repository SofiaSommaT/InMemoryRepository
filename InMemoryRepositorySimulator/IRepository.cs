namespace InMemoryRepositorySimulator
{
    public interface IRepository
    {
        bool Add<TKey, TValue>(TKey key, TValue value);
        bool Remove<TKey>(TKey key);
        TValue Get<TValue>(object key);
        bool EmptyAll();
        int Count();
    }
}