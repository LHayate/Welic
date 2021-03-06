﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UseFul.Forms.Welic;

namespace UseFul.Forms.Welic
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\lista.ico")]
    public partial class ListaCampos : UserControl
    {
        public ListaCampos()
        {
            InitializeComponent();
        }

        public enum CTipoValor { Geral = 1, Numerico = 2 };
        private CTipoValor _tipoValor = CTipoValor.Geral;
        public CTipoValor TipoValor
        {
            get { return _tipoValor; }
            set
            {
                _tipoValor = value;
                txtCampo.TipoValor = (TextBoxWelic.CTipoValor)value;
            }
        }

        private string _textChk = "Lista Campos";
        public string TextCheck
        {
            get { lbListaCampos.Text = _textChk; return _textChk; }
            set { lbListaCampos.Text = value; _textChk = value; }
        }

        private int _maxLength;
        public int MaxLengthTextBox
        {
            get { txtCampo.MaxLength = _maxLength; return _maxLength; }
            set { txtCampo.MaxLength = value; _maxLength = value; }
        }

        public string RetornaLista()
        {
            if (listGeral.Items.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                string lista = string.Empty;

                for (int i = 0; i < listGeral.Items.Count; i++)
                {
                    if (!string.IsNullOrEmpty(lista))
                    {
                        lista += ",";
                    }
                    lista += "'" + listGeral.Items[i].ToString() + "'";
                }
                return lista;
            }
        }
        public List<object> RetornaListIn()
        {
            List<object> lista = lista = new List<object>();
            if (listGeral.Items.Count == 0 || !chkListaCampos.Checked)
                return lista;
            else
                foreach (object item in listGeral.Items)
                    lista.Add(item);

            return lista;
        }

        public bool Checado()
        {
            if (chkListaCampos.Checked && listGeral.Items.Count > 0)
                return true;
            else
                return false;
        }

        private void chkListaCampos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkListaCampos.Checked)
            {
                txtCampo.Enabled = true;
                listGeral.Enabled = true;
                txtCampo.Focus();
            }
            else
            {
                txtCampo.Enabled = false;
                listGeral.Enabled = false;
            }
        }

        private void txtCampo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtCampo.Text))
                {
                    int i;
                    for (i = 0; (i < listGeral.Items.Count && txtCampo.Text != listGeral.Items[i].ToString()); i++) ;

                    if (i == listGeral.Items.Count)
                    {
                        if (listGeral.Items.IndexOf(txtCampo.Text) == -1)
                        {
                            listGeral.Items.Add(txtCampo.Text);
                            txtCampo.Clear();
                            txtCampo.Focus();
                        }
                    }
                    else
                    {
                        return;

                    }
                }
            }

        }

        private void listGeral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                while (listGeral.SelectedItems.Count > 0)
                {
                    listGeral.Items.Remove(listGeral.SelectedItem);
                }
            }
        }

    }
}
