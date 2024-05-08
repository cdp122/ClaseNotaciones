using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseNotaciones
{
    internal class TransInfPost
    {
        Pila p;
        String expInf;
        char[] arrInf;
        char[] arrPost;
        int nCar;

        public TransInfPost(String expInf)
        {
            this.expInf = expInf;
            nCar = expInf.Length;
            this.p = new Pila(nCar);
            this.arrInf = new char[nCar];
            this.arrPost = new char[nCar];
        }

        public void ConvertirArregloInfijo()
        {
            for (int i = 0; i < nCar; i++)
            {
                arrInf[i] = (char)expInf[i];
            }
        }

        public int Prioridad(char car)
        {
            int prior = -1;
            switch (car)
            {
                case '+':
                case '-':
                    {
                        prior = 1;
                        break;
                    }
                case '*':
                case '/':
                    {
                        prior = 2;
                        break;
                    }
                case '^':
                    {
                        prior = 3;
                        break;
                    }
                case '(':
                    {
                        prior = 0;
                        break;
                    }
                case ')':
                    {
                        prior = 0;
                        break;
                    }
            }
            return prior;
        }

        public void TransformarPostfijo()
        {
            int j = 0;
            for (int i = 0; i < this.nCar; i++)
            {
                if (Prioridad(arrInf[i]) == -1)
                { // si es letra 
                    this.arrPost[j] = arrInf[i]; // poner en arreglo post
                    j++;
                }
                else if (Prioridad(arrInf[i]) == 0)
                { // Si es un parentesis
                    if (arrInf[i] == '(')
                    { // si es un parentesis de apertura
                        p.Apilar(arrInf[i]); // apilar directamente
                    }
                    else
                    { // si es un parentesis de cierre
                        while ((char)p.Cima() != '(')
                        { // Desapilar elementos hasta encontrar un parentesis abierto
                            arrPost[j] = (char)p.Desapilar();
                            j++;
                        }
                        p.Desapilar(); // desapilar el parentesis abierto sin apilarlo en arrPost
                    }
                }
                else
                { // Si es un signo distinto de parentesis
                    if (p.Vacia() || Prioridad(arrInf[i]) > Prioridad((char)p.Cima()))
                    { // si la pila está vacia o el signo tiene mayor prioridad que el de la cima
                        p.Apilar(arrInf[i]);
                    }
                    else
                    { // si el signo tiene menor o igual prioridad que el de la cima
                        while (!p.Vacia() && Prioridad(arrInf[i]) <= Prioridad((char)p.Cima()))
                        { // mientras no esté vacía y 
                          // el signo tenga menor o igual prioridad que el de la cima
                            arrPost[j] = (char)p.Desapilar();
                            j++;
                        }
                        p.Apilar(arrInf[i]);
                    }
                }
            }
            while (!p.Vacia())
            { //desapila todo al acabar el arrInf
                arrPost[j] = (char)p.Desapilar();
                j++;
            }
        }


        public String RetornarExpPostfija()
        {
            String r = "";
            for (int i = 0; i < nCar; i++)
            {
                r += arrPost[i];
            }
            return r;
        }
    }
}
