using System.Collections;
using System.Collections.Generic;

//CreateTime：2023/2/3 19:46:50
namespace DataCs
{
	public struct Data_UIItemID_Struct
	{
		public string key;
		public int ID;
		public string path;

		public Data_UIItemID_Struct(string _key, int _ID, string _path)
		{
			key = _key;
			ID = _ID;
			path = _path;
		}
	}

	public static class Data_UIItemID
	{
		public static Dictionary<string, Data_UIItemID_Struct> Dic = new Dictionary<string, Data_UIItemID_Struct>()
		{
			{"LeftGameItem",new Data_UIItemID_Struct("LeftGameItem",2000,"UI/UIItem/LeftGameItem")},
			{"MainHeadItem",new Data_UIItemID_Struct("MainHeadItem",2001,"UI/UIItem/MainHeadItem")},
			{"SlideShowItem",new Data_UIItemID_Struct("SlideShowItem",2002,"UI/UIItem/SlideShowItem")},
		};
		public static string key_LeftGameItem = "LeftGameItem";
		public static string key_MainHeadItem = "MainHeadItem";
		public static string key_SlideShowItem = "SlideShowItem";
	}
}

