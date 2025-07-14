using AutoMapper;
using owasp10.A04.business.Data;
using owasp10.A04.business.Entities;
using SQLite;
using System.Reflection;

namespace owasp10.A04.data.access.Repositories;

public class SQLiteRepository<T> : ISqLiteRepository<T> where T : Entity, new()
{
    private static readonly string _dbName = SqLiteConstants.DbName;
    private static readonly string _dbDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "./";

    private readonly SQLiteAsyncConnection _context;
    private readonly IMapper _mapper;
    private readonly Type _tableReferenceType;

    public SQLiteRepository(IMapper mapper)
    {
        _mapper = mapper;
        _context = new SQLiteAsyncConnection(Path.Combine(_dbDirectory, _dbName));

        _tableReferenceType = GetTableReferenceType();
    }

    public async Task<T> GetAsync(int id)
    {
        var tableMapping = await _context.GetMappingAsync(_tableReferenceType);

        var record = await _context.FindAsync(id, tableMapping);

        return _mapper.Map<T>(record);
    }

    public async Task<IEnumerable<T>> QueryAsync(string property, string value)
    {
        var tableMapping = await _context.GetMappingAsync(_tableReferenceType);

        var tableName = tableMapping.TableName;

        var sqlStatement = $"{SqlStatements.SELECT_ALL_CLAUSE} {tableName} {SqlStatements.WHERE_CLAUSE} {property} {SqlStatements.EQUAL_CLAUSE} '{value}'";

        var records = await _context.QueryAsync(tableMapping, sqlStatement);

        return _mapper.Map<IEnumerable<T>>(records);
    }

    public async Task CreateAsync(T entity)
    {
        var tableEntity = _mapper.Map(entity, typeof(T), _tableReferenceType);

        await _context.InsertAsync(tableEntity);
    }

    public async Task DeleteAsync(T entity)
    {
        var tableEntity = _mapper.Map(entity, typeof(T), _tableReferenceType);

        await _context.DeleteAsync(tableEntity);
    }

    public async Task UpdateAsync(T entity)
    {
        var tableEntity = Activator.CreateInstance(_tableReferenceType);

        _mapper.Map(entity, tableEntity);

        await _context.UpdateAsync(tableEntity);
    }

    private static Type GetTableReferenceType()
    {
        return typeof(T) switch
        {
            var _ when typeof(T) == typeof(MedicalHistory) => typeof(Tables.MedicalHistory),
            var _ when typeof(T) == typeof(Tests) => typeof(Tables.Tests),
            _ => throw new NotSupportedException($"Entity {typeof(T)} not supported")
        };
    }
}
