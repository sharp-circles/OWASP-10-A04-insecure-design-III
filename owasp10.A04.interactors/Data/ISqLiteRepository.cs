using owasp10.A04.business.Entities;

namespace owasp10.A04.business.Data;

public interface ISqLiteRepository<T> where T : Entity
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> QueryAsync(string property, string value);
    Task CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
}
