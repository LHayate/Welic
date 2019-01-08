using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Uniube;
using System.Data.OracleClient;
using Classes.Dal;
using Classes.Entity;

namespace Classes.RecursosGenericos.Componentes.SGA
{
    public partial class grpItensCustosDiretos : UserControlUniube
    {
        public TextBoxUniube.CTipoCampo tipoCampos;

        public grpItensCustosDiretos()
        {
            InitializeComponent();
        }

        private void grpItensCustosDiretos_Load(object sender, EventArgs e)
        {

        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            EventosGenericos.txtItemCustoDireto_KeyDown(e, txtItem, txtItemDesc);
        }
        private void txtItem_Leave(object sender, EventArgs e)
        {
            EventosGenericos.txtItemCustoDireto_Leave(e, txtItem, txtItemDesc);
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {            
            if (!txtItem.Text.Trim().Equals("") && !txtItem.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtItem_Leave(sender, e);
            }
        }
    }
}
