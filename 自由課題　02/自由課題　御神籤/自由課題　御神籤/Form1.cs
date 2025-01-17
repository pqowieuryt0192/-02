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
        private Label titleLabel; //タイトルラベルを追加
        private Button[] buttons;
        private string[] fortunes = {
         "大吉",
         "中吉",
         "小吉",
         "吉",
         "末吉",
         "凶",
         "大凶"
        };
        private string[] luckyItems = {
         "お守り",
         "四葉のクローバー",
         "金色のペン",
         "ラッキーストーン",
         "ラッキーペンダント",
         "ラッキーコイン",
         "ラッキーブレスレット"
         };
        private string[] luckyColors = {
         "赤",
         "青",
         "緑",
         "黄色",
         "紫",
         "オレンジ",
         "ピンク"
         };
        private string[] shuffledFortunes; //クラスレベルで宣言 
        private string[] shuffledLuckyItems; //クラスレベルで宣言 
        private string[] shuffledLuckyColors; //クラスレベルで宣言

        

            public Form1()
            {
                InitializeComponent();

                this.Text = "御神籤";
                this.Size = new System.Drawing.Size(1200, 450);

            // タイトルラベルを設定 
            titleLabel = new Label();
            titleLabel.Text = "御神籤";
            titleLabel.Font = new Font("Arial", 20, FontStyle.Bold);　
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point((this.ClientSize.Width - titleLabel.Width)/2, 10); // フォーム上の位置を調整 
            this.Controls.Add(titleLabel);

            buttons = new Button[fortunes.Length];
                Random random = new Random();
                shuffledFortunes = ShuffleArray(fortunes, random);//コンストラクタ内で初期化
                shuffledLuckyItems = ShuffleArray(luckyItems, random); //コンストラクタ内で初期化
                shuffledLuckyColors = ShuffleArray(luckyColors, random); //コンストラクタ内で初期化

            int rows = 1; // 行数
            int cols = 7; // 列数
            int buttonWidth = 100;
            int buttonHeight = 200;
            int padding = 60;
            int buttonStartY = titleLabel.Bottom + padding * 100; // ボタンの開始位置を調整

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
                    string resultMessage = "あなたの御神籤の結果は: " + shuffledFortunes[index] +
                        "\nラッキーアイテム: " + shuffledLuckyItems[index] +
                        "\nラッキーカラー: " + shuffledLuckyColors[index];
                CustomMessageBoxForm customMessageBox = new CustomMessageBoxForm(resultMessage); 
                customMessageBox.ShowDialog();
                foreach (var button in buttons) { button.Enabled = false; }
                Application.Exit(); // アプリケーションを終了 
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
    

