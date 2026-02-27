namespace ControleGastos.Domain;
public class Pessoa
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public required int Idade { get; set; }
    public List<Transacao>? Transacoes { get; set; }
}
