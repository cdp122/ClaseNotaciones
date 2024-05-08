using System;
using System.Windows.Forms;

namespace ClaseNotaciones
{
    public partial class Form1 : Form
    {
        //Instanciamos las clases NotacionInfija y NotacionPosfija
        NInfija infija;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que se ejecuta al presionar la tecla "Enter" en cualquier textbox que lo tenga asignado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //Limpiamos la memoria de objetos ya no usados. Con el fin de optimizar el programa
                GC.Collect();
                try
                {
                    //Dependerá donde ha sido invocado se convertirán en las notaciones adecuadas. 
                    if (txtInfija.Text != "")
                    {

                        if (verificarParentesis(txtInfija.Text))
                        {
                            infija = new NInfija(txtInfija.Text);
                            txtPosfija.Text = infija.APosfija() + "";
                        }
                        else
                        {
                            MessageBox.Show("Error de parentesis");
                        }
                        
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
            else if (t.Name == "txtPosfija")
            {
                txtPosfija.Text = "";
                txtInfija.Text = "";

            }
            else if (t.Name == "txtPrefija")
            {
                txtPosfija.Text = "";
                txtInfija.Text = "";
            }
        }

        private void txtPosfija_TextChanged(object sender, EventArgs e)
        {

        }

        

        public static bool verificarParentesis(string cadena)
        {
            int contador = 0;

            for (int i = 0; i < cadena.Length; i++)
            {
                char caracter = cadena[i];

                if (caracter == '(')
                {
                    contador++;
                }
                else if (caracter == ')')
                {
                    contador--;
                }

                // Si el contador es negativo en algún momento, significa que hay más paréntesis de cierre que de apertura
                if (contador < 0)
                {
                    return false;
                }
            }

            // Si el contador es igual a 0 al final, significa que hay la misma cantidad de paréntesis de apertura y cierre
            return contador == 0;
        }

    }
}
