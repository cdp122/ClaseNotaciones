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
        Stack<char> signos = new Stack<char>();
        Stack<string> operandos = new Stack<string>();

        string notacion; 

        public NInfija(string notacion)
        {
            this.notacion = notacion;
        }

        public NPosfija APosfija()
        {
            string nuevaNotacion = string.Empty;
            int ini, fin;
            ini = 0;
            for(int i = 0; i < notacion.Length; i++)
            {
                if (!Signos.signos.Contains(notacion[i])) { nuevaNotacion += notacion[i]; }
                else
                {
                    fin = i - 1;
                    operandos.Push(notacion.Substring(ini, fin - ini + 1));
                    ini = fin + 1;
                    if (notacion[i] == '^')
                    {
                        while (signos.Count != 0 && signos.First() == '^')
                            nuevaNotacion += signos.Pop();
                        signos.Push(notacion[i]);
                    }
                    else if (notacion[i] == '*' || notacion[i] == '/')
                    {

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
                    else if (notacion[i] == '(') signos.Push(notacion[i]);
                    else if (notacion[i] == ')')
                    {
                        while (signos.Count > 0 && signos.First() != '(')
                        {
                            nuevaNotacion += signos.Pop();
                        }
                        signos.Pop();
                    }
                }
            }
            while (signos.Count != 0) nuevaNotacion += signos.Pop();
            return new NPosfija(nuevaNotacion);
        }

        //Este método aún no es funcional. 
        public float Resolver()
        {
            if (signos.Count != 0 || operandos.Count != 0) APosfija();
            else
            {
                float a, b;
                while (signos.Count != 0 && operandos.Count > 1) { 
                    b = signos.Pop(); a = signos.Pop();

                }
            }

            return 2;
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
            foreach(char c in this.notacion)
            {
                if (Signos.signos.Contains(c))
                {
                    notacion = pila.Pop();
                    pila.Push(pila.Pop() + c + notacion);
                }
                else
                {
                    pila.Push(c + "");
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