namespace WineSales.Domain.RepositoryInterfaces
{
    public interface ICrudRepository<T>
    {
        void Create(T entity);
        List<T> GetAll();
        T GetByID(int ID);
        void Update(T entity);
        void Delete(T entity);
    }
}
