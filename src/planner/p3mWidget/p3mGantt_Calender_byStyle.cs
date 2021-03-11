using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace p3mWidget
{

	//public struct tTimeAxisInfo //TIMEAXISINFO
	//{
	//    //y轴方向，x轴位置
	//    public int nXY;
	//    //xy都用的刻度大小，y只用了小刻度
	//    public int nMinTick;   //长度，只能是正数，根据方向自动转换符号
	//    public int nMaxTick;   //长度
	//    public int nMinLable;  //距离
	//    public int nMaxLable;  //距离

	//    public long m_lAxisPenWidth;

	//    public Rectangle rectDraw;             //画图的区域，去掉四个Margin
	//    public Size siMinFont, siMaxFont; //字体大小，在内部创建和使用
	//    public Color axisColor;
	//    public DateTime datetime0, datetime1;  //时间的开始-结束,可以包含小时,保证1>0
	//};



	public class p3mGantt_Calender_byStyle : p3mGantt_Calender
	{


		//style-YM时显示M的规则,,1都不显示
		public p3mGantt_Calender_Style_Pair[] m_Style_YearMonth_year =
		new p3mGantt_Calender_Style_Pair[] {
			new p3mGantt_Calender_Style_Pair(1,50,""), //1,2,3...
            new p3mGantt_Calender_Style_Pair(2, 20,""), //1,3,5,...
            new p3mGantt_Calender_Style_Pair(5, 10,""),
			new p3mGantt_Calender_Style_Pair(10, 5,"") //等于不显示
		};

		//style-YM时显示M的规则,,1都不显示
		public p3mGantt_Calender_Style_Pair[] m_Style_YearMonth_month =
		new p3mGantt_Calender_Style_Pair[] {
			new p3mGantt_Calender_Style_Pair(1,240,""), //1,2,3...
            new p3mGantt_Calender_Style_Pair(2, 180,""), //1,3,5,...
            new p3mGantt_Calender_Style_Pair(3, 120,"1-Q1,4-Q2,7-Q3,10-Q4"), //1,4,7,10
            new p3mGantt_Calender_Style_Pair(6, 60,""),
			new p3mGantt_Calender_Style_Pair(12, 10,"") //等于不显示
		};

		public p3mGantt_Calender_Style_Pair[] m_Style_MonthDay_month =
		new p3mGantt_Calender_Style_Pair[] {
			new p3mGantt_Calender_Style_Pair(1,80,""), //1,2,3... 
			new p3mGantt_Calender_Style_Pair(2,40,""), //1,7
			new p3mGantt_Calender_Style_Pair(3, 20,"") //等于不显示
		};

		//style-MD时显示M的规则,,m只会有12个，不需要步长处理，长度基准为月30天
		public p3mGantt_Calender_Style_Pair[] m_Style_MonthDay_day =
		new p3mGantt_Calender_Style_Pair[] {
			new p3mGantt_Calender_Style_Pair(1,600,""), //1,2,3...参照ym=240=20*12
            new p3mGantt_Calender_Style_Pair(2, 300,""), //1,3,5,...
            new p3mGantt_Calender_Style_Pair(4, 150,""), //1,5,10,
            new p3mGantt_Calender_Style_Pair(9, 60,""),
			new p3mGantt_Calender_Style_Pair(31, 10,"") //等于不显示
		};

		/// <summary>
		/// 实现方式：基于view坐标范围的直接映射计算，同sode
		/// 2级：		/// 超过366天为年-月，否则月-日 xx ->容许多级以适应长屏幕，当月步长为1时候允许显示日 >>* 显示实现前，后的年月字符显示方法有问题
		/// 显示：年总是绘制，月总是绘制；日根据日期范围和显示宽度计算是否显示，步长需要计算
		/// </summary>
		/// <param name="g1"></param>
		/// <param name="rtViewArea"></param>
		/// <param name="rtViewData"></param>
		public override void draw(Graphics g1, Rectangle rtViewArea, DateTime dtBegin, DateTime dtEnd, p3mGantt_draw_option drawOption)
		{
			if ((dtEnd - dtBegin).TotalDays > 366)
			{
				drawCalender_YearMonth(g1, rtViewArea, dtBegin, dtEnd, drawOption);

				//自处理年份，有可能年步长超过1

			}
			else
			{
				drawCalender_MonthDay(g1, rtViewArea, dtBegin, dtEnd, drawOption);

				//跨越年份，显示 年标识
				{
					//年绘制：加粗，不显示数值
					int y0_plot = 0;

					Pen pen1 = new Pen(Color.Black, 2);
					int year0 = dtBegin.Year;
					int year1 = dtEnd.Year;
					for (int i = year0; i <= year1; i++)
					{
						var dt1 = new DateTime(i, 1, 1, 0, 0, 0);
						//float yearx = plotOption._fDayUnit0 * (float)(dt1 - dtBegin).TotalDays;
						float yearx = subTool_getX(dtBegin, dtEnd, rtViewArea, dt1, false);

						PointF ptf1 = new PointF(yearx, y0_plot);
						PointF ptf2 = new PointF(yearx, rtViewArea.Height);
						g1.DrawLine(pen1, ptf1, ptf2);

						//Point ptText = new Point((int)yearx + 2, 2);
						//g1.DrawString(i.ToString() + "年", new Font("arial", 10), Brushes.Black, ptText);
					}
				}
			}

		}

		/// <summary>
		/// 年月刻度显示
		/// </summary>
		/// <param name="g1"></param>
		/// <param name="rtViewArea"></param>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <param name="plotOption"></param>
		protected void drawCalender_YearMonth(Graphics g1, Rectangle rtViewArea, DateTime dtBegin, DateTime dtEnd, p3mGantt_draw_option drawOption)
		{
			int y0_plot = 0;

			Font fontC1 = new Font("arial", 10);
			Font fontC2 = new Font("arial", 8);
			var brushC1 = new SolidBrush(Color.Black);
			var brushC2 = new SolidBrush(Color.Black);

			double tYearWidth_byView = rtViewArea.Width / (dtEnd - dtBegin).TotalDays * 365;

			//year
			int idxStyle_year = subTool_getStyle(m_Style_YearMonth_year, tYearWidth_byView);
			if (idxStyle_year < (m_Style_YearMonth_year.Length - 1))
			{
				Pen pen1 = new Pen(Color.Black, 1);
				//year0不绘制marker，如果是1月1日也不绘制
				int year0 = dtBegin.Year;
				int year1 = dtEnd.Year;
				for (int i = year0; i <= year1; i += m_Style_YearMonth_year[idxStyle_year]._step_Marker)
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
			int idxStyle_month = subTool_getStyle(m_Style_YearMonth_month, tYearWidth_byView);
			if (idxStyle_month < (m_Style_YearMonth_month.Length - 1))
			{
				Pen pen1 = new Pen(Color.Black, 1);

				//非1步长是从1月开始计算非任务开始月份，步长1则可以任意
				//DateTime month0 = new DateTime(dtBegin.Year, dtBegin.Month, 1, 0, 0, 0);
				DateTime month0 = new DateTime(dtBegin.Year, 1, 1, 0, 0, 0);
				while (month0 < dtEnd)
				{
					month0 = month0.AddMonths(m_Style_YearMonth_month[idxStyle_month]._step_Marker);
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

					Point ptText = new Point((int)monthx + 2, rtViewArea.Height / 2);
					//ok-全部数值--每年12个月，可以多年循环
					//g1.DrawString(month0.ToString("MM"), fontC2, brushC2, ptText);

					if (m_Style_YearMonth_month[idxStyle_month]._text_Marker == "")
					{
						//g1.DrawString(month0.ToString("MM"), fontC2, brushC2, ptText); //01,02...
						g1.DrawString(month0.Month.ToString(), fontC2, brushC2, ptText); //1,2...
					}
					else
					{
						//*每年循环
						var sms = m_Style_YearMonth_month[idxStyle_month]._text_Marker.Split(',');
						//*最后会多出一次
						int monthVal = month0.Month;
						int idx = Convert.ToInt32(1.0f * monthVal / m_Style_YearMonth_month[idxStyle_month]._step_Marker);
						if (idx < sms.Count())
						{
							g1.DrawString(sms[idx], fontC2, brushC2, ptText);
						}
					}
				}

			}

		}

		protected void drawCalender_MonthDay(Graphics g1, Rectangle rtViewArea, DateTime dtBegin, DateTime dtEnd, p3mGantt_draw_option drawOption)
		{
			int y0_plot = 0;

			Font fontC1 = new Font("arial", 10);
			Font fontC2 = new Font("arial", 8);
			var brushC1 = new SolidBrush(Color.Black);
			var brushC2 = new SolidBrush(Color.Gray);

			double tMonthWidth_byView = rtViewArea.Width / (dtEnd - dtBegin).TotalDays * 30;

			//month
			int idxStyle_month = subTool_getStyle(m_Style_MonthDay_month, tMonthWidth_byView);
			int idxStyle_day = subTool_getStyle(m_Style_MonthDay_day, tMonthWidth_byView);

			//if (idxStyle_month < (m_Style_MonthDay_month.Length-1))
			{
				Pen pen1 = new Pen(Color.Black, 1);
				DateTime month0 = new DateTime(dtBegin.Year, dtBegin.Month, 1, 0, 0, 0);
				//需要显示非完整月
				{
					month0 = month0.AddMonths(-1);
				}
				//month0 = new DateTime(dtBegin.Year, dtBegin.Month, 1, 0, 0, 0);
				while (month0 < dtEnd)
				{
					month0 = month0.AddMonths(m_Style_MonthDay_month[idxStyle_month]._step_Marker);
					float yearx = subTool_getX(dtBegin, dtEnd, rtViewArea, month0, false);

					PointF ptf1 = new PointF(yearx, y0_plot);
					PointF ptf2 = new PointF(yearx, rtViewArea.Height);
					g1.DrawLine(pen1, ptf1, ptf2);

					Point ptText = new Point((int)yearx + 2, 2);
					g1.DrawString(month0.ToString("yyyy-MM"), fontC1, brushC1, ptText);

					//day 依赖每月1日
					if (idxStyle_day < (m_Style_MonthDay_day.Length - 1))
					{
						Pen pen1d = new Pen(Color.Gray, 1);

						//非1步长是从1月开始计算非任务开始月份，步长1则可以任意
						DateTime day0 = new DateTime(month0.Year, month0.Month, 1, 0, 0, 0);
						DateTime month1 = month0.AddMonths(1); //只处理当月
						while (day0 < month1)
						{
							float dayx = subTool_getX(dtBegin, dtEnd, rtViewArea, day0, false);
							if (dayx < 0)
							{
								day0 = day0.AddDays(m_Style_MonthDay_day[idxStyle_day]._step_Marker);
								continue;
							}

							PointF ptf1d = new PointF(dayx, rtViewArea.Height / 2);
							PointF ptf2d = new PointF(dayx, rtViewArea.Height);
							g1.DrawLine(pen1d, ptf1d, ptf2d);

							Point ptTextD = new Point((int)dayx + 2, rtViewArea.Height / 2);
							g1.DrawString(day0.Day.ToString(), fontC2, brushC2, ptTextD);

							day0 = day0.AddDays(m_Style_MonthDay_day[idxStyle_day]._step_Marker);
						}
					}
				}

			}


			//if (idxStyle_day < (m_Style_MonthDay_day.Length-1))
			//         {
			//             Pen pen1 = new Pen(Color.Gray, 1);

			//             //非1步长是从1月开始计算非任务开始月份，步长1则可以任意
			//             DateTime day0 = new DateTime(dtBegin.Year, dtBegin.Month, 1, 0, 0, 0);
			//             while (day0 < dtEnd)
			//             {

			//		day0 = day0.AddDays(m_Style_MonthDay_day[idxStyle_day]._step_Marker);
			//                 //开始日期前的月份不需要显示
			//                 if (day0 < dtBegin)
			//                     continue;

			//                 float monthx = sub_getX(dtBegin, dtEnd, rtViewArea, day0, false);
			//                 if (monthx < 0)
			//                 {
			//                     //int v1 = 0;
			//                     continue;
			//                 }

			//                 PointF ptf1 = new PointF(monthx, rtViewArea.Height / 2);
			//                 PointF ptf2 = new PointF(monthx, rtViewArea.Height);
			//                 g1.DrawLine(pen1, ptf1, ptf2);

			//                 Point ptText = new Point((int)monthx + 2, rtViewArea.Height / 2);
			//                 //ok-全部数值--每年12个月，可以多年循环
			//                 //g1.DrawString(month0.ToString("MM"), fontC2, brushC2, ptText);

			//                 if (m_Style_YearMonth_month[idxStyle_month]._text_Marker == "")
			//                 {
			//                     //g1.DrawString(month0.ToString("MM"), fontC2, brushC2, ptText);
			//                     g1.DrawString(day0.Day.ToString(), fontC2, brushC2, ptText);
			//                 }
			//                 else
			//                 {
			//                     //*每年循环
			//                     var sms = m_Style_YearMonth_month[idxStyle_month]._text_Marker.Split(',');
			//                     //*最后会多出一次
			//                     int monthVal = day0.Day;
			//                     int idx = Convert.ToInt32(1.0f * monthVal / m_Style_YearMonth_month[idxStyle_month]._step_Marker);
			//                     if (idx < sms.Count())
			//                     {
			//                         g1.DrawString(sms[idx], fontC2, brushC2, ptText);
			//                     }
			//                 }
			//             }

			//         }

		}


		long GetMonthSum(DateTime date0, DateTime date1)
		{
			long monthSum = 0;

			DateTime dt = date0;
			int nYear0, nMonth0, nYear1, nMonth1;
			nYear0 = date0.Year;
			nMonth0 = date0.Month;

			nYear1 = date1.Year;
			nMonth1 = date1.Month;

			if (nYear0 == nYear1)
			{
				monthSum = nMonth1 - nMonth0;
				return monthSum;
			}

			int sumYear = nYear1 - nYear0;
			monthSum = sumYear * 12 + nMonth1 - nMonth0;
			return monthSum;
		}



	}





}
