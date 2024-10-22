using PrjGestaoClientes.Domain.Model.Entity;

namespace PrjGestaoClientes.Domain.Model
{
    public class ClienteModelView
    {
        public Cliente? Cliente { get; set; }
        public EnderecoCliente? EnderecoCliente { get; set; } = null;
    }
}
