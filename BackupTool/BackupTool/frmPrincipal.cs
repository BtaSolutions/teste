using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackupTool
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                DAL.Config.CarregarConfig();


            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                frmConfig frm = new frmConfig();
                frm.ShowDialog();
                DAL.Config.CarregarConfig();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfig frm = new frmConfig();
                frm.ShowDialog();
                DAL.Config.CarregarConfig();
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
