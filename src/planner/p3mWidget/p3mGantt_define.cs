using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Drawing;


namespace p3mWidget
{
    public class p3mGantt_define
    {

    }


    public enum calender_mode
    {
        //指定范围,
        //全体范围,
        //指定范围年份,
        //全体范围年份,

        精确日期,
        年份日期,
    }

    public class p3mGantt_Datetime_pair
    {
        public DateTime _begin = DateTime.Now;
        public DateTime _end = DateTime.Now;

        public int getDays(bool bInclude_end)
        {
            int days = 0;


            return days;
        }

    }

    //gantt_task
    //public class gmGantt_fixed_Infomation
    //{
    //    public string _sGuid;
    //    public string _sTitle;
    //    public string _sText;

    //    public DateTime _begin;
    //    public DateTime _end;

    //    //xx
    //    //public int _nOrder; *依赖list内顺序即可
    //}

    ///// <summary>
    ///// 排序类
    ///// </summary>
    //public class InfomationCompare : IComparer<gmGantt_fixed_Infomation>
    //{
    //    //public int Compare(gmGantt_fixed_Infomation x, gmGantt_fixed_Infomation y)
    //    //{
    //    //    //return x.Name.CompareTo(y.Name);
    //    //    return x._begin.CompareTo(y._begin);
    //    //}
    //    public int Compare(gmGantt_fixed_Infomation x, gmGantt_fixed_Infomation y)
    //    {
    //        //return x.Name.CompareTo(y.Name);
    //        if (x._begin == y._begin)
    //        {
    //            return x._end.CompareTo(y._end);
    //        }
    //        return x._begin.CompareTo(y._begin);
    //    }
    //}


    //public class gmGantt_item
    //{
    //    public string _sGuid;
    //    public DataRow _row;
    //    public Rectangle _rtPlot;
    //}




}
