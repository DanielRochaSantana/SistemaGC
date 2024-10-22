using Dapper;
using Microsoft.Extensions.Configuration;
using PrjGestaoClientes.Infrastructure.Factory;
using PrjGestaoClientes.Infrastructure.Interfaces.Context;
using System.Data.SqlClient;

namespace PrjGestaoClientes.Infrastructure.Context
{
    public class Context : IContext
    {
        protected readonly IConfigurationRoot configuration;
        protected readonly string? connString;
        protected SqlConnection connection;

        public Context()
        {
            configuration = new ConfigurationBuilder()
                                     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                     .AddJsonFile("appsettings.json")
                                     .Build();

            connString = configuration.GetConnectionString("DefaultConnection");

            connection = new SqlConnection(connString);
        }

        /// <summary>
        /// Efetua conexão e a retorna
        /// </summary>
        /// <returns></returns>
        public SqlConnection Conectar()
        {
            connection = new SqlConnection(connString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Efetua desconexão
        /// </summary>
        public void Desconectar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        /// <summary>
        /// Encontra por Id
        /// </summary>
        /// <typeparam name="Class"></typeparam>
        /// <param name="Id"></param>
        /// <param name="entityEnum"></param>
        /// <param name="sTableName"></param>
        /// <param name="sPropriedadeChave"></param>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        public Class? EncontrarPorCodigo<Class>(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave, string sQuery) where Class : class
        {
            using (SqlConnection connection = Conectar())
            {
                return connection.Query<Class>(sQuery, ObjectFactory.GetObject(entityEnum, Id) as Class).FirstOrDefault();
            }
        }

        /// <summary>
        /// Executa comandos
        /// </summary>
        /// <typeparam name="Class"></typeparam>
        /// <param name="_sCommand"></param>
        /// <param name="registro"></param>
        public void ExecuteCommand<Class>(string _sCommand, Class registro) where Class : class
        {
            using (SqlConnection connection = Conectar())
            {

                connection.Execute(_sCommand, registro);

                connection.Close();

            }

            Desconectar();
        }

        /// <summary>
        /// Lista registros
        /// </summary>
        /// <typeparam name="Class"></typeparam>
        /// <param name="sTableName"></param>
        /// <returns></returns>
        public IEnumerable<Class> ListarRegistros<Class>(string sTableName, string sQuery)
        {
            using (SqlConnection connection = Conectar())
            {
                return connection.Query<Class>(sQuery);
            }
        }

        /// <summary>
        /// Retorna registros a partir de uma query
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        public IList<TYPE> ReturnQueryList<TYPE>(string sQuery) where TYPE : class
        {
            Conectar();

            IList<TYPE> lstRegistros = (IList<TYPE>)connection.Query<TYPE>(sQuery);

            Desconectar();

            return lstRegistros;            
        }

    }
}
