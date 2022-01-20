using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mart.UserControls;

namespace Mart
{
    public partial class UBin : UserControl
    {
        private static UBin _instance;

        public static UBin Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UBin();
                return _instance;
            }
        }
        public UBin()
        {
            InitializeComponent();
            tpEmployee.Click += tpEmployee_Click;
            tpSupplier.Click += TpSupplier_Click;
            tpEmployee_Click(tpEmployee, null);
            TpSupplier_Click(tpSupplier,null);
        }

        private void TpSupplier_Click(object sender, EventArgs e)
        {
            UserControlBinSupplier binSupplier = new UserControlBinSupplier();            
            binSupplier.Dock = DockStyle.Fill;
            tpSupplier.Controls.Add(binSupplier);
        }

        void tpEmployee_Click(object sender, EventArgs e)
        {
            UserControlBinEmployee binEmp = new UserControlBinEmployee();            
            binEmp.Dock = DockStyle.Fill;
            tpEmployee.Controls.Add(binEmp);          
        }
        
    }
}
