using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<ForbiddenEntity> Rules { get; set; }
}
