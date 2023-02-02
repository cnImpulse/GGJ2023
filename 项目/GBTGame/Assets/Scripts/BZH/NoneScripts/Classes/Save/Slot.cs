///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Slot
{
	public static void SaveGameToNative<T>(T inSave, string saveName = defaultSaveName) where T : Slot
	{
		string jsonText = JsonUtility.ToJson(inSave, true);

		StreamWriter writer = new StreamWriter(SavePath(saveName));
		writer.Write(jsonText);
		writer.Close();
	}

	public static bool TryLoadGameFromNative<T>(out T save, string saveName = defaultSaveName) where T : Slot
	{
		save = null;
		string path = SavePath(saveName);
		bool success = File.Exists(path);
		if (success)
		{
			StreamReader reader = new StreamReader(SavePath(saveName));
			string jsonText = reader.ReadToEnd();
			reader.Close();
			save = JsonUtility.FromJson<T>(jsonText);
		}

		return success;
	}

	public static T LoadGameFromNative<T>(string saveName = defaultSaveName) where T : Slot
	{
		StreamReader reader = new StreamReader(SavePath(saveName));
		string jsonText = reader.ReadToEnd();
		reader.Close();
		return JsonUtility.FromJson<T>(jsonText);
	}

	public static void RemoveGameFromNative(string saveName = defaultSaveName)
	{
		string path = SavePath(saveName);
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	private const string defaultSaveName = "Save";

	static string SavePath(string saveName) => $"{Application.persistentDataPath}/{saveName}.json";
}
