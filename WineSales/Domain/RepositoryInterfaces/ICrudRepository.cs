namespace WineSales.Domain.RepositoryInterfaces
{
    public interface ICrudRepository<T>
    {
        T Create(T entity);
        List<T> GetAll();
        T GetByID(int ID);
        T Update(T entity);
        T Delete(T entity);
    }
}
