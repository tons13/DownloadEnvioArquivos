using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace WebApplicationExcel
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntUpload_Click(object sender, EventArgs e)
        {

            ArquivoExcelData arquivoExcelData = new ArquivoExcelData();
            StatusArquivoData statusData = new StatusArquivoData();
                     


            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileContent.Length > 0)
                {
                    Random random = new Random();
                    string FolderTemp;
                    string Foldername;
                    string Extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName.ToString());
                                        
                    if (Extension == ".XLS" || Extension == ".XLSX" || Extension == ".xls" || Extension == ".xlsx")
                    {


                        StatusArquivo arquivo = new StatusArquivo();
                        arquivo.status_arquivo_id = 1;

                        var ArquivoStatus = statusData.Select(arquivo);
                        

                        FolderTemp = Server.MapPath("~/Temporario/");
                        Foldername = Server.MapPath("~/Arquivos/");

                        String filenameRandom = random.Next().ToString() + filename.ToString();
                        String caminho = FolderTemp + filenameRandom.ToString();
                        
                        FileUpload1.PostedFile.SaveAs(caminho);
                  
                        String conStr = "";
                        switch (Extension)
                        {
                            case ".xls": //Excel 97-03
                                conStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                "Data Source=" + FolderTemp + "//" + filenameRandom + ";" +
                                "Extended Properties=Excel 8.0;";
                                break;

                            case ".xlsx": //Excel 07
                                conStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                               "Data Source=" + FolderTemp + "//" + filenameRandom + ";" +
                               "Extended Properties=Excel 8.0;";
                                break;
                        }

                        OleDbConnection oconn = new OleDbConnection(conStr);
                        //------
                        OleDbCommand ocmd = new OleDbCommand("select * from [Produtos$]", oconn);
                        oconn.Open();
                        OleDbDataReader odr = ocmd.ExecuteReader();
                        List<Produto> listaProduto = new List<Produto>();
                        while (odr.Read())
                        {

                            listaProduto.Add(new Produto
                            {
                                Produto_id = Convert.ToInt16(odr["Produto_id"].ToString()),
                                Descricao_Produto = odr["Descricao_Produto"].ToString()
                            });   

                            
                        }

                        ArquivoExcel arquivoExcel = new ArquivoExcel();

                        arquivoExcel.desc_arquivo = filenameRandom;
                        arquivoExcel.extensao = Extension;
                        arquivoExcel.caminho = Foldername + filenameRandom;
                        arquivoExcel.data_arquivo = DateTime.Now;
                        arquivoExcel.statusArquivo = ArquivoStatus;

                       
                        System.IO.File.Copy(caminho, Foldername + "//" + filenameRandom);

                        arquivoExcelData.Insert(arquivoExcel);
                        
                        lblmsg.Text = "Upload Excel File ......";
                    }
                    else
                    {
                        lblmsg.Text = "Select only Excel File ....!!";
                    }
                }
            }
        
        }

        protected void lbtDownload_Click(object sender, EventArgs e)
        {
            string caminhoTemplate = "~/Templates/Central.xls";
            Download(caminhoTemplate); 
        }

        public void Download(string caminho)
        {
            DirectoryInfo pasta = new DirectoryInfo(Server.MapPath(caminho));
            FileInfo arquivo = new FileInfo(pasta.FullName); 
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + arquivo.Name.ToString() + "");
            Response.AddHeader("Content-Length", arquivo.Length.ToString());
            Response.Flush();
            Response.WriteFile(arquivo.FullName);
        
        }
           
    }
}