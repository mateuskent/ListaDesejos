using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
namespace Controller
{
    public class ControllerDesejo
    {

        public bool GravarDesejo(Desejo desejo)
        {
            SqlConnection conexao = ADODBConnection.Connection();

            SqlCommand comando = conexao.CreateCommand();

            if (desejo.IDDesejo == 0)
            {
                comando.CommandText = "insert into tbl_desejo (id_amigo_solicitante,id_amigo_solicitado,data_desejo,valor,descricao_desejo) values(@id_solicitante,@id_solicitado,@data,@valor,@descricao)";
                comando.Parameters.AddWithValue("@id_solicitante", desejo.Solicitante);
                comando.Parameters.AddWithValue("@id_solicitado", desejo.Solicitado);
                comando.Parameters.AddWithValue("@data", desejo.DataDesejo);
                comando.Parameters.AddWithValue("@valor", desejo.Valor);
                comando.Parameters.AddWithValue("@descricao", desejo.Descricao);
            }
            else
            {
                comando.CommandText = "update tbl_desejo set id_amigo_solicitante=@id_solicitante, id_amigo_solicitado=@id_solicitado, data_desejo=@data, valor=@valor, descricao_desejo=@descricao where id_desejo=@iddesejo";
                comando.Parameters.AddWithValue("@id_solicitante", desejo.Solicitante);
                comando.Parameters.AddWithValue("@id_solicitado", desejo.Solicitado);
                comando.Parameters.AddWithValue("@data", desejo.DataDesejo);
                comando.Parameters.AddWithValue("@valor", desejo.Valor);
                comando.Parameters.AddWithValue("@descricao", desejo.Descricao);
            }
            conexao.Open();
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
                return false;
            else
                return true;

        }

        public List<Desejo> ListarDesejos()
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tbl_desejo order by nome";
            List<Desejo> listaDesejos = new List<Desejo>();
            Desejo desejo;
            conexao.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    desejo = new Desejo();
                    desejo.IDDesejo = reader.GetInt32(0);
                    desejo.Solicitante = reader.GetString(1);
                    desejo.Solicitado = reader.GetString(2);
                    desejo.Valor = reader.GetDateTime(3);
                    desejo.DataDesejo = reader.GetDateTime(4);
                    desejo.Descricao = reader.GetDateTime(5);
                    listaDesejos.Add(desejo);
                }
                conexao.Close();
            }
            return listaDesejos;
        }

        public Desejo ListarDesejoPorId(int idDesejo)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tbl_desejo order by nome where id_desejo=@iddesejo";
            comando.Parameters.AddWithValue("@iddesejo", idDesejo);
            Desejo desejo = null;
            conexao.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                if (reader.Read())
                {
                    desejo = new Desejo();
                    desejo.IDDesejo = reader.GetInt32(0);
                    desejo.Solicitante = reader.GetString(1);
                    desejo.Solicitado = reader.GetString(2);
                    desejo.Valor = reader.GetDateTime(3);
                    desejo.DataDesejo = reader.GetDateTime(4);
                    desejo.Descricao = reader.GetDateTime(5);

                }
                conexao.Close();
            }
            return desejo;
        }

    }
}
