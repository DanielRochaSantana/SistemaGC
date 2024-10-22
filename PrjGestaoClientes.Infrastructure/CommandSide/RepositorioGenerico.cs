using PrjGestaoClientes.Infrastructure.Factory;
using PrjGestaoClientes.Infrastructure.Interfaces.CommandSide;
using PrjGestaoClientes.Infrastructure.Interfaces.Context;
using static PrjGestaoClientes.Infrastructure.Factory.ObjectFactory;

namespace PrjGestaoClientes.Infrastructure.CommandSide
{
    public class RepositorioGenerico<Class> : IRepositorioGenerico<Class> where Class : class
    {

        private readonly IContext context;
        protected string sPropriedades, sValores, sOperacao;

        public RepositorioGenerico(IContext context)
        {
            this.context = context;
            sPropriedades = sValores = sOperacao = string.Empty;
        }

        /// <summary>
        /// Adiona registro
        /// </summary>
        /// <param name="registro"></param>        
        /// <param name="sPropriedadeChave"></param>        
        /// <param name="sTableName"></param>        
        public void Adicionar(Class registro, string sPropriedadeChave, string sTableName)
        {

            PopularPropriedadesValores(registro, sPropriedadeChave);

            string sCommand = " Insert into " + sTableName + " ( " +
                                 sPropriedades +
                                 " ) " +
                                 " Values (" +
                                 sValores +
                                 " ) ";

            ExecuteCommand(sCommand, registro);

        }

        /// <summary>
        /// Popula propriedades e valores
        /// </summary>
        /// <param name="registro"></param>
        /// <param name="sPropriedadeChave"></param>       
        public void PopularPropriedadesValores(Class registro, string sPropriedadeChave)
        {

            IList<string> lstPropriedades = ListarPropriedades(registro);

            if (lstPropriedades.Any(filtro => filtro == sPropriedadeChave))
                lstPropriedades.Remove(sPropriedadeChave);

            sPropriedades = string.Join(",", lstPropriedades);

            IList<string> lstValores = RetornarCamposValores(lstPropriedades);

            sValores = string.Join(",", lstValores);

        }

        /// <summary>
        /// Retorna a lista dos campos para valores
        /// </summary>
        /// <param name="lstPropriedades"></param>
        /// <returns></returns>
        public IList<string> RetornarCamposValores(IList<string> lstPropriedades)
        {

            IList<string> lstValores = (ObjectFactory.GetInstance(ObjectEnum.ListaStrings) as List<string>)!;

            foreach (string item in lstPropriedades)
                lstValores.Add("@" + item);

            return lstValores;

        }

        /// <summary>
        /// Remove registro
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="operationEnums"></param>
        /// <param name="sTableName"></param>
        /// <param name="sPropriedadeChave"></param>
        public void Remover(Guid Id, EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {

            string sCommand = " Delete from " + sTableName + " " +
                                " Where " + sPropriedadeChave + " = @" + sPropriedadeChave + " ";

            ExecuteCommand(sCommand, (ObjectFactory.GetObject(entityEnum, Id) as Class)!);

        }

        /// <summary>
        /// Atualiza registro
        /// </summary>
        /// <param name="registro"></param>
        /// <param name="sPropriedadeChave"></param>
        /// <param name="sTableName"></param>
        public void Atualizar(Class registro, string sPropriedadeChave, string sTableName)
        {

            PopularPropriedadesValores(registro, sPropriedadeChave);

            MontarStringOperacaoUpdate();

            string sCommand = " Update " + sTableName + " set  " + sOperacao +
                                " where " + sPropriedadeChave + " = @" + sPropriedadeChave + " ";

            ExecuteCommand(sCommand, registro);

        }

        /// <summary>
        /// Monta a string para operação de update
        /// </summary>
        /// <returns></returns>
        public string MontarStringOperacaoUpdate()
        {

            IList<string> lstColunas = sPropriedades.Split(',');

            IList<string> lstValores = sValores.Split(',');

            for (int iContador = 0; iContador < lstColunas.Count; iContador++)
            {
                sOperacao += lstColunas[iContador] + " = " + lstValores[iContador];

                if (iContador < lstColunas.Count - 1)
                    sOperacao += ",";

            }

            return sOperacao;
        }

        /// <summary>
        /// Executa um comando
        /// </summary>
        /// <param name="_sCommand"></param>
        /// <param name="registro"></param>
        public void ExecuteCommand(string _sCommand, Class registro)
        {
            context.ExecuteCommand<Class>(_sCommand, registro);
        }

        /// <summary>
        /// Obtem os nomes das propriedades de um objeto
        /// Baseado em https://www.codegrepper.com/code-examples/csharp/get+list+of+properties+from+class+c%23
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public IList<string> ListarPropriedades(object objeto)
        {

            if (objeto == null)
                return null;

            Type tipo = objeto.GetType();

            return tipo.GetProperties().Select(selecao => selecao.Name).ToList();

        }

    }
}
