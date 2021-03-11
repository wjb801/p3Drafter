using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace p3mWidget
{
    /// <summary>
    /// 阶段1：精度支持到 日
    /// 阶段2：精度支持到 分钟 (?小时 x)
    /// </summary>
    public class p3mGantt_Calender_byLayout : p3mGantt_Calender
    {
        public DateTime m_dt0_byDay; //当前日期，精确到日       

        public gantt_canlender_layout m_layout = new gantt_canlender_layout();

        public void draw(Graphics g1, RectangleF rtfPage)
        {
            //g1.DrawString("日历 单位：日", new Font("宋体", 12), Brushes.Red, new PointF(10.0f, 10.0f));

            //*?用event
            switch (m_eType)
            {
                case p3mGantt_Calender_Type.固定组合固定宽度_layout_year2month:
                    subdraw_Mode_year2month(g1,rtfPage);
                    break;

                case p3mGantt_Calender_Type.固定组合固定宽度_layout_month2day:
                    subdraw_Mode_month2day(g1, rtfPage);
                    break;

                case p3mGantt_Calender_Type.固定组合固定宽度_layout_month2week:
                    subdraw_Mode_month2week(g1, rtfPage);
                    break;

                case p3mGantt_Calender_Type.固定组合固定宽度_layout_week2day:
                    subdraw_Mode_week2day(g1, rtfPage);
                    break;

                //case gantt_canlender_mode.day2hour:
                //    subdraw_Mode_day2hour(g1, rtfPage);
                //    break;
            }
        }

        protected void subdraw_Mode_year2month(Graphics g1, RectangleF rtfPage)
        {
            //g1.DrawString("日历 单位：年，精度：日", new Font("宋体", 12), Brushes.Red, new PointF(10.0f, 10.0f));

            float x0 = 0;
            float y0 = 0;

            Pen pen1 = new Pen(Color.Black, 1);
            Pen pen3 = new Pen(Color.Black, 1);
            pen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            //for(int i=0;i<m_layout.e_datetimeLength;i++)
            int nyear = 100;
            for (int i = 0; i < nyear; i++)
            {

                //float x = m_layout.gantt_ColumnWidth[(int)m_layout.m_eMode] * i;
                float x = m_layout.getWidth(m_eType)*i;
                if (x > rtfPage.Right)
                    continue;

                PointF pt1 = new PointF(x, rtfPage.Top);
                PointF pt2 = new PointF(x, rtfPage.Height);
                g1.DrawLine(pen1, pt1, pt2);

                //string sYear = m_layout.e_datetimeStart.ToString("yyyy-MM-dd");
                //string sYear = m_layout.e_datetimeStart.AddYears(i).ToString("yyyy-MM-dd");
                string sYear = m_layout.e_datetimeStart.AddYears(i).ToString("yyyy年");
                PointF ptYear = new PointF(x + 2, rtfPage.Top + 2);
                g1.DrawString(sYear, new Font("宋体", 12), Brushes.Red, ptYear);

                string sub1 = m_layout.e_datetimeStart.AddYears(i).ToString("1-12月");
                PointF ptSub1 = new PointF(x + 2, rtfPage.Top + m_layout.gantt_TopTitle_height + 2);
                g1.DrawString(sub1, new Font("宋体", 12), Brushes.Red, ptSub1);

                //for(int j=1;j< m_layout.gantt_ColumnWidth_count[(int)m_layout.m_eMode]; j++)
                for (int j = 1; j < 12; j++)
                {
                    //float x3 = x + j * m_layout.gantt_ColumnWidth_mark[(int)m_layout.m_eMode];
                    float x3 = x + j * 10;
                    PointF pt31 = new PointF(x3, rtfPage.Top + m_layout.gantt_TopTitle_height + m_layout.gantt_TopTitle_height2);
                    PointF pt32 = new PointF(x3, rtfPage.Height);
                    g1.DrawLine(pen3, pt31, pt32);
                }
            }

            PointF pt1title = new PointF(rtfPage.Left, rtfPage.Top + m_layout.gantt_TopTitle_height);
            PointF pt2title = new PointF(rtfPage.Right, rtfPage.Top + m_layout.gantt_TopTitle_height);
            Pen penT1 = new Pen(Color.Black, 1);
            g1.DrawLine(penT1, pt1title, pt2title);

            PointF pt1title2 = new PointF(rtfPage.Left, rtfPage.Top + m_layout.gantt_TopTitle_height + m_layout.gantt_TopTitle_height2);
            PointF pt2title2 = new PointF(rtfPage.Right, rtfPage.Top + m_layout.gantt_TopTitle_height + m_layout.gantt_TopTitle_height2);
            Pen penT2 = new Pen(Color.Black, 1);
            g1.DrawLine(penT2, pt1title2, pt2title2);

        }
        protected void subdraw_Mode_month2week(Graphics g1, RectangleF rtfPage)
        {
            float x0 = 0;
            float y0 = 0;

            Pen pen1 = new Pen(Color.Black, 1);
            Pen pen3 = new Pen(Color.Black, 1);
            pen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            int nmonth = 100;
            for (int i = 0; i < nmonth; i++)
            {
                //float x = m_layout.gantt_ColumnWidth[(int)m_layout.m_eMode] * i;
                float x = m_layout.getWidth(m_eType)*i;
                if (x > rtfPage.Right)
                    continue;

                PointF pt1 = new PointF(x, rtfPage.Top);
                PointF pt2 = new PointF(x, rtfPage.Height);
                g1.DrawLine(pen1, pt1, pt2);

                //string sYear = m_layout.e_datetimeStart.AddMonths(i).ToString("yyyy年MM月");
                string sMonth = m_layout.e_datetimeStart.AddMonths(i).ToString("yyyy.MM");
                PointF ptYear = new PointF(x + 2, rtfPage.Top + 2);
                g1.DrawString(sMonth, new Font("宋体", 12), Brushes.Red, ptYear);

                string sub1 = m_layout.e_datetimeStart.AddYears(i).ToString("1-4周");
                PointF ptSub1 = new PointF(x + 2, rtfPage.Top + m_layout.gantt_TopTitle_height + 2);
                g1.DrawString(sub1, new Font("宋体", 12), Brushes.Red, ptSub1);

                //**需要独立计算，week与month没有直接对应关系,,,,先按照数量
                for (int j = 1; j < 4; j++)
                {
                    float x3 = x + j * 25;
                    PointF pt31 = new PointF(x3, rtfPage.Top + m_layout.gantt_TopTitle_height + m_layout.gantt_TopTitle_height2);
                    PointF pt32 = new PointF(x3, rtfPage.Height);
                    g1.DrawLine(pen3, pt31, pt32);
                }

            }

            PointF pt1title = new PointF(rtfPage.Left, rtfPage.Top + m_layout.gantt_TopTitle_height);
            PointF pt2title = new PointF(rtfPage.Right, rtfPage.Top + m_layout.gantt_TopTitle_height);
            Pen penT1 = new Pen(Color.Black, 1);
            g1.DrawLine(penT1, pt1title, pt2title);

            PointF pt1title2 = new PointF(rtfPage.Left, rtfPage.Top + m_layout.gantt_TopTitle_height + m_layout.gantt_TopTitle_height2);
            PointF pt2title2 = new PointF(rtfPage.Right, rtfPage.Top + m_layout.gantt_TopTitle_height + m_layout.gantt_TopTitle_height2);
            Pen penT2 = new Pen(Color.Black, 1);
            g1.DrawLine(penT2, pt1title2, pt2title2);

        }

        protected void subdraw_Mode_month2day(Graphics g1, RectangleF rtfPage)
        {

        }
        protected void subdraw_Mode_week2day(Graphics g1, RectangleF rtfPage)
        {

        }
        protected void subdraw_Mode_day2hour(Graphics g1, RectangleF rtfPage)
        {

        }






    }
}
