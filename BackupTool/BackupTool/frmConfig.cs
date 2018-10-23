using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackupTool
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarImagens();
                CarregarConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarConfig()
        {
            if (BLL.Config_Sessao.host              != string.Empty) txtHost.Text = BLL.Config_Sessao.host;
            if (BLL.Config_Sessao.port              != string.Empty) txtPort.Text = BLL.Config_Sessao.port;
            if (BLL.Config_Sessao.db                != string.Empty) txtDB.Text = BLL.Config_Sessao.db;
            if (BLL.Config_Sessao.user              != string.Empty) txtUser.Text = BLL.Config_Sessao.user;
            if (BLL.Config_Sessao.password          != string.Empty) txtPassword.Text = BLL.Config_Sessao.password;
            if (BLL.Config_Sessao.caminho_pg_dump   != string.Empty) txtCaminhoPgDump.Text = BLL.Config_Sessao.caminho_pg_dump;
        }

        private void CarregarImagens()
        {
            string sCaminho = Directory.GetCurrentDirectory();

            if (File.Exists(sCaminho + "\\img\\" + "save.png")) btnSalvar.Image = Image.FromFile(sCaminho + "\\img\\" + "save.png");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHost.Text        == string.Empty) throw new Exception("É necessário informar o host do servidor");
                if (txtPort.Text        == string.Empty) throw new Exception("É necessário informar a porta do servidor");
                if (txtDB.Text          == string.Empty) throw new Exception("É necessário informar o nome do banco de dados");
                if (txtUser.Text        == string.Empty) throw new Exception("É necessário informar o usuário");
                if (txtPassword.Text    == string.Empty) throw new Exception("É necessário informar a senha");

                BLL.Config_Sessao.host = txtHost.Text;
                BLL.Config_Sessao.port = txtPort.Text;
                BLL.Config_Sessao.db = txtDB.Text;
                BLL.Config_Sessao.user = txtUser.Text;
                BLL.Config_Sessao.password = txtPassword.Text;
                BLL.Config_Sessao.caminho_pg_dump = txtCaminhoPgDump.Text;

                DAL.Config.SalvarConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
