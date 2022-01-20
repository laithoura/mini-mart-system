using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mart.InstanceClasses;
using System.Data.SqlClient;

namespace Mart.UserControls
{
    public partial class UserControlBinSupplier : UserControl
    {
        public UserControlBinSupplier()
        {
            InitializeComponent();
            LoadData();
            btnExport.Click += BtnExport_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnRestore.Click += BtnRestore_Click;            
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to restore?","Restore Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                try
                {
                    int index = dgvSupplier.CurrentRow.Index;
                    int suppierId = (int)dgvSupplier.Rows[index].Cells[0].Value;

                    if (Delete(suppierId))
                    {
                        MessageBox.Show("Supplier was restored.", "Restore Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvSupplier.Rows.RemoveAt(index);
                        CountTableRow();
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }   
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Exporter.DataGridViewToExel(dgvSupplier);
        }

        private SqlCommand cmd;
        private SqlConnection con = Connection.getConnection();
        
        public void LoadData()
        {
            dgvSupplier.Columns.Clear();
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT supID AS [Supplier ID], supFirstName AS [First Name], supLastName AS [Last Name], supGender AS [Gender], supBirthdate AS [Birth Date], supPnumber AS [Phone Number], supEmail AS [Email Address], supCompany AS [Company Name] FROM Supplier where status = @status", con);
                cmd.Parameters.AddWithValue("@status",false);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSupplier.DataSource = dt;
                CountTableRow();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error Load");
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        private void CountTableRow()
        {
            lbRecordCount.Text = dgvSupplier.Rows.Count + " rows";
        }

        public bool Delete(int id)
        {
            bool succes = false;
            try
            {
                con.Open();
                cmd = new SqlCommand("Update Supplier set status=@status where supID=@id", con);
                cmd.Parameters.AddWithValue("@status", true);
                cmd.Parameters.AddWithValue("@id", id);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    succes = true;
                }
            }
            catch (Exception ex)
            {
                succes = false;
                MessageBox.Show(ex.Message, "Restore Supplier");
            }
            finally
            {
                con.Close();
            }

            return succes;
        }

    }
}
