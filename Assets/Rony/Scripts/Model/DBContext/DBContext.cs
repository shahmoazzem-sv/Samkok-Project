using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DBContext : MonoBehaviour
{
    public static DBContext Instance;
    public void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }
    private string path = Path.Combine(Application.streamingAssetsPath, "db.json");
    public void SaveData(List<HeroCardSnapshot> heroCardSnapshots)
    {
        // Load the existing data and append the newly arrived data to it and then save it altogether
        string json = JsonConvert.SerializeObject(heroCardSnapshots, Formatting.Indented);
        File.WriteAllText(path, json);
    }
    public List<HeroCardSnapshot> LoadData()
    {
        if (!File.Exists(path))
        {
            Debug.Log("Path Not Found");
            return new List<HeroCardSnapshot>();
        }
        string json = File.ReadAllText(path);
        Debug.Log("Path Found");
        Debug.Log(json.Length);
        return JsonConvert.DeserializeObject<List<HeroCardSnapshot>>(json) ?? new List<HeroCardSnapshot>();
    }
}