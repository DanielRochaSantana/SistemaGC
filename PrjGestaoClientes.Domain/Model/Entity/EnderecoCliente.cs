using PrjGestaoClientes.Domain.Model.Base;

namespace PrjGestaoClientes.Domain.Model.Entity
{
    public class EnderecoCliente : BaseEntity
    {
        public string CEP { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Número { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;        
    }
}