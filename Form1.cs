using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>();
        List<string> big = new List<string>();

        Label first, second;
        int cnt=0;
        public Form1()
        {
            InitializeComponent();
            assigning();  
        }

        private void label_click(object sender, EventArgs e)
        {
            if (first != null && second != null)
                return;

            Label clickedlbl = sender as Label;
            if(clickedlbl == null)
                return;

            if (clickedlbl.ForeColor == Color.Black)
                return;

            if(first == null)
            {
                first = clickedlbl;
                first.ForeColor = Color.Black;
                return;
            }

            second = clickedlbl;
            second.ForeColor = Color.Black;

            if(first.Text == second.Text)
            {
                first = null;
                second = null;
                cnt+=2;

                if(cnt==16)
                {
                    MessageBox.Show("Congratulation. You matched all.");
                    Close();
                }
            }
            else
                timer1.Start(); 

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;

            first = null;
            second = null;
        }

        private void assigning()
        {

            string s;
            char ch;
            Label label;
            int rndnom;

            for(int i=33; i<127; i++)
            {
                s = "";
                ch = Convert.ToChar(i);
                s = s+ch.ToString();

                big.Add(s);
                Console.WriteLine(big[i-33]);
            }

            Console.WriteLine(big.Count);

            for(int i=0; i<8; i++)
            {
                rndnom=random.Next(0,big.Count);
                icons.Add(big[rndnom]);
                icons.Add(big[rndnom]);

                big.RemoveAt(rndnom);
            }


            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else continue;

                rndnom = random.Next(0,icons.Count);
                label.Text = icons[rndnom];

                icons.RemoveAt(rndnom);
            }
        }
    }
}
