using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Drawing;
using System.Drawing.Drawing2D;

namespace p3mWidget
{
    public partial class p3mWidget_GanttChart : UserControl
    {
        public static p3mWidget_GanttChart _ins = null;
        public p3mGantt_draw_option m_option = new p3mGantt_draw_option();

        public p3mGantt_Manager_Task m_Manager_task = new p3mGantt_Manager_Task();
        public p3mGantt_Manager_Calender m_Manager_calender = new p3mGantt_Manager_Calender();


        //data 
        protected DateTime e_datetime_begin = DateTime.Now;
        protected DateTime e_datetime_end = DateTime.Now.AddDays(400); //默认30天长度,*包含


        //protected  Dictionary<string, gmGantt_item> xe_items = new Dictionary<string, gmGantt_item>();
        //public static gmGantt_item xe_selected_Item = null;

        //0=计划，1=执行，2=完成，3=取消，4=过期
        public Color m_clrChannel_0 = Color.Red; //计划
        public Color m_clrChannel_1 = Color.Blue; //完成1，双色间隔，支持多段进度
        public Color m_clrChannel_2 = Color.Green; // lime
        public Color m_clrChannel_3 = Color.Orange; //hatch xx
        public Color m_clrChannel_4 = Color.Gray; //

        public int m_channel_nHeight = 16;
        public int m_channel_nGap = 4;


        public RectangleF m_rtfPage = new RectangleF(0f, 0f, 2000f, 800f); //高度、宽度指定，超出：屏幕滚动，打印分页



        public p3mWidget_GanttChart()
        {
            InitializeComponent();

            _ins = this;
        }

        public void ex_refresh()
        {
            pictureBox_task_header.Refresh();
            pictureBox_task.Refresh();

            pictureBox_calender.Refresh();
            pictureBox_bar.Refresh();
        }

        public bool ex_Load(string sXml)
        {
            if (false == p3mGantt_top.gSub_xml_load(sXml))
                return false;
            ex_Update(false);
            ex_refresh();
            return true;
        }
        public bool ex_Save(string sXml)
        {
            return p3mGantt_top.gSub_xml_save(sXml);
        }

        /// <summary>
        /// ok,最简单的顺序显示
        /// </summary>
        /// <param name="bSelected"></param>
        public void ex_Update_1_simple(bool bSelected)
        {
            //m_Manager_task.g_listTask.Clear();
            p3mGantt_top.xg_listTask.Clear();

            var drs = p3mGantt_top.xg_dataset.Tables["gantt_task"].Rows;
            int idx = 1;

            foreach (DataRow dr1 in drs)
            {
                p3mGantt_Task task1 = new p3mGantt_Task();
                task1._drTask = dr1;
                //task1._numOrder = idx;

                //task1._nLevel =Convert.ToInt32( dr1["_nLevel"]);
                //task1._sGuid =dr1["_sGuid"].ToString();

                //task1._nLevel = task1.getLevel();
                //task1._sGuid = task1.getGuid();

                p3mGantt_top.xg_listTask.Add(task1);

                idx++;
            }

            if (false == m_Manager_task.Sub2_getScope_byViewMode(bSelected))
                return;

            //ok
            //if (false == m_Manager_task.subData_getScope_Prj(ref m_dtpPrj._begin,ref m_dtpPrj._end))
            //    return;

            //sub_setScope_byBarViewMode_byCalenderType(m_bar.m_eViewMode,m_calender.m_calender.m_eType);
            sub_setScope_byBarViewMode_byCalenderType(p3mGantt_Bar_View_Mode.项目范围整体, m_Manager_calender.m_calender.m_eType);
        }

