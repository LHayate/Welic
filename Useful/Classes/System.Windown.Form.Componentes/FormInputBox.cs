using System;
using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    public partial class FormInputBox : Form
    {
        public string Texto;
        private int Tipo;
        /// <summary>
        /// InputBox para que o usuário entre um valor
        /// </summary>
        /// <param name="tituloLabel"> Titulo para o InputBox</param>
        /// <param name="pTexto">(Opcional, se for 'Saida') Texto que deseja exibir</param>
        /// <param name="pTipo">Tipo do Campo do ImputBox, 1 - int, 2 - string, 3 - DateTime </param>
        public FormInputBox(string tituloLabel, string pTexto, int pTipo)
        {
            InitializeComponent();
            lbTitulo.Text = tituloLabel;
            txtTexto.Text = pTexto;
            Tipo = pTipo;
            switch (pTipo)
            {
                case 1:
                    txtTexto.TipoValor = UseFul.Forms.Welic.TextBoxWelic.CTipoValor.Numerico;
                    break;
                default:
                    break;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Texto = string.Empty;
            this.Dispose();
        }

        private void btConfirma_Click(object sender, EventArgs e)
        {
            if (Tipo == 3)
            {
                try
                {
                    DateTime.Parse(txtTexto.Text);
                }
                catch
                {
                    MessageBox.Show("Data Inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Texto = txtTexto.Text;
            this.Dispose();
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            txtTexto.Focus();
        }
    }
}
