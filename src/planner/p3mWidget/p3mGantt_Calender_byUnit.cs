using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3mWidget
{
    public class p3mGantt_Calender_byUnit : p3mGantt_Calender
    {
        
    }




    //private void gmGantt_fixed_Paint(object sender, PaintEventArgs e)
    //{
    //    var g0 = e.Graphics;
    //    var rt1 = this.ClientRectangle;

    //    Pen penTitle = new Pen(Color.Black, 1);
    //    Font fontTitle = new Font("arial", 12);
    //    Rectangle rtTitle = new Rectangle(0, 0, rt1.Width, m_calender_nHeight);
    //    g0.FillRectangle(Brushes.LightGray, rtTitle);


    //    var drs = xe_drs;
    //    if (drs != null)
    //    {
    //        string sHeader = "日计划";
    //        if (m_eType == gmGantt_fixed_type.day)
    //        {
    //            drawSub_day(g0, rt1, drs);
    //            sHeader = "日计划";
    //        }
    //        if (m_eType == gmGantt_fixed_type.week)
    //        {
    //            drawSub_week(g0, rt1, drs);
    //            sHeader = "周计划";
    //        }
    //        if (m_eType == gmGantt_fixed_type.month)
    //        {
    //            drawSub_month(g0, rt1, drs);
    //            sHeader = "月计划";
    //        }
    //        if (m_eType == gmGantt_fixed_type.year)
    //        {
    //            drawSub_year(g0, rt1, drs);
    //            sHeader = "年计划";
    //        }

    //        g0.DrawString(sHeader, new Font("楷体", 12), Brushes.Black, new Point(5, m_calender_nHeight + 5));

    //        if (xe_selected_Item != null)
    //        {
    //            Pen penSel = new Pen(Color.Black, 2);
    //            penSel.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
    //            g0.DrawRectangle(penSel, xe_selected_Item._rtPlot);
    //        }

    //    }

    //}

    //protected void drawSub_day(Graphics g1, Rectangle rtViewArea, DataRow[] drs)
    //{
    //    //day：显示hour，30min
    //    Pen pen1 = new Pen(Color.Black, 1);

    //    int nmarker1 = 24;
    //    for (int i = 0; i < nmarker1; i++)
    //    {
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * i) / nmarker1);

    //        //int nhour = xe_setday.Hour;
    //        //if(nhour==i)
    //        //{
    //        //    g1.DrawString(i.ToString() + ":00", new Font("arial", 9), Brushes.Red, new Point(x1, 0));
    //        //}
    //        //else
    //        {
    //            g1.DrawString(i.ToString() + ":00", new Font("arial", 9), Brushes.Black, new Point(x1, 0));
    //        }

    //        if (i == 0)
    //            continue;
    //        Point pt1 = new Point(x1, 0);
    //        Point pt2 = new Point(x1, m_calender_nHeight - 2);
    //        g1.DrawLine(pen1, pt1, pt2);
    //    }

    //    int nmarker2 = 48;
    //    for (int i = 0; i < nmarker2; i++)
    //    {
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * i) / nmarker2);

    //        if ((i % 2) == 0)
    //            continue;

    //        Point pt1 = new Point(x1, m_calender_nHeight - 5);
    //        Point pt2 = new Point(x1, m_calender_nHeight - 1);
    //        g1.DrawLine(pen1, pt1, pt2);
    //    }

    //    int cnt = 0;
    //    SolidBrush brushPlot = new SolidBrush(m_clrChannel_0);
    //    foreach (DataRow r1 in drs)
    //    {
    //        DateTime _begin = Convert.ToDateTime(r1["_begin"]);
    //        DateTime _end = Convert.ToDateTime(r1["_end"]);
    //        //判断标准：开始、结束是相同日期
    //        if (_begin.Date != _end.Date)
    //            continue;

    //        if (_begin.Date != xe_setday.Date)
    //            continue;

    //        int hour1 = _begin.Hour;
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * hour1) / 24);
    //        int hour2 = _end.Hour;
    //        int x2 = Convert.ToInt32((float)(rtViewArea.Width * hour2) / 24);
    //        int dx = x2 - x1;
    //        int y1 = cnt * (m_channel_nHeight + m_channel_nGap) + (m_calender_nHeight + m_channel_nGap);
    //        int dy = m_channel_nHeight;

    //        Rectangle rtPlot = new Rectangle(x1, y1, dx, dy);
    //        g1.FillRectangle(brushPlot, rtPlot);

    //        cnt++;

    //        string sNum = "[" + cnt.ToString() + "].";
    //        Point ptNum = new Point(x1 - 20, y1);
    //        g1.DrawString(sNum, new Font("arial", 9), Brushes.Black, ptNum);

    //        string sguid = r1["_sGuid"].ToString();
    //        //xe_items[sguid] = rtPlot;
    //        gmGantt_item it1 = new gmGantt_item();
    //        it1._sGuid = sguid;
    //        it1._row = r1;
    //        it1._rtPlot = rtPlot;
    //        it1._eType = gmGantt_fixed_type.day;
    //        xe_items[sguid] = it1;
    //    }


    //}
    //protected void drawSub_week(Graphics g1, Rectangle rtViewArea, DataRow[] drs)
    //{
    //    //g1.DrawString("周计划", new Font("楷体", 12), Brushes.Silver, new Point(10, 10));
    //    Pen pen1 = new Pen(Color.Black, 1);

    //    int nmarker1 = 7;
    //    //DateTime dt1 = DateTime.Now.AddDays((int)DateTime.Now.DayOfWeek * (-1)); //?星期日开始
    //    //DateTime dt1 = DateTime.Now.AddDays((int)DateTime.Now.DayOfWeek * (-1)+1); //星期一开始
    //    DateTime dt1 = xe_setday.AddDays((int)xe_setday.DayOfWeek * (-1) + 1);
    //    var dtMin = dt1;
    //    var dtMax = dt1.AddDays(7);
    //    for (int i = 0; i < nmarker1; i++)
    //    {
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * i) / nmarker1);
    //        var dt2 = dt1.AddDays(i);
    //        //if(Math.Abs((dt2- xe_setday).TotalDays)<0.1)
    //        //{
    //        //    //*当日特殊显示
    //        //    g1.DrawString(dt2.ToString("yyyy-MM-dd dddd"), new Font("arial", 9), Brushes.Red, new Point(x1, 0));
    //        //}
    //        //else
    //        {
    //            //g1.DrawString("星期"+i.ToString()+ " 2021-01-25", new Font("arial", 9), Brushes.Black, new Point(x1, 0));
    //            g1.DrawString(dt2.ToString("yyyy-MM-dd dddd"), new Font("arial", 9), Brushes.Black, new Point(x1, 0));
    //        }

    //        Point pt1 = new Point(x1, 0);
    //        Point pt2 = new Point(x1, m_calender_nHeight - 2);
    //        g1.DrawLine(pen1, pt1, pt2);
    //    }

    //    int nmarker2 = nmarker1 * 2; //12:00是1/2
    //    for (int i = 1; i < nmarker2; i++)
    //    {
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * i) / nmarker2);

    //        if ((i % 2) == 0)
    //            continue;

    //        Point pt1 = new Point(x1, m_calender_nHeight - 5);
    //        Point pt2 = new Point(x1, m_calender_nHeight - 1);
    //        g1.DrawLine(pen1, pt1, pt2);
    //    }

    //    int cnt = 0;
    //    SolidBrush brushPlot = new SolidBrush(m_clrChannel_0);
    //    //foreach (DataRow r1 in xe_dataset.Tables["gantt_task"].Rows)
    //    foreach (DataRow r1 in drs)
    //    {
    //        //应该是周1与周日与setday比较
    //        if (dtMin > xe_setday)
    //            continue;
    //        if (dtMax < xe_setday)
    //            continue;

    //        DateTime _begin = Convert.ToDateTime(r1["_begin"]);
    //        DateTime _end = Convert.ToDateTime(r1["_end"]);

    //        //判断标准：同周，不同日
    //        if (_begin.Date == _end.Date)
    //            continue;
    //        //xx 年开始几天未处理，计算错误
    //        //int beginweek = r1._begin.DayOfYear / 7 + 1;
    //        //int endweek = r1._end.DayOfYear / 7 + 1;
    //        //ok
    //        int beginweek = GetWeekOfYear(_begin);
    //        int endweek = GetWeekOfYear(_end);
    //        if (beginweek != endweek)
    //            continue;


    //        double nday1 = (_begin - dt1).TotalDays;
    //        int x1 = Convert.ToInt32((rtViewArea.Width * nday1) / nmarker1);
    //        double nday2 = (_end - dt1).TotalDays + 1.0; //包含结束日期
    //        int x2 = Convert.ToInt32((rtViewArea.Width * nday2) / nmarker1);
    //        int dx = x2 - x1;
    //        int y1 = cnt * (m_channel_nHeight + m_channel_nGap) + (m_calender_nHeight + m_channel_nGap);
    //        int dy = m_channel_nHeight;

    //        Rectangle rtPlot = new Rectangle(x1, y1, dx, dy);
    //        g1.FillRectangle(brushPlot, rtPlot);

    //        cnt++;

    //        string sNum = "[" + cnt.ToString() + "].";
    //        Point ptNum = new Point(x1 - 20, y1);
    //        g1.DrawString(sNum, new Font("arial", 9), Brushes.Black, ptNum);


    //        string sguid = r1["_sGuid"].ToString();
    //        //xe_items[sguid] = rtPlot;
    //        gmGantt_item it1 = new gmGantt_item();
    //        it1._sGuid = sguid;
    //        it1._row = r1;
    //        it1._rtPlot = rtPlot;
    //        it1._eType = gmGantt_fixed_type.week;
    //        xe_items[sguid] = it1;

    //    }

    //}
    ///// <summary>
    ///// 获取指定日期，在为一年中为第几周
    ///// </summary>
    ///// <param name="dt">指定时间</param>
    ///// <reutrn>返回第几周</reutrn>
    //private static int GetWeekOfYear(DateTime dt)
    //{
    //    GregorianCalendar gc = new GregorianCalendar();
    //    int weekOfYear = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    //    return weekOfYear;
    //}

    //protected void drawSub_month(Graphics g1, Rectangle rtViewArea, DataRow[] drs)
    //{
    //    //g1.DrawString("月计划", new Font("楷体", 12), Brushes.Silver, new Point(10, 10));

    //    Pen pen1 = new Pen(Color.Black, 1);
    //    DateTime dt0 = xe_setday;
    //    DateTime dt1 = new DateTime(dt0.Year, dt0.Month, 1, 0, 0, 0);
    //    DateTime dt2 = new DateTime(dt0.Year, dt0.Month, 1, 0, 0, 0).AddMonths(1);
    //    int nmarker1 = (int)(dt2 - dt1).TotalDays;
    //    for (int i = 0; i < nmarker1; i++)
    //    {
    //        //int x1 = Convert.ToInt32((float)(rtViewArea.Width * i) / nmarker1);
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * i) / nmarker1);
    //        var dt3 = dt1.AddDays(i);

    //        //int nday = xe_setday.Day;
    //        //if (nday == (i+1))
    //        //{
    //        //    //g1.DrawString(dt3.ToString("MM-dd"), new Font("arial", 9), Brushes.Red, new Point(x1, 0));
    //        //    g1.DrawString(dt3.ToString("dd"), new Font("arial", 9), Brushes.Red, new Point(x1, 0));
    //        //}
    //        //else
    //        {
    //            //g1.DrawString(dt3.ToString("MM-dd"), new Font("arial", 9), Brushes.Black, new Point(x1, 0));
    //            g1.DrawString(dt3.ToString("dd"), new Font("arial", 9), Brushes.Black, new Point(x1, 0));
    //        }

    //        //if (i == 0)
    //        //    continue;
    //        Point pt1 = new Point(x1, 0);
    //        Point pt2 = new Point(x1, m_calender_nHeight - 2);
    //        g1.DrawLine(pen1, pt1, pt2);
    //    }

    //    int nmarker2 = nmarker1 * 2; //12:00是1/2
    //    for (int i = 1; i < nmarker2; i++)
    //    {
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * i) / nmarker2);

    //        if ((i % 2) == 0)
    //            continue;

    //        Point pt1 = new Point(x1, m_calender_nHeight - 5);
    //        Point pt2 = new Point(x1, m_calender_nHeight - 1);
    //        g1.DrawLine(pen1, pt1, pt2);
    //    }


    //    int cnt = 0;
    //    SolidBrush brushPlot = new SolidBrush(m_clrChannel_0);
    //    //var dtEnd = dt1.AddDays(6);
    //    //foreach (var r1 in xe_info)
    //    //foreach (DataRow r1 in xe_dataset.Tables["gantt_task"].Rows)
    //    foreach (DataRow r1 in drs)
    //    {
    //        DateTime _begin = Convert.ToDateTime(r1["_begin"]);
    //        DateTime _end = Convert.ToDateTime(r1["_end"]);
    //        string sguid = r1["_sGuid"].ToString();

    //        //未处理过的-xx 因为重复处理有问题
    //        //gmGantt_item it0;
    //        //xe_items.TryGetValue(sguid, out it0);
    //        //if (it0 != null)
    //        //{
    //        //    if ((it0._eType != gmGantt_fixed_type.none)&&(it0._eType != gmGantt_fixed_type.month))
    //        //        continue;
    //        //}

    //        if ((_begin.Year != xe_setday.Year) || (_begin.Month != xe_setday.Month))
    //            continue;
    //        if ((_end.Year != xe_setday.Year) || (_end.Month != xe_setday.Month))
    //            continue;

    //        //判断标准：同月（开始、结束同月--不会跨年而不会出现本年外的同月）；时长>6天
    //        //*上面setday判断已经包含
    //        //if (_begin.Date.Month !=_end.Date.Month)
    //        //    continue;

    //        //xx 不是长度，而是周次检查 -- 用type代替即可xx
    //        //if ((_end.Date - _begin.Date).TotalDays < 6.0)
    //        //    continue;
    //        int beginweek = GetWeekOfYear(_begin);
    //        int endweek = GetWeekOfYear(_end);
    //        //if (beginweek == endweek)
    //        //    continue;

    //        int v1 = _begin.Day;
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * (v1 - 1)) / nmarker1); //日期从1日开始，坐标序号从0开始，需要偏移 -1
    //        int v2 = _end.Day;
    //        int x2 = Convert.ToInt32((float)(rtViewArea.Width * (v2 + 1 - 1)) / nmarker1); //包含结束日，需要+1.0
    //        int dx = x2 - x1;
    //        int y1 = cnt * (m_channel_nHeight + m_channel_nGap) + (m_calender_nHeight + m_channel_nGap);
    //        int dy = m_channel_nHeight;

    //        Rectangle rtPlot = new Rectangle(x1, y1, dx, dy);
    //        g1.FillRectangle(brushPlot, rtPlot);

    //        cnt++;

    //        string sNum = "[" + cnt.ToString() + "].";
    //        Point ptNum = new Point(x1 - 20, y1);
    //        g1.DrawString(sNum, new Font("arial", 9), Brushes.Black, ptNum);

    //        //string sguid = r1["_sGuid"].ToString();
    //        //xe_items[sguid] = rtPlot;
    //        gmGantt_item it1 = new gmGantt_item();
    //        it1._sGuid = sguid;
    //        it1._row = r1;
    //        it1._rtPlot = rtPlot;
    //        it1._eType = gmGantt_fixed_type.month;
    //        xe_items[sguid] = it1;
    //    }


    //}

    //protected void drawSub_year(Graphics g1, Rectangle rtViewArea, DataRow[] drs)
    //{
    //    //g1.DrawString("年计划", new Font("楷体", 12), Brushes.Silver, new Point(10, 10));
    //    Pen pen1 = new Pen(Color.Black, 1);

    //    DateTime dt0 = xe_setday;
    //    DateTime dt1 = new DateTime(dt0.Year, 1, 1, 0, 0, 0);
    //    DateTime dt2 = new DateTime(dt0.Year, 1, 1, 0, 0, 0).AddYears(1);
    //    //DateTime dt2 = new DateTime(dt0.Year, dt0.Month, 1, 0, 0, 0).AddMonths(1);
    //    int yeardays = (int)(dt2 - dt1).TotalDays;

    //    int nmarker1 = 12;
    //    for (int i = 0; i < nmarker1; i++)
    //    {
    //        //int x1 = Convert.ToInt32((float)(rtViewArea.Width * i) / nmarker1); //x月不是均匀的
    //        DateTime dt3 = new DateTime(dt0.Year, dt0.Month, 1, 0, 0, 0).AddMonths(i);
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * (float)(dt3 - dt1).TotalDays) / yeardays); //x月不是均匀的

    //        //int nmonth = xe_setday.Month;
    //        //if (nmonth == (i+1))
    //        //{
    //        //    //g1.DrawString(dt3.ToString("yyyy年MM月")  , new Font("arial", 9), Brushes.Red, new Point(x1, 0));
    //        //    g1.DrawString(dt3.ToString("MM月"), new Font("arial", 9), Brushes.Red, new Point(x1, 0));
    //        //}
    //        //else
    //        {
    //            //g1.DrawString(dt3.ToString("yyyy年MM月") , new Font("arial", 9), Brushes.Black, new Point(x1, 0));
    //            g1.DrawString(dt3.ToString("MM月"), new Font("arial", 9), Brushes.Black, new Point(x1, 0));
    //        }

    //        if (i == 0)
    //            continue;
    //        Point pt1 = new Point(x1, 0);
    //        Point pt2 = new Point(x1, m_calender_nHeight - 2);
    //        g1.DrawLine(pen1, pt1, pt2);
    //    }

    //    int nmarker2 = 12;
    //    for (int i = 0; i < nmarker2; i++)
    //    {
    //        //int x1 = Convert.ToInt32((float)(rtViewArea.Width * i) / nmarker2);
    //        DateTime dt3 = new DateTime(dt0.Year, dt0.Month, 15, 0, 0, 0).AddMonths(i);
    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * (float)(dt3 - dt1).TotalDays) / yeardays); //x月不是均匀的

    //        Point pt1 = new Point(x1, m_calender_nHeight - 5);
    //        Point pt2 = new Point(x1, m_calender_nHeight - 1);
    //        g1.DrawLine(pen1, pt1, pt2);
    //    }

    //    int cnt = 0;
    //    SolidBrush brushPlot = new SolidBrush(m_clrChannel_0);
    //    //foreach (DataRow r1 in xe_dataset.Tables["gantt_task"].Rows)
    //    foreach (DataRow r1 in drs)
    //    {
    //        DateTime _begin = Convert.ToDateTime(r1["_begin"]);
    //        DateTime _end = Convert.ToDateTime(r1["_end"]);

    //        if (_begin.Year != xe_setday.Year)
    //            continue;
    //        if (_end.Year != xe_setday.Year)
    //            continue;

    //        //判断标准：同年；不同月：2层含义-超过1月长度，跨月--比判断时间长度超过一个月更好*
    //        if (_begin.Date.Year != _end.Date.Year)
    //            continue;
    //        if (_begin.Date.Month == _end.Date.Month)
    //            continue;

    //        int x1 = Convert.ToInt32((float)(rtViewArea.Width * (float)(_begin - dt1).TotalDays) / yeardays); //
    //        double r2 = (_end - dt1).TotalDays + 1.0; //包含结束日，需要+1.0
    //        int x2 = Convert.ToInt32(rtViewArea.Width * r2 / yeardays);

    //        int dx = x2 - x1;
    //        int y1 = cnt * (m_channel_nHeight + m_channel_nGap) + (m_calender_nHeight + m_channel_nGap);
    //        int dy = m_channel_nHeight;

    //        Rectangle rtPlot = new Rectangle(x1, y1, dx, dy);
    //        g1.FillRectangle(brushPlot, rtPlot);

    //        cnt++;

    //        string sNum = "[" + cnt.ToString() + "].";
    //        Point ptNum = new Point(x1 - 20, y1);
    //        g1.DrawString(sNum, new Font("arial", 9), Brushes.Black, ptNum);

    //        string sguid = r1["_sGuid"].ToString();
    //        //xe_items[sguid] = rtPlot;

    //        gmGantt_item it1 = new gmGantt_item();
    //        it1._sGuid = sguid;
    //        it1._row = r1;
    //        it1._rtPlot = rtPlot;
    //        it1._eType = gmGantt_fixed_type.year;
    //        xe_items[sguid] = it1;

    //    }


    //}



}