        public void ex_Update(bool bSelected)
        {
            //m_Manager_task.g_listTask.Clear();
            p3mGantt_top.xg_listTask.Clear();

            //var drs = p3mGantt_top.xg_dataset.Tables["gantt_task"].Rows;
            var drs = p3mGantt_top.xg_dataset.Tables["gantt_task"].Select("", "_nLevel"); //保证level排序，否则需要多次遍历
            int idx = 1;

            foreach (DataRow dr1 in drs)
            {
                int nLevel = Convert.ToInt32(dr1["_nLevel"]);
                string sguid = dr1["_sGuid"].ToString();
                if(nLevel>0)
                {
                    int cnt1 = p3mGantt_top.xg_listTask.Count;
                    bool bInsert = false; //是否已经插入
                    for (int i = 0; i < cnt1; i++)
                    {

                    }

                    //非root不直接添加
                    //continue;
                }
                
                p3mGantt_Task task1 = new p3mGantt_Task();
                task1._drTask = dr1;
                p3mGantt_top.xg_listTask.Add(task1);

                idx++;
            }

            if (false == m_Manager_task.Sub2_getScope_byViewMode(bSelected))
                return;

            //ok
            //if (false == m_Manager_task.subData_getScope_Prj(ref m_dtpPrj._begin,ref m_dtpPrj._end))
            //    return;

            //sub_setScope_byBarViewMode_byCalenderType(m_bar.m_eViewMode,m_calender.m_calender.m_eType);
            sub_setScope_byBarViewMode_byCalenderType(p3mGantt_Bar_View_Mode.项目范围整体, m_Manager_calender.m_calender.m_eType);
        }


        private void POP_viewmode_Click(object sender, EventArgs e)
        {
            var m1 = sender as ToolStripMenuItem;
            if (m1 == null)
                return;
            var tag1 = m1.Tag;
            if (tag1 == null)
                return;
            var stag1 = tag1.ToString();

            var eViewMode = sub_getViewMode(stag1);
            m_Manager_task.Sub2_getScope_byViewMode(true);
            sub_setScope_byBarViewMode_byCalenderType(eViewMode, m_Manager_calender.m_calender.m_eType);
            ex_refresh();
        }


        //protected p3mGantt_Bar_View_Mode sub_getViewMode(string sViewMode)
        //{
        //    p3mGantt_Bar_View_Mode eMode = p3mGantt_Bar_View_Mode.任务范围;
        //    switch (sViewMode)
        //    {
        //        case "viewmode_task":
        //            m_Manager_bar.m_eViewMode = p3mGantt_Bar_View_Mode.任务范围;
        //            break;
        //        case "viewmode_utask":
        //            m_Manager_bar.m_eViewMode = p3mGantt_Bar_View_Mode.上级任务范围;
        //            break;
        //        //case "viewmode_eng":
        //        //    m_bar.m_eViewMode = p3mGantt_Bar_View_Mode.工程范围;
        //        //    break;
        //        case "viewmode_prj":
        //            m_Manager_bar.m_eViewMode = p3mGantt_Bar_View_Mode.项目范围整体;
        //            break;
        //    }
        //    return eMode;
        //}
        protected p3mGantt_Bar_View_Mode sub_getViewMode(string sViewMode)
        {
            p3mGantt_Bar_View_Mode eMode = p3mGantt_Bar_View_Mode.任务范围;
            switch (sViewMode)
            {
                case "viewmode_task":
                    eMode = p3mGantt_Bar_View_Mode.任务范围;
                    break;
                case "viewmode_utask":
                    eMode = p3mGantt_Bar_View_Mode.上级任务范围;
                    break;
                //case "viewmode_eng":
                //    m_bar.m_eViewMode = p3mGantt_Bar_View_Mode.工程范围;
                //    break;
                case "viewmode_prj":
                    eMode = p3mGantt_Bar_View_Mode.项目范围整体;
                    break;
            }
            return eMode;
        }

        protected bool sub_setScope_byBarViewMode_byCalenderType(p3mGantt_Bar_View_Mode eViewMode,p3mGantt_Calender_Type eType)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now.AddYears(2);

            switch (eViewMode)
            {
                case p3mGantt_Bar_View_Mode.任务范围:
                    dt1 = m_Manager_task.m_dtpTask._begin;
                    dt2 = m_Manager_task.m_dtpTask._end;
                    break;

                case p3mGantt_Bar_View_Mode.上级任务范围:
                    dt1 = m_Manager_task.m_dtpUtask._begin;
                    dt2 = m_Manager_task.m_dtpUtask._end;
                    break;

                //case p3mGantt_Bar_View_Mode.工程范围:
                //    dt1 = m_dtpEng._begin;
                //    dt2 = m_dtpEng._end;
                //    break;

                case p3mGantt_Bar_View_Mode.项目范围整体:
                    dt1 = m_Manager_task.m_dtpPrj._begin;
                    dt2 = m_Manager_task.m_dtpPrj._end;
                    break;
            }

