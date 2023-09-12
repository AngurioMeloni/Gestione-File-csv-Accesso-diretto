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
        public static int Istruzione2()
        {
            string s;
            int num;
            StreamReader reader = new StreamReader("masserini1.csv");
            s = reader.ReadLine();
            reader.Close();
            return num = s.Split(';').Length;
        }
        public static int Istruzione3()
        {
            StreamReader reader = new StreamReader("masserini1.csv");
            int ls = 0, lm = 0, i = 0;
            string s;

            s = reader.ReadLine();
            while (s != null)
            {
                ls = s.Length;
                if (i != 0)
                {
                    if (lm < ls)
                    {
                        lm = s.Length;
                    }
                }
                s = reader.ReadLine();
                i++;
            }
            reader.Close();
            return lm;
        }
        public static int[] Istruzione3A()
        {
            StreamReader reader = new StreamReader("masserini1.csv");
            string r = reader.ReadLine();
            int[] lm = new int[Istruzione2()];
            int a = 0;
            r = reader.ReadLine();

            while (r != null)
            {
                string[] split = r.Split(';');
                string[] array = new string[Istruzione2()];

                for (int i = 0; i < Istruzione2(); i++)
                {
                    reader.DiscardBufferedData();
                    reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                    r = reader.ReadLine();
                    a = 0;
                    while (r != null)
                    {
                        string[] stringaSplit = r.Split(';');
                        if (a != 0)
                        {
                            if (lm[i] < stringaSplit[i].Length)
                            {
                                lm[i] = stringaSplit[i].Length;
                            }

                        }
                        r = reader.ReadLine();
                        a++;
                    }
                }
            }
            reader.Close();
            return lm;
        }
        public static void Istruzione4()
        {
            string s;
            int i = 0;
            StreamReader reader = new StreamReader("masserini1.csv");
            StreamWriter writer = new StreamWriter("temporaneo.csv");

            s = reader.ReadLine();
            while (s != null)
            {
                if (i != 0)
                {
                    writer.WriteLine(s.PadRight(200));
                }
                else
                {
                    writer.WriteLine(s.PadRight(200));
                }

                s = reader.ReadLine();
                i++;
            }

            reader.Close();
            writer.Close();

            File.Replace("temporaneo.csv", "masserini1.csv", "backup.csv");
        }
        public static void Istruzione5(string anno, string nazioni, string MKwh, string note, string Vrandom, string Vbooleano)
        {
            int i = 0;
            StreamReader reader = new StreamReader("masserini1.csv");
            string line = reader.ReadLine();
            while (line != null)
            {
                i++;
                line = reader.ReadLine();
            }
            reader.Close();
            var oStream = new FileStream("masserini1.csv", FileMode.Append, FileAccess.Write, FileShare.Read);
            BinaryWriter writer = new BinaryWriter(oStream);
            string l = $"{anno};{nazioni};{MKwh};{note};{Vrandom};{Vbooleano};{i}".PadRight(200);
            byte[] data = Encoding.ASCII.GetBytes(l);
            writer.Write(data);

            writer.Close();
            oStream.Close();
        }
    }
}
