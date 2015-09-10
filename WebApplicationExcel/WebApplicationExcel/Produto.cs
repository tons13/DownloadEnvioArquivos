using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplicationExcel
{
    [Serializable]
    public class Produto
    {

        int m_produto_id;
        string m_descricao_produto;


        public int Produto_id 
        { 
            get
            { 
            return m_produto_id;
            }
            set
            { 
             m_produto_id = value; 
            } 
        }


        public string Descricao_Produto
        {
            get
            {
                return m_descricao_produto;
            }
            set
            {
                m_descricao_produto = value;
            }
        }


        public Produto()
        {
            m_produto_id = int.MinValue;
            m_descricao_produto = string.Empty;

        }

    }
}