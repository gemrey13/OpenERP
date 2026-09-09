using Microsoft.EntityFrameworkCore;
using OpenERP.API.Domain.Entities;

namespace OpenERP.API.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Organization> Organizations => Set<Organization>();
}