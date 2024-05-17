using System;
using System.Linq;
using System.Resources;

namespace ClaseNotaciones
{
    /// <summary>
    /// Esta clase es abstracta para que todas las clases de Notaciones puedan acceder a un arreglo. Optimizando la memoria
    /// </summary>
    abstract class Signos
    {
        public static char[] signos = new char[] { '+', '-', '*', '/', '^', '(', ')' };
    }

    /// <summary>
    /// La clase Notación Infija se encarga de almacenar la notación del mismo nombre.
    /// Además permite sus conversiones a otras Notaciones. 
    /// </summary>
    internal class NInfija
    {
        //La notación principal donde se manejaran para los metodos existentes. 
        string notacion;

        /// <summary>
        /// Constructor de la clase Notación Infija. 
        /// </summary>
        /// <param name="notacion">Es la notación, la cual debe estar escrita correctamente</param>
        public NInfija(string notacion)
        {
            this.notacion = notacion;
        }

        /// <summary>
        /// Regresa su versión de la notación a Notación Posfija. 
        /// </summary>
        /// <returns>Regresa una Notación Posfija</returns>
        public NPosfija APosfija()   //YA ESTA FUNCIONAL EL METODO APosfija()
        {
            //Usamos la clase pila para almacenar correctamente los datos

            Pila signos = new Pila(notacion.Length);

            //La cadena "nuevaNotacion" inicia como vacia.
            string nuevaNotacion = string.Empty;

            //Este bucle inspeccionará de "char" en "char" de la cadena "notacion"
            for (int i = 0; i < notacion.Length; i++)
            {
                //si el caracter actual no es signo se añadirá directamente a la nueva notación
                if (!Signos.signos.Contains(notacion[i]))
                {
                    nuevaNotacion += notacion[i];
                }
                else
                {
                    nuevaNotacion += " ";
                    //de no serlo, realizará las siguientes acciones para cada operador. 
                    if (notacion[i] == '^')
                    {
                        //Mientras que la pila signos no esté vacia y la cima del signo sea "^"
                        //se desapilarán y agregarán a la nueva Notación.
                        while (signos.getNumEle() != 0 && (char)signos.Cima() == '^')
                            nuevaNotacion += signos.Desapilar() + " ";
                        //El signo de potencia se apila dentro de la pila signos. 
                        signos.Apilar(notacion[i]);
                    }
                    else if (notacion[i] == '*' || notacion[i] == '/')
                    {
                        //La misma condición anterior, pero con los signos "+" y "-"
                        while (signos.getNumEle() != 0 && (char)signos.Cima() != '+' && (char)signos.Cima() != '-'
                            && (char)signos.Cima() != '(')
                            nuevaNotacion += signos.Desapilar() + " ";
                        signos.Apilar(notacion[i]);
                    }
                    else if (notacion[i] == '+' || notacion[i] == '-')
                    {
                        while (signos.getNumEle() != 0 && (char)signos.Cima() != '(')
                            nuevaNotacion += signos.Desapilar() + " ";
                        signos.Apilar(notacion[i]);
                    }
                    //Si es "(" se apila dentro de la pila signos
                    else if (notacion[i] == '(') signos.Apilar(notacion[i]);
                    else if (notacion[i] == ')')
                    {
                        //Al ser ")" desapilará todos los signos hasta encontrar el simbolo "("
                        while (signos.getNumEle() > 0 && (char)signos.Cima() != '(')
                            nuevaNotacion += signos.Desapilar() + " ";
                        //desapila el simbolo restante, que será "("
                        signos.Desapilar();
                    }
                }
            }
            //Por útlimo, mientras que la pila signos no esté vacía. Se desapilarán los signos
            //hasta quedarse vacía y se guardarán en la cadena nuevaNotacion. 
            nuevaNotacion += " ";
            while (signos.getNumEle() != 0) nuevaNotacion += signos.Desapilar() + " ";
            while (nuevaNotacion.Contains("  ")) nuevaNotacion = nuevaNotacion.Replace("  ", " ");

            //Regresa la nueva notación. 
            return new NPosfija(nuevaNotacion);
        }

