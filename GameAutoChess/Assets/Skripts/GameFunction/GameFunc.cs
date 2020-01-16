using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


public static class GameFunc 
{
    public static PlayerStats LoadGame(string saveName)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(saveName, FileMode.Open, FileAccess.Read, FileShare.Read);
        PlayerStats loadObj = (PlayerStats)formatter.Deserialize(stream);
        stream.Close();
        return loadObj;
    }
    public static string[] GetSaves()
    {
        return Directory.GetFiles(@"Assets\Saves\", "*.save");
    }
    public static bool SaveGame(PlayerStats saveData , string saveName)
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"Assets\Saves\" + saveName + ".save", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, saveData);
            stream.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool DeleteSave(string saveName)
    {
        try
        {
            File.Delete(saveName);
            return true;
        }
        catch
        {
            return false;
        }
       
    }
    public static void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public static byte[] CompilString(string str)
    {
        return System.Text.Encoding.UTF8.GetBytes(str);
    }
    public static string GetCommandFromRes(string str)
    {
        string[] words = str.Split(new char[] { ':' });
        return words[0];
    }
    public static string GetValueFromRes(string str)
    {
        string[] words = str.Split(new char[] { ':' });
        return words[1];
    }
}
