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
using Mart.InstanceClasses;

namespace Mart.Forms
{
    public partial class FormInsertImport : Form
    {
        private DataTable dataTableImportDetail = null;
        private SqlCommand cmdImp, cmdImpDatial;
        private SqlConnection con = Connection.getConnection();  
        public FormInsertImport()
        {
            InitializeComponent();
            CreateTable();
            ControlDataGridView();
            RegisterEvent();
            
        }

        private void ControlDataGridView()
        {
            foreach (DataGridViewColumn col in dgvImportDetail.Columns)
            {
                Controller.AlignHeaderTextCenter(col);
            }

            for (int i = 1; i < dgvImportDetail.Columns.Count; i++)
            {
                dgvImportDetail.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;   
            }

            Controller.NonSortableDataGridView(dgvImportDetail);
        }

        private void RegisterEvent()
        {
            lblAddSupplier.Click += LblAddSupplier_Click;
            lblAddProduct.Click += lblAddProduct_Click;
            btnAdd.Click += buttonAdd_Click;
            btnUpdate.Click += buttonUpdate_Click;
            btnClose.Click += buttonClose_Click;
            btnDelete.Click += buttonDelete_Click;
            btnImport.Click += buttonImport_Click;
            btnClear.Click += buttonClear_Click;
            this.Load += FrmInsertImport_Load;
            txtImportPrice.KeyPress += AllowNumberOnly;
            txtImportQty.KeyPress += AllowNumberOnly;
            txtSalePrice.KeyPress += AllowNumberOnly;

            dgvImportDetail.Click += dgvImportDetail_Click;

            Supplier.Created += Supplier_Created;
        }

