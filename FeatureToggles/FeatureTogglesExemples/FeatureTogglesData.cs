using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureTogglesExemples
{
    public class FeatureTogglesSqlData : IFeatureTogglesData
    {
        private readonly string _cn;

        public FeatureTogglesSqlData(string cn)
        {
            _cn = cn;
        }

        public string ConsultaValor(string name)
        {
            var retorno = string.Empty;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "pr_FeatureTogglesConsultar";
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;

                using (SqlConnection sqlConnection = new SqlConnection(_cn))
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    var scalar = sqlCommand.ExecuteScalar();
                    retorno = (scalar != null) ? (string)scalar : string.Empty;
                }
            }

            return retorno;
        }

        public void Insere(string name, string value)
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "pr_FeatureTogglesIncluir";
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                sqlCommand.Parameters.Add("@Value", SqlDbType.VarChar).Value = value;

                using (SqlConnection sqlConnection = new SqlConnection(_cn))
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Altera(string name, string value)
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "pr_FeatureTogglesAlterar";
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                sqlCommand.Parameters.Add("@Value", SqlDbType.VarChar).Value = value;

                using (SqlConnection sqlConnection = new SqlConnection(_cn))
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
