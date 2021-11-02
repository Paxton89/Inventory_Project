using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Public

    //Private
    private Camera _mainCam;
    
    //NonSerialized Public
    [NonSerialized] public Item CurrentItem;
    [NonSerialized] public InventorySlot TargetSlot;
    [NonSerialized] public Vector3 MousePos;
    
    //Serialized Private
    
    void Start()
    {
        _mainCam = FindObjectOfType<Camera>();
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (CurrentItem != null)
        {
            MousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            var SpriteSize = CurrentItem.GetComponent<SpriteRenderer>().size;
            CurrentItem.transform.position = new Vector3(MousePos.x - SpriteSize.x, MousePos.y - SpriteSize.y, -9f);
        }
    }
}
