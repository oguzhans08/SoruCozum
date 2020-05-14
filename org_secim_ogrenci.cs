using MetroFramework.Forms;
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
using MySql.Data.MySqlClient;
namespace SoruProjesiYon
{
    public partial class org_secim_ogrenci : MetroForm
    {

        public org_secim_ogrenci()
        {
            InitializeComponent();
        }

       
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        private void org_secim_ogrenci_Load(object sender, EventArgs e)
        {
            searchData("");


        }

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM uyeler";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
