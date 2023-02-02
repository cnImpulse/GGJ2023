using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;
using UnityEngine.EventSystems;
using LitJson;
using System.IO;

namespace MyGameFrameWork
{
	public class LocalFileSystem
	{
		private LocalFileSystem() { }
		//单例模式
		private static LocalFileSystem instance = new LocalFileSystem();
		public static LocalFileSystem Instance
		{
			get { return instance; }
		}

		/// <summary>
		/// 通过文件名称来获取指定路径下的用户文件
		/// </summary>
		/// <typeparam name="T">约束为localfile</typeparam>
		/// <param name="type_name">类型名称</param>
		/// <returns>返回一个T类型的对象或者null</returns>
		public LocalFile GetLocalFileFormPath<T>(string type_name) where T : LocalFile
		{
			string name = Data_LocalFile.Dic[type_name].name;

			if (Directory.Exists(Application.persistentDataPath))
			{
				DirectoryInfo direction = new DirectoryInfo(Application.persistentDataPath);
				FileInfo t = new FileInfo(Application.persistentDataPath + "/" + name + ".json");

				if (t.Exists)
				{
					T saveSettingFile = JsonMapper.ToObject<T>(t.OpenText().ReadToEnd());
					return saveSettingFile;
				}
				else
				{
					return null;
				}

			}
			else
			{
				return null;
			}
		}
	}
}

