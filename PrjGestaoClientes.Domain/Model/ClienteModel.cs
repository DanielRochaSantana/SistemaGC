using PrjGestaoClientes.Domain.Model.Entity;

namespace PrjGestaoClientes.Domain.Model
{
    public class ClienteModel : Cliente
    {
        public bool IsEdit { get; set; }
    }
}
