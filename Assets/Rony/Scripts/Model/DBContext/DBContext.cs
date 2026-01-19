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
    private string path = Path.Combine("./", "db.json");
    public void SaveData(List<HeroCardSnapshot> heroCardSnapshots)
    {
        string json = JsonConvert.SerializeObject(heroCardSnapshots, Formatting.Indented);
        File.WriteAllText(path, json);
    }
    public List<HeroCardSnapshot> LoadData()
    {
        if (!File.Exists(path)) return new List<HeroCardSnapshot>();
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<HeroCardSnapshot>>(json) ?? new List<HeroCardSnapshot>();
    }
}