using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace p3mWidget
{
    public class p3mGantt_TaskInfo : p3mGantt_top
    {
        public void draw(Graphics g1, Rectangle rtViewArea, p3mGantt_draw_option drawOption)
        {
            Font font1 = new Font("arial", 12);
            SolidBrush brush1 = new SolidBrush(Color.Black);
            SolidBrush brushChannel = new SolidBrush(drawOption.Task_clrSelected);

            int idx = 0;
            foreach (var task1 in xg_listTask)
            {
                Rectangle rt1 = new Rectangle(0, drawOption.Task_nHeight * idx, rtViewArea.Width, drawOption.Task_nHeight);
                g1.DrawRectangle(Pens.Black, rt1);


                if (task1 == xg_Selected_oTask)
                {
                    float y1b = drawOption.Task_nHeight * idx + 4; //bar 比 channel 小
                    float y2b = drawOption.Task_nHeight * (idx + 1) - 4;
                    g1.FillRectangle(brushChannel, 0, y1b - 2, rtViewArea.Width, y2b - y1b + 4);
                }

                int nlevel = task1.getLevel();
                //int x1 = drawOption.Task_nIndent * nlevel;
                //Rectangle rtTitle = new Rectangle(x1, drawOption.Task_nHeight * idx, rtViewArea.Right - x1, drawOption.Task_nHeight);
                //g1.DrawString(task1._drTask["_sTitle"].ToString(), font1, brush1, rtTitle);

                string preSymbol = new string('>', nlevel); //*多种颜色？
                g1.DrawString(preSymbol+task1._drTask["_sTitle"].ToString(), font1, brush1, rt1);

                idx++;
            }
        }


    }


}
