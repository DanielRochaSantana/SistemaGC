using PrjGestaoClientes.Domain.Model.Base;

namespace PrjGestaoClientes.Domain.Model.Entity
{
    public class Cliente : BaseEntity
    {
        public string CPF { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public DateTime DataExpedicao { get; set; }
        public string OrgaoExpedicao { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; } = string.Empty;
        public string EstadoCivil { get; set; } = string.Empty;
        public Guid IdEnderecoCliente { get; set; }
    }
}
