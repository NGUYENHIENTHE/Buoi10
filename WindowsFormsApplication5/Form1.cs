using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        private Label questionLabel;
        private RadioButton[] answerOptions;
        private Button submitButton;
        private int correctAnswer;

        public Form1()
        {
            InitializeComponent();

            // Khởi tạo các controls
            questionLabel = new Label();
            questionLabel.Top = 30;
            questionLabel.Left = 50;
            questionLabel.Text = "1 + 1 = ?";
            this.Controls.Add(questionLabel);

            answerOptions = new RadioButton[4];

            for (int i = 0; i < 4; i++)
            {
                answerOptions[i] = new RadioButton();
                answerOptions[i].Top = 60 + i * 30;
                answerOptions[i].Left = 50;
                answerOptions[i].Text = "Đáp án " + (i + 1);
                this.Controls.Add(answerOptions[i]);
            }

            submitButton = new Button();
            submitButton.Top = 200;
            submitButton.Left = 50;
            submitButton.Text = "Kiểm tra";
            submitButton.Click += SubmitButton_Click;
            this.Controls.Add(submitButton);

            // Cài đặt đáp án đúng
            correctAnswer = 2;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra câu trả lời
            int selectedAnswer = -1;

            for (int i = 0; i < 4; i++)
            {
                if (answerOptions[i].Checked)
                {
                    selectedAnswer = i + 1;
                    break;
                }
            }

            if (selectedAnswer == -1)
            {
                MessageBox.Show("Vui lòng chọn một đáp án!");
            }
            else if (selectedAnswer == correctAnswer)
            {
                MessageBox.Show("Đáp án đúng!");
            }
            else
            {
                MessageBox.Show("Đáp án sai!");
            }
        }
    }
}
