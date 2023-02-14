namespace WineSales.Domain.RepositoryInterfaces
{
    public interface ICrudRepository<T>
    {
        T Create(T entity);
        List<T> GetAll();
        T GetByID(int id);
        T Update(T entity);
        T Delete(int id);
    }
}
