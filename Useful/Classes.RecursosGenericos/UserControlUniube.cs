using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Uniube;

namespace Classes.RecursosGenericos
{
    public class UserControlUniube : UserControl
    {
        protected bool ControlarIntegridade;
        protected System.Windows.Forms.Uniube.FormUniube.CAcaoFormulario AcaoParentForm;
        public TextBoxUniube.CTipoCampo TipoCampos;

        public UserControlUniube()
        {
            this.Load += new EventHandler(UserControlUniube_Load);
        }

        void UserControlUniube_Load(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
                this.AcaoParentForm = ((FormUniube)this.ParentForm).AcaoFormulario;

            AlterarTipoCampos(this.Controls);

            if (this.ParentForm != null && ((FormUniube)this.ParentForm).AcaoFormulario == FormUniube.CAcaoFormulario.Novo)
            {
                this.ControlarIntegridade = true;
            }
            else
            {
                this.ControlarIntegridade = false;
            }
        }

        private void AlterarTipoCampos(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBoxUniube && ctrl.Enabled && !((TextBoxUniube)ctrl).ReadOnly)
                    ((TextBoxUniube)ctrl).TipoCampo = this.TipoCampos;

                //Se for um Container, executa a função novamente, passando os controles que existem dentro do container
                if (ctrl.HasChildren)
                {
                    AlterarTipoCampos(ctrl.Controls);
                }
            }
        }
        
        public System.Data.DataTable ExecutarSQL(string sql)
        {
            System.Data.DataTable dtRetorno = new System.Data.DataTable();

            Classes.Dal.Conexao dal = new Classes.Dal.Conexao(Classes.Entity.Globals.GetStringConnection(), 2);
            dtRetorno = dal.ExecuteQuery(sql.ToString());

            return dtRetorno;
        }
    }


}
