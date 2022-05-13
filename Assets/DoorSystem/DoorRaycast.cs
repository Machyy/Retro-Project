using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int  rayLenght = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private DoorController raycastedObject;

    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    private const string interactableTag = "InteractiveObject";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLenght, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                raycastedObject = hit.collider.gameObject.GetComponent<DoorController>();
                if (Input.GetKeyDown(openDoorKey))
                {
                    raycastedObject.PlayAnimation();
                }
            }
        }
    }
}
