﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.ClientApi;
using UseFul.Uteis;

namespace UseFul.Forms.Welic
{
    #region Classe DataGridViewWelic
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iDatagrid.ico")]
    public partial class DataGridViewWelic : DataGridView
    {
        public Panel pnlGridContainer { get; set; }
        DataGridViewWelic dgvTotais { get; set; }
        private string[] ColunasSomatorioAutomatico { get; set; }
        private bool ExibirPainelTotaisAutomaticamente { get; set; }
        private LabelWelic lblContagemItensGrid { get; set; }
        private int _UltimoIndex = -1, qtdClicados = 0, _TempoCliqueInicial = 0;
        /// <summary>
        /// Flag para utilização do recurso selecionar várias linhas com shift.
        /// </summary>
        public Boolean _UtilizarShift { get; set; }

        /// <summary>
        /// Posicao 0: vetor contendo o Nome das colunas; 
        /// Posicao 1: vetor contendo seus respectivos a serem exibidos
        /// </summary>
        public List<object[]> ColunasTotaisCalculados;

        public DataGridViewWelic()
        {
            InitializeComponent();
            pnlGridContainer = new Panel();
            ColunasSomatorioAutomatico = null;
            ColunasSomatorioAutomatico = new string[] { "" };

            ColunasTotaisCalculados = new List<object[]>();

            //JUNIOR CARVALHO BROLINI - 20/06/2013
            //Propriedade para impedir que as colunas sejam bagunçadas quando a DataSource da dgv for alterada
            //this.AutoGenerateColumns = false;
            //DESABILITADO EM 28/06/2013 POR TER CAUSADO PROBLEMAS NOS SISTEMAS QUE UTILIZAM ColumnIndex AO INVÉS DE ColumnName PARA IDENTIFICAR COLUNAS DO TIPO DataGridViewImageColumn

            this._mostrarMenuOrdenacao = true;
            this._mostrarMenuBusca = true;
            this._mostrarMenuCalcularTotais = true;
            this._mostrarMenuExportarExcel = true;

            this._aplicarEventosColorirGridAutomaticamente = false;
            this.HabilitarColunasInvisiveisExportarExcel = false;
        }

        /// <summary>
        /// Variável para guardar informações da grid antes dele ser alterado pelo método de calcular totais automáticos
        /// </summary>
        private DockStyle? bkpDockStyleGrid;
        private Point? bkpLocationGrid;

