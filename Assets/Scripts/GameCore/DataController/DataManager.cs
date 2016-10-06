using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public class DataManager
{
    public bool IsSceneBeingLoaded = false;

    public static bool FileExist()
    {
        if (!File.Exists("Saves/save.binary"))
        {
            Directory.CreateDirectory("Saves");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream saveFile = File.Create("Saves/save.binary");
            formatter.Serialize(saveFile, new PlayerStatistics());
            return false;
        }
        else
        {
            return true;
        }
    }

    public static void SaveInformationsData(PlayerInformations p)
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/informations.binary");
        formatter.Serialize(saveFile, p);

        saveFile.Close();
    }

    public static PlayerInformations LoadInformationsData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/informations.binary",
            FileMode.Open);

        PlayerInformations p =
            (PlayerInformations)formatter.Deserialize(saveFile);
        saveFile.Close();
        return p;
    }

    public static void SaveTrailData(PlayerStatistics p)
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");
        formatter.Serialize(saveFile, p);

        saveFile.Close();
    }

    public static PlayerStatistics LoadTrailData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", 
            FileMode.Open);

        PlayerStatistics p = 
            (PlayerStatistics)formatter.Deserialize(saveFile);
        saveFile.Close();
        return p;
    }
}
