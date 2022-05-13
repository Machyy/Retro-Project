using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnim;

    private PickupSystem pickupSystem;

    public GameObject doorBlock;
    
    private bool doorOpen = false;
    public bool IsDoorOpeningBlocked = false;
    
    

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
        pickupSystem = FindObjectOfType<PickupSystem>();
    }

    private void Update()
    {
        DoorBlock();
    }

    public void PlayAnimation()
    {
        if (IsDoorOpeningBlocked) return;
    
        if (!doorOpen)
        {
            doorAnim.Play("OpenDoor", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("CloseDoor", 0, 0.0f);
            doorOpen = false;
        }
    }

    public void CloseDoors()
    {
        if (!doorOpen) return;

        doorAnim.Play("CloseDoor", 0, 0.0f);
        doorOpen = false;
    }

    public void DoorBlock()
    {
        if (pickupSystem.IsBottlePaid == false && pickupSystem.IsHoldingBottle == true)
        {
            if(doorBlock.gameObject) doorBlock.SetActive(true);
        }
    }
}
