﻿using System;
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

        public void Apilar(Object elemento)
        {
            Arreglo[numEle++] = elemento;
         }

        public Object Desapilar()
        {
            if (numEle != 0 && numEle > 0)
                return Arreglo[--numEle];
            else return null;
        }

        public bool Vacia()
        {
            return numEle == 0;
        }

        public bool Llena()
        {
            return numEle == tam;
        }
        public Object Cima()
        {
            return Arreglo[numEle - 1];
        }

        public bool minElem() 
        {
            return numEle >= 2;
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
        public Object[] getArreglo()
        {
            return Arreglo;
        }

        public void setArreglo(Object[] Arreglo)
        {
            this.Arreglo = Arreglo;
        }
    }
}
