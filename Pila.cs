using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseNotaciones
{
    public class Pila
    {
        private int tam;
        private int numEle;
        private object[] Arreglo;

        public Pila(int tam)
        {
            this.tam = tam;
            this.numEle = 0;
            Arreglo = new object[tam];
        }

        public void Apilar(object elemento)
        {
            if (!Llena())
            {
                Arreglo[numEle++] = elemento;
            }
            else
            {
                throw new InvalidOperationException("La pila está llena.");
            }
        }

        public object Desapilar()
        {
            if (!Vacia())
            {
                return Arreglo[--numEle];
            }
            else
            {
                throw new InvalidOperationException("La pila está vacía.");
            }
        }

        public bool Vacia()
        {
            return numEle == 0;
        }

        public bool Llena()
        {
            return numEle == tam;
        }

        public object Cima()
        {
            if (!Vacia())
            {
                return Arreglo[numEle - 1];
            }
            else
            {
                throw new InvalidOperationException("La pila está vacía.");
            }
        }

        public int GetTam()
        {
            return tam;
        }

        public void SetTam(int tam)
        {
            this.tam = tam;
        }

        public int GetNumEle()
        {
            return numEle;
        }

        public void SetNumEle(int numEle)
        {
            this.numEle = numEle;
        }

        public object[] GetArreglo()
        {
            return Arreglo;
        }

        public void SetArreglo(object[] Arreglo)
        {
            this.Arreglo = Arreglo;
        }
    }

}
