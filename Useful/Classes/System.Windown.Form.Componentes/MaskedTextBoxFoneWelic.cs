using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using UseFul.ClientApi;

namespace UseFul.Forms.Welic
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iMasktextbox.ico")]
    public partial class MaskedTextBoxFoneWelic : MaskedTextBoxWelic
    {
        // DDDs que necessita de nove digitos (para celular)
        // 11, 12, 13, 14, 15, 16, 17, 18, 19 - São Paulo
        // 21, 22, 24 - Rio de Janeiro
        // 27, 28 - Espírito Santo
        // 96 - Amapá
        // 92, 97 - Amazonas
        // 98, 99 - Maranhão
        // 91, 93, 94 - Pará
        // 95 - Roraima
        protected readonly int[] dddsNoveDigito = new int[] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 21, 22, 24, 27, 28, 91, 92, 93, 94, 95, 96, 97, 98, 99};

        // Indica a faixa aceita para o oitavo digito do celular
        // 2, 3, 4, 5 - Telefone Fixo
        // 6, 7, 8, 9 - Celular
        protected readonly int[] faixaOitavoDigTelFixo = new int[] { 2, 3, 4, 5 };
        protected readonly int[] faixaOitavoDigCelular = new int[] { 6, 7, 8, 9 };

        public MaskedTextBoxFoneWelic()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            if (base.ReadOnly)
                base.BackColor = Color.FromArgb(231, 231, 231);

            this.initMask();
        }

        public MaskedTextBoxFoneWelic(IContainer container)
        {
            InitializeComponent();
            container.Add(this);

            this.initMask();
        }

        private void initMask()
        {
            base.Mask = "(99) 00000-0000";
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

        private bool _limpaCampo = true;

        public bool LimpaCampo
        {
            get { return _limpaCampo; }
            set { _limpaCampo = value; }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!base.ReadOnly)
                base.BackColor = Color.LemonChiffon;
            else
                base.BackColor = Color.FromArgb(231, 231, 231);
        }

        protected override void OnLeave(EventArgs e)
        {
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
            ValidaMask();
            if (!validaNonoDigito())
                this.Focus();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.validaTelefone();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            ExecutaTabPressionaEnter(e);
        }

        protected void ValidaMask()
        {
            var Digitos = "0123456789";
            if (!string.IsNullOrEmpty(base.Text))
            {
                for (int i = 0; i < base.Text.Length; i++)
                {
                    string stv = base.Text.Substring(i, 1);
                    if (Digitos.IndexOf(stv) >= 0)
                    {
                        if (base.MaskFull == false)
                        {
                            MessageBox.Show("Favor informe o campo completo.", "Atenção!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            base.Focus();
                            return;
                        }
                    }
                }
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                this.initMask();
                base.Text = value;
                validaTelefone();
            }
        }

        protected void validaTelefone()
        {
            if (this.Text.Length >= 2)
            {
                //Retira caracteres diferente de numero
                string numTelefone = this.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace("-", "").Replace(" ", "");

                int ddd = -1;
                if (numTelefone.Length >= 2)
                    ddd = int.Parse(numTelefone.Substring(0, 2));

                if (ddd != -1)
                {
                    if (numTelefone.Length >= 3)
                    {
                        int oitavoDigito = int.Parse(numTelefone.Substring(2, 1));
                        if ((Inlist(oitavoDigito, this.faixaOitavoDigCelular)) && (Inlist(ddd, this.dddsNoveDigito)))
                        {
                            this.Mask = "(99) 00000-0000";
                        }
                        else
                        {
                            this.Mask = "(99) 0000-0000";
                        }
                    }
                    else
                    {
                        this.Mask = "(99) 0000-0000";
                    }
                }
                else
                {
                    this.Mask = "(99) 0000-0000";
                }
            }
        }

        /// <summary>
        /// validaNonoDigito, verifica se o nono digito é 9
        /// </summary>
        protected Boolean validaNonoDigito()
        {
            if (this.MaskFull)
            {
                //Retira caracteres diferente de numero
                string numTel = this.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace("-", "").Replace(" ", "");
                int ddd, nonoDigito, oitavoDigito;

                if (this.Mask.Length == 14) // Telefone com 8 digitos + ddd
                {
                    ddd = int.Parse(numTel.Substring(0, 2));
                    nonoDigito = 0;
                    oitavoDigito = int.Parse(numTel.Substring(2, 1));
                }
                else // Telefone com 9 digitos + ddd
                {
                    ddd = int.Parse(numTel.Substring(0, 2));
                    nonoDigito = int.Parse(numTel.Substring(2, 1));
                    oitavoDigito = int.Parse(numTel.Substring(3, 1));
                }

                if ((Inlist(ddd, this.dddsNoveDigito)) && (!Inlist(oitavoDigito, this.faixaOitavoDigTelFixo)))
                {
                    if (nonoDigito != 9)
                    {
                        MessageBox.Show("Numero de telefone inválido para o DDD informado!", Globals.TituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else if ((Inlist(ddd, this.dddsNoveDigito)) && (Inlist(oitavoDigito, this.faixaOitavoDigTelFixo)) && (nonoDigito != 0))
                {
                    MessageBox.Show("Numero de telefone espera nono digito, mas oitavo digito não está na faixa de numero de celular (6 a 9)!", Globals.TituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private bool Inlist(int ItemBusca, int[] arrayItens)
        {
            if ((Array.IndexOf(arrayItens, ItemBusca) != -1))
                return true;
            else
                return false;
        }

        private void ExecutaTabPressionaEnter(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send((e.Shift ? "+" : "") + "{TAB}");
            }
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
    }
}