using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplicationExcel
{
    [Serializable]
    public class StatusArquivo
    {

        int m_status_arquivo_id;
        string m_descricao_arquivo;


        public int status_arquivo_id

        { 
            get { return m_status_arquivo_id; }
            set { m_status_arquivo_id = value; }
        }

        public string descricao_arquivo
        {
            get { return m_descricao_arquivo; }
            set { m_descricao_arquivo = value; }
        }


        public StatusArquivo()
        {
            m_status_arquivo_id = int.MinValue;
            m_descricao_arquivo = string.Empty;
        }
    }
}