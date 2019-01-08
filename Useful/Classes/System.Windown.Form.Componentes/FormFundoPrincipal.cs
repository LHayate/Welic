using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseFul.Forms.Welic
{
    public partial class FormFundoPrincipal : Form
    {
        private string titulo, subTitulo, duvidas, equipe, gerencia;

        public string MsgTitulo
        {
            get { return titulo; }
            set { titulo = value; lblTitulo.Text = this.titulo; }
        }
        public string MsgSubTitulo
        {
            get { return subTitulo; }
            set { subTitulo = value; lblSubTitulo.Text = this.subTitulo; }
        }
        public string MsgDuvidas
        {
            get { return duvidas; }
            set { duvidas = value; }
        }
        public string MsgEquipe
        {
            get { return equipe; }
            set { equipe = value;}
        }
        public string MsgGerencia
        {
            get { return gerencia; }
            set { gerencia = value;}
        }
        
        public FormFundoPrincipal()
        {
            InitializeComponent();
        }

        private void FormFundoPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                e.Cancel = true;
            }
        }

        private void FormFundoPrincipal_Load(object sender, EventArgs e)
        {
            lbGerenciaEquipe.Text = this.gerencia + " - Equipe " + this.equipe;
            lbDuvidas.Text = this.duvidas;
        }
    }
}
