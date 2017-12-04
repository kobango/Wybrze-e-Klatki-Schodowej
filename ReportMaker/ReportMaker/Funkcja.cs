using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMaker
{
    public class Funkcja
    {
        public double Suma(double x, double y)
        {
            double wynik;
            return wynik = x + y;
        }

        public double Roznica(double x, double y)
        {
         
            return  x - y;
        }

        public double Iloczyn(double x, double y)
        {
          
            return  x * y;
        }
        public double Iloraz(double x, double y)
        {
            
            return   x / y;
        }
        public double Logarytm_Naturalny(double x)
        {
            return Math.Log(x);
        }
        public double Exp(double x)
        {
            return Math.Exp(x);
        }
        public double Potegowanie(double x,double n)
        {
            return Math.Pow(x, n);
        }
    }




    


    
}
