using AspireWorkshopDb.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspireWorkshopDb.Data;

public class CollectionContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Song> Songs => Set<Song>();
}