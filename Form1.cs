using System;
using System.Linq;
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
                // Verificar mezcla de letras y números
                if (!VerificarSinMezclaLetrasYNumeros(this.txtInfija.Text))
                {
                    MessageBox.Show("Error: No se permite la mezcla de letras y números.");
                    return; // Salir del método si hay mezcla de letras y números
                }

                // Limpiamos la memoria de objetos ya no usados. Con el fin de optimizar el programa
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
            if (VerificarSinMezclaLetrasYNumeros(this.txtInfija.Text))
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
            else MessageBox.Show("Error, notación ingresada incorrecta\n");


        }
        /// <summary>
        /// Es un metodo que verifica si hay la misma cantidad de '(' y ')' para su correcto uso
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo para comprobar mediante metodos char si hay letras o numero en el mismo txt
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool VerificarSinMezclaLetrasYNumeros(string cadena)
        {
            bool tieneLetras = false;
            bool tieneNumeros = false;

            foreach (char c in cadena)
            {
                if (char.IsLetter(c))
                {
                    tieneLetras = true;
                }
                else if (char.IsDigit(c))
                {
                    tieneNumeros = true;
                }

                // Si encontramos tanto letras como números, devolvemos false
                if (tieneLetras && tieneNumeros)
                {
                    return false;
                }
            }

            // Si solo hay letras o solo hay números, devolvemos true
            return true;
        }

        private bool VerificarOperadoresConsecutivos(string input)
        {
            // Lista de operadores comunes
            char[] operadores = { '+', '-', '*', '/', '!', '^' };

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (operadores.Contains(input[i]) && operadores.Contains(input[i + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            //Para que cuando se de click en el botón y no se encuentre nada, se muestre mensaje
            if (string.IsNullOrWhiteSpace(this.txtInfija.Text))
            {
                MessageBox.Show("No hay contenido que validar");
            }
            else
            {
                // Verificar mezcla de letras y números
                if (!VerificarSinMezclaLetrasYNumeros(this.txtInfija.Text))
                {
                    MessageBox.Show("Error: No se permite la mezcla de letras y números.");
                    return; // Salir del método si hay mezcla de letras y números
                }

                if (verificarParentesis(this.txtInfija.Text))
                {
                    try
                    {
                        infija = new NInfija(txtInfija.Text);
                    }
                    // En caso de dar algún error, es previsto que fue por la notación mal ingresada.
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error, notación ingresada incorrecta\n" + ex.ToString());
                    }
                    finally // estructura try-catch-finally: finally sirve aunque no hay una excepción
                    {
                        MessageBox.Show("Notación Correcta");//mostrara la notación correcta
                    }
                }

                if (VerificarOperadoresConsecutivos(txtInfija.Text))
                {

                    MessageBox.Show("Error: No se permite operadores conjuntos.");
                    return; // Salir del método si hay mezcla de letras y números
                }
                else
                {
                    MessageBox.Show("Error en parentesis\nPor favor complete los parentesis");
                }
            }
        }


        private void btnEvaluar_Click(object sender, EventArgs e)
        {       //verificara que no haya mezcla de letras y numeros para que no haya errores al evaluar
            if (VerificarSinMezclaLetrasYNumeros(this.txtInfija.Text))
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
                double result = -999999999; // inicializo valores
                try //compruebo que los tokens me regresen un double y si no un mensaje de error
                {
                    result = posfija.CalcularResultado(not2);
                }
                catch (Exception ex) { MessageBox.Show("Error, notación ingresada incorrecta\n" + ex.ToString()); }


                //ahora si asigno a r lo que contiene result.ToString()

                string r = result.ToString();
                //finalmente lo imprime
                txtRespuesta.Text = r;
            }
            else MessageBox.Show("Error: No deben estar mezcla de numeros y letras");
        }
    }
}
