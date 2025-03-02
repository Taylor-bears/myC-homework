using System;
using System.Windows.Forms;

namespace calculator_window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { "+", "-", "*", "/" });
            comboBox1.SelectedIndex = 0;//Ĭ��ѡ���һ�������
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //��һ����
            if (!float.TryParse(textBox1.Text, out float firstNum))
            {
                MessageBox.Show("����ĵ�һ��������Ч������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //�ڶ�����
            if (!float.TryParse(textBox2.Text, out float doubleNum))
            {
                MessageBox.Show("����ĵڶ���������Ч������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //�����
            char operate = comboBox1.SelectedItem.ToString()[0];

            //������
            if (doubleNum == 0 && operate == '/')
            {
                MessageBox.Show("��������Ϊ0", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //����
            float result = 0;
            switch (operate)
            {
                case '+':
                    result = firstNum + doubleNum;
                    break;
                case '-':
                    result = firstNum - doubleNum;
                    break;
                case '*':
                    result = firstNum * doubleNum;
                    break;
                case '/':
                    result = firstNum / doubleNum;
                    break;
            }

            label1.Text = $"{result}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
