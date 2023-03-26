using Microsoft.EntityFrameworkCore;

namespace JurniWebApp.Data; 

public class JurniWebAppDbContext : DbContext{
    
    /**
     * Constructor.
     */
    public JurniWebAppDbContext(DbContextOptions<JurniWebAppDbContext> options) : base(options) {
        
    }
    
    /**
     * Seeder.
     */
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        // Seed values of entity.
        // modelBuilder.Entity<EntityName>().HasData(new EntityName() { Id = 1, Attribute = value });
        
        // Set requirements of entity attributes.
        // modelBuilder.Entity<EntityName>().Property(e => e.Attribute).IsRequired().HasMaxLength(100);
        
        // modelBuilder.Entity<EntityName>(entityName => {
        //     entityName.Property(e => e.Attribute).IsRequired().HasMaxLength(100);
        //     entityName.Property(e => e.Attribute).HasMaxLength(500);
        // });
        
        // Create foreign key references between entities connected via linking table.
        // modelBuilder.Entity<EntityNameOne>().HasMany(e => e.LinkingTableName).WithOne(lt => lt.EntityNameOne).HasForeignKey(lt => lt.EntityNameOneId);
        // modelBuilder.Entity<EntityNameTwo>().HasMany(e => e.LinkingTableName).WithOne(lt => lt.EntityNameTwo).HasForeignKey(ag => lt.EntityNameOneId);
        
        // Create composite key for linking table.
        // modelBuilder.Entity<AuthorGroup>().HasKey(ag => new { ag.AuthorId, ag.GroupId });
    }
}