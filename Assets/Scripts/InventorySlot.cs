using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    //Public
    
    //Private

    //NonSerialized Public
    [NonSerialized] public bool IsEmpty = true;
    [NonSerialized] public Item Item;
    [NonSerialized] public Player Player;
    [NonSerialized] public Vector3 ItemPos;

    //Serialized Private

    private void Awake()
    {
        ItemPos = new Vector3(GetComponent<SpriteRenderer>().size.x / 5,GetComponent<SpriteRenderer>().size.y / 5, -0.1f);
    }

    void Start()
    {
        Player = FindObjectOfType<Player>();
    }

    public void ObtainItem(Item newItem)
    {
        if (Player.CurrentItem == null) return;
        if (IsEmpty)
        {
            Item = newItem;
            IsEmpty = false;
            Player.CurrentItem = null;
            newItem.transform.position = transform.position + ItemPos;
            Debug.Log("Obtained Item From Player!");
        }
    }

    public void RelinquishItem()
    {
        if (Player.CurrentItem != null) return;
        if (!IsEmpty)
        {
            IsEmpty = true;
            Player.CurrentItem = Item;
            Item = null;
            Debug.Log("Relinquished Item To Player!");
        }
    }
    private void OnMouseDown()
    {
        if (Player.CurrentItem == null) // Player Grab Item
        {
            RelinquishItem();
        }
    }

    private void OnMouseOver() // Set Current Slot Player Is Hovering To TargetSlot
    {
        Player.TargetSlot = this;
    }

    private void OnMouseUp() // Give Item To TargetSlot;
    {
        Player.TargetSlot.ObtainItem(Player.CurrentItem);
    }
}
