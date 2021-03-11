using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p3mWidget
{
    public partial class p3mWidget_Gantt_Layout : UserControl
    {
        public p3mWidget_Gantt_Layout()
        {
            InitializeComponent();
        }

        public void ex_setday(DateTime dt0)
        {
            p3mGantt_top.xg_setday = new DateTime(dt0.Year, dt0.Month, dt0.Day, 0, 0, 0);
            label_today.Text = DateTime.Now.ToString("今日：yyyy年MM月dd日 dddd");
            label_setday.Text = p3mGantt_top.xg_setday.ToString("计划开始日期：yyyy年MM月dd日 dddd");
            //p3mWidget_GanttChart.ex_sql();

            //gmGantt_fixed.xe_items.Clear();

            var today0 = DateTime.Now;
            var dttoday = new DateTime(today0.Year, today0.Month, today0.Day, 0, 0, 0);
            if (dttoday == dt0)
            {
                label_rel.Text = "等于";
            }
            else if (dt0 < dttoday)
            {
                label_rel.Text = "早于";
            }
            else
            {
                label_rel.Text = "晚于";
            }

            //ex_refresh();
        }

        public void ex_add()
        {
            ////*在layout中操作，因为在fixed内add，可能不是本身显示，导致刷新缺失而不显示新内容
            //form_Gantt_fixed_Info gfi = new form_Gantt_fixed_Info();
            //if (gfi.ShowDialog() != DialogResult.OK)
            //    return;


            ////*table不需要事先排序
            ////按照日期时间先后排序
            ////InfomationCompare cmp = new InfomationCompare();
            ////gmGantt_fixed.xe_info.Sort(cmp);

            //ex_refresh();
        }

        private void p3mWidget_Gantt_Layout_Load(object sender, EventArgs e)
        {
            var dt0 = DateTime.Now;
            label_today.Text = dt0.ToString("今日：yyyy年MM月dd日 dddd");
            //gmGantt_fixed.xe_setday = dt0;
            p3mGantt_top.xg_setday = new DateTime(dt0.Year, dt0.Month, dt0.Day, 0, 0, 0);
            label_setday.Text = p3mGantt_top.xg_setday.ToString("计划开始日期：yyyy年MM月dd日 dddd");

        }
    }
}
