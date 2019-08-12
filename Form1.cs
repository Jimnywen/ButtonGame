using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonGame
{
    public partial class Form1 : Form
    {
        const int N = 4;
        Button[,] buttons = new Button[4, 4];


        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateAllButtons();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Shuffle();

        }
        void GenerateAllButtons()
        {
            for (int r = 1; r <= N; r++)
            {
                for (int c = 1; c <= N; c++)
                {
                    int w = 48, d = 50;
                    int num = (r - 1) * N + c;
                    Button btn = new Button();
                    btn.Text = num.ToString();
                    btn.Width = w;
                    btn.Height = w;
                    btn.Top = r * d ;
                    btn.Left = c * d;
                    btn.Visible = true;
                    btn.Tag = (r - 1) * N + c-1;



                    btn.Click += new EventHandler(btn_Click);

                    buttons[r-1, c-1] = btn;
                    this.Controls.Add(btn);
                }
            }
            buttons[3, 3].Visible = false;



        }
        void Swap(Button btn1,Button btn2)
        {
            string str = btn1.Text;
            btn1.Text = btn2.Text;
            btn2.Text = str;


            bool v = btn1.Visible;
            btn1.Visible = btn2.Visible;
            btn2.Visible = v;


        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btnChose = sender as Button;
            Button blank = FindVisibleBtn();
            if (IsNeighbor(btnChose,blank))
                //判断
            {
                Swap(btnChose, blank);
                blank.Focus();
            }
            
        }
        Button FindVisibleBtn()
        {
            for (int r = 1; r <= N; r++)
            {
                for (int c = 1; c <= N; c++)
                {
                    if (!buttons[r-1,c-1].Visible)
                    {
                        return buttons[r-1, c-1];
                    }
                }
            }
            return null;
        }
        bool IsNeighbor(Button btnA, Button btnB)

        {
            int a = (int)btnA.Tag; //Tag中记录是行列位置
            int b = (int)btnB.Tag;
            int r1 = a / N, c1 = a % N;
            int r2 = b / N, c2 = b % N;

            if (r1 == r2 && (c1 == c2 - 1 || c1 == c2 + 1) //左右相邻
                || c1 == c2 && (r1 == r2 - 1 || r1 == r2 + 1))
                return true;

            return false;
        }

        void Shuffle()
        {
            

                //多次随机交换两个按钮

                Random rnd = new Random();

                for (int i = 0; i < 100; i++)

                {

                    int a = rnd.Next(N);

                    int b = rnd.Next(N);

                    int c = rnd.Next(N);

                    int d = rnd.Next(N);

                    Swap(buttons[a, b], buttons[c, d]);

                }

            

        }



        public Form1()
        {
            InitializeComponent();
        }

        

     
    }
}
