using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    //Public
    //JKHFDJKHKJF

    //Private
    private GameObject _panel;
    private int InventoryXSize = 1;
    private int InventoryYSize = 1;

    //NonSerialized Public
    //SDFJHGFJAUHG

    //Serialized Private
    [SerializeField] private GameObject emptySlot;



    void Awake()
    {
        if (GameObject.Find("Inventory Grid Panel"))
        {
            _panel = GameObject.Find("Inventory Grid Panel");
        }
        else
        {
            Debug.Log("COULD NOT FIND SECONDARY PANEL");
        }
    }

    void Start()
    {
        var rect = _panel.GetComponent<RectTransform>().rect;
        InventoryXSize = (int)(rect.width / emptySlot.GetComponent<SpriteRenderer>().sprite.rect.width / 1.55f);
        InventoryYSize = (int)(rect.height / emptySlot.GetComponent<SpriteRenderer>().sprite.rect.height / 1.55f);

        Debug.Log("X" + InventoryXSize);
        Debug.Log("Y"+ InventoryYSize);
        var startPos = new Vector3((rect.center.x - rect.width/2), (rect.center.y - rect.height/2));
        for (int i = 0; i < InventoryXSize; i++)
        {
            for (int j = 0; j < InventoryYSize; j++)
            {
                var NewPos = startPos + new Vector3((i * emptySlot.GetComponent<SpriteRenderer>().sprite.rect.width) * 1.55f,(j * emptySlot.GetComponent<SpriteRenderer>().sprite.rect.height) * 1.55f, -4);
                var NewSlot = Instantiate(emptySlot, _panel.transform);
                NewSlot.transform.localPosition = NewPos;
            }
        }

        void Update()
        {

        }
    }
}