        private void Supplier_Created(Supplier sup)
        {
            if (Insert(sup))
            {
                MessageBox.Show("Supplier was saved successfully.","Supplier",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Supplier was saved unsuccessfully.", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblAddSupplier_Click(object sender, EventArgs e)
        {
            FormInsertSupplier formInsertSupplier = new FormInsertSupplier();
            formInsertSupplier.FormClosed += FormInsertSupplier_FormClosed;
            formInsertSupplier.ShowDialog();
        }

        private void FormInsertSupplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadSupplierIntoComboBox();
        }

        void dgvImportDetail_Click(object sender, EventArgs e)
        {
            if (dgvImportDetail.Rows.Count > 0)
            {
                int index = dgvImportDetail.CurrentRow.Index;
                cboProduct.SelectedValue = int.Parse(dgvImportDetail.Rows[index].Cells[5].Value.ToString());
                txtImportQty.Text = dgvImportDetail.Rows[index].Cells[1].Value.ToString();
                txtImportPrice.Text = dgvImportDetail.Rows[index].Cells[2].Value.ToString();
                txtSalePrice.Text = dgvImportDetail.Rows[index].Cells[3].Value.ToString();
                cboProduct.Enabled = false;
                EnableButton(true);
                btnAdd.Enabled = false;
            }
        }

        private void EnableButton(bool ena)
        {
            btnDelete.Enabled = ena;
            btnUpdate.Enabled = ena;
        }

        void lblAddProduct_Click(object sender, EventArgs e)
        {
            FormProductDetails frmAdd = new FormProductDetails(1, 0);
            frmAdd.Created += frmAdd_Created;
            frmAdd.ShowDialog();   
        }

        private void frmAdd_Created()
        {
            LoadProductIntoComboBox();
        }     

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int proId = 0;
            int.TryParse(cboProduct.SelectedValue.ToString(), out proId);
            string productName = cboProduct.Text.ToString();

            float importPrice = 0;
            float.TryParse(txtImportPrice.Text, out importPrice);

            int importQty = 0;
            int.TryParse(txtImportQty.Text, out importQty);

            double subAmount = importPrice * importQty;

            float salePrice = 0f;
            float.TryParse(txtSalePrice.Text, out salePrice);

            if (cboProduct.SelectedIndex == -1)
            {
                MessageBox.Show("There is no product selected!");
            }
            else if (txtImportQty.Text == "" || importQty <= 0)
            {
                MessageBox.Show("Please input quantity!");
                txtImportQty.Focus();
            }
            else if (txtImportPrice.Text.Trim() == "" || importPrice <= 0)
            {
                MessageBox.Show("Please input import price!");
                txtImportPrice.Focus();
            }
            else if (txtSalePrice.Text.Trim() == "" || salePrice <= 0)
            {
                MessageBox.Show("Pleas input sale price!");
                txtSalePrice.Focus();
            }
            else
            {            
                dgvImportDetail.Rows[dgvImportDetail.CurrentRow.Index].SetValues(cboProduct.Text.ToString(), txtImportQty.Text.ToString(), txtImportPrice.Text.ToString(), txtSalePrice.Text.ToString(), subAmount.ToString(), proId.ToString());
                RefreshTotal();
                ClearControls();
                MessageBox.Show("Product was updated successfully.","Update Product");
            }              
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearControls();
            EnableButton(false);
        }

        private void ClearControls()
        {
            if (cboProduct.Items.Count > 0)
            {
                cboProduct.SelectedIndex = -1;
            }
            txtImportQty.Clear();
            txtImportPrice.Clear();
            txtSalePrice.Clear();       
            btnImport.Enabled = true;
            btnAdd.Enabled = true;
            EnableButton(false);

            cboProduct.Enabled = true;
        }

        private void AllowNumberOnly(object sender, KeyPressEventArgs e)
        {
            Input.InputNmber(sender as TextBox, e);
        }

        private void FrmInsertImport_Load(object sender, EventArgs e)
        {
            LoadSupplierIntoComboBox();
            LoadProductIntoComboBox();
        }

        private void LoadProductIntoComboBox()
        {
            try
            {
                SqlDataAdapter daPro = new SqlDataAdapter("select proName, proID from product", con);
                DataTable dtPro = new DataTable();
                daPro.Fill(dtPro);
                cboProduct.DataSource = dtPro;
                cboProduct.DisplayMember = "proName";
                cboProduct.ValueMember = "proID";                  
                btnImport.Enabled = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message+" There was an error hapend!", "Load Product");
            }
            finally
            {
                con.Close();
            }
            if (cboProduct.Items.Count > 0)
            {
                cboProduct.SelectedIndex = -1;
                btnAdd.Enabled =true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private void LoadSupplierIntoComboBox()
        {
            try
            {
                con.Open();
                SqlDataAdapter daSup = new SqlDataAdapter("select supLastName +' '+supFirstName as [supName] , supID from supplier", con);
                DataTable dtSup = new DataTable();
                daSup.Fill(dtSup);
                cboSupplier.DataSource = dtSup;
                cboSupplier.DisplayMember = "supName";
                cboSupplier.ValueMember = "supID";                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + " There was an error hapend!", "Load Supplier");
            }
            finally
            {
                con.Close();
            }
            if (cboSupplier.Items.Count > 0)
            {
                cboSupplier.SelectedIndex = -1;
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private bool SaveImprotDetail(int impID)
        {
            bool success = false;
            int proId;
            double price, amount, unitPrice;
            int qty = 0;
            string productName;           
            foreach (DataGridViewRow Datarow in dgvImportDetail.Rows)
            {
                if (Datarow.Cells[0].Value != null && Datarow.Cells[1].Value != null && Datarow.Cells[2].Value != null && Datarow.Cells[3].Value != null && Datarow.Cells[4].Value != null && Datarow.Cells[5].Value != null)
                {
                    try
                    {
                        productName = Datarow.Cells[0].Value.ToString();
                        int.TryParse(Datarow.Cells[1].Value.ToString(),out qty);
                        double.TryParse(Datarow.Cells[2].Value.ToString(), out price);
                        double.TryParse(Datarow.Cells[3].Value.ToString(), out unitPrice);
                        double.TryParse(Datarow.Cells[4].Value.ToString(), out amount);
                        proId = int.Parse(Datarow.Cells[5].Value.ToString());

                        DataRow rw = dataTableImportDetail.NewRow();
                        rw["impID"] = impID;
                        rw["proID"] = proId;
                        rw["impQty"] = qty;
                        rw["impPrice"] = price;
                        rw["unitPrice"] = unitPrice;
                        rw["amount"] = amount;
                        rw["soldQty"] = 0;
                        dataTableImportDetail.Rows.Add(rw);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message,"Import : DataGridView to Data Table");
                    }                   
                }
            }

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmdImpDatial = new SqlCommand("InsertImportDetail", con);
                cmdImpDatial.CommandType = CommandType.StoredProcedure;
                cmdImpDatial.Parameters.Add("@importDetails", SqlDbType.Structured);
                cmdImpDatial.Parameters["@importDetails"].TypeName = "ImportDetailType";
                cmdImpDatial.Parameters["@importDetails"].Value = dataTableImportDetail;
                if (cmdImpDatial.ExecuteNonQuery() > 0)
                {
                    success = true;

                    int updated = 0;
                    SqlCommand cmd = null;
                    foreach (DataRow row in dataTableImportDetail.Rows)
                    {
                        if ((double)row["unitPrice"] > 0)
                        {
                            cmd = new SqlCommand("UPDATE Product SET price = @p WHERE proID = @id", con);
                            cmd.Parameters.AddWithValue("@p", row["unitPrice"]);
                            cmd.Parameters.AddWithValue("@id", row["proID"]);

                            if (cmd.ExecuteNonQuery() > 0)
                                updated++;
                        }
                    }

                    if (dataTableImportDetail.Rows.Count == updated) success = true;
                    else success = false;
                }
            } catch (SqlException ex)
            {
                success = false;
                MessageBox.Show("There were errors!" + ex.Message);
            }
            finally
            {
                try
                {
                    cmdImpDatial.Dispose();
                    con.Close();
                } catch (NullReferenceException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Import Detail : " + ex.Message);
                }             
            }
            return success; 
        }
        
        private void buttonImport_Click(object sender, EventArgs e)
        {

            if (cboSupplier.SelectedIndex == -1)
            {
                MessageBox.Show("Please select supplier!");
            }
            else if (dgvImportDetail.Rows.Count == 0)
            {
                MessageBox.Show("Please add product!");
            }
            else
            {
                bool success = false;
                int impID;
                try
                {
                    con.Open();
                    cmdImp = new SqlCommand("Insert into Import(impDate,supID,empID,impTotal) Values(@impDate,@supplier,@empID,@impTotal)", con);
                    cmdImp.Parameters.AddWithValue("@impDate", dtpImportDate.Value);
                    cmdImp.Parameters.AddWithValue("@supplier", (int)cboSupplier.SelectedValue);
                    cmdImp.Parameters.AddWithValue("@empID",Program.empLogin.ID);
                    double totalImport = 0;
                    double.TryParse(txtTotal.Text, out totalImport);
                    cmdImp.Parameters.AddWithValue("@impTotal", totalImport);

                    if (cmdImp.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    }
                }
                catch (SqlException ex)
                {
                    success = false;
                    MessageBox.Show("There was an error hapend! :" + ex.Message);
                }
                finally
                {
                    con.Close();
                    cmdImp.Dispose();
                }

                impID = Controller.GetLastAutoIncrement("Import");
                bool saveImportSuccess = SaveImprotDetail(impID);

                if (saveImportSuccess && success)
                {
                    MessageBox.Show("Inserted suceessfully!");
                    btnImport.Enabled = false;
                }
                else
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                        con.Open();
                        if (success)
                        {                            
                            cmdImp = new SqlCommand("DELETE Import WHERE impID = @impID", con);
                            cmdImp.Parameters.AddWithValue("@impID", impID);
                            cmdImpDatial = new SqlCommand("DELETE ImportDetail WHERE impID = @impID", con);
                            cmdImpDatial.Parameters.AddWithValue("@impID", impID);
                            cmdImp.ExecuteNonQuery();
                            cmdImpDatial.ExecuteNonQuery();
                        }          
                        MessageBox.Show("Inserted unsuceessfully!");
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Import : " + ex.Message);
                    }
                    finally
                    {
                        try
                        {
                            if (con.State == ConnectionState.Open)
                            con.Close();
                            cmdImp.Dispose();
                            cmdImpDatial.Dispose();
                        }
                        catch (NullReferenceException ex)
                        {
                            MessageBox.Show(ex.Message, "Delete Unsuccessful import");
                        }
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dgvImportDetail.Rows.Count > 0)
            {
                int i = dgvImportDetail.CurrentCell.RowIndex;
                if (i >= 0)
                {
                    dgvImportDetail.Rows.RemoveAt(i);
                    RefreshTotal();
                    ClearControls();
                }                
            } 
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close? All Data will be lost !","Close",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int proId = 0;
            int.TryParse(cboProduct.SelectedValue.ToString(), out proId);
            string productName = cboProduct.Text.ToString();

            float importPrice = 0;
            float.TryParse(txtImportPrice.Text, out importPrice);
            
            int importQty = 0;
            int.TryParse(txtImportQty.Text, out importQty);
            
            double subAmount = importPrice * importQty;
            
            float salePrice = 0f;
            float.TryParse(txtSalePrice.Text,out salePrice);

            if (cboProduct.SelectedIndex == -1)
            {
                MessageBox.Show("There is no product selected!");
            } else if (txtImportQty.Text == "" || importQty <= 0)
            {
                MessageBox.Show("Please input quantity!");
                txtImportQty.Focus();
            } else if (txtImportPrice.Text.Trim() == "" || importPrice <= 0)
            {
                MessageBox.Show("Please input import price!");
                txtImportPrice.Focus();
            }
            /*else if (txtSalePrice.Text.Trim() == "" || salePrice <= 0)
            {
                MessageBox.Show("Pleas input sale price!");
                txtSalePrice.Focus();
            }             
            */
            else {                                           

                DialogResult result;
                bool exist = false;
                foreach (DataGridViewRow row in dgvImportDetail.Rows)
                {
                    if (int.Parse(row.Cells[5].Value.ToString()) == int.Parse(cboProduct.SelectedValue.ToString()))
                    {
                        exist = true;
                        int index = row.Index;
                        dgvImportDetail.CurrentRow.Selected = false;
                        dgvImportDetail.Rows[index].Selected = true;   
                        result =  MessageBox.Show("This Product ID is already exist! Do you want to override?", "Exist Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {                          
                            dgvImportDetail.Rows[index].SetValues(cboProduct.Text.ToString(), txtImportQty.Text.ToString(), txtImportPrice.Text.ToString(), txtSalePrice.Text.ToString(), subAmount.ToString(), proId.ToString());
                            RefreshTotal();
                            ClearControls();
                            break;
                        }                        
                    }                    
                }
                if (!exist)
                {
                    dgvImportDetail.Rows.Add(cboProduct.Text.ToString(), txtImportQty.Text.ToString(), txtImportPrice.Text.ToString(), txtSalePrice.Text.ToString(), subAmount.ToString(), proId.ToString());
                    RefreshTotal();
                    ClearControls();
                }               
            }  
        }

        private bool CheckExistProduct()
        {
            bool exist = false;
            if (cboProduct.SelectedIndex == -1) return false;
            foreach (DataGridViewRow row in dgvImportDetail.Rows)
            {
                if (int.Parse(row.Cells[5].Value.ToString()) == int.Parse(cboProduct.SelectedValue.ToString()))
                {
                    MessageBox.Show("This Product ID is already exist! Do you want to override?","Exist Product",MessageBoxButtons.YesNo,MessageBoxIcon.Question);    
                }
            }

            return exist;
        }

        public bool Insert(Supplier sup)
        {
            bool success = false;
            SqlCommand cmd = null;

            try
            {
                con.Open();
                cmd = new SqlCommand("insert Supplier(supFirstName,supLastName,supGender,supBirthdate,supPnumber,supEmail,supCompany,status) Values(@fn,@ln,@g,@bd,@pn,@em,@cmp,@sta)", con);

                cmd.Parameters.AddWithValue("@fn", sup.FirstName);
                cmd.Parameters.AddWithValue("@ln", sup.LastName);
                cmd.Parameters.AddWithValue("@g", sup.Gender);
                cmd.Parameters.AddWithValue("@bd", sup.BirthDate);
                cmd.Parameters.AddWithValue("@em", sup.Email);
                cmd.Parameters.AddWithValue("@pn", sup.pNumber);
                cmd.Parameters.AddWithValue("@cmp", sup.Company);
                cmd.Parameters.AddWithValue("@sta", true);

                if (cmd.ExecuteNonQuery() > 0) success = true;
            }
            catch (Exception e)
            {
                success = false;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return success;
        }

        private void RefreshTotal()
        {
            double total = 0;
            foreach (DataGridViewRow row in dgvImportDetail.Rows)
            {
                total += double.Parse(row.Cells[4].Value.ToString());
            }
            txtTotal.Text = string.Format("{0:N2}",total);
            txtTotalRow.Text = dgvImportDetail.Rows.Count.ToString();
        }

        private void CreateTable()
        {
            dataTableImportDetail = new DataTable();
            dataTableImportDetail.Columns.Add("impID", typeof(int));
            dataTableImportDetail.Columns.Add("proID", typeof(int));
            dataTableImportDetail.Columns.Add("impQty", typeof(double));
            dataTableImportDetail.Columns.Add("impPrice", typeof(double));
            dataTableImportDetail.Columns.Add("unitPrice", typeof(double));
            dataTableImportDetail.Columns.Add("amount", typeof(double));
            dataTableImportDetail.Columns.Add("soldQty", typeof(int));
        }       
    }
}
