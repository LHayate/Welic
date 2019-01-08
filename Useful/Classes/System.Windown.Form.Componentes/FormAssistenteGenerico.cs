using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Data.Objects.DataClasses;

namespace UseFul.Forms.Welic
{
    public partial class FormAssistenteGenerico : FormWelic
    {
        /// <summary>
        /// Type da classe onde se encontra o método que retornará os dados para preencher a grid, com seu respectivo namespace. Por exemplo: base.typeClasse = typeof(SGANomeDoSistema.Bll.BLL);
        /// </summary>
        protected Type typeClasse { get; set; }

        /// <summary>
        /// Nome do método que retornará uma DataTable com os dados para preenchimento da grid. Por exemplo: base.nomeMetodo = "BuscarAlunos";
        /// </summary>
        protected string nomeMetodo { get; set; }

        protected object[] parametros { get; set; }

        protected object _Entidade { get; set; }

        public FormAssistenteGenerico()
        {
            InitializeComponent();

            PreencherGrid();


        }


        private object getRetornoMetodo()
        {
            object retorno = null;

            if (this.typeClasse != null && this.nomeMetodo != null)
            {
                //Instancia a classe "typeClasse"
                object classe = Activator.CreateInstance(this.typeClasse, null);

                //Busca o método contido na classe "typeClasse" 
                MethodInfo methodInfo = typeClasse.GetMethod(this.nomeMetodo);

                if (methodInfo.GetParameters() != null &&
                    methodInfo.GetParameters().Length > 0 &&
                    this.parametros != null)
                {
                    //Invoca o método da classe, passando os parametros
                    retorno = methodInfo.Invoke(classe, this.parametros);
                }
                else if (methodInfo.GetParameters() == null || methodInfo.GetParameters().Length == 0)
                {
                    retorno = methodInfo.Invoke(classe, this.parametros);
                }
            }

            return retorno;
        }
        protected void getParametrosMetodo()
        {
            //Instancia a classe "typeClasse"
            object classe = Activator.CreateInstance(this.typeClasse, null);

            //Busca o método contido na classe "typeClasse" 
            MethodInfo methodInfo = typeClasse.GetMethod(this.nomeMetodo);

            ParameterInfo[] p = methodInfo.GetParameters();
        }

        protected void PreencherGrid()
        {
            if (nomeMetodo != null)
            {
                dgv.AutoGenerateColumns = false;

                if (_Entidade == null && this.typeClasse != null && this.parametros != null)
                    dgv.DataSource = getRetornoMetodo();
                else
                {
                    //Busca o método contido na classe "typeClasse" 
                    //new Type[] { } serve para buscar sempre o método que não possui parametros
                    MethodInfo methodInfo = _Entidade.GetType().GetMethod(this.nomeMetodo, new Type[] { });

                    //Invoca o método da classe, passando os parametros
                    object retorno = methodInfo.Invoke(_Entidade, null);

                    dgv.DataSource = retorno;
                }

                dgv.Refresh();
            }
        }
        private void ColorirColunasAutomaticamente()
        {
            List<string> colunas = new List<string>();
            List<Color> cores = new List<Color>();
            string colunaCorPadrao = null;

            foreach (DataGridViewColumn item in dgv.Columns)
            {
                if (item.Name.ToUpper().Contains("IMGVER"))
                {
                    colunas.Add(item.Name);
                    cores.Add(Color.LightSkyBlue);
                }
                else if (item.Name.ToUpper().Contains("IMGMENU"))
                {
                    colunas.Add(item.Name);
                    cores.Add(Color.LightSkyBlue);
                }
                else if (item.Name.ToUpper().Contains("IMGIMPRIMIR"))
                {
                    colunas.Add(item.Name);
                    cores.Add(Color.LightGray);
                }
                else if (item.Name.ToUpper().Contains("IMGEDITAR"))
                {
                    colunas.Add(item.Name);
                    cores.Add(Color.Wheat);
                }
                else if (item.Name.ToUpper().Contains("IMGEXCLUIR"))
                {
                    colunas.Add(item.Name);
                    cores.Add(Color.Salmon);
                }
                else if (item.Name.ToUpper().Contains("IMGLOG"))
                {
                    colunas.Add(item.Name);
                    cores.Add(Color.Gold);
                }
                else
                {
                    colunaCorPadrao = item.Name;
                }
            }

            dgv.CriarEventosColorirAutomaticamente(colunas.ToArray(), cores.ToArray(), colunaCorPadrao);
        }
        private void atualizarContagemItensGrid()
        {
            if (dgv.Rows.Count > 0)
            {
                lblContagemItensGrid.Visible = true;
                if (dgv.Rows.Count == 1)
                    lblContagemItensGrid.Text = "Total: 01 item";
                else if ((dgv.Rows.Count > 1) && (dgv.Rows.Count < 10))
                    lblContagemItensGrid.Text = "Total: 0" + dgv.Rows.Count.ToString() + " itens";
                else if ((dgv.Rows.Count >= 10))
                    lblContagemItensGrid.Text = "Total: " + dgv.Rows.Count.ToString() + " itens";

                ColorirColunasAutomaticamente();
            }
            else
            {
                lblContagemItensGrid.Visible = false;
                lblContagemItensGrid.Text = "";
            }
        }

        private void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            atualizarContagemItensGrid();
        }
        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            atualizarContagemItensGrid();
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            atualizarContagemItensGrid();
        }

        private void FormAssistente_SizeChanged(object sender, EventArgs e)
        {
            int locX = (pnlBuscar.Size.Width / 2) - (btnBuscar.Size.Width / 2);
            btnBuscar.Location = new Point(locX, btnBuscar.Location.Y);
        }

        private void FormAssistente_Load(object sender, EventArgs e)
        {
            FormAssistente_SizeChanged(sender, e);
        }

    }
}
