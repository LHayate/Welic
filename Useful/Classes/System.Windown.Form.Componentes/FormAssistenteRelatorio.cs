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
    public partial class FormAssistenteRelatorio : FormWelic
    {
        public enum COpcaoVisualizacao { Tela = 1, Impressora = 2, Excel = 3, Word = 4, PDF = 5 };
        private COpcaoVisualizacao _ov = COpcaoVisualizacao.Tela;
        public COpcaoVisualizacao Ov
        {
            get { return _ov; }
            set { _ov = value; }
        }

        public FormAssistenteRelatorio()
        {
            InitializeComponent();
        }

        private void toolStripBtnTela_Click(object sender, EventArgs e)
        {
            _ov = COpcaoVisualizacao.Tela;
            txtOpcaoVisualizacao.Text = "VIDEO";
        }

        private void toolStripBtnImpressora_Click(object sender, EventArgs e)
        {
            _ov = COpcaoVisualizacao.Impressora;
            txtOpcaoVisualizacao.Text = "IMPRESSORA";
        }

        private void toolStripBtnExcel_Click(object sender, EventArgs e)
        {
            _ov = COpcaoVisualizacao.Excel;
            txtOpcaoVisualizacao.Text = "MICROSOFT EXCEL";
        }

        private void toolStripBtnWord_Click(object sender, EventArgs e)
        {
            _ov = COpcaoVisualizacao.Word;
            txtOpcaoVisualizacao.Text = "MICROSOFT WORD";
        }

        private void toolStripBtnPDF_Click(object sender, EventArgs e)
        {
            _ov = COpcaoVisualizacao.PDF;
            txtOpcaoVisualizacao.Text = "PDF";
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {

        }
    }
}
