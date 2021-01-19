using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace planner
{
    public partial class formProjectEdit : Form
    {
        [DefaultValue(true)]
        public bool e_bMode_new { get; set; }  //当前新建

        public formProjectEdit()
        {
            InitializeComponent();

            if(e_bMode_new==true)
            {
                this.Text = "新建";
                button_not.Text = "取消";
                button_yes.Text = "创建";
            }
            else
            {
                this.Text = "修改";
                button_not.Text = "放弃";
                button_yes.Text = "修改";
            }

        }
    }
}
