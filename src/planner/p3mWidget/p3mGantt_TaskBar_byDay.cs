using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace p3mWidget
{
    public class p3mGantt_TaskBar_byDay : p3mGantt_top
    {
        public void draw(Graphics g1, Rectangle rtViewArea, DateTime dtBegin, DateTime dtEnd, p3mGantt_draw_option gOption)
        {
            if (xg_listTask == null)
                return;

            int rowCount = xg_listTask.Count;
            Font fontTitle = new Font("楷体", 10);
            Font fontCross = new Font("arial", 8);

            SolidBrush brushChannel = new SolidBrush(gOption.Task_clrSelected);

            for (int i = 0; i < rowCount; i++)
            {
                //grid line
                //int y1 = listItemBounds[i].Y - 7; //6-7 ?
                //int y1 = listTreeItems[i].Bounds.Y - 7; //6-7 ?
                int y1 = gOption.Task_nHeight * (i + 1); //绘制bottom line
                g1.DrawLine(Pens.Gray, 0, y1, rtViewArea.Width, y1);

                ////4/5/6：开始日期，结束日期，前置
                //string s1 = i.ToString() + " -" + listTreeItems[i].Text + "：" + listTreeItems[i].SubItems[4].Text + "/" + listTreeItems[i].SubItems[5].Text;
                //Point ptTitle = new Point(5, listItemBounds[i].Top - 17 - 3); //tlv的heder？
                //g1.DrawString(s1, fontTitle, Brushes.Black, ptTitle);

                //var begin1 = xg_listTask[i]._drTask["_begin"].ToString();
                //var end1 = xg_listTask[i]._drTask["_end"].ToString();

                //DateTime bar_dtBegin, bar_dtEnd;
                //if (DateTime.TryParse(begin1, out bar_dtBegin) == false)
                //    continue;
                //if (DateTime.TryParse(end1, out bar_dtEnd) == false)
                //    continue;

                DateTime bar_dtBegin = xg_listTask[i].getBegin();
                DateTime bar_dtEnd = xg_listTask[i].getEnd();

                float x1 = subTool_getX(dtBegin, dtEnd, rtViewArea, bar_dtBegin, false);
                float x2 = subTool_getX(dtBegin, dtEnd, rtViewArea, bar_dtEnd, true);
                float y1b = gOption.Task_nHeight * i+4; //bar 比 channel 小
                float y2b = gOption.Task_nHeight * (i + 1)-4;

                if (xg_listTask[i] == p3mGantt_top.xg_Selected_oTask)
                {
                    g1.FillRectangle(brushChannel, 0, y1b - 2, rtViewArea.Width, y2b - y1b + 4);
                }

                //int lev = it1.Level; //ok
                int lev = xg_listTask[i].getLevel();

                //7色循环使用
                //int lev = it1.Level;
                g1.FillRectangle(gOption.Bar_listBrush[lev % 7], x1, y1b, x2 - x1, y2b - y1b);
                

                //if (it1.ChildrenCount > 0)
                //{
                //    //float cx1 = x1;
                //    float cx1 = x1 - 10.0f;
                //    if (cx1 < 0)
                //    {
                //        cx1 = 3.0f;
                //    }
                //    //float cy1 = listTreeItems[i].Bounds.Y - 15;
                //    //g1.DrawString("v", fontCross, listBrush[(lev + 1) % 7], new PointF(cx1, cy1)); //下级别颜色 ▼ v

                //    float cy1 = listTreeItems[i].Bounds.Y - 23;
                //    g1.DrawString("+", fontCross, plotOption._listBrush_bar[(lev + 1) % 7], new PointF(cx1, cy1)); //下级别颜色 ▼ v
                //}

            }


        }


    }


}
