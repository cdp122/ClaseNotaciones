using System.Collections.Generic;
using System.Linq;

namespace ClaseNotaciones
{
    abstract class Signos //RAMA DONDE VOY A HACER ALGUNOS CAMBIOS 
    {
        public static char[] signos = new char[] { '+', '-', '*', '/', '^', '(', ')' };
    }

    internal class NInfija
    {
        string notacion;

        public NInfija(string notacion)
        {
            this.notacion = notacion;
        }

        public NPosfija APosfija()
        {
            Stack<string> pila = new Stack<string>();
            string nuevaNotacion = string.Empty;
            int ini, fin;
            ini = 0;
            for(int i = 0; i < notacion.Length; i++)
            {
                if (!Signos.signos.Contains(notacion[i])) { }
                else
                {
                    fin = i - 1;
                    if (notacion[i] == '^')
                    {
                        while (pila.Count != 0 && pila.First() == "^")
                            nuevaNotacion += pila.Pop();
                        pila.Push(notacion.Substring(ini, fin) + "^");
                    }
                    else if (notacion[i] == '*' || notacion[i] == '/')
                    {

                        while (pila.Count != 0 && pila.First() != "+" && pila.First() != "-"
                            && pila.First() != "(")
                            nuevaNotacion += pila.Pop();
                        pila.Push(notacion.Substring(ini, fin) + notacion[i]);
                    }
                    else if (notacion[i] == '+' || notacion[i] == '-')
                    {
                        while (pila.Count != 0 && pila.First() != "(")
                            nuevaNotacion += pila.Pop();
                        pila.Push(notacion.Substring(ini, fin) + notacion[i]);
                    }
                    else if (notacion[i] == '(') pila.Push(notacion[i] + "");
                    else if (notacion[i] == ')')
                    {
                        while (pila.Count > 0 && pila.First() != "(")
                        {
                            nuevaNotacion += pila.Pop();
                        }
                        pila.Pop();
                    }
                    ini = fin + 1;
                }
            }
            while (pila.Count != 0) nuevaNotacion += pila.Pop();
            return new NPosfija(nuevaNotacion);
        }

        public override string ToString()
        {
            return notacion;
        }
    }

    internal class NPosfija
    {
        string notacion;

        public NPosfija(string notacion)
        {
            this.notacion = notacion;
        }

        public NInfija AInfija()
        {
            Stack<string> pila = new Stack<string>();
            string nuevaNotacion = string.Empty;
            string notacion = string.Empty;
            for (int i = 0; i < notacion.Length; i++)
            {
                if (Signos.signos.Contains(notacion[i]))
                {
                    notacion = pila.Pop();
                    pila.Push(pila.Pop() + notacion[i] + notacion[i]);
                }
                else
                {
                    pila.Push(notacion[i] + "");
                }
            }
            while (pila.Count > 0)
            {
                nuevaNotacion += pila.Pop();
            }
            return new NInfija(nuevaNotacion);
        }

        public override string ToString()
        {
            return notacion;
        }
    }

    internal class NPrefija
    {

    }
}