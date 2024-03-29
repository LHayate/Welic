﻿using System;
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
    public partial class frmBuscaInformacaoGrid : FormWelic
    {
        public DataGridViewWelic dgv;
        private DataTable _dtGrid;
        private List<int> rowIndexCorrepondencias = new List<int>();

        public frmBuscaInformacaoGrid(DataGridViewWelic dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
            dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);

            lblContagemRegistros.Text = "";

            _dtGrid = ((DataTable)dgv.DataSource).Clone();
            foreach (DataColumn item in _dtGrid.Columns)
            {
                item.DataType = typeof(string);
            }
            foreach (DataRow row in ((DataTable)dgv.DataSource).Rows)
            {
                _dtGrid.ImportRow(row);
            }
        }

        void dgv_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < rowIndexCorrepondencias.Count; i++)
            {
                if (i == 25)
                {

                }

                if (dgv.Rows.Count > rowIndexCorrepondencias[i])
                {
                    if (dgv.Rows[rowIndexCorrepondencias[i]].Selected)
                    {
                        lblContagemRegistros.Text = "Registro " + (i + 1) + " de " + rowIndexCorrepondencias.Count + ".";

                        btnAnterior.Enabled = ((i + 1) == 1);

                        if (((i + 1) == 1))
                            btnAnterior.Enabled = false;
                        else
                            btnAnterior.Enabled = true;

                        if (((i + 1) == rowIndexCorrepondencias.Count))
                            btnProximo.Enabled = false;
                        else
                            btnProximo.Enabled = true;
                    }
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int rowIndexAtual = 0;
            if (dgv.SelectedRows.Count > 0)
                rowIndexAtual = dgv.SelectedRows[0].Index;

            int proximoRowIndex = 0;
            for (int i = 0; i < rowIndexCorrepondencias.Count; i++)
            {
                if (rowIndexCorrepondencias[i] == rowIndexAtual)
                {
                    proximoRowIndex = rowIndexCorrepondencias[i - 1];
                }
            }

            dgv.Rows[proximoRowIndex].Selected = true;
            foreach (DataGridViewCell item in dgv.Rows[proximoRowIndex].Cells)
            {
                if (item.Visible)
                {
                    dgv.CurrentCell = item;
                    break;
                }
            }

            dgv_SelectionChanged(null, null);
            txtProcurar.Focus();
        }
        private void btnProximo_Click(object sender, EventArgs e)
        {
            int rowIndexAtual = 0;
            if (dgv.SelectedRows.Count > 0)
                rowIndexAtual = dgv.SelectedRows[0].Index;

            int proximoRowIndex = 0;
            for (int i = 0; i < rowIndexCorrepondencias.Count; i++)
            {
                if (rowIndexCorrepondencias[i] == rowIndexAtual)
                {
                    proximoRowIndex = rowIndexCorrepondencias[i + 1];
                }
            }

            dgv.Rows[proximoRowIndex].Selected = true;
            foreach (DataGridViewCell item in dgv.Rows[proximoRowIndex].Cells)
            {
                if (item.Visible)
                {
                    dgv.CurrentCell = item;
                    break;
                }
            }

            dgv_SelectionChanged(null, null);
            txtProcurar.Focus();
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            if (!txtProcurar.Text.Trim().Equals(""))
            {
                btnAnterior.Enabled = false;
                btnProximo.Enabled = true;

                List<DataRow[]> r = new List<DataRow[]>();
                rowIndexCorrepondencias.Clear();
                foreach (DataGridViewColumn c in dgv.Columns)
                {
                    if (!c.DataPropertyName.Trim().Equals("") && c.Visible)
                    {
                        DataRow[] rows = new DataRow[0];
                        try
                        {
                            rows = _dtGrid.Select(c.DataPropertyName + " like '%" + txtProcurar.Text + "%'");
                        }
                        catch (Exception)
                        {

                        }

                        foreach (DataRow item in rows)
                            rowIndexCorrepondencias.Add(_dtGrid.Rows.IndexOf(item));

                        if (rows.Length > 0)
                            r.Add(rows);
                    }
                }

                rowIndexCorrepondencias = rowIndexCorrepondencias.Distinct().ToList();
                rowIndexCorrepondencias.Sort();

                double qtdLinhas = r.Count;
                double qtdCorrespondencias = 0;
                foreach (DataRow[] item in r)
                    qtdCorrespondencias += item.Length;

                dgv_SelectionChanged(null, null);

                if (rowIndexCorrepondencias.Count > 0)
                {
                    dgv.Rows[rowIndexCorrepondencias[0]].Selected = true;

                    foreach (DataGridViewCell item in dgv.Rows[rowIndexCorrepondencias[0]].Cells)
                    {
                        if (item.Visible)
                        {
                            dgv.CurrentCell = item;
                            break;
                        }
                    }
                }
                else
                {
                    lblContagemRegistros.Text = "";
                    dgv.Rows[0].Selected = true;
                    foreach (DataGridViewCell item in dgv.Rows[0].Cells)
                    {
                        if (item.Visible)
                        {
                            dgv.CurrentCell = item;
                            break;
                        }
                    }
                }

                if (qtdCorrespondencias > 1)
                {

                }
                else
                {
                    btnAnterior.Enabled = false;
                    btnProximo.Enabled = false;
                }
            }
            else
            {
                dgv.Rows[0].Selected = true;
                btnAnterior.Enabled = false;
                btnProximo.Enabled = false;
                lblContagemRegistros.Text = "";
            }
        }
    }
}
