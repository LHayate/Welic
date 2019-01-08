using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.ClientApi;

namespace UseFul.Forms.Welic
{
    //TODO: Revisão Geral 
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iTextbox.ico")]
    public partial class TextBoxWelic : TextBox
    {
        /// <summary>
        /// ToolTip para exibir informações presentes no comentário da coluna correspondente no banco de dados.
        /// Para este recurso funcionar corretamente é necessário que as propriedades InformacaoToolTipCaminho e InformacaoToolTipDescricao estejam preenchidas corretamente.
        /// </summary>
        private ToolTip toolTipInformacao = new ToolTip();
        /// <summary>
        /// Nome do esquema, tabela e coluna no formato ESQUEMA.TABELA.COLUNA
        /// Exemplo: SGA.ALUNOS.NOME
        /// OBS: deixe em branco para não mostrar nada.
        /// </summary>
        private string _InformacaoToolTipCaminho;
        public string InformacaoToolTipCaminho
        {
            get { return _InformacaoToolTipCaminho; }
            set
            { _InformacaoToolTipCaminho = value; }
        }

        /// <summary>
        /// Texto a ser exibido no ToolTip de Informação (comentário do campo descrito na propriedade InformacaoToolTipCaminho)
        /// </summary>
        private string _InformacaoToolTipDescricao;
        public string InformacaoToolTipDescricao
        {
            get { return _InformacaoToolTipDescricao; }
            set
            { _InformacaoToolTipDescricao = value; }
        }

        /// <summary>
        /// Nome da coluna no DataTable, utilizado pelo método PreencherCampos(ControlCollection controls, DataTable dtDados)
        /// </summary>
        private string _NomeCampoDadosDataTable;
        public string NomeCampoDadosDataTable
        {
            get { return _NomeCampoDadosDataTable; }
            set
            { _NomeCampoDadosDataTable = value; }
        }

        /// <summary>
        /// PARA EFEITO DOS RECURSOS GENÉRICOS: Quando informada, esta SQL substituirá a SQL padrão do componente para o evento F3
        /// </summary>
        private object RecursosGenericosSqlF3;
        public object _RecursosGenericosSqlF3
        {
            get { return RecursosGenericosSqlF3; }
            set { RecursosGenericosSqlF3 = value; }
        }

        /// <summary>
        /// PARA EFEITO DOS RECURSOS GENÉRICOS: Quando informada, esta SQL substituirá a SQL padrão do componente para o evento Leave
        /// </summary>
        private object RecursosGenericosSqlLeave;
        public object _RecursosGenericosSqlLeave
        {
            get { return RecursosGenericosSqlLeave; }
            set { RecursosGenericosSqlLeave = value; }
        }

        public TextBoxWelic()
        {
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            if (base.ReadOnly)
                base.BackColor = Color.FromArgb(231, 231, 231);
            base.ShortcutsEnabled = true;
        }
        public enum CTipoValor { Geral = 1, Numerico = 2, Decimal = 3, Monetario = 4 };
        private CTipoValor _tipoValor = CTipoValor.Geral;
        public CTipoValor TipoValor
        {
            get { return _tipoValor; }
            set
            {
                _tipoValor = value;
                if (CTipoValor.Decimal == TipoValor)
                {
                    base.TextAlign = HorizontalAlignment.Right;
                    base.MaxLength = ParteInteira + ParteDecimal + 1;
                }
            }
        }

        public enum CTipoCampo { Normal, Chave, ChaveAutoIncremento, Obrigatorio };
        private CTipoCampo _tipoCampo = CTipoCampo.Normal;
        public CTipoCampo TipoCampo
        {
            get { return _tipoCampo; }
            set
            {
                _tipoCampo = value;
                if (!base.ReadOnly)
                {
                    if (_tipoCampo != CTipoCampo.Normal)
                        base.BackColor = Color.FromArgb(221, 236, 255);
                    else
                        base.BackColor = Color.White;
                }
                else
                    base.BackColor = Color.FromArgb(231, 231, 231);
            }
        }

        //Parte Inteira quando for decimal
        private int _LengthParteInteira;
        public int ParteInteira
        {
            get { return _LengthParteInteira; }
            set
            { _LengthParteInteira = value; }
        }

        //Quantidade de Casas Decimais quando o campo for Decimal
        private int _LengthParteDecimal;
        public int ParteDecimal
        {
            get { return _LengthParteDecimal; }
            set { _LengthParteDecimal = value; }
        }

        private bool _limpaCampo = true;
        public bool LimpaCampo
        {
            get { return _limpaCampo; }
            set { _limpaCampo = value; }
        }

