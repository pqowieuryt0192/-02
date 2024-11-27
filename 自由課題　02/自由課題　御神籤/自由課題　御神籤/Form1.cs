using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自由課題_御神籤
{
    
        
        public partial class Form1 : Form
        {
            private Button[] buttons;
            private string[] fortunes = {
            "大吉", // Great blessing
            "中吉", // Middle blessing
            "小吉", // Small blessing
            "吉",   // Blessing
            "末吉", // Future blessing
            "凶",    // Curse
           "大凶"   //Great curse
        };
            private string[] shuffledFortunes;//クラスレベルで宣言

            public Form1()
            {
                InitializeComponent();

                this.Text = "御神籤";
                this.Size = new System.Drawing.Size(400, 300);

                buttons = new Button[fortunes.Length];
                Random random = new Random();
                shuffledFortunes = ShuffleArray(fortunes, random);//コンストラクタ内で初期化

                int rows = 2; // 行数
                int cols = 4; // 列数
                int buttonWidth = 100;
                int buttonHeight = 50;
                int padding = 10;


                for (int i = 0; i < fortunes.Length; i++)
                {
                    buttons[i] = new Button();
                    buttons[i].Text = "御神籤";
                    buttons[i].Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                    int row = i / cols;
                    int col = i % cols;
                    buttons[i].Location = new System.Drawing.Point(padding + col * (buttonWidth + padding), padding + row * (buttonHeight + padding));
                    buttons[i].Click += new EventHandler(this.Button_Click);
                    this.Controls.Add(buttons[i]);
                }
            }

            private void Button_Click(object sender, EventArgs e)
            {
                Button clickedButton = sender as Button;
                int index = Array.IndexOf(buttons, clickedButton);
                if (index >= 0 && index < shuffledFortunes.Length)
                {
                    MessageBox.Show("あなたの御神籤の結果は: " + shuffledFortunes[index]);
                }
            }

            private string[] ShuffleArray(string[] array, Random random)
            {
                string[] shuffledArray = (string[])array.Clone();
                for (int i = shuffledArray.Length - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);
                    string temp = shuffledArray[i];
                    shuffledArray[i] = shuffledArray[j];
                    shuffledArray[j] = temp;
                }
                return shuffledArray;
            }
        }
    }
    