        ContextMenuStrip MenuStripOpcoes;
        private bool _limpaCampo = true;
        public bool LimpaCampo
        {
            get { return _limpaCampo; }
            set { _limpaCampo = value; }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            atualizarContagemItensGrid();

            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.DefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.EnableHeadersVisualStyles = false;
            this.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (!this.Enabled)
            {
                this.BackgroundColor = Color.WhiteSmoke;
                this.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
                this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                this.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                this.DefaultCellStyle.SelectionForeColor = Color.Gray;
                this.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                this.DefaultCellStyle.ForeColor = Color.Gray;
                this.RowHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                this.RowHeadersDefaultCellStyle.ForeColor = Color.Gray;
                this.RowHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                this.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Gray;
            }
            else
            {
                this.BackgroundColor = Color.White;
                this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(195, 217, 241);
                this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                this.DefaultCellStyle.SelectionBackColor = Color.LemonChiffon;
                this.DefaultCellStyle.SelectionForeColor = Color.Black;
                this.DefaultCellStyle.BackColor = Color.White;
                this.DefaultCellStyle.ForeColor = Color.Black;
                this.RowHeadersDefaultCellStyle.BackColor = Color.White;
                this.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
                this.RowHeadersDefaultCellStyle.SelectionBackColor = Color.LemonChiffon;
                this.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }
        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            AjustarLarguraColunasGridTotais();
        }
        protected override void OnColumnStateChanged(DataGridViewColumnStateChangedEventArgs e)
        {
            base.OnColumnStateChanged(e);

            if (dgvTotais != null && dgvTotais.Columns.Contains(e.Column.Name))
            {
                dgvTotais.Columns[e.Column.Name].Visible = e.Column.Visible;
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            //Executa o método OnMouseClick original
            base.OnMouseClick(e);

            DataGridView.HitTestInfo hti = this.HitTest(e.X, e.Y);

            //Verifica se a row clicada não é a header e se o botão clicado foi o direito
            if (hti.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                bool abortarEvento = false;
                //Caso tenha sido informadas colunas que não devem mostrar o menu, percorre as colunas e 
                //seta o flag de abordar evento caso a coluna ColumnIndex estiver presente no vetor
                if (this._columnNameExcecoesMostrarMenu != null)
                {
                    foreach (string item in this._columnNameExcecoesMostrarMenu)
                    {
                        if (this.Columns[hti.ColumnIndex].Name.Equals(item))
                        {
                            abortarEvento = true;
                        }
                    }
                }

                if (!abortarEvento)
                {
                    this.ClearSelection();
                    this.Rows[hti.RowIndex].Selected = true;

                    if (this.Columns.Count > 0 &&
                        this.Rows.Count > 0 &&
                        hti.RowIndex >= 0 &&
                        hti.ColumnIndex >= 0)
                    {
                        CriarMenu(hti.RowIndex, hti.ColumnIndex);
                    }

                    if (hti.Type == DataGridViewHitTestType.Cell)
                    {
                        MenuStripOpcoes.Show(this, new Point(e.X + 2, e.Y + 2));
                    }
                }
            }
            else if (_UltimoIndex < this.Rows.Count && !this.ReadOnly && _UltimoIndex >= 0 && hti.RowIndex != _UltimoIndex && hti.RowIndex > -1 && e.Button == MouseButtons.Left &&
                      this.Columns[hti.ColumnIndex].CellType == typeof(DataGridViewCheckBoxCell) && _UtilizarShift && !this.Rows[_UltimoIndex].Cells[hti.ColumnIndex].ReadOnly)
            {
                try
                {
                    if (Control.ModifierKeys != Keys.Shift && (this.Columns[hti.ColumnIndex].ToolTipText.Equals("") || this.Columns[hti.ColumnIndex].ToolTipText.Equals("Dica: Use Shift para selecionar vários itens.\nSelecione o primeiro item do intervalo, segure a tecla Shift, e selecione o último.\nTodos os itens nesse intervalo serão marcados ou desmarcados conforme sua seleção inicial.")))
                    {
                        #region Verifica qtd de cliques para criar ToolTip
                        qtdClicados++;
                        if (qtdClicados == 1)
                            _TempoCliqueInicial = DateTime.Now.Second;
                        else if (qtdClicados == 4 && ((DateTime.Now.Second - _TempoCliqueInicial) <= 7))
                        {
                            this.Columns[hti.ColumnIndex].ToolTipText = "Dica: Use Shift para selecionar vários itens.\nSelecione o primeiro item do intervalo, segure a tecla Shift, e selecione o último.\nTodos os itens nesse intervalo serão marcados ou desmarcados conforme sua seleção inicial.";
                            for (int i = 0; i < (this.Rows.Count > (hti.RowIndex + 50) ? (hti.RowIndex + 50) : this.Rows.Count); i++)
                                if (this.Rows[i].Cells[hti.ColumnIndex].ToolTipText.Equals(""))
                                    this.Rows[i].Cells[hti.ColumnIndex].ToolTipText = "Dica: Use Shift para selecionar vários itens.\nSelecione o primeiro item do intervalo, segure a tecla Shift, e selecione o último.\nTodos os itens nesse intervalo serão marcados ou desmarcados conforme sua seleção inicial.";
                        }
                        else if (qtdClicados > 10)
                        {
                            for (int i = 0; i < (this.Rows.Count > (hti.RowIndex + 50) ? (hti.RowIndex + 50) : this.Rows.Count); i++)
                                this.Rows[i].Cells[hti.ColumnIndex].ToolTipText = "";
                        }
                        #endregion
                    }
                    if (Control.ModifierKeys == Keys.Shift && _UltimoIndex >= 0 && !this.ReadOnly)
                    {
                        #region Processo de marcar os checks
                        bool valor = false;
                        int validou = 0;
                        if (this.Rows[_UltimoIndex].Cells[hti.ColumnIndex].Value != null)
                        {
                            if (!bool.TryParse(this.Rows[_UltimoIndex].Cells[hti.ColumnIndex].Value.ToString(), out valor))
                                if (int.TryParse(this.Rows[_UltimoIndex].Cells[hti.ColumnIndex].Value.ToString(), out validou))
                                    valor = validou == 1 ? true : false;
                                else
                                    //Valor para conversão diferente de bool e int
                                    throw new Exception("Erro ao converter valor da célula.\nValor encontrado: " + this.Rows[_UltimoIndex].Cells[hti.ColumnIndex].Value + "\n\nFalha ao converter para booleano e para inteiro.");
                        }
                        else
                            valor = false;
                        if (_UltimoIndex > hti.RowIndex)
                            for (int i = hti.RowIndex; i <= _UltimoIndex; i++)
                            {
                                if (!this.Rows[i].Cells[hti.ColumnIndex].ReadOnly)
                                    this.Rows[i].Cells[hti.ColumnIndex].Value = valor;
                            }
                        else
                            for (int i = hti.RowIndex; i >= _UltimoIndex; i--)
                            {
                                if (!this.Rows[i].Cells[hti.ColumnIndex].ReadOnly)
                                    this.Rows[i].Cells[hti.ColumnIndex].Value = valor;
                            }
                        this.EndEdit();
                        #endregion
                    }
                }
                catch (Exception ex) { /*Classes.Uteis.EnviarEmailErro.EnviaEmailErro(ex, this.Text, "PROG001");*/ }
            }
            _UltimoIndex = hti.RowIndex;
        }
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            //executa o método padrão
            base.OnCellMouseEnter(e);

            if (this._aplicarEventosColorirGridAutomaticamente)
            {
                int posicao = 0;
                foreach (string item in this._colunasEventosColorirGridAutomaticamente)
                {
                    if (e.RowIndex != -1 && e.ColumnIndex != -1 && e.RowIndex < this.RowCount &&
                    this.Columns[e.ColumnIndex].Name.Equals(item))
                    {
                        this.Rows[e.RowIndex].Cells[item].Style.BackColor = this._backColorsEventosColorirGridAutomaticamente[posicao];
                        this.Rows[e.RowIndex].Cells[item].Style.SelectionBackColor = this._backColorsEventosColorirGridAutomaticamente[posicao];
                    }

                    posicao++;
                }
            }
        }
        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            //executa o método padrão
            base.OnCellMouseLeave(e);

