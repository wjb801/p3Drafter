using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace p3mWidget
{
    public class p3mGantt_draw_option
    {
        public int _nScopeGap_cent = 5; //两端增加空余量,百分比

        //public int w_viewPanX = 0;
        //public int w_viewPanY = 0;

        ////-----------------------------
        ////用于view pan，基于数据数值 
        //public int t_down_x = -1;
        //public int t_down_y = -1;
        //public int t_move_x = -1;
        //public int t_move_y = -1;

        ////基于视图的数值
        //public int t_View_down_x = -1;
        //public int t_View_down_y = -1;

        //public int t_View_move_x = -1;
        //public int t_View_move_y = -1;

        //public bool t_bPanning = false;

        //---------
        public int _nFontSize_info_header = 10;
        public int _nFontSize_task = 12;
        public int _nFontSize_calender_C1 = 12;
        public int _nFontSize_calender_C2 = 10;
        public int _nFontSize_bar = 12;

        public string _sFontName_info_header = "arial";
        public string _SFontName_task = "arial";
        public string _SFontName_calender_C1 = "arial";
        public string _SFontName_calender_C2 = "arial";
        public string _SFontName_bar = "arial";

        public Color _clrFontColor_info_header = Color.Black;
        public Color _clrFontColor_task = Color.Black;
        public Color _clrFontColor_calender_C1 = Color.Black;
        public Color _clrFontColor_calender_C2 = Color.Black;
        public Color _clrFontColor_bar = Color.Black;

        //infoHeaer,calender,task,bar

        public int Calender_marker_c1_nLength = 20;
        public int Calender_marker_c2_nLength = 10;
        public Color Calender_clrBackColor = Color.Silver;


        public Color InfoHeader_clrBackColor = Color.Silver;
        

        public Color Task_clrBackColor= Color.White;
        public Color Task_clrGridColor = Color.DarkGray;


        public Color Bar_clrBackColor = Color.White;
        public Color Bar_clrGridColor = Color.DarkGray;

        //public Brush[] Bar_listBrush = new Brush[] { Brushes.Black, Brushes.Red, Brushes.Lime, Brushes.Blue, Brushes.Gold, Brushes.Brown, Brushes.DarkGoldenrod };
        public Brush[] Bar_listBrush = new Brush[] { Brushes.Gray, Brushes.Red, Brushes.Lime, Brushes.Blue, Brushes.Gold, Brushes.Brown, Brushes.DarkGoldenrod };

        ////0=计划，1=执行，2=完成，3=取消，4=过期
        //public Color m_clrChannel_0 = Color.Red; //计划
        //public Color m_clrChannel_1 = Color.Blue; //完成1，双色间隔，支持多段进度
        //public Color m_clrChannel_2 = Color.Green; // lime
        //public Color m_clrChannel_3 = Color.Orange; //hatch xx
        //public Color m_clrChannel_4 = Color.Gray; //

        public int Task_nHeight = 25;  //task=info+bar
        public int Task_nIndent = 10; //level显示缩进
        public Color Task_clrSelected = Color.LightGray;


    }


}
