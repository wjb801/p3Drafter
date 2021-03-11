using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace p3mWidget
{
    public class p3mGantt_Calender_byAuto : p3mGantt_Calender
    {
		public p3mGantt_Calender_Style_Pair[] m_Style_Year_fixed =
			new p3mGantt_Calender_Style_Pair[] {
			new p3mGantt_Calender_Style_Pair(6,80,"上半年,下半年"),
			new p3mGantt_Calender_Style_Pair(12, 10,"") //等于不显示
		};

		public override void draw(Graphics g1, Rectangle rtViewArea, DateTime dtBegin, DateTime dtEnd, p3mGantt_draw_option drawOption)
		{
			int y0_plot = 0;

			//DateTime dtBegin = new DateTime(_dtBegin.Year, 1, 1, 0, 0, 0);
			//DateTime dtEnd = new DateTime(_dtEnd.Year, 12, 31, 0, 0, 0);

			Font fontC1 = new Font("arial", 10);
			Font fontC2 = new Font("arial", 8);
			var brushC1 = new SolidBrush(Color.Black);
			var brushC2 = new SolidBrush(Color.Black);

			double tYearWidth_byView = rtViewArea.Width / (dtEnd - dtBegin).TotalDays * 365;

			//year
			{
				Pen pen1 = new Pen(Color.Black, 1);
				//year0不绘制marker，如果是1月1日也不绘制
				int year0 = dtBegin.Year;
				int year1 = dtEnd.Year;
				for (int i = year0; i <= year1; i++)
				{
					var dt1 = new DateTime(i, 1, 1, 0, 0, 0);
					float yearx = subTool_getX(dtBegin, dtEnd, rtViewArea, dt1, false);

					PointF ptf1 = new PointF(yearx, y0_plot);
					PointF ptf2 = new PointF(yearx, rtViewArea.Height);
					g1.DrawLine(pen1, ptf1, ptf2);

					Point ptText = new Point((int)yearx + 2, 2);
					g1.DrawString(i.ToString() + "年", fontC1, brushC1, ptText);
				}
			}

			//month
			//刻度总是显示，文字根据宽度判断
			int idxStyle_month = subTool_getStyle(m_Style_Year_fixed, tYearWidth_byView);
			{
				Pen pen1 = new Pen(Color.Gray, 1);

				//非1步长是从1月开始计算非任务开始月份，步长1则可以任意
				//DateTime month0 = new DateTime(dtBegin.Year, dtBegin.Month, 1, 0, 0, 0);
				DateTime month0 = new DateTime(dtBegin.Year, 1, 1, 0, 0, 0);
				while (month0 < dtEnd)
				{
					month0 = month0.AddMonths(6);
					//开始日期前的月份不需要显示
					if (month0 < dtBegin)
						continue;

					float monthx = subTool_getX(dtBegin, dtEnd, rtViewArea, month0, false);
					if (monthx < 0)
					{
						//int v1 = 0;
						continue;
					}

					PointF ptf1 = new PointF(monthx, rtViewArea.Height / 2);
					PointF ptf2 = new PointF(monthx, rtViewArea.Height);
					g1.DrawLine(pen1, ptf1, ptf2);

					if (idxStyle_month < (m_Style_Year_fixed.Length - 1))
					{
						//Point ptText = new Point((int)monthx + 2, rtViewArea.Height / 2);
						var ts1 = g1.MeasureString("上半年下半年", fontC2);
						Point ptText = new Point((int)monthx + (int)(tYearWidth_byView - ts1.Width) / 4, rtViewArea.Height / 2);

						if (m_Style_Year_fixed[idxStyle_month]._text_Marker == "")
						{
							g1.DrawString(month0.Month.ToString(), fontC2, brushC2, ptText);
						}
						else
						{
							//*每年循环
							var sms = m_Style_Year_fixed[idxStyle_month]._text_Marker.Split(',');
							//*最后会多出一次
							int monthVal = month0.Month;
							int idx = Convert.ToInt32(1.0f * monthVal / m_Style_Year_fixed[idxStyle_month]._step_Marker);
							if (idx < sms.Count())
							{
								g1.DrawString(sms[idx], fontC2, brushC2, ptText);
							}
						}
					}

				}

			}


		}

	}
}
