using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.VisualBasic;

namespace ReportMaker
{
    public class Funkcja
    {
        public double Średnia(double[] tablica)
        {
            double średnia = 0;

            for (int n = 0; n < tablica.Length; n++)
            {
                średnia = średnia + tablica[n];
            }
            return średnia / tablica.Length;
        }

        internal static double diffAdd(double Dx, double Dy)  // f = x + y ALBO f = x - y
        {
            return Dx + Dx;
        }

        internal static double diffMultiply(double x, double Dx, double y, double Dy) // f = x * y
        {
            return Math.Abs(y) * Dx + Math.Abs(x) * Dy;
        }

        internal static double diffDivide(double x, double Dx, double y, double Dy) // f = x / y
        {
            return Math.Abs(1 / y) * Dx + Math.Abs(x / (y * y)) * Dy;
        }

        internal static double diffLogarithm(double x, double Dx) // f(x) = ln(x)
        {
            return Math.Abs(1 / x) * Dx;
        }

        internal static double diffExp(double x, double Dx) // f(x) = exp(x)
        {
            return Math.Exp(x) * Dx;
        }

        internal static double diffPower(double x, double Dx, int n)  // f(x) = x^n
        {
            return Math.Abs(n * Math.Pow(x, n - 1)) * Dx;
        }

    }

    public class Oblicz
    {
          static public void Count(double[] x, double[] y, int zmienna_warunkowa, ref double Xsr, ref double Ysr, ref double[] Dx, ref double[] Dy, ref double[] Df, ref double Fsr)
        {
            int n = x.Length;
            Dx = new double[n];
            Dy = new double[n];
            Df = new double[n];

            int i = 0;

            double suma = 0;
            for (i = 0; i < n; i++)
            {
                suma += x[i];
            }
            Xsr = suma / n;

            suma = 0;
            for (i = 0; i < n; i++)
            {
                suma += y[i];
            }
            Ysr = suma / n;

            for (i = 0; i < n; i++)
            {
                Dx[i] = Math.Abs(Xsr - x[i]);
                Dy[i] = Math.Abs(Ysr - y[i]);
            }

            switch (zmienna_warunkowa)
            {
                case 0:
                    for (i = 0; i < n; i++)
                    {
                        Df[i] = Funkcja.diffAdd(Dx[i], Dy[i]);
                    }
                    break;


                case 1:
                    for (i = 0; i < n; i++)
                    {
                        Df[i] = Funkcja.diffAdd(Dx[i], Dy[i]);
                    }
                    break;


                case 2:
                    {
                        for (i = 0; i < n; i++)
                        {
                            Df[i] = Funkcja.diffMultiply(x[i], Dx[i], y[i], Dy[i]);
                        }
                        break;
                    }

                case 3:
                    {
                        for (i = 0; i < n; i++)
                        {
                            Df[i] = Funkcja.diffDivide(x[i], Dx[i], y[i], Dy[i]);
                        }
                        break;
                    }

                case 4:
                    {
                        for (i = 0; i < n; i++)
                        {
                            Df[i] = Funkcja.diffLogarithm(x[i], Dx[i]);
                        }
                        break;
                    }

                case 5:
                    {
                        for (i = 0; i < n; i++)
                        {
                            Df[i] = Funkcja.diffExp(x[i], Dx[i]);
                        }
                        break;
                    }

                case 6:
                    {
                        for (i = 0; i < n; i++)
                        {  
                            int N = int.Parse(Interaction.InputBox("Podaj n (dla wzoru x^n)", "Potrzebuje wartości by to policzyć xD", ""));
                            Df[i] = Funkcja.diffPower(x[i], Dx[i], N);
                        }
                        break;
                    }

            }

            Fsr = Df.Sum() / Df.Length;



        }
    }
}