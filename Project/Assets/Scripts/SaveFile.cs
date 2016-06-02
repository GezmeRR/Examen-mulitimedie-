using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class SaveFile
{
    public static int newScore;
    public List<Score> scores = new List<Score>();

    [Serializable]
    public class Score
    {
        public string name;
        public int score;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Format("{0}/HighScore.sav", Application.persistentDataPath));
        bf.Serialize(file, this);
        file.Close();
    }

    public void Load()
    {
        string fileName = string.Format("{0}/HighScore.sav", Application.persistentDataPath);

        if (File.Exists(fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileName, FileMode.Open);
            SaveFile save = (SaveFile)bf.Deserialize(file);
            file.Close();

            scores = save.scores;
        }
    }
}
