using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace p3mWidget
{

    public enum p3mGantt_Bar_View_Mode
    {
        任务范围,
        上级任务范围,
        //工程范围,
        项目范围整体,
    }



    /// <summary>
    /// 初始显示模仿tree，有3种样式可选：0=全部展开，1=全部折叠，2=只展开1层
    /// </summary>
    public class p3mGantt_Task
    {
        //public string _sGuid;
        //public int _nLevel = 0; //等级

        //public int _nStatus = 0; //0=计划，1=执行，2=完成，3=取消，4=过期

        //task=info+bar
        public DataRow _drTask = null; //可以指定显示字段：1 title,2 begin,3 end,4 preTask

        public DataRow _drAppendix = null; //附加信息，用row提供，可以联合多表，只读，弹出显示

        //public string _Charger; //负责人
        //public string _worker; //参与人
        //public bool _bAlarm_begin = false; //开始通知
        //public bool _bAlarm_end = false; //结束通知
        //public int _numOrder = 0; //序号 -?-tree显示样式不适合序号，--如果显示可只用于root item **
        //public bool _bAlarm_begin = false; //开始通知

        public bool toShow_bExpand = true; //显示 展开
        public bool toShow_bVisible = true; //显示 显示节点


        public List<p3mGantt_Task> _subtask = new List<p3mGantt_Task>();

        public int getLevel()
        {
            if (_drTask == null)
                return -1;

            int nLevel = Convert.ToInt32(_drTask["_nLevel"]);
            return nLevel;
        }

        public string getGuid()
        {
            if (_drTask == null)
                return "";

            string sguid = _drTask["_sGuid"].ToString();
            return sguid;
        }

        public DateTime getBegin()
        {
            //var begin1 = xg_listTask[i]._drTask["_begin"].ToString();
            //var end1 = xg_listTask[i]._drTask["_end"].ToString();

            //DateTime bar_dtBegin, bar_dtEnd;
            //if (DateTime.TryParse(begin1, out bar_dtBegin) == false)
            //	continue;
            //if (DateTime.TryParse(end1, out bar_dtEnd) == false)
            //	continue;

            var begin1 = _drTask["_begin"].ToString();
            DateTime bar_dtBegin = Convert.ToDateTime(begin1);
            //, bar_dtEnd;
            return bar_dtBegin;
        }
        public DateTime getEnd()
        {
            var end1 = _drTask["_end"].ToString();
            DateTime bar_dtEnd = Convert.ToDateTime(end1);
            return bar_dtEnd;
        }

    }


    public class p3mGantt_Manager_Task : p3mGantt_top
    {
        //task view=infoHeader+info+bar
        public p3mGantt_Bar_View_Mode m_eViewMode = p3mGantt_Bar_View_Mode.项目范围整体; //bar view mode

        //@task

        public p3mGantt_Datetime_pair m_dtpTask = new p3mGantt_Datetime_pair();
        public p3mGantt_Datetime_pair m_dtpUtask = new p3mGantt_Datetime_pair();
        //protected p3mGantt_Datetime_pair m_dtpEng = new p3mGantt_Datetime_pair();
        public p3mGantt_Datetime_pair m_dtpPrj = new p3mGantt_Datetime_pair();


        //@bar
        public p3mGantt_TaskBar_byDay m_oBar = new p3mGantt_TaskBar_byDay();

        //@info
        public p3mGantt_TaskInfo m_oInfo = new p3mGantt_TaskInfo();

        //@info header
        public int[] _infoWidth = new int[] { 32, 64, 128, 128, 64 }; //显示宽度 5



        public static void exTask_add()
        {
            //level=0 顶层,1 子项

            //*在layout中操作，因为在fixed内add，可能不是本身显示，导致刷新缺失而不显示新内容
            Form_Task_Admin gfi = new Form_Task_Admin();
            gfi.e_bNew = true;
            //if (gfi.ShowDialog() != DialogResult.OK)
            //	return;
            gfi.e_nLevel = 0;
            gfi.e_sGuid_up = "";
            gfi.ShowDialog();

            //*table不需要事先排序
            //按照日期时间先后排序
            //InfomationCompare cmp = new InfomationCompare();
            //gmGantt_fixed.xe_info.Sort(cmp);

        }

        public static bool exTask_add_child()
        {
            //level=0 顶层,1 子项

            if (p3mGantt_top.xg_Selected_oTask == null)
                return false;

            int nLevel = p3mGantt_top.xg_Selected_oTask.getLevel() + 1;
            string sGuid_up = p3mGantt_top.xg_Selected_oTask.getGuid();

            //*在layout中操作，因为在fixed内add，可能不是本身显示，导致刷新缺失而不显示新内容
            Form_Task_Admin gfi = new Form_Task_Admin();
            gfi.e_bNew = true;
            //if (gfi.ShowDialog() != DialogResult.OK)
            //	return;
            gfi.e_nLevel = nLevel;
            gfi.e_sGuid_up = sGuid_up;
            gfi.ShowDialog();

            //*table不需要事先排序
            //按照日期时间先后排序
            //InfomationCompare cmp = new InfomationCompare();
            //gmGantt_fixed.xe_info.Sort(cmp);

            return true;
        }

        public static void exTask_edit()
        {
            if (p3mGantt_top.xg_Selected_oTask == null)
                return;

            Form_Task_Admin fgfi = new Form_Task_Admin();
            fgfi.e_bNew = false;
            fgfi.ShowDialog();

            //取消选择最合适
            p3mGantt_top.xg_Selected_oTask = null;
        }

        //public static void exTask_delete()
        //{
        //	if (xg_Selected_oTask == null)
        //		return;

        //	//string sguid = xg_Selected_oTask._drTask[" _sGuid"].ToString();
        //	string sguid = xg_Selected_oTask._sGuid_temp;
        //	var dt = xg_dataset.Tables["gantt_task"];
        //	DataRow[] drs = dt.Select("_sGuid='" + sguid + "'");
        //	if (drs.Any())
        //	{
        //		dt.Rows.Remove(drs.First());
        //	}
        //	dt.AcceptChanges();
        //}

        public static void exTask_delete()
        {
            if (xg_Selected_oTask == null)
                return;

            if (xg_Selected_oTask._drTask == null)
                return;

            var dt = xg_dataset.Tables["gantt_task"];
            dt.Rows.Remove(xg_Selected_oTask._drTask);
            dt.AcceptChanges();

            xg_Selected_oTask._drTask = null;
            xg_Selected_oTask = null;
        }





        //public bool Sub2_getScope_byViewMode(ref DateTime dtBegin,ref DateTime dtEnd,bool bSelected)
        public bool Sub2_getScope_byViewMode(bool bSelected)
        {
            if (xg_listTask.Count <= 0)
                return false;

            //默认第0item
            var task1 = xg_listTask[0];

            ////如果有选中，则使用
            if (xg_Selected_oTask!=null)
            {
                task1 = xg_Selected_oTask;
            }

            ////task
            {
                var begin1 = task1._drTask["_begin"].ToString();
                var end1 = task1._drTask["_end"].ToString();

                if (false == Sub2sub_getDatetime(begin1, end1, ref m_dtpTask._begin, ref m_dtpTask._end))
                    return false;

            }

            ////utask
            //{
            //    var it1u = it1.Parent;

            //    //如果是root则utask=task
            //    if (it1u == null)
            //    {
            //        it1u = it1;
            //    }
            //    var _begin = it1u.SubItems[4].Text;
            //    var _end = it1u.SubItems[5].Text;

            //    if (false == Sub2sub_getDatetime(_begin, _end, ref m_dtUtask_begin, ref m_dtUtask_end))
            //        return false;

            //    string t1 = "utask: " + m_dtUtask_begin.ToString() + "/" + m_dtUtask_end.ToString() + "/" + it1u.Text + ";\r\n";
            //    dbg_Text_datetime += t1;
            //}

            ////eng
            //{
            //    //递归到root层，没有上级

            //    var it1u = it1;
            //    //工程可能在root，也可能不是
            //    for (; ; )
            //    {
            //        if (it1u.Text.Contains("工程") == true)
            //        {
            //            break;
            //        }
            //        //没有标志字符，到root也停止
            //        if (it1u.Parent == null)
            //        {
            //            break;
            //        }

            //        it1u = it1u.Parent;
            //    }

            //    var _begin = it1u.SubItems[4].Text;
            //    var _end = it1u.SubItems[5].Text;

            //    if (false == Sub2sub_getDatetime(_begin, _end, ref m_dtEng_begin, ref m_dtEng_end))
            //        return false;

            //    string t1 = "eng: " + m_dtEng_begin.ToString() + "/" + m_dtEng_end.ToString() + "/" + it1u.Text + ";\r\n";
            //    dbg_Text_datetime += t1;
            //}

            //prj
            {
                if (false == subData_getScope_Prj(ref m_dtpPrj._begin, ref m_dtpPrj._end))
                    return true;

            }

            return true;
        }


        public bool subData_getScope_Prj(ref DateTime dtBegin, ref DateTime dtEnd)
        {
            //获得全部范围
            if (xg_listTask.Count <= 0)
                return false;

            List<DateTime> listBegin = new List<DateTime>();
            List<DateTime> listEnd = new List<DateTime>();

            foreach (var task1 in xg_listTask)
            {
                var begin1 = task1._drTask["_begin"].ToString();
                var end1 = task1._drTask["_end"].ToString();

                DateTime _begin, _end;
                if (DateTime.TryParse(begin1, out _begin) == false)
                    return false;
                if (DateTime.TryParse(end1, out _end) == false)
                    return false;

                listBegin.Add(_begin);
                listEnd.Add(_end);
            }
            if (listBegin.Count <= 0)
                return false;
            if (listEnd.Count <= 0)
                return false;

            listBegin.Sort();
            listEnd.Sort();

            dtBegin = listBegin.First();
            dtEnd = listEnd.Last();

            return true;
        }


        protected bool Sub2sub_getDatetime(string _begin, string _end, ref DateTime dtBegin, ref DateTime dtEnd)
        {
            if (DateTime.TryParse(_begin, out dtBegin) == false)
                return false;
            if (DateTime.TryParse(_end, out dtEnd) == false)
                return false;

            return true;
        }


    }



}
