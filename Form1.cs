using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace FilmArsivi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=FilmArsivim;Integrated Security=True");
        Color[] colors = new Color[] { Color.Yellow, Color.Green, Color.Red };
        void filmler()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tblfilm", baglanti);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
         }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("insert into tblfilm(name,category,link) values (@P1, @P2, @P3)",baglanti);
            command.Parameters.AddWithValue("@P1", txtFilmAdı.Text);
            command.Parameters.AddWithValue("@P2", txtKategori.Text);
            command.Parameters.AddWithValue("@P3", txtLink.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[selected].Cells[3].Value.ToString();

            webBrowser1.Navigate(link);
        }

        private void btnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void btnRenk_Click(object sender, EventArgs e)
        {
           
        }
    }
}
