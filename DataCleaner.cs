using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataCleaner : MonoBehaviour
{
    public Button clearDataButton;

    private void Start()
    {
        if (clearDataButton != null)
        {
            clearDataButton.onClick.AddListener(ClearAllData);
        }
    }

    public void ClearAllData()
    {
        // Clear PlayerPrefs
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        // Clear Persistent Data Path
        string path = Application.persistentDataPath;
        DirectoryInfo directory = new DirectoryInfo(path);
        
        try
        {
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                dir.Delete(true);
            }
            Debug.Log("All data cleared successfully!");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error clearing data: {e.Message}");
        }
    }

    private void OnDestroy()
    {
        if (clearDataButton != null)
        {
            clearDataButton.onClick.RemoveListener(ClearAllData);
        }
    }
}