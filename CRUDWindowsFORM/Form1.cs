﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWindowsFORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeopleDB oPeople = new PeopleDB();
            if (oPeople.Ok())
            {
                MessageBox.Show("Connection OK");
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }
        }

        private void Refresh()
        {
            PeopleDB oPeople = new PeopleDB();
            dataGridView1.DataSource = oPeople.Get();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmNuevo oFrmNuevo = new FrmNuevo();
            oFrmNuevo.ShowDialog();
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)

            {
                FrmNuevo oFrmEdit = new FrmNuevo(Id);
                oFrmEdit.ShowDialog();
                Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        #region HELPER
        private int? GetId()

        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion HELPER

        private void button5_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)

            {
                PeopleDB oPeople = new PeopleDB();
                oPeople.Delete((int)Id);
                Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
    }
}
