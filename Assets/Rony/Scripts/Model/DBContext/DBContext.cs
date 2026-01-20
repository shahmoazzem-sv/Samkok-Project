using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DBContext : MonoBehaviour
{
    public static DBContext Instance;
    private string _path;
    public void Awake()
    {
        if (Instance != null) return;
        Instance = this;
        _path = Path.Combine(Application.persistentDataPath, "database.sqlite");
        Debug.Log(_path);
    }

    void Start()
    {
        UseConnection(conn =>
        {
            conn.CreateTable<HeroCardSnapshot>();
        });
    }

    private T UseConnection<T>(System.Func<SQLiteConnection, T> func)
    {
        var options = new SQLiteConnectionString(_path, false);
        using (var conn = new SQLiteConnection(options))
        {
            return func(conn);
        }
    }
    private void UseConnection(System.Action<SQLiteConnection> action)
    {
        var options = new SQLiteConnectionString(_path, false);
        using (var conn = new SQLiteConnection(options))
        {
            action(conn);
        }
    }

    public void SaveData<T>(T snapshot)
    {
        UseConnection(conn =>
        {
            conn.Insert(snapshot);
        });
    }
    public List<HeroCardSnapshot> LoadData()
    {
        if (!File.Exists(_path))
        {
            Debug.Log("Path Not Found");
            return new List<HeroCardSnapshot>();
        }
        List<HeroCardSnapshot> result;
        return UseConnection<List<HeroCardSnapshot>>(conn =>
        {
            result = conn.Table<HeroCardSnapshot>().ToList();
            return result;
        });
    }
}