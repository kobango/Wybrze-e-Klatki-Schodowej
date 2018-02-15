using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReportMaker
{
    public class InputOutput
    {
        public static void Odczyt(string path, ref double[] x, ref double[] y)
        {
            StreamReader sr = new StreamReader(path);

            int i = 0;

            while (sr.ReadLine() != null)
            {
                i++;
            }

            sr.Close();

            x = new double[i];
            y = new double[i];

            StreamReader Sr = new StreamReader(path);

            for (int j = 0; j < i; j++)
            {
                string alfa = Sr.ReadLine();
                string[] beta = alfa.Split('\t');
                x[j] = double.Parse(beta[0]);
                y[j] = double.Parse(beta[1]);
            }

            Sr.Close();
        }

        public static void ZapiszW(string path, double[] x, double[] y)
        {
            StreamWriter wr = new StreamWriter(path);
            for (int i = 0; i < y.Length; i++)
            {
                wr.Write(x[i]); wr.Write('\t'); wr.WriteLine(y[i]);
            }

            wr.Close();
        }
        public static void Zapisz(string path, double[] x, double[] y, double[] dx, double[] dy, double[] df, double xsr, double ysr, double fśr, double wynik)
        {
            StreamWriter wr = new StreamWriter(path);
            wr.Write("średnia x: ");
            wr.Write('\t');
            wr.Write("średnia y: ");
            wr.Write('\t');
            wr.Write("błąd: ");
            wr.Write('\t');
            wr.WriteLine("wynik: ");
            wr.Write(xsr); wr.Write('\t'); wr.Write('\t'); wr.Write(ysr); wr.Write('\t'); wr.Write('\t'); wr.Write(fśr);  wr.Write('\t'); wr.WriteLine(wynik);
            wr.WriteLine();
            wr.Write("x: ");
            wr.Write('\t');
            wr.Write("y: ");
            wr.Write('\t');
            wr.Write("dx: ");
            wr.Write('\t');
            wr.Write("dy: ");
            wr.Write('\t');
            wr.WriteLine("df: ");
            for (int i = 0; i < y.Length; i++)
            {
                wr.Write(x[i]); wr.Write('\t'); wr.Write(y[i]); wr.Write('\t'); wr.Write(dx[i]);
                wr.Write('\t'); wr.Write(dy[i]); wr.Write('\t'); wr.Write(df[i]); wr.WriteLine('\t');
            }
            wr.Close();

        }
    }
}
