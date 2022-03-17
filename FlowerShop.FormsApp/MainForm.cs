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
    using Microsoft.Data.SqlClient;
    using Models;
    using Services;
    using System.Reflection;

    public partial class MainForm : Form
    {
        internal MainService service = new MainService();
        internal Bouquet bouquet1;
        public MainForm()
        {
            InitializeComponent();
            UpdateGrid();

            





            if (UserForm.user != null)
            {
                User user = UserForm.user;
                foreach (PropertyInfo prop in user.GetType().GetProperties())
                {
                    richTextBox1.Text += prop.Name + ": " + prop.GetValue(user)+"\n";
                }
            }
            label2.Visible = false;
            textBox2.Visible = false;



            foreach (BouquetFlower bouquetflower in service.BouquetService.GetAllBouquetFlower())
            {
                richTextBox1.Text += "BouquetId: " + bouquetflower.Bouquet.Id.ToString() +
                    ", Flower name: " + bouquetflower.Flower.Name.ToString() +
                    ", Quantity: " + bouquetflower.Quantity + "\n";
            }
            foreach (Bouquet bouquet in service.BouquetService.GetAllBouquets())
            {
                richTextBox1.Text += service.BouquetService.GetTotalFlowerQuantity(bouquet);
            }

        }

        public void AdjustColumnOrder(DataGridView dataGridView, string ColumnName, int Index)
        {
            dataGridView.Columns[ColumnName].DisplayIndex = Index;
        }

        public void UpdateGrid()
        {
            dataGridView1.DataSource = service.FlowerService.GetAllFlowers();
            dataGridView2.DataSource = service.BouquetService.GetAllBouquetFlower();
            dataGridView3.DataSource = service.BouquetService.GetAllBouquets();
        }
        public void DataGridViewFitToContent(DataGridView dataGridView)
        {
            DataGridViewElementStates states = DataGridViewElementStates.Visible;
            int containerheight = dataGridView.Height;
            int totalheight = dataGridView.Rows.GetRowsHeight(states) + dataGridView.ColumnHeadersHeight;
            if (containerheight > totalheight)
            {
                dataGridView.Width = dataGridView.Columns.GetColumnsWidth(states) + 3;
            }
            else
            {
                dataGridView.Width = SystemInformation.VerticalScrollBarWidth
                    + dataGridView.Columns.GetColumnsWidth(states) + 3;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> input = textBox1.Text.Split(',').ToList();
            service.FlowerService.AddFlower(input[0], input[1], int.Parse(input[2]));
            UpdateGrid();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                service.FlowerService.DeleteFlower(item[1].Value.ToString());
            }
            //service.FlowerService.DeleteFlower(textBox2.Text);
            UpdateGrid();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            service.FlowerService.UpdateFlower(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            UpdateGrid();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
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


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            DataGridViewFitToContent(dataGridView1);
        }
        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView2.Columns[0].Visible = false;
            AdjustColumnOrder(dataGridView2, "Quantity", 2);
            AdjustColumnOrder(dataGridView2, "Bouquet", 1);
            DataGridViewFitToContent(dataGridView2);
        }
        private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView3.Columns[3].Visible = false;
            dataGridView3.Columns[4].Visible = false;
            dataGridView3.Columns[5].Visible = false;
            dataGridView3.Columns[6].Visible = false;
            DataGridViewFitToContent(dataGridView3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string flowername = textBox1.Text;
            try
            {
                if (bouquet1 == null)
                {
                    throw new ArgumentException("Create a Bouquet first!");
                }
                service.BouquetService.AddFlowerToBouquet(flowername, bouquet1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            

            UpdateGrid();    
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bouquet1 = service.BouquetService.CreateBouquet();
            UpdateGrid();
        }
    }
}
