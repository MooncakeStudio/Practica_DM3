using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Linq;
using TMPro;

public class DataHandler : MonoBehaviour
{
    // ATRIBUTOS

    string path;

    SerializableScoreList scl;
    [SerializeField] GameObject mostrarPuntuaciones;

    public static DataHandler instance;
    // METODOS

    public void Awake()
    {

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + Path.DirectorySeparatorChar + "Puntuaciones.json";

        if (File.Exists(path))
        {
            using (File.OpenRead(path))
            {
                string json = File.ReadAllText(path);
                scl = JsonUtility.FromJson<SerializableScoreList>(json);
            }
            //scl.list = scl.list.OrderByDescending(x => x.tiempo).ToList();
        } else
        {
            scl = new SerializableScoreList();

            var fs = new FileStream(path, FileMode.Create);
            fs.Dispose();
            string txt = JsonUtility.ToJson(scl);
            File.WriteAllText(path, txt);
        }
        Debug.Log(path);
    }

    public void Guardar()
    {
        SerializableScore sc = new SerializableScore();
        sc.tiempo = GameManager.instance.GetTiempo();
        sc.ronda = GameManager.instance.GetRonda();
        sc.enemigosDerrotados = GameManager.instance.GetEnemigosTotalesDerrotados();

        scl.list.Add(sc);

        scl.list = scl.list.OrderByDescending(x => x.enemigosDerrotados).ThenByDescending(x => x.ronda).ThenByDescending(x=>x.tiempo).ToList();

        string puntuacionesJson = JsonUtility.ToJson(scl);

        foreach(var s in scl.list)
        {
            Debug.Log(s);
        }

        File.WriteAllText(path, puntuacionesJson);
    }

    public void MostrarPuntuaciones()
    {
        if (!mostrarPuntuaciones.gameObject.activeSelf)
        {

            mostrarPuntuaciones.gameObject.SetActive(true);

            SerializableScoreList scl = gameObject.GetComponent<DataHandler>().CargarPuntuaciones();

            var texto = mostrarPuntuaciones.transform.Find("Modal/ListaHS/Container/Texto").GetComponent<TextMeshProUGUI>();

            for(int i = 0; i < 10; i++)
            {
                float minutos = Mathf.FloorToInt(scl.list[i].tiempo / 60);
                float segundos = Mathf.FloorToInt(scl.list[i].tiempo % 60);
                texto.text += scl.list[i].enemigosDerrotados + "\t\t" + scl.list[i].ronda + "\t\t" + string.Format("{0:0}:{1:00}", minutos, segundos) + "\n";
            }
        }
    }

    public void CerrarPuntuaciones()
    {
        var texto = mostrarPuntuaciones.GetComponent<TextMeshProUGUI>();
        texto.text = "";

        mostrarPuntuaciones.gameObject.SetActive(false);
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

    public int enemigosDerrotados;
}

[Serializable]
public class SerializableScoreList
{
    public List<SerializableScore> list = new List<SerializableScore>();
}
