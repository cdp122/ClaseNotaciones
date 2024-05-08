using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseNotaciones
{
    internal class Pila
    {
        private int tam;
        private int numEle;
        private Object[] Arreglo;

        public Pila(int tam)
        {
            this.tam = tam;
            this.numEle = 0;
            Arreglo = new Object[tam];

        }

        public void Apilar(object elemento)
        {
            Arreglo[numEle++] = elemento;
            //numEle++;
        }

        public object Desapilar()
        {
            numEle--;
            return Arreglo[numEle];
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
            return Arreglo[numEle - 1];
        }

        public int getTam()
        {
            return tam;
        }

        public void setTam(int tam)
        {
            this.tam = tam;
        }

        public int getNumEle()
        {
            return numEle;
        }

        public void setNumEle(int numEle)
        {
            this.numEle = numEle;
        }
        public object[] getArreglo()
        {
            return Arreglo;
        }

        public void setArreglo(object[] Arreglo)
        {
            this.Arreglo = Arreglo;
        }
    }
}
