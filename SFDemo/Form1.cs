using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoryFine;

namespace SFDemo
{
    public partial class Form1 : Form
    {
        GameEpisode ge;
        ISFModule m;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ge = new GameEpisode(
                delegate (SFSearcher s, ISFEpisode ep) {
                    switch (s.Id)
                    {
                        case "IS_CURRENT_TIME_EVEN":
                            return DateTime.Now.Second % 2 == 0;
                    }
                    return false;
                }
            );
            m = ge.entry.Next;
            tabControl1.SelectedIndex = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m = m.Next.Next;
            if(m.Id == "NOT_EVEN_FINAL") tabControl1.SelectedIndex = 2;
            else tabControl1.SelectedIndex = 3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((SFChoice)m).Choose(SFChoice.ChoiceResult.A);
            Continue();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((SFChoice)m).Choose(SFChoice.ChoiceResult.B);
            Continue();
        }

        private void Continue()
        {
            m = m.Next;
            if(m.Id == "EVEN_FINAL")
            {
                tabControl1.SelectedIndex = 4;
            }
            else
            {
                tabControl1.SelectedIndex = 5;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            m = m.Next;
            tabControl1.SelectedIndex = 6;
        }
    }
}
