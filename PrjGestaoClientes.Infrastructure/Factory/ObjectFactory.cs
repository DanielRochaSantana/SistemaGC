using PrjGestaoClientes.Domain.Model;
using PrjGestaoClientes.Domain.Model.Entity;

namespace PrjGestaoClientes.Infrastructure.Factory
{
    public static class ObjectFactory
    {
        public static object GetObject(EntityEnum entityEnum, Guid Id)
        {
            switch (entityEnum)
            {
                case EntityEnum.Cliente:
                    return new Cliente { Id = Id };
                case EntityEnum.EnderecoCliente:
                    return new EnderecoCliente { Id = Id };
                default:
                    return default;
            }
        }

        public static object GetInstance(ObjectEnum objEnum)
        {
            switch (objEnum)
            {
                case ObjectEnum.ListaStrings:
                    return new List<string>();
                default:
                    return default;
            }
        }

        public static ClienteModelView GetClienteModelView(Cliente? cliente, EnderecoCliente? endereco)
        {
            return new ClienteModelView
            {
                Cliente = cliente,
                EnderecoCliente = endereco
            };
        }

        public static ClienteModel GetClientModel(ClienteModelView? clienteMV)
        {
            if (clienteMV != null && clienteMV.Cliente != null)
                return new ClienteModel
                {
                    CPF = clienteMV.Cliente.CPF,
                    Nome = clienteMV.Cliente.Nome,
                    RG = clienteMV.Cliente.RG,
                    DataExpedicao = clienteMV.Cliente.DataExpedicao,
                    OrgaoExpedicao = clienteMV.Cliente.OrgaoExpedicao,
                    DataNascimento = clienteMV.Cliente.DataNascimento,
                    Sexo = clienteMV.Cliente.Sexo,
                    EstadoCivil = clienteMV.Cliente.EstadoCivil,
                    IdEnderecoCliente = clienteMV.Cliente.IdEnderecoCliente
                };

            return new ClienteModel();
        }

        public static Cliente GetClientEntity(ClienteModel model)
        {
            if (model != null)
                return new Cliente
                {
                    CPF = model.CPF,
                    Nome = model.Nome,
                    RG = model.RG,
                    DataExpedicao = model.DataExpedicao,
                    OrgaoExpedicao = model.OrgaoExpedicao,
                    DataNascimento = model.DataNascimento,
                    Sexo = model.Sexo,
                    EstadoCivil = model.EstadoCivil,
                    IdEnderecoCliente = model.IdEnderecoCliente
                };

            return new Cliente();
        }

        public enum EntityEnum
        {
            Cliente = 0,
            EnderecoCliente = 1
        }

        public enum ObjectEnum
        {
            ListaStrings = 0
        }
    }
}
