namespace ControleGastos.Domain;

public class Transacao
{
    public long Id { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public TipoTransacaoEnum Tipo { get; set; }
    public long CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public long PessoaId { get; set; }
    public Pessoa? Pessoa { get; set; }
}