        // Exibir icone de Pesquisa do campo
        private bool _ExibirIconePesquisa;
        public bool ExibirIconePesquisa
        {
            get
            {
                return _ExibirIconePesquisa;
            }
            set
            {
                _ExibirIconePesquisa = value;
                // executa o AtualizarIconeLupa no set para exibir/remover o icone no Design ainda no visual studio ou caso a propriedade seja alterada em tempo de execução
                this.AtualizarIconeLupa();
            }
        }

        // Ativa segurança por centro de Custo 
        public enum CSegurancaCentroCusto { NaoUtilizado = 0 , Matricula = 1, CPF = 2};
        public CSegurancaCentroCusto _segurancaCentroCusto = CSegurancaCentroCusto.NaoUtilizado;
        public CSegurancaCentroCusto SegurancaCCusto
        {
            get { return _segurancaCentroCusto ; }
            set { _segurancaCentroCusto = value;}
        }

        private PictureBox pb;
        private void AtualizarIconeLupa()
        {
            if (this._ExibirIconePesquisa && this.pb == null)
            {
                this.pb = new PictureBox();
                this.pb.Size = new Size(16, this.ClientSize.Height + 2);
                this.pb.Cursor = Cursors.Hand;
                this.pb.Image =  null;//TODO: SOlucionar imagem Icon de Busca
                this.pb.Click += pb_Click;
            }

            if (this._ExibirIconePesquisa && !this.Controls.Contains(pb))
            {
                this.Controls.Add(pb);
                this.TextAlign = HorizontalAlignment.Left;
                // Utilizado para que o texto digitado não fique atrás do ícone
                SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(this.pb.Width << 16));
            }

