using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;

namespace planner
{
    public partial class ppWidget_GanttChart : UserControl
    {
        public ppWidget_GanttChart()
        {
            InitializeComponent();
        }

        private void ihWidget_GanttChart_Paint(object sender, PaintEventArgs e)
        {
            var g0 = e.Graphics;
            g0.DrawString("甘特图 绘图", new Font("楷体", 32), Brushes.Blue, new Point(10, 10));
        }
    }
}
