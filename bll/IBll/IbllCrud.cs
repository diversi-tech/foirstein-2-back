namespace BL.BLApi;

public interface IblCrud<T>
{
    Task<bool> Create(T item);

    Task<bool> Delete(T item);

    Task<List<T>> Read(Func<T, bool> filter);

    Task<T> ReadbyId(int item);

    Task<List<T>> ReadAll();

    Task<bool> Update(T item);
}
