using ControleGastos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleGastos.Infrastructure.Configurations;

public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
{
	public void Configure(EntityTypeBuilder<Transacao> builder)
	{
		builder.ToTable("T_TRANSACOES");

		builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
                .HasColumnName("ID_TRANSACAO")
                .ValueGeneratedOnAdd()
                .IsRequired();

		builder.Property(t => t.Descricao)
			.IsRequired()
			.HasMaxLength(400)
			.HasColumnName("TX_DESCRICAO");

		builder.Property(t => t.Valor)
			.HasPrecision(18, 2)
			.HasColumnName("QT_VALOR")
			.IsRequired();

		builder.Property(t => t.Tipo)
			.HasColumnName("TX_TIPO_TRANSACAO")
			.IsRequired();

		builder.Property(t => t.CategoriaId)
			.HasColumnName("CATEGORIA_ID")
			.IsRequired();

		builder.Property(t => t.PessoaId)
			.HasColumnName("PESSOA_ID")
			.IsRequired();

		builder.HasOne(t => t.Categoria)
			.WithMany(c => c.Transacoes)
			.HasForeignKey(t => t.CategoriaId)
			.IsRequired()
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(t => t.Pessoa)
			.WithMany(p => p.Transacoes)
			.HasForeignKey(t => t.PessoaId)
			.IsRequired()
			.OnDelete(DeleteBehavior.Cascade);
	}
}
