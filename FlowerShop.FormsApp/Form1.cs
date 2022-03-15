using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShop.FormsApp
{
    using Models;
    using Services;
    public partial class Form1 : Form
    {
        internal MainService service = new MainService();
        public Form1()
        {
            InitializeComponent();
            UpdateGrid();
            label2.Visible = false;
            textBox2.Visible = false;
        }
        public void UpdateGrid()
        {
            //dataGridView1.DataSource = service.BouquetService.GetAllBouquets();
            dataGridView1.DataSource = service.FlowerService.GetAllFlowers();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            DataGridViewElementStates states = DataGridViewElementStates.Visible;
            dataGridView1.Width = SystemInformation.VerticalScrollBarWidth
                + dataGridView1.Columns.GetColumnsWidth(states) + 3;
            //var totalHeight = dataGridView1.Rows.GetRowsHeight(states) + dataGridView1.ColumnHeadersHeight;
            //dataGridView1.ClientSize = new System.Drawing.Size(width, totalHeight);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> input = textBox1.Text.Split(',').ToList();
            service.FlowerService.AddFlower(input[0], input[1], int.Parse(input[2]));
            UpdateGrid();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            service.FlowerService.DeleteFlower(textBox2.Text);
            UpdateGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //List<string> input = textBox3.Text.Split(',').ToList();
            service.FlowerService.UpdateFlower(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text);
            UpdateGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox2.Visible = true;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox2.Visible = false;
        }
    }
}
