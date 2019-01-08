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
    public partial class grpCustosDiretos : UserControlUniube
    {
        public TextBoxUniube.CTipoCampo tipoCampos;

        public grpCustosDiretos()
        {
            InitializeComponent();
        }

        private void grpItensCustosDiretos_Load(object sender, EventArgs e)
        {

        }

        private void txtCusto_KeyDown(object sender, KeyEventArgs e)
        {
            EventosGenericos.txtCustoDireto_KeyDown(e, txtCusto, txtCustoDesc);
        }
        private void txtCusto_Leave(object sender, EventArgs e)
        {
            EventosGenericos.txtCustoDireto_Leave(e, txtCusto, txtCustoDesc);
        }

        private void txtCusto_TextChanged(object sender, EventArgs e)
        {
            if (!txtCusto.Text.Trim().Equals("") && !txtCusto.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtCusto_Leave(sender, e);
            }
        }
    }
}
