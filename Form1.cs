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
                    infija = new NInfija(txtInfija.Text); 
                    txtPosfija.Text = infija.APosfija().ToString();
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
            txtPosfija.Text = "";
            txtRespuesta.Text = string.Empty;
        }

        private void btnTransformar_Click(object sender, EventArgs e)
        {
            //Limpiamos la memoria de objetos ya no usados. Con el fin de optimizar el programa
            GC.Collect();
            try
            {
                infija = new NInfija(txtInfija.Text); 
                txtPosfija.Text = infija.APosfija() + "";
            }
            //En caso de dar algun error, es previsto que fue por la notación mal ingresada. 
            catch (Exception ex) { MessageBox.Show("Error, notación ingresada incorrecta\n" + ex.ToString()); }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            //Para que cuando se de click en el botón y no se encuentre nada, se muestre mensaje
            if(string.IsNullOrWhiteSpace(this.txtInfija.Text))
            {
                MessageBox.Show("No hay contenido que validar");
            }
            else
            {
                
                try { infija = new NInfija(txtInfija.Text); }
                //En caso de dar algun error, es previsto que fue por la notación mal ingresada. 
                catch (Exception ex) { MessageBox.Show("Error, notación ingresada incorrecta\n" + ex.ToString()); }
                finally { MessageBox.Show("Notación Correcta"); }
            }
            
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            //Primero va convertir de infija a posfija, si ya fue transformada continua con la resolución.
            if (txtPosfija.Text != "") posfija = new NPosfija(txtPosfija.Text);
            else
            {
                infija = new NInfija(txtInfija.Text);
                posfija = infija.APosfija();
                txtPosfija.Text = posfija.ToString().Replace(" ", "");
            }
            string not = posfija.ToString();
            string not2 = not.Replace('.', ',');
            double result = posfija.CalcularResultado(not2);
            string r = result.ToString();
            //finalmente lo imprime
            txtRespuesta.Text = r;
        }
    }
}
