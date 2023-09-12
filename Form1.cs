using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_File_csv_Accesso_diretto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string n;
        char de = ';';

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Istruzione1();
            MessageBox.Show("Istruzione eseguita correttamente");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il numero di campi è: " + Class1.Istruzione2());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il numero di caratteri è: " + Class1.Istruzione3());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int contatore = 7;
            listView1.Clear(); // pulizia della listview
            int[] MaxC = new int[contatore];//Dichiaro l'array massimoo numero di caratteri(MaxC)
            MaxC = Class1.Istruzione3A();//pongo l'array uguale alla funzione Istruzione3A
            for (int i = 0; i < contatore; i++)//ciclo for che mi permette di visualizzare i valori dell'array nella listview
            {
                listView1.Items.Add(MaxC[i].ToString());//visualizzazione dei valori dell'array nella listview
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Class1.Istruzione4();//richiamo alla funzione 4
            MessageBox.Show("Istruzione 4 eseguita con successo");//messaggio di output che indica che la funzione 4 è stata eseguita con successo
        }
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Show();//funzione che mostra la groupbox1
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Class1.Istruzione5(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);//richiamo alla funzione 5
            MessageBox.Show("Istruzione 5 eseguita con successo");//messaggio di output che indica che la funzione 5 è stata eseguita con successo
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int i = 0;//dichiaro la variabile i
            StreamReader reader = new StreamReader("masserini1.csv");//dichiaro lo streamreader
            n = reader.ReadLine();//pongo la variabile n uguale alla lettura della prima riga del file
            while (n != null)//ciclo while che mi permette di leggere tutte le righe del file
            {
                String[] split = n.Split(de);//dichiaro un array di stringhe
                String[] split1 = split[5].Split(' ');//dichiaro un array di stringhe
                if (split1[0] == "false")//se split1 è uguale a false
                {
                    listView1.Items.Add(split[0] + de + split[1] + de + split[2]);//aggiungo alla listview i 3 campi
                }
                i++;//incremento i
                n = reader.ReadLine();//leggo la riga successiva
            }
            reader.Close();//chiudo lo streamreader
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.Show();//funzione che mostra la groupbox2
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int L = Class1.Istruzione7(textBox7.Text);//pongo la variabile L uguale alla funzione 7
            if (L != -1)//se L è diverso da -1
            {
                MessageBox.Show("Il tuo valore è stato trovato alla riga " + L);//messaggio di output che indica la riga in cui è stato trovato il valore
            }
            else//altrimenti
            {
                MessageBox.Show("La ricerca non ha avuto successo");//messaggio di output che indica che la ricerca non ha avuto successo
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Show();//funzione che mostra la groupbox1
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int linea = Class1.Istruzione7(textBox7.Text);
            Class1.Istruzione8(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, linea);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox3.Show();//funzione che mostra la groupbox3
        }
        private void button14_Click(object sender, EventArgs e)
        {
            Class1.Istruzione9(textBox9.Text);//richiamo alla funzione 9
        }

       
    }
}
