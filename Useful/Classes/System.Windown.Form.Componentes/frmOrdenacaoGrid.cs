using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.Forms.Welic;

namespace UseFul.Forms.Welic
{
    public partial class frmOrdenacaoGrid : FormWelic
    {        
        public DataGridViewWelic dgv;

        private string[][] itens;
        private const int _indexDataPropertyNames = 0;
        private const int _indexHeaderTexts = 1;
        private const int _indexOrdenacao = 2;

        public frmOrdenacaoGrid(DataGridViewWelic dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
        }

        private void TrocarPosicao(object[] values, int origem, int destino)
        {
            object temp = values[origem];
            values[origem] = values[destino];
            values[destino] = temp;
        }
        private void CarregarLista(bool aplicarOrdenacao)
        {
            try
            {
                int selectedIndex = listColunas.SelectedIndex;

                listColunas.Items.Clear();

                for (int i = 0; i < this.itens[_indexHeaderTexts].Length; i++)
                {
                    string ordem = "";
                    if (aplicarOrdenacao)
                        ordem = (this.itens[_indexOrdenacao][i] == "ASC" ? "(Crescente)" : "(Decrescente)");

                    listColunas.Items.Add(this.itens[_indexHeaderTexts][i] + "  " + ordem);
                }

                if (aplicarOrdenacao)
                {
                    string sort = "";
                    for (int i = 0; i < this.itens[_indexDataPropertyNames].Length; i++)
                    {
                        if (!this.itens[_indexDataPropertyNames][i].Trim().Equals(""))
                        {
                            sort += this.itens[_indexDataPropertyNames][i] + " " + this.itens[_indexOrdenacao][i];
                            sort += ", ";
                        }
                    }

                    sort = sort.Substring(0, sort.Length - 2);

                    DataTable dt = ((DataTable)dgv.DataSource);
                    dt.DefaultView.Sort = sort;

                    listColunas.Focus();
                }

                if (selectedIndex >= 0)
                {
                    listColunas.SetSelected(selectedIndex, true);
                }

                if (listColunas.Items.Count == 0)
                {
                    MessageBox.Show("Não existem opções de ordenação disponíveis.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                //Enviar erro considerando que é o sistema 118 (Processos Seletivos) para enviar para Junior Carvalho Brolini
                //Classes.Uteis.EnviarEmailErro.EnviaEmailErro(ex, @"
                //Projeto Classes - 
                //Formulário de Ordenação da Grid - 
                //Windows.Forms.Welic.frmOrdenacao - 
                //Método CarregarLista", 118);
            }
        }

        private void frmOrdenacaoGrid_Load(object sender, EventArgs e)
        {
            try
            {
                frmOrdenacaoGrid_SizeChanged(null, null);

                List<string> dataPropertyNames = new List<string>();
                List<string> headerTexts = new List<string>();
                List<string> ordenacao = new List<string>();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible && dgv.Columns[i].GetType().Equals(typeof(DataGridViewTextBoxColumn)))
                    {
                        //columnNames.Add(dgv.Columns[i].Name);
                        if (dgv.Columns[i].SortMode != DataGridViewColumnSortMode.NotSortable)
                        {
                            dataPropertyNames.Add(dgv.Columns[i].DataPropertyName);
                            headerTexts.Add(dgv.Columns[i].HeaderText);
                            ordenacao.Add("ASC");
                        }
                    }
                }

                this.itens = new string[][] { dataPropertyNames.ToArray(), headerTexts.ToArray(), ordenacao.ToArray() };



                CarregarLista(false);
            }
            catch (Exception ex)
            {
                //Enviar erro considerando que é o sistema 118 (Processos Seletivos) para enviar para Junior Carvalho Brolini
                //Classes.Uteis.EnviarEmailErro.EnviaEmailErro(ex, @"
                //Projeto Classes - 
                //Formulário de Ordenação da Grid - 
                //Windows.Forms.Welic.frmOrdenacao - 
                //Método Load", 118);
            }
        }

        private void btnMoverUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (listColunas.SelectedIndex > 0)
                {
                    int indexOrigem = listColunas.SelectedIndex;
                    int indexDestino = listColunas.SelectedIndex - 1;

                    TrocarPosicao(itens[_indexDataPropertyNames], indexOrigem, indexDestino);
                    TrocarPosicao(itens[_indexHeaderTexts], indexOrigem, indexDestino);
                    TrocarPosicao(itens[_indexOrdenacao], indexOrigem, indexDestino);

                    CarregarLista(true);

                    listColunas.SetSelected(indexDestino, true);
                }
            }
            catch (Exception ex)
            {
                //Enviar erro considerando que é o sistema 118 (Processos Seletivos) para enviar para Junior Carvalho Brolini
                //Classes.Uteis.EnviarEmailErro.EnviaEmailErro(ex, @"
                //Projeto Classes - 
                //Formulário de Ordenação da Grid - 
                //Windows.Forms.Welic.frmOrdenacao - 
                //Método btnMoverUp_Click", 118);
            }
        }
        private void btnMoverDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (listColunas.SelectedIndex >= 0 && listColunas.SelectedIndex + 1 < listColunas.Items.Count)
                {
                    int indexOrigem = listColunas.SelectedIndex;
                    int indexDestino = listColunas.SelectedIndex + 1;

                    TrocarPosicao(itens[_indexDataPropertyNames], indexOrigem, indexDestino);
                    TrocarPosicao(itens[_indexHeaderTexts], indexOrigem, indexDestino);
                    TrocarPosicao(itens[_indexOrdenacao], indexOrigem, indexDestino);

                    CarregarLista(true);

                    listColunas.SetSelected(indexDestino, true);
                }
            }
            catch (Exception ex)
            {
                //Enviar erro considerando que é o sistema 118 (Processos Seletivos) para enviar para Junior Carvalho Brolini
                //Classes.Uteis.EnviarEmailErro.EnviaEmailErro(ex, @"
                //Projeto Classes - 
                //Formulário de Ordenação da Grid - 
                //Windows.Forms.Welic.frmOrdenacao - 
                //Método MoverUp_Down", 118);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmOrdenacaoGrid_SizeChanged(object sender, EventArgs e)
        {
            int locX = (pnlRight.Size.Width / 2) - (pnlBotoesUpDown.Size.Width / 2);
            int locY = (pnlRight.Size.Height / 2) - (pnlBotoesUpDown.Size.Height / 2);
            pnlBotoesUpDown.Location = new Point(locX, locY);
        }

        private void listColunas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (itens[_indexOrdenacao][listColunas.SelectedIndex].Equals("ASC"))
                {
                    itens[_indexOrdenacao][listColunas.SelectedIndex] = "DESC";
                }
                else
                {
                    itens[_indexOrdenacao][listColunas.SelectedIndex] = "ASC";
                }

                CarregarLista(true);
            }
            catch (Exception ex)
            {
                //Enviar erro considerando que é o sistema 118 (Processos Seletivos) para enviar para Junior Carvalho Brolini
                //Classes.Uteis.EnviarEmailErro.EnviaEmailErro(ex, @"
                //Projeto Classes - 
                //Formulário de Ordenação da Grid - 
                //Windows.Forms.Welic.frmOrdenacao - 
                //Método listColunas_DoubleClick", 118);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
@"1. Selecione um item
2. Mova o item para cima ou para baixo
3. Clique duas vezes sobre o item para alterar a direção da ordenação (Crescente/Decrescente)", "Instruções", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
