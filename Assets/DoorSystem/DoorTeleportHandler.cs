using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTeleportHandler : MonoBehaviour
{
    public string SceneToTeleportTo = "SCENE1";
    public GameObject TextToShow = null;
    private bool isInsideTrigger = false;
    
    private void OnTriggerEnter(Collider otherCollider)
    {
        isInsideTrigger = true;
    }
    private void OnTriggerExit(Collider otherCollider)
    {
        isInsideTrigger = false;

        if (TextToShow != null)
        {
            TextToShow.SetActive(false);
        }
    }

    void Update()
    {
        if (!isInsideTrigger) return;

        if (TextToShow != null)
        {
            TextToShow.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneToTeleportTo);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

    }
}
