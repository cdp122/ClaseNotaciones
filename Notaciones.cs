using System.Collections.Generic;
using System.Linq;

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
        Pila p1; //declaro mi pila


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
        public NPosfija APosfija()
        {
            //Usamos la clase pila para almacenar correctamente los datos
            Stack<char> signos = new Stack<char>();
            
            //La cadena "nuevaNotacion" inicia como vacia.
            string nuevaNotacion = string.Empty;

            //Este bucle inspeccionará de "char" en "char" de la cadena "notacion"
            for(int i = 0; i < notacion.Length; i++)
            {
                //si el caracter actual no es signo se añadirá directamente a la nueva notación
                if (!Signos.signos.Contains(notacion[i])) { nuevaNotacion += notacion[i]; }
                else
                {
                    //de no serlo, realizará las siguientes acciones para cada operador. 
                    if (notacion[i] == '^')
                    {
                        //Mientras que la pila signos no esté vacia y la cima del signo sea "^"
                        //se desapilarán y agregarán a la nueva Notación.
                        while (signos.Count != 0 && signos.First() == '^')
                            nuevaNotacion += signos.Pop();
                        //El signo de potencia se apila dentro de la pila signos. 
                        signos.Push(notacion[i]);
                    }
                    else if (notacion[i] == '*' || notacion[i] == '/')
                    {
                        //La misma condición anterior, pero con los signos "+" y "-"
                        while (signos.Count != 0 && signos.First() != '+' && signos.First() != '-'
                            && signos.First() != '(')
                            nuevaNotacion += signos.Pop();
                        signos.Push(notacion[i]);
                    }
                    else if (notacion[i] == '+' || notacion[i] == '-')
                    {
                        while (signos.Count != 0 && signos.First() != '(')
                            nuevaNotacion += signos.Pop();
                        signos.Push(notacion[i]);
                    }
                    //Si es "(" se apila dentro de la pila signos
                    else if (notacion[i] == '(') signos.Push(notacion[i]);
                    else if (notacion[i] == ')')
                    {
                        //Al ser ")" desapilará todos los signos hasta encontrar el simbolo "("
                        while (signos.Count > 0 && signos.First() != '(')
                        {
                            nuevaNotacion += signos.Pop();
                        }
                        //desapila el simbolo restante, que será "("
                        signos.Pop();
                    }
                }
            }
            //Por útlimo, mientras que la pila signos no esté vacía. Se desapilarán los signos
            //hasta quedarse vacía y se guardarán en la cadena nuevaNotacion. 
            while (signos.Count != 0) nuevaNotacion += signos.Pop();

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
            Stack<string> pila = new Stack<string>();
            string nuevaNotacion = string.Empty;
            string notacion = string.Empty;

            //Por cada "char" que haya en la notación de la clase se realizará:
            foreach(char c in this.notacion)
            {
                //Si es signo se desapila el ultimo valor apilado en pila y es almacenado en notacion,
                //Luego se apila nuevamente el nuevo utimo valor y agregamos el signo
                //con el valor almacenado en notacion.
                if (Signos.signos.Contains(c))
                {
                    notacion = pila.Pop();
                    pila.Push(pila.Pop() + c + notacion);
                }
                //de no ser signo, solo se almacena el "char" actual del foreach. 
                else
                {
                    pila.Push(c + "");
                }
            }
            //Al ultimo, vaciamos la pila almacenando los valores guardados en pila a la nuevaNotacion.
            while (pila.Count > 0) nuevaNotacion += pila.Pop(); 

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
    }
}