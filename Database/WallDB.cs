using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalRApp.Entities;


namespace SignalRApp.Database;
public class WallDB : DbContext
{
    private DbSet<ChatUser> _users => Set<ChatUser>();
    private DbSet<Publication> _publications => Set<Publication>();

    public WallDB() => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder) // в этом не уверен, если не работает - снесу
    {
        modelBuilder.Entity<ChatUser>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Wall.db");

    }

    public IEnumerable<ChatUser> GetAllUsers() => _users;
    public IEnumerable<Publication> GetAllPublications() => _publications;

    public ChatUser? GetUserById(Guid id) => _users.FirstOrDefault(u => u.Id == id);
    public ChatUser? GetUserByUsername(string username) => _users.FirstOrDefault(u => u.Username == username);


    public Publication? GetPublicationById(Guid id) => _publications.FirstOrDefault(p => p.Id == id);


    public void AddUser(ChatUser user)
    {
        _users.Add(user);
        SaveChanges();
    }
    public void AddPublication(Publication publication)
    {
        _publications.Add(publication);
        SaveChanges();
    }
}