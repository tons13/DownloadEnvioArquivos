using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplicationExcel
{
    public class ArquivoExcel
    {

        int m_arquivo_id;
        string m_desc_arquivo;
        string m_extensao;
        string m_caminho;
        DateTime m_data_arquivo;
        StatusArquivo m_statusarquivo;

        public int arquivo_id
        {
            get { return m_arquivo_id; }
            set { m_arquivo_id = value; }
        }

        public string desc_arquivo
        {
            get { return m_desc_arquivo; }
            set { m_desc_arquivo = value; }
        }

        public string caminho
        {
            get { return m_caminho; }
            set { m_caminho = value; }
        }

        public string extensao
        {
            get { return m_extensao; }
            set { m_extensao = value; }
        }

        public DateTime data_arquivo 
        {
            get { return m_data_arquivo;}
            set { m_data_arquivo = value;} 
        }

        public StatusArquivo statusArquivo
        {

            get { return m_statusarquivo; }
            set { m_statusarquivo = value; }
        }


        public ArquivoExcel()
        {


            m_desc_arquivo = string.Empty;
            m_extensao = string.Empty;
            m_caminho = string.Empty;
            m_data_arquivo = DateTime.MinValue;
            m_statusarquivo = new StatusArquivo(); 
        
        }

    }
}