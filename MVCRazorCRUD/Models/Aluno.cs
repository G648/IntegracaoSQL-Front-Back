using MVCRazorCRUD.Context;
using MVCRazorCRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRazorCRUD.Models
{
    public class Aluno : UsuarioBase , IAluno
    { 
        public string Escolaridade { get; set; }

        public Aluno AlterarAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public Aluno CadastroAluno(Aluno aluno)
        {
            try
            {
                //defininfo a conexão -- precisamos criar a classe de conexao
                var connectioin = Conexao.GetConnect();
                connectioin.Open();
                var query = "insert into Alunos (alunoNome, alunoEmail, alunoEndereco, alunoTelefone, alunoEscolaridade) values (@nome, @email,@end,@tel,@esc)";
                
                //juntando a query com a conexao
                var command = new SqlCommand(query, connectioin);

                //agora vamos atribuir os valores para as variaveis - Formato CamelCase
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = aluno.Nome;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = aluno.Email;
                command.Parameters.Add("@end", SqlDbType.VarChar).Value = aluno.Endereco;
                command.Parameters.Add("@tel", SqlDbType.VarChar).Value = aluno.Telefone;
                command.Parameters.Add("@esc", SqlDbType.VarChar).Value = aluno.Escolaridade;

                //executando a query
                command.ExecuteNonQuery();
                
                //fechamos a conexao
                connectioin.Close();
                
                //retornamos o aluno cadastrado
                return aluno;


            }
            catch (Exception )
            {

                throw;
            }
        }

        public List<Aluno> ListarAluno()
        {
            throw new NotImplementedException();
        }

        public Aluno RemoverAluno(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
