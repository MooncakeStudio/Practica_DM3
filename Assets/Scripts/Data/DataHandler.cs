using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.Runtime.Serialization.Json;

public class DataHandler : MonoBehaviour
{
    // ATRIBUTOS

    string path;

    SerializableScoreList scl;


    // METODOS

    public void Awake()
    {
        path = Application.persistentDataPath;

        if (File.Exists(path + "/Puntuaciones.json"))
        {
            string json = File.ReadAllText(path + "/Puntuaciones.json");
            scl = JsonUtility.FromJson<SerializableScoreList>(json);
        } else
        {
            scl = new SerializableScoreList();
        }
        Debug.Log(path);
    }

    public void Guardar()
    {
        SerializableScore sc = new SerializableScore();
        sc.tiempo = GameManager.tiempo;
        sc.ronda = GameManager.ronda;

        scl.list.Add(sc);

        String puntuacionesJson = JsonUtility.ToJson(scl);

        File.WriteAllText(path + "/Puntuaciones.json", puntuacionesJson);
    }

    public SerializableScoreList CargarPuntuaciones()
    {
        return this.scl;
    }
}

[Serializable]
public class SerializableScore
{
    public float tiempo;

    public int ronda;
}

[Serializable]
public class SerializableScoreList
{
    public List<SerializableScore> list = new List<SerializableScore>();
}
