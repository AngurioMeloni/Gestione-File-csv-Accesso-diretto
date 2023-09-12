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

    }
}
