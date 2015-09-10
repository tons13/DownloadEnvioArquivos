using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationExcel
{
    public class StatusArquivoData
    {

        public StatusArquivo Select(StatusArquivo status)
        {

            StatusArquivo retorno = new StatusArquivo();

            string con = "Data Source=LAB-FANTASMA;Initial Catalog=ControleExcel;User ID=sa;Password=123";
            SqlConnection connection = new SqlConnection(con);

            try
            {
                connection.Open();
                
                SqlCommand command = new SqlCommand(string.Format("Select * from cad_status_arquivo where status_arquivo_id = {0}", status.status_arquivo_id.ToString()), connection);
                SqlDataReader odr = command.ExecuteReader();
                while (odr.Read())
                {
                    retorno.status_arquivo_id = Convert.ToInt16(odr["status_arquivo_id"].ToString());
                    retorno.descricao_arquivo = odr["descricao_arquivo"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return retorno;
        
        
        }

    }
}