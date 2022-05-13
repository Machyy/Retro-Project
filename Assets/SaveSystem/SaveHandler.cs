using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveHandler : MonoBehaviour
{
    private string saveFileName = "save.txt";
    private const string alternativeFileName = "alternativesave.txt";
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (File.Exists(saveFileName)) return;

        try
        {
            File.Create(saveFileName);
        }
        catch (Exception ex)
        {
#if UNITY_EDITOR
            print("Failed creating the file " + ex);
#endif
        }

    }

    public void SaveGame()
    {

        var scene = SceneManager.GetActiveScene();

        try
        {
            using var sw = new StreamWriter(saveFileName, false);

            sw.WriteLine(scene.name);
        }
        catch (UnauthorizedAccessException unauthorizedAccessException)
        {
#if UNITY_EDITOR
            print("Cannot write to file: " + saveFileName + " access was denied! Exception: " +
                  unauthorizedAccessException);
            print("trying with another filename... ");
#endif
            saveFileName = alternativeFileName;
            SaveGame();
        }
        catch (Exception ex)
        {
#if UNITY_EDITOR
            print("Cannot write to file: " + saveFileName + " Exception: " +
                  ex);
#endif
        }
    }

    public void LoadGame()
    {
        try
        {
            if (!File.Exists(saveFileName))
            {
                if (File.Exists(alternativeFileName))
                {
                    saveFileName = alternativeFileName;
                }
            }
                
            using var streamReader = new StreamReader(saveFileName);
            var savedSceneName = streamReader.ReadLine();

            SceneManager.LoadScene(savedSceneName);
        }
        catch (Exception ex)
        {
#if UNITY_EDITOR
            print("Cannot read file: " + saveFileName + " Exception: " + ex);
#endif
        }
    }
}
