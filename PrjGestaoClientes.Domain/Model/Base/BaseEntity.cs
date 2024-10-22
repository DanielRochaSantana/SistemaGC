namespace PrjGestaoClientes.Domain.Model.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataModificacao { get; set; } = null;
        public bool IsAtivo { get; set; } = true;
    }
}
