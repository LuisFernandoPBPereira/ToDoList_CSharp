using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Infraestructure.Entities;

namespace ToDoList.Infraestructure.Data;

public class ToDoListContext : IdentityDbContext<UsuarioIdentity, IdentityRole<Guid>, Guid>
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Tarefa

        modelBuilder.Entity<TarefaEntity>().ToTable("Tarefa");

        modelBuilder.Entity<TarefaEntity>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<TarefaEntity>()
            .Property(x => x.Titulo)
            .IsRequired()
            .HasMaxLength(256);

        modelBuilder.Entity<TarefaEntity>()
            .Property(x => x.Descricao)
            .HasMaxLength(1024);

        modelBuilder.Entity<TarefaEntity>()
            .Property(x => x.DataCriacao)
            .IsRequired();

        modelBuilder.Entity<TarefaEntity>()
            .Property(x => x.DataVencimento)
            .IsRequired();

        modelBuilder.Entity<TarefaEntity>()
            .Property(x => x.Prioridade)
            .HasConversion<string>();
        
        modelBuilder.Entity<TarefaEntity>()
            .Property(x => x.Status)
            .HasConversion<string>();

        modelBuilder.Entity<TarefaEntity>()
            .Property(x => x.UsuarioId);

        modelBuilder.Entity<TarefaEntity>()
            .HasOne(x => x.Usuario)
            .WithMany(x => x.Tarefas)
            .HasForeignKey(x => x.UsuarioId);

        modelBuilder.Entity<TarefaEntity>()
            .HasMany(x => x.Categorias)
            .WithMany(x => x.Tarefas)
            .UsingEntity(x => x.ToTable("TarefasCategorias")); ;

        #endregion

        #region Usuário

        modelBuilder.Entity<UsuarioIdentity>()
            .HasMany(x => x.Tarefas)
            .WithOne(x => x.Usuario);

        #endregion

        #region Categoria

        modelBuilder.Entity<CategoriaEntity>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<CategoriaEntity>()
            .Property(x => x.Nome);

        modelBuilder.Entity<CategoriaEntity>()
            .HasMany(x => x.Tarefas)
            .WithMany(x => x.Categorias);

        #endregion

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=../ToDoList.Infraestructure/Data/database.db");
    }
}
