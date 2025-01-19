using CustomerRegistrationApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistrationApi.Repositories;

public class ApplicationDbContext : DbContext
{
    // Construtor com DbContextOptions
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CompanyFile> CompanyFiles { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração para Address
        modelBuilder.Entity<Address>()
            .HasKey(a => a.Id); // Definindo o Id como chave primária

        modelBuilder.Entity<Address>()
            .Property(a => a.Street)
            .HasMaxLength(50)  // Definindo o tamanho máximo para o campo Street
            .IsRequired();     // Torna o campo obrigatório

        // Configuração para a tabela CompanyFile
        modelBuilder.Entity<CompanyFile>()
            .Property(cf => cf.FileName)
            .HasMaxLength(50)  // Limita o tamanho do campo 'FileName' a 50 caracteres
            .IsRequired();

        modelBuilder.Entity<CompanyFile>()
            .Property(cf => cf.ContentType)
            .HasMaxLength(50)  // Limita o tamanho do campo 'ContentType' a 50 caracteres
            .IsRequired();

        modelBuilder.Entity<CompanyFile>()
                .Property(cf => cf.Data)
                .HasColumnType("VARBINARY(MAX)") // Usar o tipo VARBINARY(MAX) para dados binários
                .IsRequired();
        // Configuração para a tabela Customer
        modelBuilder.Entity<Customer>()
            .Property(c => c.Name)
            .HasMaxLength(50)  // Limita o tamanho do campo 'Name' a 50 caracteres
            .IsRequired();     // Define o campo como obrigatório

        modelBuilder.Entity<Customer>()
            .Property(c => c.Email)
            .HasMaxLength(50)  // Limita o tamanho do campo 'Email' a 50 caracteres
            .IsRequired();     // Define o campo como obrigatório
               
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.CompanyFile)
            .WithMany() // Defina o relacionamento conforme necessário
            .HasForeignKey("CompanyFileId"); // Supondo que você tenha uma chave estrangeira
                                             // Relacionamento 1:N (Customer -> Address)
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Addresses)
            .WithOne() // Não temos uma navegação explícita em Address para Customer
            .HasForeignKey("CustomerId") // Chave estrangeira em Address
            .OnDelete(DeleteBehavior.Cascade); // Quando Customer for excluído, exclui também os endereços associados



        base.OnModelCreating(modelBuilder);
    }
}
