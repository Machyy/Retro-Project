using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPaidCheck : MonoBehaviour
{
    public GameObject PickUpSystem;
    public GameObject DoorSystem;

    private void OnTriggerEnter(Collider other)
    {
        var pickupSystemComponent = PickUpSystem.GetComponent<PickupSystem>();
        
        if (!(pickupSystemComponent.IsHoldingBottle && !pickupSystemComponent.IsBottlePaid)) return;

        var doorSystemComponent = DoorSystem.GetComponent<DoorController>();
        
        doorSystemComponent.CloseDoors();
        doorSystemComponent.IsDoorOpeningBlocked = true;
    }
}
