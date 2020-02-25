using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string Stringconexao = "Data Source=DESKTOP-1N95O0N; initial catalog=M_Peoples; integrated security=true;";

        public void Atualizar(FuncionarioDomain funcionario)
        {
            using(SqlConnection con = new SqlConnection(Stringconexao))
            {
                string queryAtualizar = "Update Funcionarios Set Nome = @NOME , Sobrenome = @SOBRENOME Where Id = @ID";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryAtualizar,con))
                {
                    cmd.Parameters.AddWithValue("@NOME", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@SOBRENOME", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@ID", funcionario.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(Stringconexao))
            {
                string queryBuscarId = "Select Id ,Nome, Sobrenome from Funcionarios Where Id = @Id";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryBuscarId, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Nome = Convert.ToString(rdr[1]),
                            Sobrenome = Convert.ToString(rdr[2])
                        };
                        return funcionario;
                    }
                    return null;
                }
            }
        }

        public List<FuncionarioDomain> BuscarPorNome(string nome)
        {
            List<FuncionarioDomain> Funcionarios = new List<FuncionarioDomain>();
            using (SqlConnection con = new SqlConnection(Stringconexao))
            {
                con.Open();

                string querySelect = "Select Id ,Nome, Sobrenome from Funcionarios Where Nome = @NOME";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", nome);
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Nome = Convert.ToString(rdr[1]),
                            Sobrenome = Convert.ToString(rdr[2])
                        };
                        Funcionarios.Add(funcionario);
                    }
                }
                return Funcionarios;
            }  
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(Stringconexao))
            {
                string queryDelete = "Delete From Funcionarios Where Id = @ID";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@ID",id);

                    cmd.ExecuteNonQuery();
                }
                

            }
        }

        public void Inserir(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(Stringconexao))
            {
                string queryInserir = "Insert Into Funcionarios (Nome,Sobrenome) Values (@NOME,@SOBRENOME)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInserir,con))
                {
                    cmd.Parameters.AddWithValue("@NOME", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@SOBRENOME", funcionario.Sobrenome);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> Funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(Stringconexao))
            {
                string queryListar = "Select Id, Nome, Sobrenome From Funcionarios";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryListar, con))
                {
                    var rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Nome = Convert.ToString(rdr[1]),
                            Sobrenome = Convert.ToString(rdr[2])
                        };
                        Funcionarios.Add(funcionario);
                    }
                    return Funcionarios;
                }
            }
            
        }
    }
}