            if (this._aplicarEventosColorirGridAutomaticamente)
            {
                foreach (string item in this._colunasEventosColorirGridAutomaticamente)
                {
                    if (e.RowIndex != -1 && e.ColumnIndex != -1 && e.RowIndex < this.RowCount &&
                    this.Columns[e.ColumnIndex].Name.Equals(item))
                    {
                        //pega o padrão da DataGridViewWelic
                        Color backColor = Color.White;
                        Color selectionBackColor = Color.LemonChiffon;

                        //Caso tenha informado uma coluna, pega o padrão desta coluna
                        if (!string.IsNullOrEmpty(this._colunaCorPadrao))
                        {
                            backColor = this.Rows[e.RowIndex].Cells[this._colunaCorPadrao].Style.BackColor;
                            selectionBackColor = this.Rows[e.RowIndex].Cells[this._colunaCorPadrao].Style.SelectionBackColor;
                        }

                        //volta para as cores padrão
                        this.Rows[e.RowIndex].Cells[item].Style.BackColor = backColor;
                        this.Rows[e.RowIndex].Cells[item].Style.SelectionBackColor = selectionBackColor;
                    }
                }
            }
        }
        protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
        {
            //executa o método padrão
            base.OnCellMouseMove(e);

            if (this._aplicarEventosColorirGridAutomaticamente)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (this._colunasEventosColorirGridAutomaticamente.Contains(this.Columns[e.ColumnIndex].Name))
                    {
                        this.Cursor = Cursors.Hand;
                    }
                    else if (!this.Columns[e.ColumnIndex].GetType().Equals(typeof(DataGridViewLinkColumn)))
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            //executa o método padrão
            base.OnMouseLeave(e);

            if (this._aplicarEventosColorirGridAutomaticamente)
            {
                base.Cursor = Cursors.Default;
            }
        }
        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);

            if (dgvTotais != null || this.ExibirPainelTotaisAutomaticamente)
            {
                ToolStripMenuItemCalcularTotais_ToolStripMenuItem(null, null);
            }

            foreach (DataGridViewColumn item in this.Columns)
            {
                if (item.DefaultCellStyle.Format.Equals("C2"))
                {
                    item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            atualizarContagemItensGrid();
        }

        #region Propriedades referentes ao menu de opções da grid - JUNIOR CARVALHO BROLINI
        private bool _mostrarMenuExportarExcel { get; set; }
        private bool _mostrarMenuOrdenacao { get; set; }
        private bool _mostrarMenuBusca { get; set; }
        private bool _mostrarMenuCalcularTotais { get; set; }
        /// <summary>
        /// Quando true, esta propriedade permite que o recurso de Exportar para Excel inclua as colunas invisíveis da DataGridView. Por padrão, possui valor false.
        /// </summary>
        public bool HabilitarColunasInvisiveisExportarExcel { get; set; }
        private string[] _columnNameExcecoesMostrarMenu { get; set; }
        #endregion
        #region Propriedades referentes aos eventos de colorir a grid automaticamente - JUNIOR CARVALHO BROLINI
        private bool _aplicarEventosColorirGridAutomaticamente { get; set; }
        private string[] _colunasEventosColorirGridAutomaticamente { get; set; }
        private Color[] _backColorsEventosColorirGridAutomaticamente { get; set; }
        private string _colunaCorPadrao { get; set; }
        #endregion

        #region Métodos referentes ao menu de opções da grid - JUNIOR CARVALHO BROLINI
        private void CriarMenu(int rowIndex, int columnIndex)
        {
            MenuStripOpcoes = new ContextMenuStrip();

            DataGridViewCell cell = this.Rows[rowIndex].Cells[columnIndex];
            if (cell.GetType().Equals(typeof(DataGridViewTextBoxCell)) && cell.Value != null && !cell.Value.ToString().Equals(""))
            {
                ToolStripMenuItem teste = new ToolStripMenuItem();
                string texto = cell.Value.ToString();
                teste.Tag = texto;
                teste.Text = "Copiar Texto '" + (texto.Length > 20 ? texto.Substring(0, 20) + "..." : texto) + "'";
                teste.Image = new Bitmap(@"S:\Sistemas dotNet\Figuras\copy 16x16.png");
                teste.Click += new EventHandler(ToolStripMenuItemCopiar_Click);
                MenuStripOpcoes.Items.Add(teste);
            }

            if (this._mostrarMenuBusca)
            {
                ToolStripMenuItem menuitem = new ToolStripMenuItem();
                menuitem.Text = "Buscar Informações";
                menuitem.Image = new Bitmap(@"S:\Sistemas dotNet\Figuras\pesquisa 16x16.png");
                menuitem.Click += new EventHandler(ToolStripMenuItemBusca_Click);
                MenuStripOpcoes.Items.Add(menuitem);
            }
            if (this._mostrarMenuOrdenacao)
            {
                ToolStripMenuItem menuitem = new ToolStripMenuItem();
                menuitem.Text = "Ordenação";
                menuitem.Image = new Bitmap(@"S:\Sistemas dotNet\Figuras\iToolStripMenu16.png");
                menuitem.Click += new EventHandler(ToolStripMenuItemOrdenacao_Click);
                MenuStripOpcoes.Items.Add(menuitem);
            }
            if (this._mostrarMenuCalcularTotais && ColunasSomatorioAutomatico != null)
            {
                string s = "";
                foreach (string item in ColunasSomatorioAutomatico)
                    s += item;
                if (!s.Trim().Equals(""))
                {
                    ToolStripMenuItem menuitem = new ToolStripMenuItem();
                    menuitem.Text = "Calcular Totais";
                    menuitem.Image = new Bitmap(@"S:\Sistemas dotNet\Figuras\iSomatorio40.png");
                    menuitem.Click += new EventHandler(ToolStripMenuItemCalcularTotais_ToolStripMenuItem);
                    MenuStripOpcoes.Items.Add(menuitem);
                }
            }
            if (this._mostrarMenuExportarExcel)
            {
                ToolStripMenuItem menuitem = new ToolStripMenuItem();
                menuitem.Text = "Exportar para Excel";
                menuitem.Image = new Bitmap(@"S:\Sistemas dotNet\Figuras\iExcelDados22.png");
                menuitem.Click += new EventHandler(ToolStripMenuItemExportarExcel_ToolStripMenuItem);
                MenuStripOpcoes.Items.Add(menuitem);
            }
        }
        public enum MenuAutomatico { BuscarInformacoes, Ordenacao, CalcularTotais, ExportarParaExcel };
        public void DesabilitarMenuAutomatico()
        {
            this._mostrarMenuExportarExcel = false;
            this._mostrarMenuOrdenacao = false;
            this._mostrarMenuBusca = false;
            this._mostrarMenuCalcularTotais = false;
        }
        /// <summary>
        /// Desabilitar o Exportar para Excel para todas as colunas da DataGridView
        /// </summary>
        public void DesabilitarMenuAutomatico(MenuAutomatico menu)
        {
            if (menu == MenuAutomatico.ExportarParaExcel)
            {
                this._mostrarMenuExportarExcel = false;
            }
            else if (menu == MenuAutomatico.Ordenacao)
            {
                this._mostrarMenuOrdenacao = false;
            }
            else if (menu == MenuAutomatico.BuscarInformacoes)
            {
                this._mostrarMenuBusca = false;
            }
            else if (menu == MenuAutomatico.CalcularTotais)
            {
                this._mostrarMenuCalcularTotais = false;
            }
        }
        /// <summary>
        /// Desabilitar o Exportar para Excel apenas para as colunas especificadas via parâmetro, mantendo para as demais. 
        /// Normalmente este overload é útil quando se tem uma coluna Menu, por exemplo, que mostra um menu personalizado do sistema. Assim é possível não mostrar o Exportar para Excel para esta coluna específica e mostrar para a demais.
        /// </summary>
        /// <param name="columnNames">Vetor de strings contendo os nomes das colunas que não devem mostrar o Exportar para Excel</param>
        public void DesabilitarMenuAutomatico(string[] columnNames)
        {
            this._columnNameExcecoesMostrarMenu = columnNames;
        }

        private void ToolStripMenuItemCopiar_Click(object sender, EventArgs e)
        {
            string texto = ((ToolStripMenuItem)(sender)).Tag.ToString();
            Clipboard.SetText(texto);
        }
        private void ToolStripMenuItemBusca_Click(object sender, EventArgs e)
        {
            frmBuscaInformacaoGrid frm = new frmBuscaInformacaoGrid(this);
            frm.ShowDialog();
        }
        private void ToolStripMenuItemOrdenacao_Click(object sender, EventArgs e)
        {
            //frmOrdenacaoGrid frm = new frmOrdenacaoGrid(this);
            //frm.ShowDialog();
        }
        private void ToolStripMenuItemExportarExcel_ToolStripMenuItem(object sender, EventArgs e)
        {
            DataTable dtDados = ((DataTable)this.DataSource).Copy();

            //remove as colunas que não devem aparecer no excel
            if (!this.HabilitarColunasInvisiveisExportarExcel)
            {
                //remove as colunas que estão invisiveis na grid
                foreach (DataGridViewColumn item in this.Columns)
                {
                    if (item.Visible == false && dtDados.Columns.Contains(item.DataPropertyName))
                    {
                        dtDados.Columns.Remove(item.DataPropertyName);
                    }
                }

                //remove as colunas que existem na DataTable cujo nome não está associado a nenhuma coluna da Grid
                List<string> colunasRemover = new List<string>();
                foreach (DataColumn item in dtDados.Columns)
                {
                    bool encontrou = false;
                    foreach (DataGridViewColumn item2 in this.Columns)
                    {
                        if (item2.DataPropertyName.ToUpper().Equals(item.ColumnName.ToUpper()))
                        {
                            encontrou = true;
                            break;
                        }
                    }
                    if (!encontrou)
                    {
                        colunasRemover.Add(item.ColumnName);
                    }
                }
                foreach (string item in colunasRemover)
                {
                    dtDados.Columns.Remove(item);
                }
            }

            //atribui o texto da Header de cada coluna da dgv à respectiva coluna da datatable
            foreach (DataColumn item in dtDados.Columns)
            {
                foreach (DataGridViewColumn item2 in this.Columns)
                {
                    if (item.ColumnName.ToLower().Equals(item2.DataPropertyName.ToLower()) &&
                        !item2.HeaderText.Trim().Equals("") &&
                        !dtDados.Columns.Contains(item2.HeaderText.ToUpper()))
                    {
                        item.ColumnName = item2.HeaderText.ToUpper();
                    }
                }
            }

            ExportaExcel.ExportaParaExcel(dtDados, @"C:\Temp\ExportadoDoSistema_" + Globals.Sysdate.ToString().Replace(" ", "").Replace(":", "").Replace("/", "") + ".xls", true);
        }

        private void ToolStripMenuItemCalcularTotais_ToolStripMenuItem(object sender, EventArgs e)
        {
            if (this.Rows.Count > 0 && this.Parent != null)
            {
                #region Remover os controles possivelmente adicionados anteriormente
                if (!this.Parent.Equals(this.pnlGridContainer))
                    this.Parent.Controls.Add(this.pnlGridContainer);
                while (this.pnlGridContainer.Controls.Count > 0)
                {
                    foreach (Control item in this.pnlGridContainer.Controls)
                    {
                        this.pnlGridContainer.Controls.Remove(item);
                    }
                }
                #endregion

                HScrollBar hScrollBar = this.Controls.OfType<HScrollBar>().First();
                if (hScrollBar.Visible)
                {
                    hScrollBar.Scroll += new ScrollEventHandler(hScrollBar_Scroll);
                }

                #region Calcular totais
                Panel pnlConteudo = new Panel();
                pnlConteudo.BorderStyle = BorderStyle.FixedSingle;
                pnlConteudo.Size = new Size(this.Width, 56);

                List<string> colunasNumericas = new List<string>();
                List<string> colunasTempo = new List<string>();
                foreach (DataGridViewRow row in this.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            int m;
                            double n;

                            for (int i = 0; i < this.ColunasSomatorioAutomatico.Length; i++)
                                this.ColunasSomatorioAutomatico[i] = this.ColunasSomatorioAutomatico[i].ToLower();

                            //Verificar se a coluna contém números
                            if (double.TryParse(cell.Value.ToString(), out n) && this.ColunasSomatorioAutomatico.Contains(cell.OwningColumn.Name.ToLower()))
                                colunasNumericas.Add(cell.OwningColumn.Name);

                            //Verificar se a coluna é do tipo duração de tempo. Ex: 01:45 (1 hora e 45 minutos), 41:12 (41 horas e 12 minutos)
                            string[] valores = cell.Value.ToString().Split(':');
                            if (valores.Length == 2 && this.ColunasSomatorioAutomatico.Contains(cell.OwningColumn.Name.ToLower()))
                            {
                                bool ok = true;
                                foreach (string v in valores)
                                {
                                    ok = int.TryParse(v, out m);

                                    if (!ok)
                                        break;
                                }

                                if (ok)
                                {
                                    colunasTempo.Add(cell.OwningColumn.Name);
                                }
                            }
                        }
                    }
                }

                colunasNumericas = colunasNumericas.Distinct().ToList();
                colunasTempo = colunasTempo.Distinct().ToList();

                double[] totaisNumericos = new double[colunasNumericas.Count];
                string[] totaisTempo = new string[colunasTempo.Count];

                foreach (DataGridViewRow row in this.Rows)
                {
                    for (int i = 0; i < colunasTempo.Count; i++)
                    {
                        string[] valores = row.Cells[colunasTempo[i]].Value.ToString().Split(':');
                        int horas = int.Parse(valores[0]);
                        int minutos = int.Parse(valores[1]);

                        DateTime dt1 = Globals.Sysdate;
                        DateTime dt2 = Globals.Sysdate;
                        dt1 = dt1.AddHours(horas);
                        dt1 = dt1.AddMinutes(minutos);

                        TimeSpan ts = dt1 - dt2;
                        if (totaisTempo[i] == null)
                            totaisTempo[i] = ts.ToString();
                        else
                            totaisTempo[i] = (TimeSpan.Parse(totaisTempo[i]) + ts).ToString();

                        string s = ts.ToString();
                    }

                    for (int i = 0; i < colunasNumericas.Count; i++)
                    {
                        double valor;
                        bool b = double.TryParse(row.Cells[colunasNumericas[i]].Value.ToString(), out valor);
                        totaisNumericos[i] += valor;
                    }
                }

                for (int i = 0; i < totaisTempo.Length; i++)
                {
                    TimeSpan ts = TimeSpan.Parse(totaisTempo[i]);
                    totaisTempo[i] = Math.Floor(ts.TotalHours).ToString().PadLeft(2, '0') + ":" + ts.Minutes.ToString().PadLeft(2, '0');
                }
                #endregion

                #region Criar o painel com a mensagem e o botão de fechar
                Panel pnlMsg = new Panel();
                pnlMsg.BorderStyle = BorderStyle.None;
                pnlMsg.Height = 15;
                pnlMsg.Dock = DockStyle.Top;
                pnlMsg.BackColor = this.ColumnHeadersDefaultCellStyle.BackColor;
                LabelWelic lblMsg = new LabelWelic();
                lblMsg.Text = "SOMATÓRIO";
                lblMsg.Dock = DockStyle.Fill;
                lblMsg.TextAlign = ContentAlignment.MiddleCenter;
                LabelWelic lblFecharPainelSomatorio = new LabelWelic();
                lblFecharPainelSomatorio.Margin = new Padding(0, 0, 0, 0);
                lblFecharPainelSomatorio.Padding = new Padding(0, 0, 0, 0);
                lblFecharPainelSomatorio.Text = "x";
                lblFecharPainelSomatorio.Size = new System.Drawing.Size(15, 15);
                lblFecharPainelSomatorio.Dock = DockStyle.Right;
                lblFecharPainelSomatorio.Cursor = Cursors.Hand;
                lblFecharPainelSomatorio.Click += new EventHandler(lblFecharPainelSomatorio_Click);
                pnlMsg.Controls.Add(lblFecharPainelSomatorio);
                pnlMsg.Controls.Add(lblMsg);
                lblMsg.BringToFront();
                pnlConteudo.Controls.Add(pnlMsg);
                #endregion

                #region Criar grid com os totais
                dgvTotais = new DataGridViewWelic();
                DataGridViewRow rowTotais = new DataGridViewRow();

                foreach (DataGridViewColumn dgvc in this.Columns)
                {
                    DataGridViewColumn clone = (DataGridViewColumn)dgvc.Clone();
                    dgvTotais.Columns.Add(clone);
                }

                int qtd = rowTotais.Cells.Count;

                DataGridViewRow row3 = this.Rows[0];
                DataGridViewRow clonedRow = (DataGridViewRow)this.Rows[0].Clone();

                for (Int32 index = 0; index < row3.Cells.Count; index++)
                {
                    string nomeColuna = row3.Cells[index].OwningColumn.Name;
                    object valor = null;

                    if (colunasNumericas.Contains(nomeColuna))
                    {
                        valor = totaisNumericos[colunasNumericas.IndexOf(row3.Cells[index].OwningColumn.Name)];
                    }
                    else if (colunasTempo.Contains(nomeColuna))
                    {
                        valor = totaisTempo[colunasTempo.IndexOf(row3.Cells[index].OwningColumn.Name)];
                    }
                    else if (this.ColunasTotaisCalculados.Count > 0 && this.ColunasTotaisCalculados[0].Contains(nomeColuna))
                    {
                        valor = this.ColunasTotaisCalculados[1][this.ColunasTotaisCalculados[0].ToList().IndexOf(nomeColuna)];
                    }

                    clonedRow.Cells[index].Value = valor;
                }

                clonedRow.DefaultCellStyle.SelectionBackColor = Color.White;
                clonedRow.DefaultCellStyle.BackColor = Color.White;

                dgvTotais.Rows.Add(clonedRow);
                #region Limpar conteudo das headers e células não utilizadas
                foreach (DataGridViewCell cell in dgvTotais.Rows[0].Cells)
                {
                    if (cell.Value == null || !cell.GetType().Equals(typeof(DataGridViewTextBoxCell)))
                    {
                        cell.OwningColumn.HeaderText = "";
                        cell.Value = null;

                        if (cell.GetType().Equals(typeof(DataGridViewImageCell)))
                        {
                            ((DataGridViewImageCell)cell).Value = new Bitmap(1, 1);
                        }
                        else if (cell.GetType().Equals(typeof(DataGridViewCheckBoxCell)))
                        {
                            //esconde a caixinha fora dos limites da célula
                            ((DataGridViewCheckBoxCell)cell).Style.Padding = new Padding(99999);
                        }
                    }
                }
                #endregion

                pnlConteudo.Controls.Add(dgvTotais);
                dgvTotais.Dock = DockStyle.Fill;
                dgvTotais.RowHeadersVisible = this.RowHeadersVisible;
                dgvTotais.AllowUserToAddRows = false;
                dgvTotais.AllowUserToDeleteRows = false;
                dgvTotais.AllowUserToOrderColumns = false;
                dgvTotais.AllowUserToResizeColumns = false;
                dgvTotais.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvTotais.DefaultCellStyle.SelectionBackColor = Color.White;
                dgvTotais.DefaultCellStyle.BackColor = Color.White;
                dgvTotais.AllowUserToResizeRows = false;
                dgvTotais.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgvTotais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvTotais.ColumnHeadersHeight = 17;
                dgvTotais.ScrollBars = ScrollBars.None;
                dgvTotais.BorderStyle = BorderStyle.None;
                dgvTotais.Rows[0].DefaultCellStyle.Font = new Font(dgvTotais.Font, FontStyle.Regular);
                dgvTotais.Rows[0].Height = 22;
                dgvTotais.DesabilitarMenuAutomatico();
                dgvTotais.BringToFront();
                AjustarLarguraColunasGridTotais();
                #endregion

                if (bkpDockStyleGrid == null)
                    bkpDockStyleGrid = this.Dock;

                if (bkpLocationGrid == null)
                    bkpLocationGrid = this.Location;

                foreach (DataGridViewColumn item in dgvTotais.Columns)
                {
                    item.DisplayIndex = this.Columns[item.Name].DisplayIndex;
                }

                this.pnlGridContainer.Location = (Point)bkpLocationGrid;
                this.pnlGridContainer.Dock = (DockStyle)bkpDockStyleGrid;

                this.pnlGridContainer.BorderStyle = BorderStyle.None;

                int height = (this.Height < this.pnlGridContainer.Height ? this.pnlGridContainer.Height : this.Height);
                this.pnlGridContainer.Size = new System.Drawing.Size(this.Width, height);

                this.pnlGridContainer.Controls.Add(this);
                this.pnlGridContainer.BringToFront();

                pnlConteudo.Dock = DockStyle.Bottom;
                this.Dock = DockStyle.Fill;
                this.pnlGridContainer.Controls.Add(pnlConteudo);
                pnlConteudo.BringToFront();
                this.BringToFront();
            }
            else
            {
                lblFecharPainelSomatorio_Click(null, null);
            }
        }

        void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (dgvTotais != null)
                dgvTotais.HorizontalScrollingOffset = this.HorizontalScrollingOffset;
        }
        private void lblFecharPainelSomatorio_Click(object sender, EventArgs e)
        {
            while (this.pnlGridContainer.Controls.Count > 1)
            {
                foreach (Control item in this.pnlGridContainer.Controls)
                {
                    if (!item.GetType().Equals(this.GetType()))
                        this.pnlGridContainer.Controls.Remove(item);
                }
            }

            dgvTotais = null;
            bkpDockStyleGrid = null;
            bkpLocationGrid = null;
        }
        private void AjustarLarguraColunasGridTotais()
        {
            if (dgvTotais != null)
            {
                if (this.Columns.Count == dgvTotais.Columns.Count ||
                    (this.Controls.OfType<VScrollBar>().First().Visible && this.Columns.Count == dgvTotais.Columns.Count - 1))
                {
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        dgvTotais.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvTotais.Columns[i].Width = this.Columns[i].Width;
                    }
                }
            }
        }

        public void HabilitarCalculoTotaisAutomaticos(string[] colunas)
        {
            HabilitarCalculoTotaisAutomaticos(colunas, false);
        }
        public void HabilitarCalculoTotaisAutomaticos(string[] colunas, bool executarAutomaticamente)
        {
            this.ColunasSomatorioAutomatico = colunas;
            this.ExibirPainelTotaisAutomaticamente = executarAutomaticamente;

            if (executarAutomaticamente)
            {
                ToolStripMenuItemCalcularTotais_ToolStripMenuItem(null, null);
            }
        }
        #endregion
        #region Métodos referentes aos eventos de colorir a grid automaticamente - JUNIOR CARVALHO BROLINI
        /// <summary>
        /// Método para criar os eventos CellMouseEnter, CellMouseLeave e CellMouseMove.
        /// CellMouseEnter e CellMouseLeave servem para pintar a celular conforme o mouse passar por cima das mesmas. 
        /// A ideia é para as grids que possuem colunas do tipo Ver, Editar, Excluir, etc, que mudam de cor quando o usuario passa o mouse por cima da mesma.
        /// O evento CellMouseMove serve para mudar o cursor do mouse para Hand quando ele entrar na celula e voltar para Default quando ele sair.
        /// </summary>
        /// <param name="colunas">Vetor de string contendo os nomes das colunas que serao modificadas</param>
        /// <param name="backColors">Vetor de Color contendo as cores da célula que serão aplicadas nas colunas na posição correspondente</param>
        /// <param name="colunaCorPadrao">OPCIONAL: quando informado, o método adota as cores dessa coluna como padrão para quando o evento Leave ocorrer (útil quando existem rows coloridas manualmente). Caso contrário, o a BackColor e SelectionBackColor será o padrão da DataGridViewWelic</param>
        public void CriarEventosColorirAutomaticamente(string[] colunas, Color[] backColors, string colunaCorPadrao = null)
        {
            this._colunasEventosColorirGridAutomaticamente = colunas;
            this._backColorsEventosColorirGridAutomaticamente = backColors;
            this._colunaCorPadrao = colunaCorPadrao;

            this._aplicarEventosColorirGridAutomaticamente = true;
        }
        public void EscreverSobreImagem(string nomeColunaImagem, string nomeColunaTexto, int x = 0, int y = 11)
        {
            foreach (DataGridViewRow item in this.Rows)
            {
                //Load the Image to be written on.
                Bitmap bitMapImage = new Bitmap((Image)(item.Cells[nomeColunaImagem].Value));
                Graphics graphicImage = Graphics.FromImage(bitMapImage);

                //Smooth graphics is nice.
                graphicImage.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //Write your text.
                graphicImage.DrawString(item.Cells[nomeColunaTexto].Value.ToString().Trim(), new Font("Arial", 7, FontStyle.Bold), SystemBrushes.WindowText, x, y);

                graphicImage.Save();

                item.Cells[nomeColunaImagem].Value = bitMapImage;
            }

            this.RefreshEdit();
        }
        #endregion


        public void AdicionarColunasCadastro(string nomeColunaVer = "colImgVer", string nomeColunaEditar = "colImgEditar", string nomeColunaExcluir = "colImgExcluir")
        {
            if (!this.Columns.Contains(nomeColunaVer) && !this.Columns.Contains(nomeColunaEditar) && !this.Columns.Contains(nomeColunaExcluir))
            {
                #region Criar Colunas
                DataGridViewImageColumn colImgVer = new System.Windows.Forms.DataGridViewImageColumn();
                DataGridViewImageColumn colImgEditar = new System.Windows.Forms.DataGridViewImageColumn();
                DataGridViewImageColumn colImgExcluir = new System.Windows.Forms.DataGridViewImageColumn();

                this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colImgVer,
                colImgEditar,
                colImgExcluir});

                // 
                // colImgVer
                // 
                colImgVer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
                colImgVer.HeaderText = "Ver";
                colImgVer.Image = new Bitmap(@"S:\Sistemas dotNet\Figuras\iVisualizarFormulario16.png");
                colImgVer.Name = nomeColunaVer;
                colImgVer.Width = 34;
                // 
                // colImgEditar
                // 
                colImgEditar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
                colImgEditar.HeaderText = "Editar";
                colImgEditar.Image = new Bitmap(@"S:\Sistemas dotNet\Figuras\iEditar22.png");
                colImgEditar.Name = nomeColunaEditar;
                colImgEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                colImgEditar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                colImgEditar.Width = 52;
                // 
                // colImgExcluir
                // 
                colImgExcluir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
                colImgExcluir.HeaderText = "Excluir";
                colImgExcluir.Image = new Bitmap(@"S:\Sistemas dotNet\Figuras\button_cancel16.png");
                colImgExcluir.Name = nomeColunaExcluir;
                colImgExcluir.Width = 57;
                #endregion

                #region Colorir Colunas Automaticamente
                List<string> colunas;
                if (this._colunasEventosColorirGridAutomaticamente != null)
                    colunas = this._colunasEventosColorirGridAutomaticamente.ToList();
                else
                    colunas = new List<string>();

                List<Color> cores;
                if (this._backColorsEventosColorirGridAutomaticamente != null)
                    cores = this._backColorsEventosColorirGridAutomaticamente.ToList();
                else
                    cores = new List<Color>();

                foreach (DataGridViewColumn item in this.Columns)
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
                }
                this.CriarEventosColorirAutomaticamente(colunas.ToArray(), cores.ToArray(), this.Columns[0].Name);
                #endregion
            }
        }

        public void VincularLabelContagemItensGrid(LabelWelic lbl)
        {
            this.lblContagemItensGrid = lbl;
        }
        private void atualizarContagemItensGrid()
        {
            if (lblContagemItensGrid != null)
            {
                if (this.Rows.Count > 0)
                {
                    this.lblContagemItensGrid.Visible = true;
                    if (this.Rows.Count == 1)
                        this.lblContagemItensGrid.Text = "Total: 01 item";
                    else if ((this.Rows.Count > 1) && (this.Rows.Count < 10))
                        this.lblContagemItensGrid.Text = "Total: 0" + this.Rows.Count.ToString() + " itens";
                    else if ((this.Rows.Count >= 10))
                        this.lblContagemItensGrid.Text = "Total: " + this.Rows.Count.ToString() + " itens";
                }
                else
                {
                    this.lblContagemItensGrid.Visible = false;
                    this.lblContagemItensGrid.Text = "";
                }
            }

            if (this.Rows.Count == 0)
            {
                ToolStripMenuItemCalcularTotais_ToolStripMenuItem(null, null);
                //lblFecharPainelSomatorio_Click
            }
        }

        public void AdicionarHeaderColunaCheckBox(string columnName)
        {
            DataGridViewCheckBoxColumn colCB = (DataGridViewCheckBoxColumn)this.Columns[columnName];

            //só executa quando a header ainda não for uma DatagridViewCheckBoxHeaderCell
            if (!colCB.HeaderCell.GetType().Equals(typeof(DatagridViewCheckBoxHeaderCell)))
            {
                string s = colCB.HeaderText;
                DatagridViewCheckBoxHeaderCell cbHeader = new DatagridViewCheckBoxHeaderCell();
                colCB.HeaderCell = cbHeader;
                colCB.HeaderText = "    " + s;
                colCB.Resizable = DataGridViewTriState.False;
                cbHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            }
        }

        public void DesmarcarCheckHeader(string nomeColuna)
        {
            ((DatagridViewCheckBoxHeaderCell)this.Columns[nomeColuna].HeaderCell).SetChecked(false);
        }

        DataGridViewAutoSizeColumnsMode bkpAutoSizeColumnsMode;
        private void cbHeader_OnCheckBoxClicked(int columnIndex, bool state)
        {
            bkpAutoSizeColumnsMode = this.AutoSizeColumnsMode;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            if (this.Columns[columnIndex].ReadOnly)
            {
                ((DatagridViewCheckBoxHeaderCell)this.Columns[columnIndex].HeaderCell).SetChecked(false);
            }

            for (int i = 0; i < this.Rows.Count; i++)
            {
                if (!this.Rows[i].Cells[columnIndex].ReadOnly)
                {
                    this.Rows[i].Cells[columnIndex].Value = state;
                }
            }

            this.EndEdit();
            this.AutoSizeColumnsMode = bkpAutoSizeColumnsMode;
        }

        public void SetTipoOrdenacao(DataGridViewColumnSortMode tipoOrdenacao = DataGridViewColumnSortMode.NotSortable)
        {
            foreach (DataGridViewColumn coluna in this.Columns)
                coluna.SortMode = tipoOrdenacao;
        }

        #region Funcionalidade de mesclar células da grid - MURILO ROCHA
        private string[] ColunasMesclar { get; set; }

        public void HabilitaMesclarColunas(string[] colunasMesclar)
        {
            if (colunasMesclar.Count() > 0)
            {
                this.ColunasMesclar = colunasMesclar;

                this.CellPainting += new DataGridViewCellPaintingEventHandler(dgvCellPainting);
                this.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvCellFormatting);
            }
        }
        private void dgvCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (this.ColunasMesclar.Contains(this.Columns[e.ColumnIndex].Name))
                {
                    if (e.RowIndex == this.Rows.Count - 1)
                        e.AdvancedBorderStyle.Bottom = this.AdvancedCellBorderStyle.Bottom;
                    else
                        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                    if (e.RowIndex < 1 || e.ColumnIndex < 0)
                        return;
                    if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                    {
                        e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                    }
                    else
                    {
                        e.AdvancedBorderStyle.Top = this.AdvancedCellBorderStyle.Top;
                    }
                }
            }
        }
        private void dgvCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (this.ColunasMesclar.Contains(this.Columns[e.ColumnIndex].Name))
                {
                    if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                    {
                        e.Value = "";
                        e.FormattingApplied = true;
                    }
                }
            }
        }
        bool IsTheSameCellValue(int column, int row)
        {
            try
            {
                if (row > 0 && (this[column, row] is DataGridViewTextBoxCell))
                {
                    DataGridViewCell cell1 = this[column, row];
                    DataGridViewCell cell2 = this[column, row - 1];
                    if (cell1.Value == null || cell2.Value == null)
                    {
                        return false;
                    }
                    return cell1.Value.ToString() == cell2.Value.ToString();
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion
    }
    #endregion

    #region Classes CheckBoxHeaderCell
    public delegate void CheckBoxClickedHandler(int columnIndex, bool state);
    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        bool _bChecked;
        public DataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
        {
            _bChecked = bChecked;
        }
        public bool Checked
        {
            get { return _bChecked; }
        }
    }
    public partial class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        public event CheckBoxClickedHandler OnCheckBoxClicked;

        public DatagridViewCheckBoxHeaderCell()
        {
        }

        public bool IsChecked()
        {
            return _checked;
        }
        public void SetChecked(bool state)
        {
            //o Paint vai cuidar de definir o estado do chk de acordo com a prop _checked
            _checked = state;

            if (_checked != state)
            {
                foreach (DataGridViewRow item in this.DataGridView.Rows)
                {
                    if (!item.Cells[this.ColumnIndex].ReadOnly)
                    {
                        item.Cells[this.ColumnIndex].Value = state;
                    }
                }
            }
        }

        protected override void Paint(System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                dataGridViewElementState, value,
                formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);

            //original (centralizado):
            //p.X = cellBounds.Location.X +
            //    (cellBounds.Width / 2) - (s.Width / 2);

            //alterado para ficar à esquerda da header
            p.X = cellBounds.Location.X + (s.Width / 2) - 3;

            p.Y = cellBounds.Location.Y +
                (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(e.ColumnIndex, _checked);
                    this.DataGridView.InvalidateCell(this);
                }

            }
            base.OnMouseClick(e);
        }
    }
    #endregion
}