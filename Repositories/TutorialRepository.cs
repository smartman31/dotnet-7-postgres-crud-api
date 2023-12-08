namespace WebApi.Repositories;

using Dapper;
using WebApi.Entities;
using WebApi.Helpers;

public interface ITutorialRepository
{
    Task<IEnumerable<Tutorial>> GetAll(string? title);
    Task<Tutorial> GetById(int id);
    Task Create(Tutorial tutorial);
    Task Update(Tutorial tutorial);
    Task Delete(int id);
    Task DeleteAll();
}

public class TutorialRepository : ITutorialRepository
{
    private DataContext _context;

    public TutorialRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tutorial>> GetAll(string? title)
    {
        using var connection = _context.CreateConnection();
        Console.WriteLine($">>>>111 title : {title}");
        var sql = $"SELECT * FROM Tutorials WHERE title LIKE '%{@title}%'";
        Console.WriteLine($">>>>222 sql : : {sql}");
        return await connection.QueryAsync<Tutorial>(sql);
    }

    public async Task<Tutorial> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Tutorials 
            WHERE Id = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Tutorial>(sql, new { id });
    }

    public async Task Create(Tutorial tutorial)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO Tutorials (Title, Description, Published)
            VALUES (@Title, @Description, @Published)
        """;
        await connection.ExecuteAsync(sql, tutorial);
    }

    public async Task Update(Tutorial tutorial)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE Tutorials 
            SET Title = @Title,
                Description = @Description,
                Published = @Published
            WHERE Id = @Id
        """;
        await connection.ExecuteAsync(sql, tutorial);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Tutorials 
            WHERE Id = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }

    public async Task DeleteAll()
    {
        using var connection = _context.CreateConnection();
        var sql = "DELETE FROM Tutorials";
        await connection.ExecuteAsync(sql);
    }
}