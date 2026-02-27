namespace ControleGastos.Domain;
public class Categoria
{
    public long Id { get; set; }
    public string? Descricao { get; set; }
    public FinalidadeCategoriaEnum Finalidade { get; set; }
    public List<Transacao>? Transacoes { get; set; }
}