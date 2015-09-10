using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationExcel
{
    public class ArquivoExcelData
    {

        public void Insert(ArquivoExcel arquivoExcel)
        {

            string con = "Data Source=LAB-FANTASMA;Initial Catalog=ControleExcel;User ID=sa;Password=123";
            SqlConnection connection = new SqlConnection(con);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(string.Format("INSERT INTO Cad_arquivo_excel (Desc_arquivo,Extensao,Caminho,Data_Arquivo,StatusArquivo) VALUES ('{0}','{1}','{2}','{3}',{4})", 
                    arquivoExcel.desc_arquivo, 
                    arquivoExcel.extensao,
                    arquivoExcel.caminho,
                    arquivoExcel.data_arquivo.ToString("s"), 
                    arquivoExcel.statusArquivo.status_arquivo_id), connection);
                
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connection.Close();
            }
        
        
        }

    }
}