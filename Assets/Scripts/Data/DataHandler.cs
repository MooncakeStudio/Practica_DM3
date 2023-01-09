using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Linq;

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
            //scl.list = scl.list.OrderByDescending(x => x.tiempo).ToList();
        } else
        {
            scl = new SerializableScoreList();
        }
        Debug.Log(path);
    }

    public void Guardar()
    {
        SerializableScore sc = new SerializableScore();
        sc.tiempo = GameManager.instance.GetTiempo();
        sc.ronda = GameManager.instance.GetRonda();

        scl.list.Add(sc);

        scl.list = scl.list.OrderByDescending(x => x.ronda).ThenByDescending(x => x.tiempo).ToList();

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
