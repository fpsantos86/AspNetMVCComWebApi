using Impacta.Tarefas.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.Tarefas.DAL
{
    public class Data
    {
		SqlConnection sqlConn;

		SqlCommand cmd;

		bool resultado;

		string conexao = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Pessoal;Integrated Security=True;Pooling=False";

		public Data()
		{

		}

		private bool CriarConexao() {

			bool criadoConexao = false;

			if (sqlConn == null) {
				sqlConn = new SqlConnection(conexao);

				criadoConexao = true;
			}

			return criadoConexao;
		}

		private void CriarCommandoTarefa(string querySql, Tarefa tarefa) {
			cmd = new SqlCommand();

			cmd.CommandText = querySql;
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.AddWithValue("@Nome", tarefa.Nome);
			cmd.Parameters.AddWithValue("@Prioridade", tarefa.Prioridade);
			cmd.Parameters.AddWithValue("@Concluida", tarefa.Concluida);
			cmd.Parameters.AddWithValue("@Observacoes", tarefa.Observacao);

			if (tarefa.Id > 0) {
				cmd.Parameters.AddWithValue("@Id", tarefa.Id);
			}
			cmd.Connection = sqlConn;
		}


		public bool CriarTarefa(Tarefa tarefa)
		{
			resultado = false;

			try
			{
				string query = @"INSERT INTO TAREFAS (Nome, Prioridade, Concluida, Observacoes)
									VALUES (@Nome, @Prioridade, @Concluida, @Observacoes)";

				if (CriarConexao())
				{
					CriarCommandoTarefa(query, tarefa);

					sqlConn.Open();
					var ret = cmd.ExecuteNonQuery();

					resultado = true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally {
				if (sqlConn.State == ConnectionState.Open) {
					sqlConn.Close();
				}
			}

			return resultado;
		}

		public List<Tarefa> ListarTarefas() {
			resultado = false;

			List<Tarefa> Lista = new List<Tarefa>();

			try
			{
				if (CriarConexao())
				{
					string sql = @"SELECT ID, NOME ,PRIORIDADE, CONCLUIDA, OBSERVACOES FROM TAREFAS ORDER BY CONCLUIDA, PRIORIDADE";

					using (var conn = sqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							conn.Open();

							using (var dr = cmd.ExecuteReader())
							{
								while (dr.Read())
								{
									var tarefa = new Tarefa();

									tarefa.Id = Convert.ToInt32(dr["Id"]);
									tarefa.Nome = dr["Nome"].ToString();
									tarefa.Prioridade = Convert.ToInt32(dr["Prioridade"]);
									tarefa.Concluida = Convert.ToBoolean(dr["Concluida"]);
									tarefa.Observacao = Convert.ToString(dr["Observacoes"]);

									Lista.Add(tarefa);

								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally {
				if (sqlConn.State == ConnectionState.Open) {
					sqlConn.Close();
				}
			}
			return Lista;
		}

		public bool AtualizarTarefa(Tarefa tarefa) {
			resultado = false;

			try
			{
				string query = @"UPDATE TAREFAS 
											set Nome=@Nome, 
												Prioridade=@Prioridade, 
												Concluida=@Concluida,
												Observacoes=@Observacoes
									WHERE Id = @Id";

				if (CriarConexao())
				{
					CriarCommandoTarefa(query, tarefa);

					sqlConn.Open();
					var ret = cmd.ExecuteNonQuery();

					resultado = true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlConn.State == ConnectionState.Open)
				{
					sqlConn.Close();
				}
			}

			return resultado;
		}


		public bool DeletarTarefa(int id)
		{
			resultado = false;

			try
			{
				string query = @"DELETE TAREFAS WHERE Id = @Id";

				if (CriarConexao())
				{
					using (var conn = sqlConn)
					{
						using (cmd = new SqlCommand()) {

							cmd.CommandText = query;
							cmd.Connection = conn;
							cmd.CommandType = CommandType.Text;
							cmd.Parameters.AddWithValue("@Id", id);

							sqlConn.Open();
							var ret = cmd.ExecuteNonQuery();

							resultado = true;
						}
						

					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (sqlConn.State == ConnectionState.Open)
				{
					sqlConn.Close();
				}
			}

			return resultado;
		}

		public Tarefa ConsultarTarefa(int id) {

			Tarefa tarefa = null;
			try
			{
				if (CriarConexao())
				{
					string sql = @"SELECT id,nome, prioridade, concluida, observacoes
									FROM Tarefas
									WHERE id=@id";

					using (var conn = sqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							cmd.Parameters.AddWithValue("@id", id);

							conn.Open();

							var res = cmd.ExecuteReader();

							if (res.HasRows && res.Read())
							{
								tarefa = new Tarefa()
								{
									Id = (int)res["Id"],
									Nome = res["Nome"] as string,
									Prioridade = (int)res["Prioridade"],
									Concluida = (bool)res["Concluida"],
									Observacao = res["Observacoes"].ToString()
								};
							}
						}

					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return tarefa;
		}

	}
}
