using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HairManager
{
    public partial class settingConnect : Form
    {
        public settingConnect()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string s = Properties.Settings.Default.SettingConnect.ToString();

            //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.ConnectionStrings.ConnectionStrings["HairManagerEntities"].ConnectionString = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=" + txtConnect.Text + ";initial catalog=HairManager;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            //config.Save(ConfigurationSaveMode.Modified);
            
            //ConfigurationManager.RefreshSection("connectionStrings");

            //ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["HairManagerEntities"];
            //string connectionString = conSettings.ConnectionString;
            MessageBox.Show(s);
            //this.Close();
        }
    }
}
