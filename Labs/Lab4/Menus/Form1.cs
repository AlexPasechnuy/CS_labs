using System;
using System.Windows.Forms;

namespace Labs.Lab4.Menus
{
    public partial class FormMatrix : Form
    {
        public FormMatrix()
        {
            InitializeComponent();
            InitTable(1, 1);
            comboBoxM.SelectedIndex = 0;
            comboBoxN.SelectedIndex = 0;
        }

        public void InitTable(int n,int m)
        {
            
            Matrix.Columns.Clear();
            Matrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Matrix.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            

            for (int i = 1; i <= m; i++)
                Matrix.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()) { HeaderText = i + "" });

            for (int i = 0; i < n; i++)
            {
                Matrix.Rows.Add(new DataGridViewRow());
                for (int j = 0; j < m; j++)
                    Matrix.Rows[i].Cells[j].Value = 0;
            }
        }

        private void CheakedChanged(object sender, EventArgs e)
        {
            InitTable(comboBoxN.SelectedIndex + 1, comboBoxM.SelectedIndex + 1);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            InitTable(1, 1);
            ResultTextBox.Text = "";
            CheckBox.Checked = false;
            comboBoxN.SelectedIndex = 0;
            comboBoxM.SelectedIndex = 0;
        }


        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] matrix = new double[comboBoxN.SelectedIndex + 1,comboBoxM.SelectedIndex + 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = double.Parse(Matrix.Rows[i].Cells[j].Value + "");

            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double product = 1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    product *= matrix[i, j];
                }
                sum += product;
            }

            if (CheckBox.Checked)
                MessageBox.Show("Result = " + sum);
            else
                ResultTextBox.Text = sum.ToString();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program for searcing the sum of product of rows");
        }
    }
}
