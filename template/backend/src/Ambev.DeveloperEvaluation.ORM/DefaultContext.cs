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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }  // Adicionando a DbSet de Venda
        public DbSet<ItemVenda> ItensVenda { get; set; } // Adicionando a DbSet de ItensVenda


        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configuração das tabelas
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Filial>().ToTable("Filiais");
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Venda>().ToTable("Vendas");  // Configuração da tabela Venda
            modelBuilder.Entity<ItemVenda>().ToTable("ItensVenda"); // Configuração da tabela ItensVenda


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

            // Configuração do relacionamento entre Venda e ItensVenda
            modelBuilder.Entity<ItemVenda>()
                .HasOne(iv => iv.Venda)  // Relaciona o ItemVenda com a Venda
                .WithMany(v => v.ItensVenda)  // Uma Venda pode ter muitos ItensVenda
                .HasForeignKey(iv => iv.IdVenda)  // A chave estrangeira em ItemVenda é IdVenda
                .OnDelete(DeleteBehavior.Cascade);  // Ao deletar uma Venda, os ItensVenda são deletados

            // Configuração do relacionamento entre Produto e ItensVenda
            //modelBuilder.Entity<ItemVenda>()
            //    .HasOne(iv => iv.Produto)  // Relaciona o ItemVenda com o Produto
            //    .WithMany()  // Um Produto pode ser relacionado a vários ItensVenda
            //    .HasForeignKey(iv => iv.IdProduto)  // A chave estrangeira em ItemVenda é IdProduto
            //    .OnDelete(DeleteBehavior.Restrict);  // Não permitir a exclusão de Produto se estiver vinculado a um ItemVenda

            // Configuração da tabela Venda
            modelBuilder.Entity<Venda>()
                .HasKey(v => v.Id);  // Definir a chave primária da Venda

            // Configuração de outras propriedades da tabela Venda
            modelBuilder.Entity<Venda>()
                .Property(v => v.NumeroVenda)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Venda>()
                .Property(v => v.ValorTotalVenda)
                .HasColumnType("numeric(10,2)");

            modelBuilder.Entity<Venda>()
                .Property(v => v.ValorTotalProdutos)
                .HasColumnType("numeric(10,2)");

            modelBuilder.Entity<Venda>()
                .Property(v => v.Status)
                .HasMaxLength(20);

            modelBuilder.Entity<Venda>()
                .Property(v => v.DataCadastro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Venda>()
                .Property(v => v.DataVenda)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Configuração da tabela ItemVenda
            modelBuilder.Entity<ItemVenda>()
                .HasKey(iv => iv.Id);  // Definir a chave primária de ItemVenda

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
