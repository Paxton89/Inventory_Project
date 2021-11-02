using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{

    //Public
    //JKHFDJKHKJF

    //Private
    private Player _player;
    private GameObject _panel;
    private RectTransform _rectTrans;
    private int InventoryXSize = 1;
    private int InventoryYSize = 1;

    //NonSerialized Public
    //SDFJHGFJAUHG

    //Serialized Private
    [SerializeField] private GameObject emptySlot;
    [SerializeField] private Item testItem;



    private void Awake()
    {
        if (GameObject.Find("Inventory Grid Panel"))
        {
            _panel = GameObject.Find("Inventory Grid Panel");
        }
        else
        {
            Debug.Log("COULD NOT FIND SECONDARY PANEL");
        }

        if (FindObjectOfType<Player>())
        { 
            _player = FindObjectOfType<Player>();
        }
        else
        {
            Debug.Log("COULD NOT FIND PLAYER");
        }
        _rectTrans = _panel.GetComponent<RectTransform>();
    }

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        InventoryXSize = (int)(_rectTrans.rect.width / emptySlot.GetComponent<SpriteRenderer>().sprite.rect.width / 1.55f);
        InventoryYSize = (int)(_rectTrans.rect.height / emptySlot.GetComponent<SpriteRenderer>().sprite.rect.height / 1.55f);

        Debug.Log("X" + InventoryXSize);
        Debug.Log("Y"+ InventoryYSize);
        var rect = _rectTrans.rect;
        var startPos = new Vector3((rect.center.x - rect.width/2), (rect.center.y - rect.height/2));
        for (int i = 0; i < InventoryXSize; i++)
        {
            for (int j = 0; j < InventoryYSize; j++)
            {
                var newPos = startPos + new Vector3((i * emptySlot.GetComponent<SpriteRenderer>().sprite.rect.width) * 1.55f,(j * emptySlot.GetComponent<SpriteRenderer>().sprite.rect.height) * 1.55f, -4);
                var newSlot = Instantiate(emptySlot, _panel.transform);
                newSlot.transform.localPosition = newPos;

                //Create Item 15% chance
                var randomInt = Random.Range(0, 100);
                if (randomInt <= 15) CreateBaseItem(newSlot.GetComponent<InventorySlot>());
                
            }
        }
    }
    private void CreateBaseItem(InventorySlot newSlot)
    {
        Item newItem = Instantiate(testItem, newSlot.transform);
        newItem.transform.position = newSlot.transform.position + newSlot.ItemPos;
        newSlot.Item = newItem;
        newSlot.IsEmpty = false;
    }
}
