using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM
{
    public class DefaultContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Garantir que User, Cliente e Filial mapeiem para tabelas separadas
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Filial>().ToTable("Filiais");

            // Configurando a relação entre Cliente e Filial
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Filial)  // Um cliente tem uma filial
                .WithMany()  // Muitas filiais podem ter muitos clientes
                .HasForeignKey(c => c.FilialId)  // A chave estrangeira é FilialId
                .OnDelete(DeleteBehavior.SetNull);  // Se a filial for deletada, setar o FilialId como null

            // Garantir que o nome da filial seja comparado de forma insensível a maiúsculas/minúsculas
            modelBuilder.Entity<Filial>()
                .HasIndex(f => f.Nome)
                .IsUnique();  // Garantir que o nome da filial seja único

            // Definir a comparação insensível a maiúsculas/minúsculas para o nome da filial
            modelBuilder.Entity<Filial>()
                .Property(f => f.Nome)
                .HasConversion(
                    v => v.ToLower(),  // Converte para minúsculas ao salvar no banco
                    v => v) // Quando carregar do banco, mantém a string original
                .HasMaxLength(255);  // Define o tamanho máximo do nome

            modelBuilder.Entity<Produto>()
            .ToTable("Produtos")
            .HasKey(p => p.Id);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Produto>()
                .Property(p => p.PrecoUnitario)
                .HasColumnType("numeric(10,2)");

            modelBuilder.Entity<Venda>()
           .ToTable("Vendas")
           .HasKey(v => v.Id);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);  // Evitar deletar vendas quando cliente for excluído

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Filial)
                .WithMany()
                .HasForeignKey(v => v.IdFilial)
                .OnDelete(DeleteBehavior.Restrict);  // Evitar deletar vendas quando filial for excluída

            base.OnModelCreating(modelBuilder);
        }
    }

    public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DefaultContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
            );

            return new DefaultContext(builder.Options);
        }
    }
}
