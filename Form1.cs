using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaseNotaciones
{
    public partial class Form1 : Form
    {
        NInfija infija;
        NPosfija posfija;
        NPrefija prefija;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GC.Collect();
                try
                {
                    if (txtInfija.Text != "")
                    {
                        txtPosfija.Text = "";
                        txtPrefija.Text = "";
                        infija = new NInfija(txtInfija.Text);
                        txtPosfija.Text = infija.APosfija() + "";
                    }
                    else if (txtPosfija.Text != "")
                    {
                        txtInfija.Text = "";
                        txtPrefija.Text = "";
                        posfija = new NPosfija(txtPosfija.Text);
                        txtInfija.Text = posfija.AInfija() + "";
                    }
                    else if (txtPrefija.Text != "")
                    {
                        txtPosfija.Text = "";
                        txtInfija.Text = "";
                    }
                    //Aqui iria el codigo para resolver. 
                }
                catch (Exception ex) { MessageBox.Show("Error, notación ingresada incorrecta\n" + ex.ToString()); }
            }
        }

        private void Focus_Enter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Name == "txtInfija")
            {
                txtPosfija.Text = "";
                txtPrefija.Text = "";
            }
            else if (t.Name == "txtPosfija")
            {
                txtInfija.Text = "";
                txtPrefija.Text = "";
            }
            else if (t.Name == "txtPrefija")
            {
                txtPosfija.Text = "";
                txtInfija.Text = "";
            }
        }
    }
}
