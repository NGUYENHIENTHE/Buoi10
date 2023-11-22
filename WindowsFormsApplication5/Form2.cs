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
        public partial class Form2 : Form
        {
            private Label questionLabel;
            private RadioButton[] answerOptions;
            private Button submitButton;

            private List<Question> questions;
            private int currentQuestionIndex;

            public Form2()
            {
                InitializeComponent();

                // Khởi tạo các controls
                questionLabel = new Label();
                questionLabel.Top = 30;
                questionLabel.Left = 50;
                this.Controls.Add(questionLabel);

                answerOptions = new RadioButton[4];

                for (int i = 0; i < 4; i++)
                {
                    answerOptions[i] = new RadioButton();
                    answerOptions[i].Top = 60 + i * 30;
                    answerOptions[i].Left = 50;
                    this.Controls.Add(answerOptions[i]);
                }

                submitButton = new Button();
                submitButton.Top = 200;
                submitButton.Left = 50;
                submitButton.Text = "Kiểm tra";
                submitButton.Click += SubmitButton_Click;
                this.Controls.Add(submitButton);

                // Khởi tạo danh sách câu hỏi
                questions = new List<Question>()
            {
                new Question("Câu hỏi 1: 1 + 1 bằng bao nhiêu?", new string[] { "2", "3", "4", "5" }, 0),
                new Question("Câu hỏi 2: 2 * 3 bằng bao nhiêu?", new string[] { "4", "6", "8", "9" }, 1),
                new Question("Câu hỏi 3: Ai là người đầu tiên đặt chân lên Mặt trăng?", new string[] { "Neil Armstrong", "Buzz Aldrin", "Yuri Gagarin", "Alan Shepard" }, 0)
            };

                // Khởi tạo câu hỏi đầu tiên
                currentQuestionIndex = 0;
                LoadQuestion(currentQuestionIndex);
            }

            private void LoadQuestion(int questionIndex)
            {
                if (questionIndex >= 0 && questionIndex < questions.Count)
                {
                    Question currentQuestion = questions[questionIndex];

                    questionLabel.Text = currentQuestion.Text;

                    for (int i = 0; i < 4; i++)
                    {
                        answerOptions[i].Text = currentQuestion.Answers[i];
                        answerOptions[i].Checked = false;
                    }
                }
            }

            private void SubmitButton_Click(object sender, EventArgs e)
            {
                // Kiểm tra câu trả lời
                int selectedAnswer = -1;

                for (int i = 0; i < 4; i++)
                {
                    if (answerOptions[i].Checked)
                    {
                        selectedAnswer = i;
                        break;
                    }
                }

                if (selectedAnswer == -1)
                {
                    MessageBox.Show("Vui lòng chọn một đáp án!");
                }
                else
                {
                    Question currentQuestion = questions[currentQuestionIndex];

                    if (selectedAnswer == currentQuestion.CorrectAnswerIndex)
                    {
                        MessageBox.Show("Đáp án đúng!");

                        // Chuyển sang câu hỏi tiếp theo
                        currentQuestionIndex++;
                        if (currentQuestionIndex < questions.Count)
                        {
                            LoadQuestion(currentQuestionIndex);
                        }
                        else
                        {
                            MessageBox.Show("Bạn đã hoàn thành bài trắc nghiệm!");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đáp án sai! Vui lòng chọn lại đáp án đúng.");
                    }
                }
            }
        }

        public class Question
        {
            public string Text { get; set; }
            public string[] Answers { get; set; }
            public int CorrectAnswerIndex { get; set; }

            public Question(string text, string[] answers, int correctAnswerIndex)
            {
                Text = text;
                Answers = answers;
                CorrectAnswerIndex = correctAnswerIndex;
            }
        }
    }
