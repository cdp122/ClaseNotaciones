using System;
using System.Windows.Forms;

namespace ClaseNotaciones
{
    public partial class Form1 : Form
    {
        //Instanciamos las clases NotacionInfija y NotacionPosfija
        NInfija infija;
        NPosfija posfija;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        /// <summary>
        /// Evento que se ejecuta al presionar la tecla "Enter" en cualquier textbox que lo tenga asignado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyEnter(object sender, KeyPressEventArgs e)
        {
            //Se activará unicamente al ser "Enter"
            if (e.KeyChar == (char)Keys.Enter)
            {
                //Limpiamos la memoria de objetos ya no usados. Con el fin de optimizar el programa
                GC.Collect();
                try
                {
                    //Dependerá donde ha sido invocado se convertirán en las notaciones adecuadas. 
                    if (txtInfija.Text != "")
                    {
                        txtPosfija.Text = "";

                        infija = new NInfija(txtInfija.Text);
                        txtPosfija.Text = infija.APosfija() + "";
                    }
                    else if (txtPosfija.Text != "")
                    {
                        txtInfija.Text = "";

                        posfija = new NPosfija(txtPosfija.Text);
                        txtInfija.Text = posfija.AInfija() + "";
                    }
                }
                //En caso de dar algun error, es previsto que fue por la notación mal ingresada. 
                catch (Exception ex) { MessageBox.Show("Error, notación ingresada incorrecta\n" + ex.ToString()); }
            }
        }

        /// <summary>
        /// Permite que al dar "foco" a un textbox especifico, los demás se borrarán el texto almacenado. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Focus_Enter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Name == "txtInfija")
            {
                txtPosfija.Text = "";

            }
            else if (t.Name == "txtPosfija")
            {
                txtInfija.Text = "";

            }
            else if (t.Name == "txtPrefija")
            {
                txtPosfija.Text = "";
                txtInfija.Text = "";
            }
        }

        private void btnTransformar_Click(object sender, EventArgs e)
        {
            //Limpiamos la memoria de objetos ya no usados. Con el fin de optimizar el programa
            GC.Collect();
            try
            {
                //Dependerá donde ha sido invocado se convertirán en las notaciones adecuadas. 
                if (txtInfija.Text != "")
                {
                    txtPosfija.Text = "";

                    infija = new NInfija(txtInfija.Text);
                    txtPosfija.Text = infija.APosfija() + "";
                }
                else if (txtPosfija.Text != "")
                {
                    txtInfija.Text = "";

                    posfija = new NPosfija(txtPosfija.Text);
                    txtInfija.Text = posfija.AInfija() + "";
                }
            }
            //En caso de dar algun error, es previsto que fue por la notación mal ingresada. 
            catch (Exception ex) { MessageBox.Show("Error, notación ingresada incorrecta\n" + ex.ToString()); }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try { infija = new NInfija(txtInfija.Text); }
            //En caso de dar algun error, es previsto que fue por la notación mal ingresada. 
            catch (Exception ex) { MessageBox.Show("Error, notación ingresada incorrecta\n" + ex.ToString()); }
            finally { MessageBox.Show("Notación Correcta"); }
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            posfija = new NPosfija(txtPosfija.Text);
            double result = posfija.CalcularResultado(txtPosfija.Text);
            string r = result.ToString();
            txtRespuesta.Text = r;
        }
    }
}
