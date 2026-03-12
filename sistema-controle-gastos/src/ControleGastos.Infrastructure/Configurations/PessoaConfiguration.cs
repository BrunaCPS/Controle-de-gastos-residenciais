using ControleGastos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleGastos.Infrastructure.Configurations;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
       builder.ToTable("T_PESSOAS");

		builder.HasKey(p => p.Id);

        builder.Property(t => t.Id)
                .HasColumnName("ID_PESSOA")
                .ValueGeneratedOnAdd()
                .IsRequired();

		builder.Property(p => p.Nome)
			.IsRequired()
			.HasMaxLength(200)
            .HasColumnName("TX_PESSOA");

		builder.Property(p => p.Idade)
            .HasColumnName("QT_IDADE")
			.IsRequired();
    }
}
