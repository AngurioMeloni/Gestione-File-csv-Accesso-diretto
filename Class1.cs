using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_File_csv_Accesso_diretto
{
    internal class Class1
    {
        public static int Istruzione1()
        {
            string s;
            int i = 0;
            int c = 0;
            StreamWriter writer = new StreamWriter("masserini1.csv", append: false);
            if (File.Exists("masserini.csv"))
            {
                StreamReader reader = new StreamReader("masserini.csv");
                s = reader.ReadLine();
                while (s != null)
                {
                    if (i == 0)
                    {
                        writer.WriteLine(s + ";Valore Randomico;Campo Cancellazione Logica;Campo Univoco");
                    }
                    else
                    {
                        int valore = r.Next(10, 21);
                        writer.WriteLine(s + ";" + valore + ";false;" + i + "");
                    }
                    i++;
                    s = reader.ReadLine();
                }
                reader.Close();
            }
            else
            {
                c = 1;
            }
            writer.Close();

            return c;
        }
    }
}
