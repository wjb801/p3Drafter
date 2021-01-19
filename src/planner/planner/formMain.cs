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
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void MENU_FILE_QUIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            dataGridView_gantt.Columns.Clear();
            dataGridView_gantt.Columns.Add("numOrder", "序号");
            dataGridView_gantt.Columns.Add("L1", "L1");
            dataGridView_gantt.Columns.Add("L2", "L2");
            dataGridView_gantt.Columns.Add("L3", "L3");
            dataGridView_gantt.Columns.Add("L4", "L4");
        }

        private void 项目添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProjectEdit pe = new formProjectEdit();
            pe.ShowDialog();
        }
    }
}
