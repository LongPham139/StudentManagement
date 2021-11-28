using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand comm;
        String str = "Data Source=LONGPHAM;Initial Catalog=QLSVien;Persist Security Info=True;User ID=sa;Password=123";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dataTable = new DataTable();


        public Form1()
        {
            InitializeComponent();
        }
        private void Load_Data()
        {
            if(cbCode.Text.Length == 0)
            {
                comm = conn.CreateCommand();
                comm.CommandText = "Select MASV, HO, TEN, NAM from SVIEN";
                adapter.SelectCommand = comm;
                dataTable.Clear();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
                dgv.Columns[0].HeaderText = "Mã SV";
                dgv.Columns[1].HeaderText = "HỌ SV";
                dgv.Columns[2].HeaderText = "Tên SV";
                dgv.Columns[3].HeaderText = "Ngày Sinh";
                
            }
            else
            {
                comm = conn.CreateCommand();
                comm.CommandText = "select DISTINCT SVIEN.MASV, SVIEN.HO, SVIEN.TEN, SVIEN.NAM, SVIEN.NAM, KQUA.DIEM " +
                    "from SVIEN, KQUA, HPHAN where SVIEN.MAKH = (select DISTINCT MAKH from MHOC where MAMH = '" + cbCode.Text + "')" +
                    " and DIEM = (select DISTINCT DIEM from KQUA where MASV = SVIEN.MASV and " +
                    "MAHP = (select DISTINCT MAHP from HPHAN where MAMH = '"+cbCode.Text+"'))";
                adapter.SelectCommand = comm;
                dataTable.Clear();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
                dgv.Columns[0].HeaderText = "Mã SV";
                dgv.Columns[1].HeaderText = "HỌ SV";
                dgv.Columns[2].HeaderText = "Tên SV";
                dgv.Columns[3].HeaderText = "Ngày Sinh";
                dgv.Columns[4].HeaderText = "Điểm";
                
                
            }
        }
        private void cbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCode.Text.Length > 0)
            {
                conn.Open();
                comm = conn.CreateCommand();               
                comm.CommandText = "select DISTINCT SVIEN.MASV, SVIEN.HO, SVIEN.TEN, SVIEN.NAM, SVIEN.NAM, KQUA.DIEM " +
                    "from SVIEN, KQUA, HPHAN where SVIEN.MAKH = (select DISTINCT MAKH from MHOC where MAMH = '" + cbCode.Text + "')" +
                    " and DIEM = (select DISTINCT DIEM from KQUA where MASV = SVIEN.MASV and " +
                    "MAHP = (select DISTINCT MAHP from HPHAN where MAMH = '" + cbCode.Text + "'))";            
                adapter.SelectCommand = comm;
                dataTable.Clear();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
                
                comm = conn.CreateCommand();
                comm.CommandText = "select TENMH, TINCHI from MHOC where MAMH = '" + cbCode.Text + "'";               
                try
                {
                    SqlDataReader dr = comm.ExecuteReader();
                    
                    while (dr.Read()) 
                    {
                        txtName.Text = dr["TENMH"].ToString();
                        txtNumber.Text = dr["TINCHI"].ToString();
                    }
                }
                catch (Exception exc)
                {

                    MessageBox.Show(exc.Message);
                }
                conn.Close();
            }

        }

        public void loadComboBox()
        {
            cbCode.Items.Clear();
            comm = conn.CreateCommand();
            comm.CommandText = "SELECT MAMH FROM MHOC";
            ////Fill cbBox
            ////cach 1:
            comm.ExecuteNonQuery();
            adapter = new SqlDataAdapter(comm);
            adapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {

                cbCode.Items.Add(dr["MAMH"].ToString());
            }

            //cach 2:
            //SqlDataReader dr;
            //try
            //{
            //    dr = comm.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        string mHoc = dr.GetString(0);
            //        cbCode.Items.Add(mHoc);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbCode.Items.Add("CSD201");
            cbCode.Items.Add("PRN292");
            cbCode.Items.Add("PRO192");
            cbCode.Items.Add("SWR302");
            cbCode.Items.Add("SWT301");
            conn = new SqlConnection(str);
            conn.Open();
            //loadComboBox();
            Load_Data();
            conn.Close();
        }

        
        }
    }

