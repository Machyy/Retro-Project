using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenu : MonoBehaviour
{
    public GameObject escMenuCanvas = null;
    private SaveHandler saveHandler = null;
#if UNITY_EDITOR
    private bool runnedWithoutMenu = false;
#endif

    void Start()
    {
        var tempGameObject = GameObject.Find("SaveGameObject");
#if UNITY_EDITOR
        if (tempGameObject == null)
        {
            print("The game was not run from the MENU scene, creating the save object from scratch.");

            var saveGameObject = new GameObject("SaveGameObject");
            Instantiate(saveGameObject, Vector3.zero, Quaternion.identity);
            saveGameObject.AddComponent<SaveHandler>();
            tempGameObject = saveGameObject;
        }
#endif
        saveHandler = tempGameObject.GetComponent<SaveHandler>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escMenuCanvas.SetActive(!escMenuCanvas.activeSelf);
        }
    }

    public void OnSaveGameButton_Clicked()
    {
        saveHandler.SaveGame();
    }
    public void OnLoadGameButton_Clicked()
    {
        saveHandler.LoadGame();
    }

    public void OnReturnToMenuButton_Clicked()
    {
        SceneManager.LoadScene("MENU");
    }
}
