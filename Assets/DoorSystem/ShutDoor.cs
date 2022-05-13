using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDoor : MonoBehaviour
{
    public GameObject shutDoor;

    public GameObject trigger;
    
    private DoorController doorController;

    public void Start()
    {
        doorController = FindObjectOfType<DoorController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        doorController.CloseDoors();
        Destroy(trigger);
    }
}
