using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DataWarehouseProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string sqlQuery = "";
        //string connectstring = "server=139.255.11.84;uid=student;pwd=isbmantap;database=DW_ZEFANYA_OLAP;";
        string cabang;
        string reseller;
        string produk;

        private void openConnection()
        {
            sqlConnection = new MySqlConnection();
            sqlConnection.ConnectionString = "server=139.255.11.84;uid=student;pwd=isbmantap;database=DW_ZEFANYA_OLAP;";

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                openConnection();
                tbCabang.Text = "";
                tbProduk.Text = "";
                tbReseller.Text = "";

                if (cbView.SelectedItem == "ALL")
                {
                    DataTable dtView = new DataTable();
                    sqlQuery = "SELECT NAMA_CABANG as `Nama Cabang`, ID_SALES as `ID Sales`,  R_ID as `ID Reseller`, R_NAMA as `Nama Reseller`, J_SKU as `SKU`, PRODUK as `Nama Produk`, HARGA as `Harga`, QTY as `Quantity` FROM `VIEW_SALES`";
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                    sqlAdapter.Fill(dtView);

                    dgvView.DataSource = dtView;

                    tbCabang.Enabled = true;
                    tbProduk.Enabled = true;
                    tbReseller.Enabled = true;
                    label5.Text = dtView.Rows.Count + " Rows";
                }
                else if (cbView.SelectedItem == "CABANG")
                {
                    DataTable dtView = new DataTable();
                    sqlQuery = "SELECT nama_cabang as `Nama Cabang`, concat(sum(qty), ' pcs') as `Total Penjualan`, concat('Rp ', format(sum(harga), 0)) as `Total Pendapatan` FROM DW_ZEFANYA_OLAP.VIEW_SALES group by id_cabang";
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                    sqlAdapter.Fill(dtView);

                    dgvView.DataSource = dtView;

                    tbCabang.Enabled = true;
                    tbProduk.Enabled = false;
                    tbReseller.Enabled = false;
                    label5.Text = dtView.Rows.Count + " Rows";
                }
                else if (cbView.SelectedItem == "RESELLER")
                {
                    DataTable dtView = new DataTable();
                    sqlQuery = "select r_id as `ID Reseller`, r_nama as `Nama Reseller`, concat(sum(qty), ' pcs') as `Total Pembelian`, concat('Rp ', format(sum(harga), 0)) as `Total Harga (Rp)` FROM DW_ZEFANYA_OLAP.VIEW_SALES group by r_id order by r_id asc";
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                    sqlAdapter.Fill(dtView);

                    dgvView.DataSource = dtView;

                    tbReseller.Enabled = true;
                    tbProduk.Enabled = false;
                    tbCabang.Enabled = false;
                    label5.Text = dtView.Rows.Count + " Rows";
                }
                else if (cbView.SelectedItem == "PRODUK")
                {
                    DataTable dtView = new DataTable();
                    sqlQuery = "select j_sku as `SKU`, produk as `Nama Produk`, concat(sum(qty), ' pcs') as `Quantity`, concat('Rp ', format(sum(harga), 0)) as `Total Harga` FROM DW_ZEFANYA_OLAP.VIEW_SALES group by j_sku, produk order by j_sku asc";
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                    sqlAdapter.Fill(dtView);

                    dgvView.DataSource = dtView;

                    tbProduk.Enabled = true;
                    tbCabang.Enabled = false;
                    tbReseller.Enabled = false;
                    label5.Text = dtView.Rows.Count + " Rows";
                }
                else if (cbView.SelectedItem == "CABANG + RESELLER")
                {
                    DataTable dtView = new DataTable();
                    sqlQuery = "select nama_cabang as `Nama Cabang`, r_id as `ID Reseller`, r_nama as `Nama Reseller`, concat(sum(qty), ' pcs') as `Total Pembelian`, concat('Rp ', format(sum(harga), 0)) as `Total Harga(Rp)` FROM DW_ZEFANYA_OLAP.VIEW_SALES where nama_cabang like '%"+cabang+"%' and r_nama like '%"+reseller+"%' group by r_id, id_cabang order by r_id asc";
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                    sqlAdapter.Fill(dtView);

                    dgvView.DataSource = dtView;

                    tbCabang.Enabled = true;
                    tbReseller.Enabled = true;
                    tbProduk.Enabled = false;
                    label5.Text = dtView.Rows.Count + " Rows";
                }
                else if (cbView.SelectedItem == "CABANG + PRODUK")
                {
                    DataTable dtView = new DataTable();
                    sqlQuery = "select nama_cabang as `Nama Cabang`, j_sku as `SKU`, produk as `Nama Produk`, concat(sum(qty), ' pcs') as `Quantity`, concat('Rp ', format(sum(harga), 0)) as `Total Harga` FROM DW_ZEFANYA_OLAP.VIEW_SALES where nama_cabang like '%" + cabang + "%' group by j_sku, produk, nama_cabang having `Nama Produk` like '%"+produk+"%'order by nama_cabang asc";
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                    sqlAdapter.Fill(dtView);

                    dgvView.DataSource = dtView;

                    tbCabang.Enabled = true;
                    tbReseller.Enabled = false;
                    tbProduk.Enabled = true;
                    label5.Text = dtView.Rows.Count + " Rows";
                }
                else if (cbView.SelectedItem == "RESELLER + PRODUK")
                {
                    DataTable dtView = new DataTable();
                    sqlQuery = "select r_id as `ID Reseller`, r_nama as `Nama Reseller`, j_sku as `SKU`, produk as `Nama Produk`, concat(sum(qty), ' pcs') as `Quantity`, concat('Rp ', format(sum(harga), 0)) as `Total Harga`FROM DW_ZEFANYA_OLAP.VIEW_SALES where r_nama like '%" + reseller + "%'group by j_sku, produk, r_id having `Nama Produk` like '%" + produk + "%'order by r_id asc";
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                    sqlAdapter.Fill(dtView);

                    dgvView.DataSource = dtView;

                    tbCabang.Enabled = false;
                    tbProduk.Enabled = true;
                    tbReseller.Enabled = true;
                    label5.Text = dtView.Rows.Count + " Rows";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbCabang_TextChanged(object sender, EventArgs e)
        {
            cabang = tbCabang.Text.ToString();
            if (cbView.SelectedItem == "ALL")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "SELECT NAMA_CABANG as `Nama Cabang`, ID_SALES as `ID Sales`,  R_ID as `ID Reseller`, R_NAMA as `Nama Reseller`, J_SKU as `SKU`, PRODUK as `Nama Produk`, HARGA as `Harga`, QTY as `Quantity` FROM `VIEW_SALES` where nama_cabang like '%" + cabang + "%' and r_nama like '%" + reseller + "%' having `Nama Produk` like '%" + produk + "%'";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = true;
                tbProduk.Enabled = true;
                tbReseller.Enabled = true;
                label5.Text = dtView.Rows.Count + " Rows";
            }
            else if (cbView.SelectedItem == "CABANG")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "SELECT nama_cabang as `Nama Cabang`, concat(sum(qty), ' pcs') as `Total Penjualan`, concat('Rp ', format(sum(harga), 0)) as `Total Pendapatan` FROM DW_ZEFANYA_OLAP.VIEW_SALES where nama_cabang like '%" + cabang + "%' group by id_cabang ";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = true;
                tbProduk.Enabled = false;
                tbReseller.Enabled = false;
                label5.Text = dtView.Rows.Count + " Rows";
            }
            else if (cbView.SelectedItem == "CABANG + PRODUK")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "select nama_cabang as `Nama Cabang`, j_sku as `SKU`, produk as `Nama Produk`, concat(sum(qty), ' pcs') as `Quantity`, concat('Rp ', format(sum(harga), 0)) as `Total Harga` FROM DW_ZEFANYA_OLAP.VIEW_SALES where nama_cabang like '%" + cabang + "%' group by j_sku, produk, nama_cabang having `Nama Produk` like '%" + produk + "%' order by nama_cabang asc";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = true;
                tbReseller.Enabled = false;
                tbProduk.Enabled = true;
                label5.Text = dtView.Rows.Count + " Rows";
            }
            else if (cbView.SelectedItem == "CABANG + RESELLER")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "select nama_cabang as `Nama Cabang`, r_id as `ID Reseller`, r_nama as `Nama Reseller`, concat(sum(qty), ' pcs') as `Total Pembelian`, concat('Rp ', format(sum(harga), 0)) as `Total Harga(Rp)` FROM DW_ZEFANYA_OLAP.VIEW_SALES where nama_cabang like '%" + cabang + "%' and r_nama like '%" + reseller + "%' group by r_id, id_cabang order by r_id asc";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = true;
                tbReseller.Enabled = true;
                tbProduk.Enabled = false;
                label5.Text = dtView.Rows.Count + " Rows";
            }
        }

        private void tbReseller_TextChanged(object sender, EventArgs e)
        {
            reseller = tbReseller.Text.ToString();
            if (cbView.SelectedItem == "ALL")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "SELECT NAMA_CABANG as `Nama Cabang`, ID_SALES as `ID Sales`,  R_ID as `ID Reseller`, R_NAMA as `Nama Reseller`, J_SKU as `SKU`, PRODUK as `Nama Produk`, HARGA as `Harga`, QTY as `Quantity` FROM `VIEW_SALES` where nama_cabang like '%" + cabang + "%' and r_nama like '%" + reseller + "%' having `Nama Produk` like '%" + produk + "%'";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = true;
                tbProduk.Enabled = true;
                tbReseller.Enabled = true;
                label5.Text = dtView.Rows.Count + " Rows";
            }
            else if (cbView.SelectedItem == "RESELLER")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "select r_id as `ID Reseller`, r_nama as `Nama Reseller`, concat(sum(qty), ' pcs') as `Total Pembelian`, concat('Rp ', format(sum(harga), 0)) as `Total Harga (Rp)` FROM DW_ZEFANYA_OLAP.VIEW_SALES where r_nama like '%" + reseller + "%' group by r_id order by r_id asc";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbReseller.Enabled = true;
                tbProduk.Enabled = false;
                tbCabang.Enabled = false;
                label5.Text = dtView.Rows.Count + " Rows";
            }
            else if (cbView.SelectedItem == "CABANG + RESELLER")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "select nama_cabang as `Nama Cabang`, r_id as `ID Reseller`, r_nama as `Nama Reseller`, concat(sum(qty), ' pcs') as `Total Pembelian`, concat('Rp ', format(sum(harga), 0)) as `Total Harga(Rp)` FROM DW_ZEFANYA_OLAP.VIEW_SALES where nama_cabang like '%" + cabang + "%' and r_nama like '%" + reseller + "%' group by r_id, id_cabang order by r_id asc";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = true;
                tbReseller.Enabled = true;
                tbProduk.Enabled = false;
                label5.Text = dtView.Rows.Count + " Rows";
            }
            else if (cbView.SelectedItem == "RESELLER + PRODUK")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "select r_id as `ID Reseller`, r_nama as `Nama Reseller`, j_sku as `SKU`, produk as `Nama Produk`, concat(sum(qty), ' pcs') as `Quantity`, concat('Rp ', format(sum(harga), 0)) as `Total Harga`FROM DW_ZEFANYA_OLAP.VIEW_SALES where r_nama like '%" + reseller + "%' group by j_sku, produk, r_id having `Nama Produk` like '%" + produk + "%'order by r_id asc";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = false;
                tbProduk.Enabled = true;
                tbReseller.Enabled = true;
                label5.Text = dtView.Rows.Count + " Rows";
            }
        }

        private void tbProduk_TextChanged(object sender, EventArgs e)
        {
            produk = tbProduk.Text.ToString();
            if (cbView.SelectedItem == "ALL")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "SELECT NAMA_CABANG as `Nama Cabang`, ID_SALES as `ID Sales`,  R_ID as `ID Reseller`, R_NAMA as `Nama Reseller`, J_SKU as `SKU`, PRODUK as `Nama Produk`, HARGA as `Harga`, QTY as `Quantity` FROM `VIEW_SALES` where nama_cabang like '%" + cabang + "%' and r_nama like '%" + reseller + "%' having `Nama Produk` like '%" + produk + "%'";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = true;
                tbProduk.Enabled = true;
                tbReseller.Enabled = true;
                label5.Text = dtView.Rows.Count + " Rows";
            }
            else if (cbView.SelectedItem == "PRODUK")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "select j_sku as `SKU`, produk as `Nama Produk`, concat(sum(qty), ' pcs') as `Quantity`, concat('Rp ', format(sum(harga), 0)) as `Total Harga` FROM DW_ZEFANYA_OLAP.VIEW_SALES group by j_sku, produk having `Nama Produk` like '%" + produk + "%' order by j_sku asc";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);
                dgvView.Refresh();
                dgvView.DataSource = dtView;
                
                tbProduk.Enabled = true;
                tbCabang.Enabled = false;
                tbReseller.Enabled = false;
                label5.Text = dtView.Rows.Count + " Rows";
            }
            else if (cbView.SelectedItem == "CABANG + PRODUK")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "select nama_cabang as `Nama Cabang`, j_sku as `SKU`, produk as `Nama Produk`, concat(sum(qty), ' pcs') as `Quantity`, concat('Rp ', format(sum(harga), 0)) as `Total Harga` FROM DW_ZEFANYA_OLAP.VIEW_SALES where nama_cabang like '%" + cabang + "%' group by j_sku, produk, nama_cabang having `Nama Produk` like '%" + produk + "%' order by nama_cabang asc";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = true;
                tbReseller.Enabled = false;
                tbProduk.Enabled = true;
                label5.Text = dtView.Rows.Count + " Rows";
            }
            else if (cbView.SelectedItem == "RESELLER + PRODUK")
            {
                DataTable dtView = new DataTable();
                sqlQuery = "select r_id as `ID Reseller`, r_nama as `Nama Reseller`, j_sku as `SKU`, produk as `Nama Produk`, concat(sum(qty), ' pcs') as `Quantity`, concat('Rp ', format(sum(harga), 0)) as `Total Harga`FROM DW_ZEFANYA_OLAP.VIEW_SALES where r_nama like '%" + reseller + "%'group by j_sku, produk, r_id having `Nama Produk` like '%" + produk + "%'order by r_id asc";
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, sqlConnection);
                sqlAdapter.Fill(dtView);

                dgvView.DataSource = dtView;

                tbCabang.Enabled = false;
                tbProduk.Enabled = true;
                tbReseller.Enabled = true;
                label5.Text = dtView.Rows.Count + " Rows";
            }
        }

        private void dgvView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbView.SelectedIndex = 0;
        }
    }
}
