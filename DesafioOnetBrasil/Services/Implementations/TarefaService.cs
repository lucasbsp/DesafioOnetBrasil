using SQLite;
using DesafioOnetBrasil.Models;
using DesafioOnetBrasil.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioOnetBrasil.Services.Implementations
{
    /// <summary>
    /// Classe responsável por fazer a conexão com o banco de dados, 
    /// e realizar as operações de CRUD, referentes ao objeto Tarefa
    /// </summary>
    public class TarefaService : ITarefaService
    {
        #region Propriedades

        /// <summary>
        /// Objeto de conexão com o banco de dados
        /// </summary>
        private SQLiteAsyncConnection _dbConnection;

        #endregion

        #region Métodos da Interface

        /// <summary>
        /// Inicializa a conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        public async Task InitializeAsync()
        {
            await SetUpDB();
        }

        /// <summary>
        /// Cria uma tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> CreateTarefa(TarefaModel tarefa)
        {
            return await _dbConnection.InsertAsync(tarefa);
        }

        /// <summary>
        /// Obtém uma lista de tarefas
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TarefaModel>> ReadTarefas()
        {
            return await _dbConnection.Table<TarefaModel>().ToListAsync();
        }

        /// <summary>
        /// Atualiza os dados de uma tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> UpdateTarefa(TarefaModel tarefa)
        {
            return await _dbConnection.UpdateAsync(tarefa);
        }

        /// <summary>
        /// Exclui uma tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> DeleteTarefa(TarefaModel tarefa)
        {
            return await _dbConnection.DeleteAsync(tarefa);
        }

        #endregion

        #region Métodos Complementares

        /// <summary>
        /// Configura a inicialização da conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        private async Task SetUpDB()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "DesafioOnetBrasil.db3"
                );

                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<TarefaModel>();
            }
        }

        #endregion
    }
}
