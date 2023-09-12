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
            Random r = new Random();
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
        public static int Istruzione7(string parola)
        {
            StreamReader reader = new StreamReader("masserini.csv");
            string s;
            int i = 0;
            s = reader.ReadLine();
            while (s != null)
            {

                String[] split = s.Split(';');
                String[] split1 = split[Istruzione2() - 1].Split(' ');

                if (split1[0] == parola)
                {
                    reader.Close();
                    return i;
                }

                i++;
                s = reader.ReadLine();

            }
            reader.Close();
            return -1;
        }
        public static void Istruzione8(string anno, string regione, string Mkwh, string note, string Vrandom, string Vbooleano, int linea)
        {
            var oStream = new FileStream("masserini1.csv", FileMode.Open, FileAccess.Write, FileShare.Read);
            BinaryWriter writer = new BinaryWriter(oStream);

            oStream.Seek(0, SeekOrigin.Begin);

            oStream.Seek((200 * linea), SeekOrigin.Current);
            string s = $"{anno};{regione};{Mkwh};{note};{Vrandom};{Vbooleano};{linea}".PadRight(200);
            byte[] data = Encoding.ASCII.GetBytes(s);
            writer.Write(data);

            writer.Close();
        }
        public static int Istruzione9(string ricerca)
        {
            int riga = Istruzione7(ricerca);
            int i = 0;
            int successo = 0;
            var readStream = new FileStream("masserini1.csv", FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader read = new BinaryReader(readStream);

            //Legge i dati e li converte in stringa
            readStream.Seek(0, SeekOrigin.Begin);
            readStream.Seek((200 * riga), SeekOrigin.Current);

            byte[] data = new byte[200];
            readStream.Read(data, 0, 200);
            string s = Encoding.ASCII.GetString(data);

            readStream.Close();
            read.Close();

            String[] split = s.Split(';');
            String[] split1 = split[7].Split(' ');

            var writeStream = new FileStream("masserini1.csv", FileMode.Open, FileAccess.Write, FileShare.Write);
            BinaryWriter writer = new BinaryWriter(writeStream);

            writeStream.Seek(0, SeekOrigin.Begin);
            writeStream.Seek((200 * riga), SeekOrigin.Current);

            //Scrive i dati
            string linea = $"{split[0]};{split[1]};{split[2]};{split[3]};{split[4]};{split[5]};true;{split[7]}".PadRight(200);
            byte[] data2 = Encoding.ASCII.GetBytes(linea);
            writer.Write(data2);
            successo = 1;

            writer.Close();
            writeStream.Close();

            return successo;
        }
    }
}