            if (this._ExibirIconePesquisa)
                this.pb.Dock = DockStyle.Right;//this.pb.Location = new Point(this.ClientSize.Width - this.pb.Width + 2, -1);
            else if (!this._ExibirIconePesquisa && this.Controls.Contains(pb))
                this.Controls.Remove(pb);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void pb_Click(object sender, EventArgs e)
        {
            this.Focus();

            //verifica se está focado após o Focus() para prever caso a validação de outro campo impeça o Focus().
            if (this.Focused && !this.ReadOnly)
                SendKeys.Send("{F3}");
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this._ExibirIconePesquisa)
                // Utilizado para que o texto digitado não fique atrás do ícone
                SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(this.pb.Width << 16));
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);

            if (this._ExibirIconePesquisa)
                // Utilizado para que o texto digitado não fique atrás do ícone
                SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(this.pb.Width << 16));
        }
        protected override void OnTextAlignChanged(EventArgs e)
        {
            base.OnTextAlignChanged(e);

            if (this._ExibirIconePesquisa)
            {
                this.TextAlign = HorizontalAlignment.Left;
                // Utilizado para que o texto digitado não fique atrás do ícone
                SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(this.pb.Width << 16));
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!base.ReadOnly)
                base.BackColor = Color.LemonChiffon;
            else
                base.BackColor = Color.FromArgb(231, 231, 231);

            base.ShortcutsEnabled = true;
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.InformacaoToolTipCaminho != null && this.InformacaoToolTipDescricao != null)
            {
                if (!string.IsNullOrEmpty(this.InformacaoToolTipCaminho.Trim()) &&
                    !string.IsNullOrEmpty(this.InformacaoToolTipDescricao.Trim()))
                {
                    toolTipInformacao.ToolTipIcon = ToolTipIcon.None;
                    toolTipInformacao.IsBalloon = false;
                    toolTipInformacao.UseAnimation = true;
                    toolTipInformacao.UseFading = true;
                    toolTipInformacao.ToolTipTitle = string.Empty;
                    toolTipInformacao.Show(this.InformacaoToolTipDescricao, this, this.Size.Width, this.Size.Height);
                }
            }

            if (CTipoValor.Monetario == TipoValor)
            {
                this.Text = this.Text.Replace("R", "").Replace("$", "").Replace(".", "").Replace(" ", "");
            }
        }
        protected override void OnLeave(EventArgs e)
        {
            //TODO: Revisar Mais tarde
//            if (CSegurancaCentroCusto.Matricula == SegurancaCCusto)
//            {
//                Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
//                dal.AddParam("usuario", this.Text);
//                StringBuilder sql = new StringBuilder();
//                sql.Append(@"SELECT * 
//FROM 
// (
//            SELECT CASE WHEN FUN.USU_CCUSTO BETWEEN UCPC.CENTRO_CUSTO_INICIAL AND UCPC.CENTRO_CUSTO_FINAL THEN 'TRUE' ELSE 'FALSE' END VALIDACAO
//              FROM BHORA.R034FUN                       FUN 
//              JOIN BHORA.USUARIOS_CENTROS_PERMISSOES   UCP  ON (1 = 1)
//              JOIN BHORA.FORM_PESSOAL_USUARIOS_CENTROS UCPC ON (UCP.USUARIO = UCPC.USUARIO)
//              WHERE FUN.NUMCAD = &usuario AND UCP.USUARIO = USER AND UCP.TIPO_PERMISSAO = 7
// ) V
//WHERE V.VALIDACAO IS NOT NULL ");
//                bool val = false;
//                DataTable dt = dal.ExecuteQuery(sql.ToString());

//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (!bool.Parse(dt.Rows[i]["VALIDACAO"].ToString()))
//                    {
//                        val = true;
//                    }
//                    else
//                    {
//                        val = false;
//                        break;
//                    }
//                }

//                if (dt.Rows.Count > 0 && val)
//                {
//                    MessageBox.Show("Você não tem permissão no Centro de Custo deste colaborador.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    this.Focus();
//                    return;
//                }
//            }
//            else if (CSegurancaCentroCusto.CPF == SegurancaCCusto)
//            {
//                Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
//                dal.AddParam("CPF", this.Text);
//                StringBuilder sql = new StringBuilder();
//                sql.Append(@"
//                SELECT * FROM 
//(
//SELECT     (
//            SELECT 'FALSE' 
//              FROM BHORA.R034FUN                       FUN 
//              JOIN BHORA.USUARIOS_CENTROS_PERMISSOES   UCP  ON (1 = 1)
//              JOIN BHORA.FORM_PESSOAL_USUARIOS_CENTROS UCPC ON (UCP.USUARIO = UCPC.USUARIO)
//              WHERE FUN.USU_CCUSTO NOT BETWEEN UCPC.CENTRO_CUSTO_INICIAL AND UCPC.CENTRO_CUSTO_FINAL
//                    AND FUN.NUMCPF = &CPF AND UCP.USUARIO = USER AND UCP.TIPO_PERMISSAO = 7
//            ) VALIDACAO
//FROM DUAL   
//) V
//WHERE V.VALIDACAO IS NOT NULL");

//                DataTable dt = dal.ExecuteQuery(sql.ToString());
//                if (dt.Rows.Count > 0 && !bool.Parse(dt.Rows[0]["VALIDACAO"].ToString()))
//                {
//                    MessageBox.Show("Você não tem permissão no Centro de Custo deste colaborador.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    this.Focus();
//                    return;
//                }
//            }

            base.OnLeave(e);
            if (!base.ReadOnly)
            {
                if (_tipoCampo != CTipoCampo.Normal)
                    base.BackColor = Color.FromArgb(221, 236, 255);
                else
                    base.BackColor = Color.White;
            }
            else
                base.BackColor = Color.FromArgb(231, 231, 231);

            if (IsFormClosing() == true)
                return;

            if (CTipoValor.Decimal == TipoValor)
            {
                if (this.Text.IndexOf(',') >= 0)
                {
                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        int dec = this.Text.Substring(this.Text.IndexOf(",")).Length;
                        int index = dec - 1;
                        while (index < ParteDecimal)
                        {
                            this.Text = this.Text + "0";
                            index++;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        string c = string.Empty;
                        this.Text = this.Text + "," + c.PadRight(ParteDecimal, '0');
                    }
                }
            }
            else if (CTipoValor.Monetario == TipoValor)
            {
                this.Text = this.Text.Replace("R", "").Replace("$", "").Replace(" ", "");

                if (!this.Text.Trim().Equals("") &&
                    !this.Text.Contains("R$"))
                    this.Text = double.Parse(this.Text).ToString("C2");
            }

            //Esconde o ToolTip
            if (this.InformacaoToolTipCaminho != null && this.InformacaoToolTipDescricao != null)
            {
                if (!string.IsNullOrEmpty(this.InformacaoToolTipCaminho.Trim()) &&
                    !string.IsNullOrEmpty(this.InformacaoToolTipDescricao.Trim()))
                {
                    toolTipInformacao.Hide(this);
                }
            }

            
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (CTipoValor.Numerico == TipoValor)
            {
                if (!((Convert.ToInt32(e.KeyChar) > 47 && Convert.ToInt32(e.KeyChar) < 58) ||
                    (Convert.ToInt32(e.KeyChar) == 13) ||
                    (Convert.ToInt32(e.KeyChar) == 8) ||
                    ((Char.IsControl(e.KeyChar) && e.KeyChar != ((char)Keys.V | (char)Keys.ControlKey))
                    || (Char.IsControl(e.KeyChar) && e.KeyChar != ((char)Keys.C | (char)Keys.ControlKey))
                    || (Char.IsControl(e.KeyChar) && e.KeyChar != ((char)Keys.X | (char)Keys.ControlKey))
                    || (Char.IsControl(e.KeyChar) && e.KeyChar != ((char)Keys.Z | (char)Keys.ControlKey)))))
                    e.Handled = true;
            }
            if (CTipoValor.Decimal == TipoValor || CTipoValor.Monetario == TipoValor)
            {
                if (e.KeyChar == ',')
                {
                    Char[] cs = Array.FindAll<Char>(base.Text.ToCharArray(), new Predicate<Char>(delegate(Char c) { return c.Equals(','); }));
                    // Se já tem uma virgula...
                    if (cs.Length > 0)
                        e.Handled = true;

                    if (string.IsNullOrEmpty(base.Text))
                        e.Handled = true;
                }
                else
                    VerificaDecimal(e, ParteInteira, ParteDecimal);
                return;
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            int MaxLength = base.MaxLength;
            //if (base.Text.Length == MaxLength)
            //SendKeys.Send("{TAB}");  //Código comentado por mim (Ademar), pois além de estar dando tab no TexBox estava executando no DataGridViewer mudando as colunas selecionadas.

            if (CTipoValor.Numerico == TipoValor)
            {
                string texto = "";
                var Digitos = "0123456789";
                foreach (char l in base.Text)
                {
                    if (Digitos.IndexOf(l) >= 0)
                    {
                        texto += l;
                    }
                }
                base.Text = texto;
            }
            else if (CTipoValor.Monetario == TipoValor && !this.Focused)
            {
                if (!this.Text.Contains("R$"))
                    OnLeave(e);
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            ExecutaTabPressionaEnter(e);
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (!base.ReadOnly)
            {
                if (base.Enabled == false)
                    base.BackColor = Color.FromArgb(231, 231, 231);
                else
                {
                    if (_tipoCampo != CTipoCampo.Normal)
                        base.BackColor = Color.FromArgb(221, 236, 255);
                    else
                        base.BackColor = Color.White;
                }
            }
            else
                base.BackColor = Color.FromArgb(231, 231, 231);
        }
        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);
            if (base.ReadOnly)
                base.BackColor = Color.FromArgb(231, 231, 231);
            else
            {
                if (_tipoCampo != CTipoCampo.Normal)
                    base.BackColor = Color.FromArgb(221, 236, 255);
                else
                    base.BackColor = Color.White;
            }
        }

        protected void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TextBoxWelic
            // 
            this.ResumeLayout(false);
        }

        private void ExecutaTabPressionaEnter(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.Multiline)
                    SendKeys.Send((e.Shift ? "+" : "") + "{TAB}");
            }
        }

        private const string WMCLOSE = "WmClose";

        public bool IsFormClosing()
        {
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
            foreach (System.Diagnostics.StackFrame sf in stackTrace.GetFrames())
            {
                if (sf.GetMethod().Name == WMCLOSE)
                {
                    return true;
                }
            }
            return false;
        }

        public void VerificaDecimal(KeyPressEventArgs e, int bd, int ad) // bd Parte inteira e ad parte decimal
        {
            if (!string.IsNullOrEmpty(this.SelectedText))
            {
                if ((this.Text.IndexOf(",") != -1))
                {
                    if ((e.KeyChar.ToString() == ","))
                    {
                        e.Handled = true;
                    }
                    if (!((Convert.ToInt32(e.KeyChar) > 47 && Convert.ToInt32(e.KeyChar) < 58) ||
                    (Convert.ToInt32(e.KeyChar) == 13)))
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (Convert.ToInt32(e.KeyChar) != 8)
                {
                    if (((char.IsControl(e.KeyChar)
                          || (char.IsDigit(e.KeyChar) == true))
                          || ((e.KeyChar.ToString() == ","))))
                    {
                        if ((this.Text.IndexOf(",") != -1))
                        {
                            if ((e.KeyChar.ToString() == ","))
                            {
                                e.Handled = true;
                            }
                            if (((this.SelectionStart >= 0)
                                        && (Convert.ToInt32(e.KeyChar) == 8)))
                            {
                                if (((((this.Text.Substring(this.Text.IndexOf(",")).Length > ad)
                                            && (this.SelectionStart > this.Text.IndexOf(",")))
                                            || ((this.Text.Substring(0, (this.Text.IndexOf(",") + 1)).Length > bd)
                                            && (this.SelectionStart
                                            < (this.Text.IndexOf(",") + 1))))
                                            && (this.SelectionLength == 0)))
                                {
                                    e.Handled = true;
                                }
                            }
                            if (this.SelectionStart <= this.Text.IndexOf(","))
                            {
                                if (this.Text.Substring(0, (this.Text.IndexOf(","))).Length == ParteInteira)
                                    e.Handled = true;
                            }
                            else
                            {
                                if (this.SelectionStart >= this.Text.IndexOf(","))
                                    if (this.Text.Substring(this.Text.IndexOf(",")).Length - 1 == ParteDecimal)
                                        e.Handled = true;
                            }
                        }
                        else if ((((ad == 0)
                                    && (e.KeyChar.ToString() == ","))
                                    || ((((this.Text.Substring(0).Length > (bd - 1))
                                    && ((e.KeyChar.ToString() != ",")
                                    && (Convert.ToInt32(e.KeyChar) != 8)))
                                    || ((this.SelectionStart > bd)
                                    && e.KeyChar.ToString().Equals(",")))
                                    && (this.SelectionLength == 0))))
                        {
                            e.Handled = true;
                        }

                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                    e.Handled = false;
            }
        }

        public bool ContemValor()
        {
            string valor = this.Text.Replace(" ", "");

            if (CTipoValor.Monetario == TipoValor)
            {
                valor = valor.Replace("R", "").Replace("$", "");
            }

            if (valor.Trim().Equals(""))
                return false;

            return true;
        }
        public double getValorDouble()
        {
            string valor = this.Text.Replace("R", "").Replace("$", "").Replace(" ", "");
            try
            {
                return double.Parse(valor);
            }
            catch (Exception)
            {
                string msg = this.Name;
                if (!this.Text.Trim().Equals(""))
                    msg += "; Text=" + valor;
                else
                    msg += "; Text=null";
                throw new Exception("Erro ao converter para Double (" + msg + ")");
            }
        }
        public double? getValorDoubleNull()
        {
            string valor = this.Text.Replace("R", "").Replace("$", "").Replace(" ", "");

            try
            {
                if (valor.Trim().Equals(""))
                    return null;
                else
                    return double.Parse(valor);
            }
            catch (Exception)
            {
                string msg = this.Name;
                if (!this.Text.Trim().Equals(""))
                    msg += "; Text=" + valor;
                else
                    msg += "; Text=null";
                throw new Exception("Erro ao converter para Double (" + msg + ")");
            }
        }
        public int getValorInt()
        {
            string valor = this.Text.Replace("R", "").Replace("$", "").Replace(" ", "");
            try
            {
                return int.Parse(valor);
            }
            catch (Exception)
            {
                string msg = this.Name;
                if (!this.Text.Trim().Equals(""))
                    msg += "; Text=" + valor;
                else
                    msg += "; Text=null";
                throw new Exception("Erro ao converter para Integer (" + msg + ")");
            }
        }
        public int? getValorIntNull()
        {
            string valor = this.Text.Replace("R", "").Replace("$", "").Replace(" ", "");
            try
            {
                if (valor.Trim().Equals(""))
                    return null;
                else
                    return int.Parse(valor);
            }
            catch (Exception)
            {
                string msg = this.Name;
                if (!this.Text.Trim().Equals(""))
                    msg += "; Text=" + valor;
                else
                    msg += "; Text=null";
                throw new Exception("Erro ao converter para Integer (" + msg + ")");
            }
        }

        public long getValorLong()
        {
            string valor = this.Text.Replace("R", "").Replace("$", "").Replace(" ", "");
            try
            {
                return long.Parse(valor);
            }
            catch (Exception)
            {
                string msg = this.Name;
                if (!this.Text.Trim().Equals(""))
                    msg += "; Text=" + valor;
                else
                    msg += "; Text=null";
                throw new Exception("Erro ao converter para Long (" + msg + ")");
            }
        }
        public long? getValorLongNull()
        {
            string valor = this.Text.Replace("R", "").Replace("$", "").Replace(".","").Replace("-","").Replace(" ", "");
            try
            {
                if (valor.Trim().Equals(""))
                    return null;
                else
                    return long.Parse(valor);
            }
            catch (Exception)
            {
                string msg = this.Name;
                if (!this.Text.Trim().Equals(""))
                    msg += "; Text=" + valor;
                else
                    msg += "; Text=null";
                throw new Exception("Erro ao converter para Long (" + msg + ")");
            }
        }
    }
}
