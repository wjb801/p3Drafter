using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace p3mWidget
{
    public class p3mGantt_Manager_Calender
    {
        //mode ：精确，年份
        //type ：4种
        //layout ：对立的，如年，月
        //style：显示的不同规则，自动计算选择

        public p3mGantt_Calender m_calender = new p3mGantt_Calender_byStyle();

        protected bool m_calender_bShow = true;
        protected int m_calender_nHeight = 20;

    }

    public enum p3mGantt_Calender_Type
    {
        灵活间隔_auto, //sode 方式 - auto

        固定组合固定宽度_layout_year2month, //p3m 方式
        固定组合固定宽度_layout_month2day,
        固定组合固定宽度_layout_month2week,
        固定组合固定宽度_layout_week2day,
        固定组合固定宽度_layout_day2hour, 

        预定义样式_style, //proGantt style 方式 -style
        
        固定日期时间单位_unit_year, //todolist 方式 unit
        固定日期时间单位_unit_season,
        固定日期时间单位_unit_month,
        固定日期时间单位_unit_tendays,
        固定日期时间单位_unit_week,
        固定日期时间单位_unit_day,

        年份_year, //todolist 方式 unit
    }
       

    public class gantt_canlender_layout
    {
        public float[] gantt_ColumnWidth = new float[] { 120, 100, 100, 100, 100 }; //column,string,well

        public float gantt_TopTitle_height = 22; //统一
        public float gantt_TopTitle_height2 = 22; //统一

        public DateTime e_datetimeStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime e_datetimeEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        public float getWidth(p3mGantt_Calender_Type eType)
        {
            return gantt_ColumnWidth[(eType - p3mGantt_Calender_Type.固定组合固定宽度_layout_year2month) % 5];
        }
    }


}
