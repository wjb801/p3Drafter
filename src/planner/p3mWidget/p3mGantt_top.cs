using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.IO;

namespace p3mWidget
{
    public class p3mGantt_top
    {
		public static DataSet xg_dataset = null; //未获得数据前，跳过显示处理
		
		public static List<p3mGantt_Task> xg_listTask = new List<p3mGantt_Task>();
		public static p3mGantt_Task xg_Selected_oTask = null;

		public static DateTime xg_setday = DateTime.Now;//.ToString("yyyy年MM月dd日 dddd");

		public static bool gSub_xml_load(string sXml)
		{
			if (File.Exists(sXml) == false)
			{
				xg_dataset = gSub_xml_create(sXml);
			}
			if (xg_dataset == null)
			{
				xg_dataset = new DataSet();
			}
			xg_dataset.ReadXml(sXml);
			//ex_Update();
			return true;
		}


		protected static DataSet gSub_xml_create(string sXml)
		{
			//return null;

			//创建中，刷新显示仍然获得的是ds=null，创建后接收ds对象
			DataSet ds1 = new DataSet();

			//public string _sGuid;
			//public string _sTitle;
			//public string _sText;
			//public DateTime _begin;
			//public DateTime _end;
			//public int _nStatus = 0; //0=计划，1=执行，2=完成，3=取消，4=过期
			//public bool _bAlarm_begin = false; //开始通知

			DataTable tblDatas = new DataTable("gantt_task");
			DataColumn dc = null;
			//dc = tblDatas.Columns.Add("ID", Type.GetType("System.Int32"));
			//dc.AutoIncrement = true;//自动增加
			//dc.AutoIncrementSeed = 1;//起始为1
			//dc.AutoIncrementStep = 1;//步长为1
			//dc.AllowDBNull = false;//

			dc = tblDatas.Columns.Add("_sGuid", Type.GetType("System.String"));
			dc = tblDatas.Columns.Add("_sGuid_up", Type.GetType("System.String"));
			dc = tblDatas.Columns.Add("_nLevel", Type.GetType("System.Int32"));

			dc = tblDatas.Columns.Add("_sTitle", Type.GetType("System.String"));
			dc = tblDatas.Columns.Add("_sText", Type.GetType("System.String"));

			dc = tblDatas.Columns.Add("_begin", Type.GetType("System.DateTime"));
			dc = tblDatas.Columns.Add("_end", Type.GetType("System.DateTime"));

			dc = tblDatas.Columns.Add("_nStatus", Type.GetType("System.Int32"));
			dc = tblDatas.Columns.Add("_bAlarm_begin", Type.GetType("System.Boolean"));

			ds1.Tables.Add(tblDatas);
			ds1.WriteXmlSchema(sXml);

			return ds1;
		}

		public static bool gSub_xml_save(string sXml)
		{
			if (xg_dataset == null)
			{
				return false;
			}
			xg_dataset.WriteXml(sXml, XmlWriteMode.WriteSchema);
			return true;
		}

		public float subTool_getX(DateTime dtLeft, DateTime dtRight, Rectangle rtCanvas, DateTime dtX, bool bInclude = true)
		{
			//bInclude=false dtX的0点,true dtX的24点

			if (dtLeft > dtRight)
			{
				return -1f;
			}
			//*允许计算点在范围外--左侧开始的非整年份
			if (dtX.Date < dtLeft.Date)
			{
				return -1f;
			}
			//*允许计算点在范围外--本身显示也看不到
			//if(dtX.Date>dtRight.AddDays(1.0).Date)
			//         {
			//	return -1f;
			//         }

			if (dtX.Date == dtLeft.Date)
			{
				return rtCanvas.Left;
			}

			if (bInclude == false)
			{
				if (dtX.Date == dtRight.Date)
				{
					return rtCanvas.Right;
				}
			}
			else
			{
				if (dtX.Date == dtRight.AddDays(1.0).Date)
				{
					return rtCanvas.Right;
				}
			}

			int vvs = (int)(dtRight - dtLeft).TotalDays; //virtual value span
			if (bInclude == true)
			{
				vvs += 1;
			}

			int dvs = rtCanvas.Width; //device value span

			int dts = (int)(dtX - dtLeft).TotalDays; //时间跨度
			if (bInclude == true)
			{
				dts += 1;
			}

			//x1 / dvs = dts / vvs;
			float x1 = ((float)dts / vvs) * dvs;

			return x1;
		}



	}




}
