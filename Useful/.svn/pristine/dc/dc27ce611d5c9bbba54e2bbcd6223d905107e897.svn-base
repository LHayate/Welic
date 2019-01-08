using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Uniube;
using Classes.Entity;
using Classes.Dal;

namespace Classes.RecursosGenericos.Telas.Cadastros
{
    public partial class frmAssistenteCadastrosBasicos : FormUniube
    {
        Panel p = new Panel();
        Label l = new Label();
        public frmAssistenteCadastrosBasicos()
        {
            InitializeComponent();
            p.BackColor = this.BackColor;
            p.Dock = DockStyle.Fill;

            l.Text = "Selecione um cadastro no painel ao lado.";
            l.AutoSize = false;
            l.Size = new System.Drawing.Size(250, 17);
            l.Font = new Font(l.Font.FontFamily, 9, FontStyle.Italic);
            l.ForeColor = Color.Gray;
            p.Controls.Add(l);

            this.Controls.Add(p);
            p.BringToFront();
            p.Resize += new EventHandler(p_Resize);
            p_Resize(null, null);
        }

        void p_Resize(object sender, EventArgs e)
        {
            l.Location = new Point(p.Size.Width / 2 - l.Width / 2, p.Size.Height / 2);
        }

        private void frmAssistenteCadastrosBasicos_Load(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
            SELECT sp.sistema,
                   sp.programa,
                   nvl(p.descricao_formal, p.descricao) AS programa_desc,
                   sp.categoria,
                   nvl(pc.descricao_formal, pc.descricao) AS categoria_desc
              FROM seg.sistemas_programas sp
              JOIN seg.programas p ON (p.programa = sp.programa)
              JOIN seg.programas_categorias pc ON (pc.categoria = sp.categoria)
             WHERE sp.sistema = " + Globals.Sistema + @"
             ORDER BY categoria_desc,
                      programa_desc");
            DataTable dt = ExecutarSQL(sql.ToString());

            List<string> pais = new List<string>();
            List<string> filhos = new List<string>();

            foreach (DataRow item in dt.Rows)
            {
                pais.Add(item["categoria_desc"].ToString());
                filhos.Add(item["programa_desc"].ToString());
            }
            pais = pais.Distinct().ToList();


            foreach (string pai in pais)
            {
                TreeNode node = new TreeNode();
                node.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
                node.Text = pai + "      ";
                node.Expand();

                foreach (DataRow row in dt.Rows)
                {
                    if (row["categoria_desc"].ToString().Equals(pai))
                    {
                        TreeNode filho = new TreeNode();
                        filho.Tag = row["programa"].ToString();
                        filho.Text = row["programa_desc"].ToString();
                        node.Nodes.Add(filho);
                    }
                }

                treeView1.Nodes.Add(node);
            }
        }

        private void frmAssistenteCadastrosBasicos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //p.Visible = (this.MdiChildren.Length == 0);
        }
        private void frmAssistenteCadastrosBasicos_MdiChildActivate(object sender, EventArgs e)
        {
            //p.Visible = (this.MdiChildren.Length == 0);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            lblTituloFormulario.Text = "";
            p.Visible = true;

            if (treeView1.SelectedNode.Tag != null)
            {
                lblTituloFormulario.Text = "";
                System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                Type[] types = myAssembly.GetTypes();

                foreach (Type myType in types)
                {
                    if (myType.BaseType.FullName == "System.Windows.Forms.Uniube.FormAssistenteCadastro")
                    {
                        try
                        {
                            FormAssistenteCadastro frmAssistenteCadastro = (FormAssistenteCadastro)Activator.CreateInstance(myType);
                            if (frmAssistenteCadastro.CodigoSeguranca.Equals(treeView1.SelectedNode.Tag.ToString()))
                            {
                                frmAssistenteCadastro.MdiParent = this;
                                frmAssistenteCadastro.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                                frmAssistenteCadastro.Dock = DockStyle.Fill;
                                frmAssistenteCadastro.Refresh();
                                frmAssistenteCadastro.Show();
                                lblTituloFormulario.Text = treeView1.SelectedNode.Text;
                                p.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string msg = "Message: " + ex.Message;
                            if (ex.InnerException != null)
                                msg = "Inner Exception: " + ex.InnerException.ToString();
                            MessageBox.Show("Ocorreu um erro ao abrir o formulário: " + msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}
