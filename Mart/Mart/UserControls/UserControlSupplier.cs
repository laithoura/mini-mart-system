using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mart.UserControls;
using Mart.Intefaces;
using Mart.InstanceClasses;
using Mart.Forms;

namespace Mart.UserControls
{
    public partial class UserControlSupplier : UserControl, IFunctionModel<Supplier>, IMessageType
    {

        #region
        private SqlCommand cmd;
        private SqlConnection con = Connection.getConnection();
        private List<Supplier> supplierList = new List<Supplier>();
        private SqlDataReader dr;
        private Supplier sup;
       
        private readonly string[] searchBy = new string[] { "Suppllier ID", "First Name","Last Name"};
        private static UserControlSupplier _instance;

        #endregion
        public static UserControlSupplier Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControlSupplier();
                return _instance;
            }
        } 
           



        public UserControlSupplier()
        {
            InitializeComponent();
            eventRegister();
        }
        private void eventRegister()
        {
            this.Load+=Supplier_Load;
            btnSupAdd.Click += DoClick;
            btnSupDelete.Click += DoClick;
            btnSupUpate.Click += DoClick;
            btnSearch.Click += DoClick;
            btnRefresh.Click += DoClick;
            cboSearchBy.SelectedIndexChanged+=cboSearchBy_SelectedIndexChanged;
            txtKeyword.GotFocus += txtKeyword_GotFocus;
            txtKeyword.KeyDown += txtKeyword_KeyDown;

            Supplier.Created += Supplier_Created;
            Supplier.Updated += Supplier_Updated;
            Supplier.Loaded += Supplier_Loaded;
        }

        void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtKeyword.Text.Trim() == "") return;
            if (e.KeyCode == Keys.Enter)
            {
                dgvSup.Rows.Clear();
                if (cboSearchBy.SelectedIndex == 0) /* Search By Employee ID */
                {
                    if (txtKeyword.Text.Trim() == searchBy[0]) return;
                    int id = 0;
                    int.TryParse(txtKeyword.Text.Trim(), out id);
                    try
                    {
                        foreach (Supplier sup in supplierList)
                        {
                            try
                            {
                                if (id == sup.ID)
                                {
                                    AddDataRowToDataGrid(sup);
                                    btnSupAdd.Enabled = false;
                                }
                            }


                            catch (NullReferenceException)
                            {

                            }
                        }
                    }
                    catch (InvalidOperationException)
                    {
                    }

                }
                else if (cboSearchBy.SelectedIndex == 1)/* Search By Employee ID */
                {

                    try
                    {
                        //MessageBox.Show(supplierList.Count.ToString());
                        if (txtKeyword.Text.Trim() == searchBy[1]) return;

                        foreach (Supplier sup in supplierList)
                        {
                            // MessageBox.Show(sup.FirstName + " " + sup.LastName + ";  " + txtKeyword.Text.Trim());
                            try
                            {

                                if (sup.FirstName.Trim().ToLower().StartsWith(txtKeyword.Text.ToString().Trim().ToLower()))
                                {

                                    AddDataRowToDataGrid(sup);
                                    btnSupAdd.Enabled = false;
                                }
                            }
                            catch (NullReferenceException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Ivalid");
                    }

                }
                else if (cboSearchBy.SelectedIndex == 2)/* Search By Last Name */
                {


                    if (txtKeyword.Text.Trim() == searchBy[2]) return;
                    foreach (Supplier sup in supplierList)
                    {
                        try
                        {

                            if (sup.LastName.Trim().ToLower().StartsWith(txtKeyword.Text.Trim().ToLower()))
                            {

                                AddDataRowToDataGrid(sup);
                                btnSupAdd.Enabled = false;
                            }
                        }
                        catch (NullReferenceException)
                        {
                        }
                    }







                }


            }



        }

        void txtKeyword_GotFocus(object sender, EventArgs e)
        {
            txtKeyword.Text = "";
        }

        private void cboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKeyword.Text = cboSearchBy.Text;
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            LoadData();
        }
       private void Supplier_Loaded(Supplier sup)
        {
            if (sup == null) MessageBox.Show(" null");
            supplierList.Add(sup);
            int index = dgvSup.Rows.Add(sup.ID, sup.FirstName, sup.LastName, sup.Gender, sup.BirthDate, sup.pNumber, sup.Email, sup.Company);
            dgvSup.Rows[index].Tag = sup;
            sup.Tag = dgvSup.Rows[index];
        }

        void Supplier_Updated(Supplier sup)

        {
            if (Update(sup))
            {
                int index = dgvSup.CurrentRow.Index; 
                foreach (DataGridViewRow row in dgvSup.Rows)
                {
                    if (row.Tag == sup)
                    {
                        row.SetValues(sup.ID, sup.FirstName, sup.LastName, sup.Gender, sup.BirthDate, sup.pNumber, sup.Email, sup.Company);
                       ///update list pg
                       

                        break; 
                    }
                }
                MessageSuccess("Updated successfully", "Update");
            }
            else MessageError("Error Update", "Update");     
        }

        void Supplier_Created(Supplier sup)
        {
            if(Insert(sup))
            {
                supplierList.Add(sup);
                int index = dgvSup.Rows.Add(sup.ID, sup.FirstName, sup.LastName, sup.Gender, sup.BirthDate, sup.pNumber, sup.Email, sup.Company);
                dgvSup.Rows[index].Tag = sup;
                sup.Tag = dgvSup.Rows[index];
                lbRecordCount.Text = dgvSup.RowCount.ToString();
            }
        } 
        public void LoadData()
        {
          
            try
            {
                con.Open();
             
                cmd = new SqlCommand("SELECT * FROM Supplier where status=@status", con);
                cmd.Parameters.AddWithValue("@status", true);
                dr = cmd.ExecuteReader();
                dgvSup.Rows.Clear();
               supplierList.Clear();
                while (dr.Read())
                {
                    Supplier.LoadedInstance((int)dr["supID"], (string)dr["supFirstName"], (string)dr["supLastName"], (string)dr["supGender"], (DateTime)dr["SupBirthdate"],(string)dr["supPnumber"],(string)dr["supEmail"], (string)dr["supCompany"]);
                    //supplierList.Add(sup);
                    lbRecordCount.Text = dgvSup.RowCount.ToString();
                   
                }
              
            }
            catch (Exception e)
            {
                MessageError(e.Message, "Error Load");
            }
            finally
            {
                con.Close();
               dr.Close();
                cmd.Dispose();
            }
        }

  
        public bool Insert(Supplier sup)
        {
            bool success = false;
            try
            {
                con.Open();
                cmd = new SqlCommand("insert Supplier(supFirstName,supLastName,supGender,supBirthdate,supPnumber,supEmail,supCompany,status) Values(@fn,@ln,@g,@bd,@pn,@em,@cmp,@sta)", con);
                
                cmd.Parameters.AddWithValue("@fn", sup.FirstName);
                cmd.Parameters.AddWithValue("@ln", sup.LastName);
                cmd.Parameters.AddWithValue("@g", sup.Gender);
                cmd.Parameters.AddWithValue("@bd", sup.BirthDate);
                cmd.Parameters.AddWithValue("@em", sup.Email);
                cmd.Parameters.AddWithValue("@pn",sup.pNumber);
                cmd.Parameters.AddWithValue("@cmp", sup.Company);
                cmd.Parameters.AddWithValue("@sta", true);
   
                if (cmd.ExecuteNonQuery() > 0) success = true;
                lbRecordCount.Text = dgvSup.RowCount.ToString();
            }
            catch (Exception e)
            {
                success = false;
                MessageError(e.Message, "Error Insert");
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return success;
        }
        private void DoClick(object sender, EventArgs e)
        {
            if (sender == btnSupAdd)
            {

                FormInsertSupplier SupInsert = new FormInsertSupplier();
                lbRecordCount.Text = dgvSup.RowCount.ToString();
                SupInsert.ShowDialog();
            }
            else if (sender == btnSupUpate)
            {
                sup = dgvSup.CurrentRow.Tag as Supplier;
                FormInsertSupplier SupUpdate = new FormInsertSupplier(sup);

                SupUpdate.ShowDialog();


            }
            else if (sender == btnSupDelete)
            {

                DialogResult SupDeleteDR = this.MessageVerify("Do you want to delete?", "Delete");
                if (SupDeleteDR == DialogResult.Yes)
                {
                   

                   foreach (DataGridViewRow row in dgvSup.SelectedRows)
                    {
                        int index = supplierList.IndexOf(row.Tag as Supplier);
                         int id = supplierList[index].ID;
                       
                         if (Delete(id))
                         {
                             MessageSuccess("Deleted successfully", "Delete");
                             supplierList.RemoveAt(index);
                             dgvSup.Rows.Remove(row);
                             lbRecordCount.Text = dgvSup.RowCount.ToString();
                         }
                         else MessageError("Deleted Unsuccessfully", "Delete");                                            
                    }


                }
            }
            else if (sender == btnSearch)
            {
                Search();                            
            }
            else if (sender == btnRefresh)
            {

                if (supplierList.Count == 0) return;
                cboSearchBy.SelectedIndex = 0;
                dgvSup.Rows.Clear();
                txtKeyword.Text  = "";

                try
                {
                    LoadData();
                    lbRecordCount.Text = dgvSup.RowCount.ToString();
                    btnSupAdd.Enabled = true;                                     
                }
                catch (InvalidOperationException)
                {

                }
            }

        }


        private void Search()
        {
            if (txtKeyword.Text.Trim() == "") return;

            {
                dgvSup.Rows.Clear();
                if (cboSearchBy.SelectedIndex == 0) /* Search By Employee ID */
                {
                    if (txtKeyword.Text.Trim() == searchBy[0]) return;
                    int id = 0;
                    int.TryParse(txtKeyword.Text.Trim(), out id);
                    try
                    {
                        foreach (Supplier sup in supplierList)
                        {
                            try
                            {
                                if (id == sup.ID)
                                {
                                   
                                    AddDataRowToDataGrid(sup);
                                    lbRecordCount.Text = dgvSup.RowCount.ToString();
                                    btnSupAdd.Enabled = false;
                                }
                            }


                            catch (NullReferenceException)
                            {

                            }
                        }
                    }
                    catch (InvalidOperationException)
                    {
                    }

                }
                else if (cboSearchBy.SelectedIndex == 1)/* Search By Employee ID */
                {

                    try
                    {
                        //MessageBox.Show(supplierList.Count.ToString());
                        if (txtKeyword.Text.Trim() == searchBy[1]) return;

                        foreach (Supplier sup in supplierList)
                        {
                           // MessageBox.Show(sup.FirstName + " " + sup.LastName + ";  " + txtKeyword.Text.Trim());
                            try
                            {
                                if (sup.FirstName.Trim().ToLower().StartsWith(txtKeyword.Text.ToString().Trim().ToLower()))
                                {

                                    AddDataRowToDataGrid(sup);
                                    lbRecordCount.Text = dgvSup.RowCount.ToString();
                                    btnSupAdd.Enabled = false;
                                }
                            }
                            catch (NullReferenceException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Ivalid");
                    }

                }
                else if (cboSearchBy.SelectedIndex == 2)/* Search By Last Name */
                {                   
                        if (txtKeyword.Text.Trim() == searchBy[2]) return;
                        foreach (Supplier sup in supplierList)
                        {
                            try
                            {

                                if (sup.LastName.Trim().ToLower().StartsWith(txtKeyword.Text.Trim().ToLower()))
                                {

                                    AddDataRowToDataGrid(sup);
                                    lbRecordCount.Text = dgvSup.RowCount.ToString();
                                    btnSupAdd.Enabled = false;
                                }
                            }
                            catch (NullReferenceException)
                            {
                            }
                        }
                    }                          
            }
        }

          public void AddDataRowToDataGrid(Supplier sup)
        {
           // supplierList.Add(sup);
            int index = dgvSup.Rows.Add(sup.ID, sup.FirstName, sup.LastName, sup.Gender, sup.BirthDate, sup.pNumber, sup.Email, sup.Company);
            dgvSup.Rows[index].Tag = sup;
            sup.Tag = dgvSup.Rows[index];
        }


         public bool Update(Supplier obj)
         {
            bool success = false;
             try{
                 con.Open();
                 cmd = new SqlCommand("UPDATE Supplier set supFirstName= @fn,supLastName= @ln,supGender= @g,supBirthdate= @bd,supPnumber = @pn,supEmail=@em,supCompany= @cmp WHERE supID=@id",con);
                 cmd.Parameters.AddWithValue("@id", sup.ID);
                 cmd.Parameters.AddWithValue("@fn", sup.FirstName);
                 cmd.Parameters.AddWithValue("@ln", sup.LastName);
                    cmd.Parameters.AddWithValue("@g", sup.Gender);
                    cmd.Parameters.AddWithValue("@bd", sup.BirthDate);
                    cmd.Parameters.AddWithValue("@em", sup.Email);
                    cmd.Parameters.AddWithValue("@pn",sup.pNumber);
                    cmd.Parameters.AddWithValue("@cmp", sup.Company);
   
                    if (cmd.ExecuteNonQuery() > 0) success = true;
                }
                catch (Exception e)
                {
                    success = false;
                    MessageError(e.Message, "Error Update");
                }
                finally
                {
                    con.Close();
                    cmd.Dispose();
                }
            return success;
        }
        public bool Delete(int id)
        {
            bool succes = false;
            try
            {
                con.Open();
                cmd=new SqlCommand("Update Supplier set status=@status where supID=@id",con);
                cmd.Parameters.AddWithValue("@status", false);
                cmd.Parameters.AddWithValue("@id", id);
                if(cmd.ExecuteNonQuery()>0)
                {
                    succes = true;


                }
            }
            catch (Exception ex)
            {
                succes = false;
                MessageError("Error Data Store" +ex.Message,"Error Delete");
            }
            finally
            {

                con.Close();
            }
            
            return succes;
        }

        public void MessageSuccess(string des, string title)
        {
            MessageBox.Show(des, title, MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        public void MessageError(string des, string title)
        {
            MessageBox.Show(des, title, MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        public void MessageWarning(string des, string title)
        {
            MessageBox.Show(des,title,MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        public DialogResult MessageVerify(string des, string title)
        {
            return MessageBox.Show(des, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
        }

        private void USupplier_Load(object sender, EventArgs e)
        {
            //btnKbach1.Enabled = false;
          
            btnKbach3.Enabled = false;
            dgvSup.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            Controller.AlignHeaderTextCenter(dgvSup.Columns[0], dgvSup.Columns[1], dgvSup.Columns[2], dgvSup.Columns[3], dgvSup.Columns[4], dgvSup.Columns[5], dgvSup.Columns[6], dgvSup.Columns[7]);
          dgvSup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
       
        }

        private void btnKbach3_Click(object sender, EventArgs e)
        {

        }

     
    

      
      
    }
}
