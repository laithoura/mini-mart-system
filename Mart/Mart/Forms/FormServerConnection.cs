using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Mart.Forms
{
    public partial class FormServerConnection : Form
    {
        readonly string PCName = Environment.MachineName;
        private string conString = "";
        private Point mouseLocation;

        public FormServerConnection()
        {
            InitializeComponent();
            
            this.TestServerConnection.Click += btnConnect_Click;
            this.pbClose.Click += pbClose_Click;
            this.pbClose.MouseHover += pbClose_MouseHover;
            this.cboAuthentication.SelectedIndex = 0;
            this.panelAccount.Enabled = false;
            this.cboAuthentication.SelectedIndexChanged += cboAuthentication_SelectedIndexChanged;

            this.MouseMove += FormServerConnection_MouseMove;
            this.MouseDown += FormServerConnection_MouseDown;
            GetConnectionFromProperties();
        }


        private void GetConnectionFromProperties()
        {
            var serverName = Properties.Settings.Default.ServerName;
            var databaseName = Properties.Settings.Default.DatabaseName;
            var userName = Properties.Settings.Default.Username;
            var password = Properties.Settings.Default.Password;
            

            if (!(string.IsNullOrEmpty(serverName) && string.IsNullOrEmpty(databaseName)) && string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                conString = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True", serverName, databaseName);
            }
            else if (!(string.IsNullOrEmpty(serverName) && string.IsNullOrEmpty(databaseName) && string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password)))
            {
                conString = string.Format(@"Data Source={0};Initial Catalog={1};User={2};Password={3};", serverName, databaseName, userName, password);
            }
            else
            {
                LoadLocalDatabaseNameToComboBox();
            }
            
            if (!string.IsNullOrEmpty(conString))
            {
                LoadDataToControl(serverName,databaseName,userName,password);
                checkBoxRemember.Checked = true;
                ConnectionToServer();
            }

        }



        private void LoadDataToControl(string serverName, string databaseName, string userName, string password)
        {
            cboServerName.Text = serverName;
            cboDatabaseName.Text = databaseName;
            txtUsername.Text = userName;
            txtPassword.Text = password;
        }        



        private void LoadLocalDatabaseNameToComboBox()
        {
            cboServerName.Items.Add("(local)");
            cboServerName.Items.Add(PCName);
            cboServerName.Items.Add(@".\SQLEXPRESS");
            cboServerName.Items.Add(string.Format(@"{0}/SQLEXPRESS", PCName));
            cboServerName.Items.Add(string.Format(@"{0}\MSSQLSERVER", PCName));

            string connectionString = "Data Source=.; Integrated Security=True;";

            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter("SELECT name from sys.databases", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboDatabaseName.DataSource = dt;
                cboDatabaseName.DisplayMember = "name";
                cboDatabaseName.ValueMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve all Server ");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        void FormServerConnection_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X,-e.Y);
        }


        void FormServerConnection_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X,mouseLocation.Y);
                Location = mousePose;
            }
        }


        void pbClose_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pbClose,"Close Connection");
        }


        void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAuthentication.SelectedIndex == 0)
            {
                panelAccount.Enabled = false;
            }
            else panelAccount.Enabled = true;
        }

        void btnConnect_Click(object sender, EventArgs e)
        {            

            if (cboAuthentication.SelectedIndex == 0)
            {
               conString = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True", cboServerName.Text.Trim(), cboDatabaseName.Text.Trim());
            }
            else
            {
                if (txtPassword.Text.Trim() == "" || txtUsername.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Username or Password to access your database","Connect",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
               conString = string.Format(@"Data Source={0};Initial Catalog={1};User={2};Password={3};", cboServerName.Text.Trim(), cboDatabaseName.Text.Trim(),txtUsername.Text.Trim(),txtPassword.Text.Trim());         
            }

           ConnectionToServer();
        }

        private void ConnectionToServer()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    if (checkBoxRemember.Checked)
                    {
                        SaveServerConnection();
                    }
                    else
                    {
                        Properties.Settings.Default.Reset();
                    }

                    if (conString != "")
                    {
                        Connection conn = new Connection();
                        if (conn.SaveConnectionString("LocalConnection", conString))
                        {
                            this.Hide();
                            FormLogin formLogin = new FormLogin();                            
                            formLogin.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to server. " + ex.Message, "Connection");
            }
            finally
            {
                con.Close();
            }
        }

        private void SaveServerConnection()
        {
            Properties.Settings.Default.ServerName = cboServerName.Text.Trim();
            Properties.Settings.Default.DatabaseName = cboDatabaseName.Text.Trim();
            Properties.Settings.Default.Username = txtUsername.Text.Trim();
            Properties.Settings.Default.Password = txtPassword.Text.Trim();
            Properties.Settings.Default.Save();
        }


            
    }
}