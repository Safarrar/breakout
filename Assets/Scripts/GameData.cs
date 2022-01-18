using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Singleton class to share and persist game data between scenes and across sessions
/// </summary>
public class GameData : MonoBehaviour
{
    [SerializeField]
    public class SaveData
    {
        public string name;
        public int points;
    }

    // Static Fields
    public static GameData Instance;

    // Public Fields
    public string Name;
    public int Points;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Persist the user data to the long-term storage
    /// </summary>
    public void SaveGame()
    {
        // Create a new SaveData object to persist data
        SaveData data = new SaveData() { name = this.Name, points = this.Points };

        // Create the file path and serialize Json
        string filename = Application.persistentDataPath + "/savegame.json";
        string json = JsonUtility.ToJson(data);

        // Write the file contents
        File.WriteAllText(filename, json);
    }

    /// <summary>
    /// Read the highscore information from long-term storage
    /// </summary>
    public SaveData LoadGame()
    {
        // Validate the file exists
        string filename = Application.persistentDataPath + "/savegame.json";
        if(File.Exists(filename))
        {
            // Read the information from file
            string data = File.ReadAllText(filename);

            // Return the results
            return JsonUtility.FromJson<SaveData>(data);
        }

        // Return a new SaveData object
        return new SaveData();
    }
}
