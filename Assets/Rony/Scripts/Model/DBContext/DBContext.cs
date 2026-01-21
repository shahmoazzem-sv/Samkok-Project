using SQLite;
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
            conn.CreateTable<HeroCardRecord>();
            conn.CreateTable<HeroCardSquadRecord>();
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
    // This should do all CREATE thingy for our different Tables
    public void SaveData<T>(T snapshot)
    {
        UseConnection(conn =>
        {
            conn.Insert(snapshot);
        });
    }
    // This should do all the READ thingy for our different Tables
    public List<T> LoadData<T>() where T : new()
    {
        if (!File.Exists(_path))
        {
            Debug.Log("Path Not Found");
            return new List<T>();
        }
        List<T> result;
        return UseConnection(conn =>
        {
            result = conn.Table<T>().ToList();
            return result;
        });
    }
    // We need an UPDATE method that is Record Agnostic
    public int UpdateData<T>(T obj)
    {
        return UseConnection(conn =>
        {
            return conn.Update(obj);
        });
    }

    // We need an DELETE method as well to delete a tuple from the database and we want it to take an Id and delete it
    public int DeleteData<T>(string Id)
    {
        return UseConnection(conn =>
        {
            return conn.Delete<T>(Id);
        });
    }
}