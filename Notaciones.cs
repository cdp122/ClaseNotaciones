using System.Collections.Generic;
using System.Linq;

namespace ClaseNotaciones
{
    abstract class Signos
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
            Stack<char> pila = new Stack<char>();
            string nuevaNotacion = string.Empty;
            foreach (char c in notacion)
            {
                if (!Signos.signos.Contains(c)) nuevaNotacion += c;
                else
                {
                    if (c == '^')
                    {
                        while (pila.Count != 0 && pila.First() == '^')
                            nuevaNotacion += pila.Pop();
                        pila.Push(c);
                    }
                    else if (c == '*' || c == '/')
                    {

                        while (pila.Count != 0 && pila.First() != '+' && pila.First() != '-'
                            && pila.First() != '(')
                            nuevaNotacion += pila.Pop();
                        pila.Push(c);
                    }
                    else if (c == '+' || c == '-')
                    {
                        while (pila.Count != 0 && pila.First() != '(')
                            nuevaNotacion += pila.Pop();
                        pila.Push(c);
                    }
                    else if (c == '(') pila.Push(c);
                    else if (c == ')')
                    {
                        while (pila.Count > 0 && pila.First() != '(')
                        {
                            nuevaNotacion += pila.Pop();
                        }
                        pila.Pop();
                    }
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
            string c = string.Empty;
            for (int i = 0; i < notacion.Length; i++)
            {
                if (Signos.signos.Contains(notacion[i]))
                {
                    c = pila.Pop();
                    pila.Push(pila.Pop() + notacion[i] + c);
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