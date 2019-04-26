using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace WindowsFormsApp22
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine sentitizzatore = new SpeechRecognitionEngine();
        SpeechSynthesizer jarvis = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Sentitizzatore_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox1.Text = e.Result.Text.ToString();
            string parola = e.Result.Text;
            if (parola == "ciao")
            {
                jarvis.Speak("ciao come va");
            }
            if (parola == "e tu")
            {
                jarvis.Speak("bene grazie");
            }
            if (parola == "apri google")
            {
                jarvis.Speak("lo sto aprendo");
                System.Diagnostics.Process.Start("http://www.google.com");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choices testo = new Choices();
            testo.Add(new string[] { "ciao"+"apri google" });
            Grammar newlista = new Grammar(testo);
            sentitizzatore.RequestRecognizerUpdate();
            sentitizzatore.LoadGrammar(newlista);
            sentitizzatore.RecognizeAsync(RecognizeMode.Multiple);
            sentitizzatore.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Sentitizzatore_SpeechRecognized);

        }
    }
}
