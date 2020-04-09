using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_l6
{

    public partial class Form1 : Form
    {
        double result; // Результат, он же промежуточный результат.
        double operand; // Операнд
        string operation; // Знак операции
        bool op_flag = false,eq_flag = false, er_flag=false; // Флаги арифметической операции, знака равенства и ошибки
        int cnt_signs; // Ограничиваем количество знаков числа

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик события Click кнопок, отвечающих за цифры 0-9 и разделитель целой и дробной части
        /// </summary>
        private void button17_Click_1(object sender, EventArgs e)
        {
            
            if (cnt_signs < 30 || op_flag|| er_flag|| eq_flag)
            {
                string tmp = textBox1.Text;
                if (er_flag)
                {
                    button2_Click(null, null);
                    textBox1.Text = "";
                }
                else if (textBox1.Text == "0" || op_flag )
                {
                    textBox1.Text = "";
                    op_flag = false;
                    er_flag = false;
                }
                if (eq_flag == false)
                {
                    op_flag = false;
                }
                else
                {
                    button2_Click(null, null);
                    textBox1.Text = "";
                }
                Button button = (Button)sender;
                if (button.Text == ",")
                {
                    if (!textBox1.Text.Contains(","))
                    {
                        if (tmp == "0"|| tmp!= textBox1.Text)
                        {
                            textBox1.Text = "0" + button.Text;
                        }
                        else
                        {
                            textBox1.Text += button.Text;
                        }
                    }
                }
                else
                {
                    textBox1.Text += button.Text;
                }
            }
        }
        /// <summary>
        /// Обработчик события Click кнопки, отвечающей за отмену всех действий CE
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            cnt_signs = 1;
            result = 0;
            operand = 0;
            textBox1.Text = "0";
            label1.Text = "";
            operation = "";
            op_flag = false;
            eq_flag = false;
            er_flag = false ;
        }
        /// <summary>
        /// Обработчик события Click кнопок, отвечающей за выполнение операций /,*,+,-
        /// </summary>
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (er_flag)
            {
                button2_Click(null, null);
            }
            else
            {
                Button button = (Button)sender;
                
                if (op_flag)
                {
                    operation = button.Text;
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1) + operation;
                }
                else if (eq_flag)
                {
                    operation = button.Text;
                    operand = result;
                    label1.Text = result.ToString() + operation;
                    op_flag = true;
                }
                else
                {
                    if (double.TryParse(label1.Text + textBox1.Text, out double promres))
                    {
                        operand = double.Parse(textBox1.Text);
                        operation = button.Text;
                        label1.Text=promres.ToString() + operation;
                    }
                    else
                    {
                        button1_Click(null, null);
                        operation = button.Text;
                        operand = result;
                        label1.Text = result.ToString() + operation;
                    }
                    op_flag = true;
                }
            }
            eq_flag = false;
        }
        /// <summary>
        /// Обработчик события KeyDown ввода цифр с помощью клавиатуры
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.D1:
                    button6.PerformClick();
                    break;
                case (char)Keys.D2:
                    button5.PerformClick();
                    break;
                case (char)Keys.D3:
                    button4.PerformClick();
                    break;
                case (char)Keys.D4:
                    button10.PerformClick();
                    break;
                case (char)Keys.D5:
                    button9.PerformClick();
                    break;
                case (char)Keys.D6:
                    button8.PerformClick();
                    break;
                case (char)Keys.D7:
                    button17.PerformClick();
                    break;
                case (char)Keys.D8:
                    button16.PerformClick();
                    break;
                case (char)Keys.D9:
                    button15.PerformClick();
                    break;
                case (char)Keys.D0:
                    button12.PerformClick();
                    break;
                case (char)Keys.Delete:
                    button2.PerformClick();
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// Обработчик события Click кнопки =.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (er_flag)
            {
                button2_Click(null,null);
            }
            
            else
            {
                double tmp;
                switch (operation)
                {
                    case "+":
                        if (eq_flag)
                        {
                            result += double.Parse(label1.Text.Substring(label1.Text.Length-2,1));
                        }
                        else if (double.TryParse(textBox1.Text, out tmp))
                        {
                            result = operand + tmp;
                            label1.Text += tmp + "=";
                        }
                        else
                        {
                            result = operand + operand;
                            label1.Text += operand + "=";
                        }
                        textBox1.Text = result.ToString();
                        eq_flag = true;
                        break;
                    case "-":
                        if (eq_flag)
                        {
                            result -= double.Parse(label1.Text.Substring(label1.Text.Length - 2, 1));
                        }
                        else if (double.TryParse(textBox1.Text, out tmp))
                        {
                            result = operand - tmp;
                            label1.Text += tmp + "=";
                        }
                        else
                        {
                            result = operand - operand;
                            label1.Text += operand + "=";
                        }
                        textBox1.Text = result.ToString();
                        eq_flag = true;
                        break;
                    case "*":
                        if (eq_flag)
                        {
                            result *= double.Parse(label1.Text.Substring(label1.Text.Length - 2, 1));
                        }
                        else if (double.TryParse(textBox1.Text, out tmp))
                        {
                            result = operand * tmp;
                            label1.Text += + tmp + "=";
                        }
                        else
                        {
                            result = operand * operand;
                            label1.Text += operand + "=";
                        }
                        textBox1.Text = result.ToString();
                        eq_flag = true;
                        break;
                    case "/":
                        if (eq_flag)
                        {
                            result /= double.Parse(label1.Text.Substring(label1.Text.Length - 2, 1));
                        }
                        else if (double.TryParse(textBox1.Text, out tmp))
                        {
                            if (tmp == 0)
                            {
                                textBox1.Text = "Ошибка";
                                label1.Text = "";
                                er_flag = true;
                                break;
                            }
                            else
                            {
                                result = operand / tmp;
                                label1.Text += tmp + "=";
                            }
                        }
                        else
                        {
                            result = operand / operand;
                            label1.Text += operand + "=";
                        }
                        textBox1.Text = result.ToString();
                        eq_flag = true;
                        break;
                    default:
                        result = double.Parse(textBox1.Text);
                        label1.Text = textBox1.Text + "=";
                        break;
                }
            }
            // Передаем промежуточный результат в буфер обмена.
            Clipboard.SetText(result.ToString());
        }
        /// <summary>
        /// Обработчик события Resize формы.
        /// Изменяем размер шрифта в Text Box в зависимости от размера окна.
        /// </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Width >= 354 && Width < 708)
            {
                if (cnt_signs < 15)
                {
                    textBox1.Font = new Font(textBox1.Font.FontFamily, 24, FontStyle.Bold);

                }
                else
                {
                    textBox1.Font = new Font(textBox1.Font.FontFamily, 12, FontStyle.Bold);
                }
            }
            else if (Width == 708)
            {
                textBox1.Font = new Font(textBox1.Font.FontFamily, 24, FontStyle.Bold);
            }
            else if (Width >= 236 && Width < 354)
            {
                if (cnt_signs < 15)
                {
                    textBox1.Font = new Font(textBox1.Font.FontFamily, 16, FontStyle.Bold);

                }
                else
                {
                    textBox1.Font = new Font(textBox1.Font.FontFamily, 8, FontStyle.Bold);
                }
            }
        }
        /// <summary>
        /// Обработчик события Text Changed для Text Box.
        /// Фиксируем количество символов в Text Box и меняем размер шрифта при необходимости.
        /// </summary>
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            cnt_signs = textBox1.Text.Length;
            Form1_Resize(null, null);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
