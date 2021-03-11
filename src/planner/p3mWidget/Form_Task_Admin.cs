using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p3mWidget
{
    public partial class Form_Task_Admin : Form
    {
        //public gmGantt_fixed_Infomation gi1 = new gmGantt_fixed_Infomation();
        public bool e_bNew = true;

        public int e_nLevel = 0;
        public string e_sGuid_up = "";

        public Form_Task_Admin()
        {
            InitializeComponent();
        }

        private void button_yes_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("标题内容不能为空白.");
                return;
            }

            //不能跨年
            var dt1t = dateTimePicker1.Value;
            var dt2t = dateTimePicker2.Value;
            if (dt1t > dt2t)
            {
                MessageBox.Show("开始日期时间必须小于结束日期时间.");
                return;
            }

            var dt1 = new DateTime(dt1t.Year, dt1t.Month, dt1t.Day);
            var dt2 = new DateTime(dt2t.Year, dt2t.Month, dt2t.Day);
            if (dt2.Year!=dt1.Year)
            {
                MessageBox.Show("计划日期时间不能跨年.");
                return;
            }

            //1日内，需要记录小时
            if(dt1==dt2)
            {
                dt1 = new DateTime(dt1t.Year, dt1t.Month, dt1t.Day, dt1t.Hour, 0, 0);
                dt2 = new DateTime(dt2t.Year, dt2t.Month, dt2t.Day, dt2t.Hour, 0, 0); //不包含

                if(dt1==dt2)
                {
                    MessageBox.Show("开始时间、结束时间不能相同。小时计算不包含结束.");
                    return;
                }
            }
            //gmGantt_fixed_Infomation gi1 = new gmGantt_fixed_Infomation();
            if (e_bNew == true)
            {
                DataRow dr1 = p3mGantt_top.xg_dataset.Tables["gantt_task"].NewRow();
                dr1["_sGuid"] = Guid.NewGuid().ToString();

                dr1["_nLevel"] = textBox_level.Text;
                dr1["_sGuid_up"] = textBox_up_guid.Text;

                dr1["_sTitle"] = textBox1.Text;
                dr1["_sText"] = textBox4.Text;
                dr1["_begin"] = dt1;
                dr1["_end"] = dt2; 

                dr1["_nStatus"] = 0;
                dr1["_bAlarm_begin"] = false;
                p3mGantt_top.xg_dataset.Tables["gantt_task"].Rows.Add(dr1);
            }
            else
            {
                p3mGantt_top.xg_Selected_oTask._drTask["_sTitle"] = textBox1.Text;
                p3mGantt_top.xg_Selected_oTask._drTask["_sText"] = textBox4.Text;
                p3mGantt_top.xg_Selected_oTask._drTask["_begin"]  = dt1;
                p3mGantt_top.xg_Selected_oTask._drTask["_end"]  = dt2;
                //dr1["_nStatus"] = 0;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void form_Gantt_fixed_Info_Load(object sender, EventArgs e)
        {
            if (e_bNew == false)
            {
                //显示原有数据

                textBox1.Text = p3mGantt_top.xg_Selected_oTask._drTask["_sTitle"].ToString();
                textBox4.Text= p3mGantt_top.xg_Selected_oTask._drTask["_sText"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(p3mGantt_top.xg_Selected_oTask._drTask["_begin"].ToString());
                dateTimePicker2.Value = Convert.ToDateTime(p3mGantt_top.xg_Selected_oTask._drTask["_end"].ToString());

                //*修改时：不显示，不操作
                textBox_level.Text = p3mGantt_top.xg_Selected_oTask._drTask["_nLevel"].ToString();
                textBox_up_guid.Text = p3mGantt_top.xg_Selected_oTask._drTask["_sGuid_up"].ToString();

                button_yes.ForeColor = Color.Red;
                button_yes.Text = "(修改) 确定";
            }
            else
            {
                textBox_level.Text = e_nLevel.ToString();
                textBox_up_guid.Text = e_sGuid_up;

                button_yes.ForeColor = Color.Green;
                button_yes.Text = "(新建) 确定";
            }

        }

        private void button_not_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        protected void subDay_1hour()
        {
            //默认规则显示初始化内容
            var dt0 = DateTime.Now.AddHours(1.0); //下小时开始
            dateTimePicker1.Value = dt0;
            dateTimePicker2.Value = dt0.AddHours(1.0);
        }
        protected void subDay_2hour()
        {
            var dt0 = DateTime.Now.AddHours(1.0); //下小时开始
            dateTimePicker1.Value = dt0;
            dateTimePicker2.Value = dt0.AddHours(2.0);
        }
        protected void subDay_am()
        {
            var dt0 = DateTime.Now; 
            dateTimePicker1.Value = new DateTime(dt0.Year, dt0.Month, dt0.Day, 8, 0, 0);
            dateTimePicker2.Value = new DateTime(dt0.Year, dt0.Month, dt0.Day, 11, 0, 0);
        }
        protected void subDay_pm()
        {
            var dt0 = DateTime.Now;
            dateTimePicker1.Value = new DateTime(dt0.Year, dt0.Month, dt0.Day, 14, 0, 0);
            dateTimePicker2.Value = new DateTime(dt0.Year, dt0.Month, dt0.Day, 17, 0, 0);
        }

        protected void subDay_today()
        {
            var dt0 = DateTime.Now;
            dateTimePicker1.Value = new DateTime(dt0.Year, dt0.Month, dt0.Day, 8, 0, 0);
            dateTimePicker2.Value = new DateTime(dt0.Year, dt0.Month, dt0.Day, 17, 0, 0);
        }

        protected void subDay_tomorrow()
        {
            var dt0 = DateTime.Now.AddDays(1.0);
            dateTimePicker1.Value = new DateTime(dt0.Year, dt0.Month, dt0.Day, 8, 0, 0);
            dateTimePicker2.Value = new DateTime(dt0.Year, dt0.Month, dt0.Day, 17, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subDay_1hour();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            subDay_2hour();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            subDay_am();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            subDay_pm();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            subDay_today();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            subDay_tomorrow();
        }

        private void Form_Task_Admin_Shown(object sender, EventArgs e)
        {

        }
    }
}
