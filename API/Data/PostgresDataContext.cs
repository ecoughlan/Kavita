using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class PostgresDataContext(DbContextOptions options): DataContext(options)
{
}
