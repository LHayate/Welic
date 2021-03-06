﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.Forms.Welic;

namespace IntervaloCampos
{
    public partial class IntervaloCampos2 : UserControl
    {
        public IntervaloCampos2()
        {
            InitializeComponent();
        }
        public enum CTipoValor { Numerico = 2 };
        private CTipoValor _tipoValor = CTipoValor.Numerico;
        public CTipoValor TipoValor
        {
            get { return _tipoValor; }
            set
            {
                _tipoValor = value;
                txtInicial.TipoValor = (TextBoxWelic.CTipoValor)value;
                txtFinal.TipoValor = (TextBoxWelic.CTipoValor)value;
            }
        }
        private string _textChk = "Inter. Campo";
        public string TextCheck
        {
            get { chkTitulo.Text = _textChk; return _textChk; }
            set { chkTitulo.Text = value; _textChk = value; }
        }

        private int _maxLength;
        public int MaxLengthTextBox
        {
            get
            {
                txtInicial.MaxLength = _maxLength;
                txtFinal.MaxLength = _maxLength;
                return _maxLength;
            }
            set
            {
                txtInicial.MaxLength = value;
                txtFinal.MaxLength = value;
                _maxLength = value;
            }
        }

        private void chkTitulo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTitulo.Checked)
            {
                txtInicial.Enabled = true;
                txtFinal.Enabled = true;
                txtInicial.Focus();
            }
            else
            {
                txtInicial.Enabled = false;
                txtFinal.Enabled = false;
            }
        }
        public bool Checado()
        {
            if (chkTitulo.Checked && !(string.IsNullOrEmpty(txtInicial.Text)) && !(string.IsNullOrEmpty(txtFinal.Text)))
                return true;
            else
                return false;
        }

        private void txtInicial_Leave(object sender, EventArgs e)
        {
            Copiar();
            if (string.IsNullOrEmpty(txtInicial.Text))
                txtFinal.Text = "";
        }
        private void Copiar()
        {
            if (string.IsNullOrEmpty(txtFinal.Text))
            {
                txtFinal.SelectAll();
                txtFinal.Text = txtInicial.Text;
            }
        }

        private void txtInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Copiar();
            }
        }

        private void txtInicial_TextChanged(object sender, EventArgs e)
        {
            txtFinal.Text = "";
        }
        public string RetornoTxtInicial()
        {
            return txtInicial.Text;
        }
        public string RetornoTxtFinal()
        {
            return txtFinal.Text;
        }
    }
}
