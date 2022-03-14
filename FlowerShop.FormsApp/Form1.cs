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
        public Form1()
        {
            InitializeComponent();
           MainService service = new MainService();
            dataGridView1.DataSource = service.BouquetService.GetAllBouquets();

        }
        private void dataGridView1_DataBindingComplete(object sender,DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;            
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.AutoResizeColumns();
        }
    }
}