            //dt1需要小于dt2：保证顺序，也限制不能相同日期，即工期必须大于1天
            //if (dt1 > dt2)
            if (dt1.Date >= dt2.Date)
            {
                return false;
            }

            //*限制不能早于10年前
            if (dt1 < DateTime.Now.AddYears(-10))
                return false;
            //*限制不能晚于于30年后
            if (dt2 > DateTime.Now.AddYears(30))
                return false;


            switch (eType)
            {
                case p3mGantt_Calender_Type.年份_year:
                    e_datetime_begin = new DateTime(dt1.Year, 1, 1, 0, 0, 0);
                    e_datetime_end = new DateTime(dt2.Year, 12, 31, 0, 0, 0);
                    break;

                default:
                    //时间单位：日，去除time的影响
                    e_datetime_begin = new DateTime(dt1.Year, dt1.Month, dt1.Day, 0, 0, 0);
                    e_datetime_end = new DateTime(dt2.Year, dt2.Month, dt2.Day, 0, 0, 0);  //?结束日包含

                    if (m_option._nScopeGap_cent > 0)
                    {
                        double days = (dt2 - dt1).TotalDays;
                        int dayGap = Convert.ToInt32(days * m_option._nScopeGap_cent / 100.0);
                        e_datetime_begin = e_datetime_begin.AddDays(-dayGap);
                        e_datetime_end = e_datetime_end.AddDays(dayGap);
                    }

                    break;                
            }

            m_Manager_task.m_eViewMode = eViewMode;
            m_Manager_calender.m_calender.m_eType = eType;

            return true;
        }



        private void pictureBox_bar_Paint(object sender, PaintEventArgs e)
        {
            var rtViewArea = pictureBox_bar.ClientRectangle;
            var g0 = e.Graphics;
            //g0.Clear(m_plot_option._clrBackColor_calender);
            g0.SmoothingMode = SmoothingMode.AntiAlias;

            // g0.DrawString("甘特图 绘图", new Font("楷体", 32), Brushes.Silver, new Point(10, 10));
            //g0.DrawString("甘特图", new Font("楷体", 12), Brushes.Silver, rtViewArea);

            m_Manager_task.m_oBar.draw(g0, rtViewArea, e_datetime_begin, e_datetime_end, m_option);

        }

        private void pictureBox_task_Paint(object sender, PaintEventArgs e)
        {
            var rtViewArea = pictureBox_task.ClientRectangle;
            var g0 = e.Graphics;
            //g0.Clear(m_plot_option._clrBackColor_calender);
            g0.SmoothingMode = SmoothingMode.AntiAlias;

            //g0.DrawString("任务", new Font("楷体", 12), Brushes.Silver, rtViewArea);

            m_Manager_task.m_oInfo.draw(g0, rtViewArea, m_option);
        }

        private void pictureBox_calender_Paint(object sender, PaintEventArgs e)
        {
            var rtViewArea = pictureBox_calender.ClientRectangle;
            var g0 = e.Graphics;
            //g0.Clear(m_plot_option._clrBackColor_calender);
            g0.SmoothingMode = SmoothingMode.AntiAlias;

            //g0.DrawString("日历", new Font("楷体", 12), Brushes.Silver, rtViewArea);
            m_Manager_calender.m_calender.draw(g0, rtViewArea, e_datetime_begin, e_datetime_end, m_option);
        }

        private void pictureBox_task_header_Paint(object sender, PaintEventArgs e)
        {
            var rtViewArea = pictureBox_task_header.ClientRectangle;
            var g0 = e.Graphics;
            //g0.Clear(m_plot_option._clrBackColor_calender);
            g0.SmoothingMode = SmoothingMode.AntiAlias;

            g0.DrawString("信息标题", new Font("楷体", 12), Brushes.Silver, rtViewArea);
        }

        private void POP_TASK_ADD_ROOT_Click(object sender, EventArgs e)
        {
            p3mGantt_Manager_Task.exTask_add();
            ex_Update(false);
            ex_refresh();
        }

        private void POP_TASK_ADD_CHILD_Click(object sender, EventArgs e)
        {
            p3mGantt_Manager_Task.exTask_add_child();
            ex_Update(false);
            ex_refresh();

        }

