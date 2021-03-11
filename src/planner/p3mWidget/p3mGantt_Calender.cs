using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace p3mWidget
{
    public class p3mGantt_Calender : p3mGantt_top
	{
        public p3mGantt_Calender_Type m_eType = p3mGantt_Calender_Type.预定义样式_style;

		public virtual void draw(Graphics g1, Rectangle rtViewArea, DateTime dtBegin, DateTime dtEnd, p3mGantt_draw_option drawOption)
		{

        }

		protected int subTool_getStyle(p3mGantt_Calender_Style_Pair[] _styles, double _width_byView)
		{
			//需要宽度，所以判断为：大于 >
			int idx = _styles.Count();
			for (int i = (_styles.Count() - 1); i >= 0; i--)
			{
				if (_width_byView > _styles[i]._width_View)
				{
					idx = i;
				}
			}
			return idx;
		}

	}

	public class p3mGantt_Calender_Style_Pair
	{
		public int _step_Marker = 1; //刻度步长，单位为当前：年，月，日
		public float _width_View = 10; //整年宽度，
		public string _text_Marker = ""; //刻度显示指定文字；如果为空则显示step，否则显示此序列

		public p3mGantt_Calender_Style_Pair()
		{

		}
		public p3mGantt_Calender_Style_Pair(int inc1, int days1, string _text)
		{
			_step_Marker = inc1;
			_width_View = days1;
			_text_Marker = _text;
		}
	}


}
