using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public Transform HeadJointTransform = null;
    private const int LayerMask = 1 << 8;
    public bool IsHoldingBottle = false;
    public bool IsBottlePaid = false;
    public GameObject BottleInHand;
    public GameObject KeyInHand;

    private void Awake()
    {
        HeadJointTransform = gameObject.transform;
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.F) || IsHoldingBottle) return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask)) return;

        var objectHit = hit.transform;
        Destroy(objectHit.gameObject);
        BottleInHand.SetActive(true);
        IsHoldingBottle = true;
        KeyInHand.SetActive(true);
        
    }
}
