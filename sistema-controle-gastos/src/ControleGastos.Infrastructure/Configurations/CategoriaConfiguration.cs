using ControleGastos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ControleGastos.Infrastructure.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
	public void Configure(EntityTypeBuilder<Categoria> builder)
	{
		builder.ToTable("T_CATEGORIAS");

		builder.HasKey(c => c.Id);

        builder.Property(t => t.Id)
                .HasColumnName("ID_CATEGORIA")
                .ValueGeneratedOnAdd()
                .IsRequired();

		builder.Property(c => c.Descricao)
			.HasMaxLength(400)
            .HasColumnName("TX_DESCRICAO");

		builder.Property(c => c.Finalidade)
			.IsRequired()
            .HasColumnName("TX_FINALIDADE");
	}
}
