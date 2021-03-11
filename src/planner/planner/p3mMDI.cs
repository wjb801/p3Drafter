using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace planner
{
    public partial class p3mMDI : Form
    {
        public static string m_sRunDir = Application.StartupPath;
        public static string m_sXml = Application.StartupPath + "\\db\\g01.xml";

        public p3mMDI()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void p3mMDI_Load(object sender, EventArgs e)
        {
            p3mWidget_GanttChart1.ex_Load(m_sXml);
        }

        private void 项目添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Project_Admin pe = new Form_Project_Admin();
            pe.ShowDialog();
        }

        private void MENU_FILE_QUIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void p3mMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            p3mWidget_GanttChart1.ex_Save(m_sXml);

        }
    }
}
