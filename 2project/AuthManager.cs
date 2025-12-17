using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class AuthManager
{
    private List<User> users = new List<User>();
    private string filePath = "users.json";

    public AuthManager()
    {
        Load();
    }

    private void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(json))
                users = JsonSerializer.Deserialize<List<User>>(json);
        }
    }

    private void Save()
    {
        File.WriteAllText(
            filePath,
            JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true })
        );
    }

    public bool Register(string username, string password)
    {
        if (users.Any(u => u.Username == username))
            return false;

        users.Add(new User { Username = username, Password = password });
        Save();
        return true;
    }

    public bool Login(string username, string password)
    {
        return users.Any(u => u.Username == username && u.Password == password);
    }
}
