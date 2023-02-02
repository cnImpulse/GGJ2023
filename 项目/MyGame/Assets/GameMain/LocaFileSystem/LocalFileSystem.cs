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
		//����ģʽ
		private static LocalFileSystem instance = new LocalFileSystem();
		public static LocalFileSystem Instance
		{
			get { return instance; }
		}

		/// <summary>
		/// ͨ���ļ���������ȡָ��·���µ��û��ļ�
		/// </summary>
		/// <typeparam name="T">Լ��Ϊlocalfile</typeparam>
		/// <param name="type_name">��������</param>
		/// <returns>����һ��T���͵Ķ������null</returns>
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

