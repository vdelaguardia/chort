namespace chort_backend.source.data
{
    public interface IRepository<T>
    {
        T Get(string id);

        void Post(T entity);

        void Put(T entity);

        void Delete(string id);
    }
}
