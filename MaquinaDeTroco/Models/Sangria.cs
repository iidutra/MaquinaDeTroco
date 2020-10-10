namespace MaquinaDeTroco.Models
{
    public class Sangria
    {
        public int Id { get; private set; }
        public int Quantidade { get; private set; }
        public int MoedaId { get; private set; }
        public Moeda Moeda { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public int CaixaId { get; private set; }
        public Caixa Caixa { get; private set; }
    }
}
