using System.Collections;
using System.Collections.Generic;

//CreateTime：2023/2/4 15:31:24
namespace DataCs
{
	public struct Data_LocalFile_Struct
	{
		public string key;
		public string name;

		public Data_LocalFile_Struct(string _key, string _name)
		{
			key = _key;
			name = _name;
		}
	}

	public static class Data_LocalFile
	{
		public static Dictionary<string, Data_LocalFile_Struct> Dic = new Dictionary<string, Data_LocalFile_Struct>()
		{
			{"LoginUserInfo",new Data_LocalFile_Struct("LoginUserInfo","LoginUserInfo")},
		};
		public static string key_LoginUserInfo = "LoginUserInfo";
	}
}