        /// <summary>
        /// Regresa la notación en string. 
        /// </summary>
        /// <returns>El atributo notación.</returns>
        public override string ToString()
        {
            return notacion;
        }
    }

    /// <summary>
    /// Es la clase de Notación Posfija. 
    /// </summary>
    internal class NPosfija
    {
        ///atributo principal de la notación, permite manejar a los diferentes métodos. 
        string notacion;

        /// <summary>
        /// Constructor de la clase Notación Posfija. 
        /// </summary>
        /// <param name="notacion">El atributo notación debe estar correctamente escrito.</param>
        public NPosfija(string notacion)
        {
            this.notacion = notacion;
        }

        /// <summary>
        /// Regresa su versión de Notación a Notación Infija
        /// </summary>
        /// <returns>Regresa la clase Notación Infija</returns> 
        public NInfija AInfija()
        {
            //Instanciamos la clase pila. Una cadena "nuevaNotacion" y una nueva cadena "notación".
            //Ambas cadenas empezarán vacias. 

            string nuevaNotacion = string.Empty;
            string notacion = string.Empty;
            Pila pila = new Pila(this.notacion.Length);

            //Por cada "char" que haya en la notación de la clase se realizará:
            foreach (char c in this.notacion)
            {
                //Si es signo se desapila el ultimo valor apilado en pila y es almacenado en notacion,
                //Luego se apila nuevamente el nuevo utimo valor y agregamos el signo
                //con el valor almacenado en notacion.
                if (Signos.signos.Contains(c))
                {
                    notacion = (string)pila.Desapilar();
                    pila.Apilar((string)pila.Desapilar() + c + notacion);
                }
                //de no ser signo, solo se almacena el "char" actual del foreach. 
                else
                {
                    pila.Apilar(c + "");
                }
            }
            //Al ultimo, vaciamos la pila almacenando los valores guardados en pila a la nuevaNotacion.
            while (pila.getNumEle() > 0) nuevaNotacion += pila.Desapilar();

            //Regresamos el objeto de tipo Notacion Infija.
            return new NInfija(nuevaNotacion);
        }

        /// <summary>
        /// Convierte la clase notación a tipo string
        /// </summary>
        /// <returns>El atributo notación</returns>
        public override string ToString()
        {
            return notacion;
        }

        public double CalcularResultado(string notacion)
        {
            //Le quito el ultimo espacio de txtResultado
            notacion.Substring(0, notacion.Length - 1);
            notacion = notacion.Replace(".", ",");

            // Dividimos la expresión en tokens utilizando el espacio como delimitador
            string[] tokens = notacion.Split(' ');

            Pila pila_aux = new Pila(tokens.Length / 2); 

            foreach (string token in tokens)
            {
                // Si el token es un número, lo agregamos a la pila
                if (double.TryParse(token, out double number))
                {
                    pila_aux.Apilar(number);
                }
                else if (token == "") continue;
                else
                {
                    // Si el token es un operador, realizamos la operación correspondiente
                    double operand2 = Convert.ToDouble(pila_aux.Desapilar());
                    double operand1 = Convert.ToDouble(pila_aux.Desapilar());

                    switch (token)
                    {
                        case "+":
                            pila_aux.Apilar(operand1 + operand2);
                            break;
                        case "-":
                            pila_aux.Apilar(operand1 - operand2);
                            break;
                        case "*":
                            pila_aux.Apilar(operand1 * operand2);
                            break;
                        case "/":
                            pila_aux.Apilar(operand1 / operand2);
                            break;
                        case "^":
                            pila_aux.Apilar(Math.Pow(operand1,operand2));
                            break;
                        default:
                            throw new ArgumentException("Token inválido: " + token);
                    }
                }
            }

            
            // El resultado final estará en la cima de la pila
            return Convert.ToDouble(pila_aux.Desapilar());
            
        }
    }
}