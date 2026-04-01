 using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyBMICalculator
{
    public class Form1 : Form
    {
        // 1. 宣告介面元件
        private Label lblHeight, lblWeight, lblResult;
        private TextBox txtHeight, txtWeight;
        private Button btnCalculate, btnClear;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // 視窗設定
            this.Text = "BMI 計算機 - 羅健安的作品";
            this.Size = new Size(320, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 身高元件
            lblHeight = new Label() { Text = "身高 (cm):", Location = new Point(30, 40), AutoSize = true };
            txtHeight = new TextBox() { Location = new Point(130, 35), Width = 120 };

            // 體重元件
            lblWeight = new Label() { Text = "體重 (kg):", Location = new Point(30, 90), AutoSize = true };
            txtWeight = new TextBox() { Location = new Point(130, 85), Width = 120 };

            // 計算按鈕
            btnCalculate = new Button() { Text = "計算 BMI", Location = new Point(30, 150), Width = 100, Height = 40, BackColor = Color.LightBlue };
            btnCalculate.Click += new EventHandler(btnCalculate_Click);

            // 清除按鈕
            btnClear = new Button() { Text = "清除重填", Location = new Point(150, 150), Width = 100, Height = 40 };
            btnClear.Click += new EventHandler(btnClear_Click);

            // 結果顯示區域
            lblResult = new Label() 
            { 
                Text = "請輸入數值後點擊計算", 
                Location = new Point(30, 220), 
                Size = new Size(240, 100), 
                BorderStyle = BorderStyle.Fixed3D,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("微軟正黑體", 10, FontStyle.Bold)
            };

            // 將元件放入視窗
            this.Controls.Add(lblHeight);
            this.Controls.Add(txtHeight);
            this.Controls.Add(lblWeight);
            this.Controls.Add(txtWeight);
            this.Controls.Add(btnCalculate);
            this.Controls.Add(btnClear);
            this.Controls.Add(lblResult);
        }

        // 【計算按鈕】執行動作
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // 讀取數值並轉換
                double height = double.Parse(txtHeight.Text) / 100; // 公分轉公尺
                double weight = double.Parse(txtWeight.Text);
                
                // BMI 公式
                double bmi = weight / (height * height);

                // 判斷建議
                string suggestion = "";
                if (bmi < 18.5) suggestion = "你的體重過輕囉！";
                else if (bmi < 24) suggestion = "恭喜，體重在正常範圍！";
                else if (bmi < 27) suggestion = "過重，要注意飲食囉！";
                else suggestion = "肥胖，該動起來了！";

                // 顯示結果
                lblResult.Text = $"你的 BMI: {bmi:F2}\n\n結果: {suggestion}";
                lblResult.ForeColor = Color.DarkBlue;
            }
            catch
            {
                MessageBox.Show("請輸入數字！不要輸入文字或空白喔。", "輸入錯誤");
                txtHeight.Focus();
            }
        }

        // 【清除按鈕】執行動作
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHeight.Clear();
            txtWeight.Clear();
            lblResult.Text = "請輸入數值後點擊計算";
            lblResult.ForeColor = Color.Black;
            txtHeight.Focus(); // 游標自動回到身高輸入框
        }
    }
}