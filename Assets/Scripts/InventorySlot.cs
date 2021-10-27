using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    //Public

    //Private
    

    //NonSerialized Public
    [NonSerialized]
    public bool IsEmpty = true;
    [NonSerialized]
    public Item Item;

    //Serialized Private

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        
    }
}
