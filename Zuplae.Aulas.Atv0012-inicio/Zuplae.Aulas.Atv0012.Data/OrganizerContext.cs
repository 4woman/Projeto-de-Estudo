using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zuplae.Aulas.Atv0012.Models;

namespace Zuplae.Aulas.Atv0012.Data
{
    public class OrganizerContext : DbContext
    {
        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options){}

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        //Entity Framework a converter automaticamente data/hora
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(
                            new ValueConverter<DateTime, DateTime>(
                                v => DateTime.SpecifyKind(v, DateTimeKind.Utc),
                                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                            )
                        );
                    }
                }
            }
        }


    }
}