        private void pictureBox_bar_MouseUp(object sender, MouseEventArgs e)
        {
            Point pt1 = new Point(e.X, e.Y);
            p3mGantt_top.xg_Selected_oTask = null;

            int idx =(int) (e.Y / m_option.Task_nHeight);
            if (idx >= p3mGantt_top.xg_listTask.Count)
            {
                if (e.Button == MouseButtons.Right)
                {
                    //弹出菜单
                    POP_task_Noselected.Show(pictureBox_bar, new Point(e.X, e.Y));
                }
                return;
            }

            p3mGantt_top.xg_Selected_oTask = p3mGantt_top.xg_listTask[idx];
            ex_refresh();

            if (p3mGantt_top.xg_Selected_oTask != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //显示info
                    //MessageBox.Show(p3mGantt_top.xg_Selected_oTask._sGuid_temp);
                }

                if (e.Button == MouseButtons.Right)
                {
                    //弹出菜单
                    POP_task_Selected.Show(pictureBox_bar, new Point(e.X, e.Y));
                }

                //应该getscope

            }
            //else
            //{
            //    POP_bar.Show(pictureBox_bar, new Point(e.X, e.Y));
            //}

        }

        private void pictureBox_task_MouseUp(object sender, MouseEventArgs e)
        {
            //bar=task 选择操作
            Point pt1 = new Point(e.X, e.Y);
            p3mGantt_top.xg_Selected_oTask = null;

            int idx = (int)(e.Y / m_option.Task_nHeight);
            if (idx >= p3mGantt_top.xg_listTask.Count)
            {
                if (e.Button == MouseButtons.Right)
                {
                    //弹出菜单
                    POP_task_Noselected.Show(pictureBox_task, new Point(e.X, e.Y));
                }
                return;
            }


            p3mGantt_top.xg_Selected_oTask = p3mGantt_top.xg_listTask[idx];
            ex_refresh();

            if (p3mGantt_top.xg_Selected_oTask != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //显示info
                    //MessageBox.Show(p3mGantt_top.xg_Selected_oTask._sGuid_temp);
                }

                if (e.Button == MouseButtons.Right)
                {
                    //弹出菜单
                    POP_task_Selected.Show(pictureBox_task, new Point(e.X, e.Y));
                }

                //应该getscope

            }
            //else
            //{
            //    POP_task.Show(pictureBox_task, new Point(e.X, e.Y));
            //}

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            p3mGantt_Manager_Task.exTask_edit();
            ex_Update(true);
            ex_refresh();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            p3mGantt_Manager_Task.exTask_delete();
            ex_Update(false);
            ex_refresh();
        }
    }


}


//var dt0 = DateTime.Now;
//label_today.Text = dt0.ToString("今日：yyyy年MM月dd日 dddd");
////gmGantt_fixed.xe_setday = dt0;
//gmGantt_fixed.xe_setday = new DateTime(dt0.Year, dt0.Month, dt0.Day, 0, 0, 0);
//label_setday.Text = gmGantt_fixed.xe_setday.ToString("计划开始日期：yyyy年MM月dd日 dddd");



//public static void ex_sql()
//{
//    var y1 = (xe_setday.Year - 1).ToString() + "-12-31";
//    var y2 = (xe_setday.Year + 1).ToString() + "-01-01";
//    //DataRow[] drs = xe_dataset.Tables["gantt_task"].Select("_begin>'" + y1 + "' and _end<'" + y2+"'", "_begin asc,_end desc"); xx

//    //DataRow[] drs = xe_dataset.Tables["gantt_task"].Select("_begin>'" + y1 + "' and _end<'" + y2 + "'", "_begin,_end");
//    xe_drs = xe_dataset.Tables["gantt_task"].Select("_begin>'" + y1 + "' and _end<'" + y2 + "'", "_begin,_end");
//    //xe_items.Clear();
//}

//public void ex_sql()
//{
//    m_task._tasks.Clear();

//    var drs = xe_dataset.Tables["gantt_task"].Rows;
//    int idx = 1;

//    foreach(DataRow  dr1 in drs)
//    {
//        p3mGantt_Task task1 = new p3mGantt_Task();
//        task1._drTask = dr1;
//        task1._numOrder = idx;
//        m_task._tasks.Add(task1);

//        idx++;
//    }
//}



