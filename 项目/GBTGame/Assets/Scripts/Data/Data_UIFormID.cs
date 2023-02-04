using System.Collections;
using System.Collections.Generic;

//CreateTime：2023/2/4 18:22:13
namespace DataCs
{
	public struct Data_UIFormID_Struct
	{
		public string key;
		public int ID;
		public string path;
		public int root;

		public Data_UIFormID_Struct(string _key, int _ID, string _path, int _root)
		{
			key = _key;
			ID = _ID;
			path = _path;
			root = _root;
		}
	}

	public static class Data_UIFormID
	{
		public static Dictionary<string, Data_UIFormID_Struct> Dic = new Dictionary<string, Data_UIFormID_Struct>()
		{
			{"StartGameForm",new Data_UIFormID_Struct("StartGameForm",1000,"ZKW/StartGameForm",1)},
			{"MainForm",new Data_UIFormID_Struct("MainForm",1001,"ZKW/MainForm",1)},
			{"DeveloperForm",new Data_UIFormID_Struct("DeveloperForm",1002,"ZKW/DeveloperForm",1)},
			{"MenuForm",new Data_UIFormID_Struct("MenuForm",1003,"ZKW/MenuForm",1)},
			{"GameOverForm",new Data_UIFormID_Struct("GameOverForm",1004,"ZKW/GameOverForm",1)},
			{"SkillForm",new Data_UIFormID_Struct("SkillForm",1005,"ZKW/SkillTreeForm",1)},
			{"HelperForm",new Data_UIFormID_Struct("HelperForm",1006,"ZKW/HelperForm",1)},
			{"AllGameStartForm",new Data_UIFormID_Struct("AllGameStartForm",1007,"ZKW/AllGameStartForm",1)},
			{"AllGameOverForm",new Data_UIFormID_Struct("AllGameOverForm",1008,"ZKW/AllGameOverForm",1)},
			{"TestPanel",new Data_UIFormID_Struct("TestPanel",1009,"ZKW/TestPanel/TestPanel",1)},
			{"HandleForm_1",new Data_UIFormID_Struct("HandleForm_1",2001,"GX/HandleForm_1",1)},
			{"ToolForm_1",new Data_UIFormID_Struct("ToolForm_1",1010,"ZKW/ToolForm_1",3)},
			{"HUDForm",new Data_UIFormID_Struct("HUDForm",1011,"ZKW/HUDForm",3)},
			{"ToolForm_2",new Data_UIFormID_Struct("ToolForm_2",1012,"ZKW/ToolForm_2",3)},
			{"ToolForm_3",new Data_UIFormID_Struct("ToolForm_3",1013,"ZKW/ToolForm_3",3)},
			{"HandleForm_2",new Data_UIFormID_Struct("HandleForm_2",2002,"GX/HandleForm_2",1)},
			{"HandleForm_3",new Data_UIFormID_Struct("HandleForm_3",2003,"GX/HandleForm_3",1)},
			{"GameFailForm",new Data_UIFormID_Struct("GameFailForm",1014,"ZKW/GameFailForm",1)},
		};
		public static string key_StartGameForm = "StartGameForm";
		public static string key_MainForm = "MainForm";
		public static string key_DeveloperForm = "DeveloperForm";
		public static string key_MenuForm = "MenuForm";
		public static string key_GameOverForm = "GameOverForm";
		public static string key_SkillForm = "SkillForm";
		public static string key_HelperForm = "HelperForm";
		public static string key_AllGameStartForm = "AllGameStartForm";
		public static string key_AllGameOverForm = "AllGameOverForm";
		public static string key_TestPanel = "TestPanel";
		public static string key_HandleForm_1 = "HandleForm_1";
		public static string key_ToolForm_1 = "ToolForm_1";
		public static string key_HUDForm = "HUDForm";
		public static string key_ToolForm_2 = "ToolForm_2";
		public static string key_ToolForm_3 = "ToolForm_3";
		public static string key_HandleForm_2 = "HandleForm_2";
		public static string key_HandleForm_3 = "HandleForm_3";
		public static string key_GameFailForm = "GameFailForm";
	}
}

