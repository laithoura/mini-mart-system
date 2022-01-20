using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mart.InstanceClasses;


namespace Mart.Forms
{
   
    public partial class FormInsertSupplier : Form
    {
        private int mouseX = 0, mouseY = 0;
        private bool mouseDown;
        private Supplier sup;
       
         public FormInsertSupplier(Supplier sup):this()
        {
            this.sup = sup;            
        }
        public FormInsertSupplier()
        {
            InitializeComponent();

            pBannerTop.MouseDown += DoMouseDown;
            pBannerTop.MouseUp += DoMouseUp;
            pBannerTop.MouseMove += DoMouseMove;

            lblTitle.MouseDown += DoMouseDown;
            lblTitle.MouseUp += DoMouseUp;
            lblTitle.MouseMove += DoMouseMove;

            btnSave.Click += DoInsertClick;
            btnClear.Click += DoInsertClick;
            btnCancel.Click += DoInsertClick;
           
        }
        void DoMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 100;
                mouseY = MousePosition.Y - 10;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        void DoMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        void DoMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
        private void SetDataToControls()
        {
            if (sup == null) return;
            txtSupplierID.Text = sup.ID.ToString();
            txtSupFirstName.Text = sup.FirstName.ToString();
            txtSupLastName.Text = sup.LastName.ToString();
            if (sup.Gender == "Male") rdMale.Checked = true;
            else rdFemale.Checked = true;
            txtPnumber.Text = sup.pNumber.ToString();
            txtSupEmail.Text = sup.Email;
            txtSupCompany.Text = sup.Company;
            dtpSupBd.Value = sup.BirthDate;
        }
        private void DoInsertClick(object sender, EventArgs e)
        {
            if (sender == btnSave)
            {
                GetValueFromControl();
                ClearControl();
           

            }
            else if (sender == btnClear)
            {
                ClearControl();
            }
            else if (sender == btnCancel)
            {
                
                this.Close();
            }
        }
        private void ClearControl()
        {
            txtSupplierID.Text = "Auto Number";
            txtSupFirstName.Clear();
            txtSupLastName.Clear();
            rdMale.Checked = true;
            rdFemale.Checked = false;
            dtpSupBd.Value = DateTime.Now;
        
            txtPnumber.Clear();
            txtSupEmail.Clear();
            txtSupCompany.Clear();
           
         
        }
        private void GetValueFromControl()
        {
       
            if (txtSupFirstName.Text.Trim() == "")
            {
                RequiredMessage("Enter First Name");
                return;
            }
            else if (txtSupLastName.Text.Trim() == "")
            {
                RequiredMessage("Enter Last Name");
                return;
            }
            else if (txtPnumber.Text.Trim() == "")
            {
                RequiredMessage("Enter Phnone Number");
                return;
            }
            else if (txtSupEmail.Text.Trim()== "")
            {
                RequiredMessage("Enter Email Address");
                return;
            }
            else if (txtSupCompany.Text.Trim() == "")
            {
                RequiredMessage("Enter the Company Name");
                return;
            }

            if (sup == null)  /* Add new Supplier */
            {
                int id = Controller.GetLastAutoIncrement("Supplier") + 1;
                Supplier.CreatedInstance(
                            id,
                           txtSupFirstName.Text,
                           txtSupLastName.Text,
                           (rdMale.Checked) ? "Male" : "Female",
                           dtpSupBd.Value,
                         txtPnumber.Text,
                           txtSupEmail.Text,
                          txtSupCompany.Text
                          );
            }
            else /* Update Supplier */
            {
                if (sup != null)
                {
                    sup.setSupplierData(
                              sup.ID,
                             txtSupFirstName.Text.Trim(),
                                txtSupLastName.Text.Trim(),
                                (rdMale.Checked) ? "Male" : "Female",
                                dtpSupBd.Value,
                              txtPnumber.Text.Trim(),
                                txtSupEmail.Text.Trim(),
                               txtSupCompany.Text.Trim()
                             );
                }
            }
        }
        private void MessageError(string des, string title)
        {
            MessageBox.Show(des, title, MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void RequiredMessage(string des)
        {
            MessageBox.Show(des, "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void frmInsertSupplier_Load(object sender, EventArgs e)
        {
         
           
             if (sup != null)
            {
                lblTitle.Text = "Update Supplier";
                SetDataToControls();
            }
            dtpSupBd.CustomFormat = "dd/MM/yyyy";
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }

       
    }

