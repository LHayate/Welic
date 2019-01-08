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
    public partial class grpSgaDocentes : UserControlUniube
    {
        public TextBoxUniube.CTipoCampo tipoCampos;

        public grpSgaDocentes()
        {
            InitializeComponent();
        }
        
        private void txtMatriculaDocente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && !txtMatriculaDocente.ReadOnly)
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(@"
                SELECT d.matricula,
                       d.colaborador AS nome,
                       d.dt_admissao,
                       d.cpf,
                       d.ds_cargo,
                       d.centro_custo,
                       d.no_campus,
                       d.curso
                  FROM sga.docentes d
                 WHERE NVL(d.ficticio, 0) = 0
                   AND d.origem = 1
                 ORDER BY d.matricula");

                FormBusca fb = new FormBusca(sql.ToString(), new List<OracleParameter>(), true, "Busca por Itens de Custos Diretos", "descricao", "", "Nenhum Registro Encontrado");
                fb.ShowDialog();

                if (fb.retorno != null)
                {
                    txtMatriculaDocente.Text = fb.retorno["matricula"].ToString();
                    txtMatriculaDocente_Leave(null, null);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtMatriculaDocente_Leave(null, null);
            }
        }
        private void txtMatriculaDocente_Leave(object sender, EventArgs e)
        {
            if (!txtMatriculaDocente.Text.Trim().Equals(""))
            {
                DataTable dt = BLL.BuscarSgaDocentes(txtMatriculaDocente.Text);

                if (dt.Rows.Count == 1)
                {
                    txtMatriculaDocenteNome.Text = dt.Rows[0]["descricao"].ToString();
                }
                else
                {
                    txtMatriculaDocente.Text = "";
                    txtMatriculaDocenteNome.Text = "";
                }
            }
            else
            {
                txtMatriculaDocente.Text = "";
                txtMatriculaDocenteNome.Text = "";
            }
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {            
            if (!txtMatriculaDocente.Text.Trim().Equals("") && !txtMatriculaDocente.Focused)
            {
                //Essa verificação serve para quando o valor do TextBox for definido através do método de 
                //preenchimento automático dos campos utilizando o Assistente de Cadastros
                txtMatriculaDocente_Leave(sender, e);
            }
        }
    }
}
