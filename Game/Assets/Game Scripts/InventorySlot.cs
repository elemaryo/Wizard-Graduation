using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    private GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        item = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(GameObject newItem)
    {
        item = newItem;
        //icon.sprite = null;
        icon.sprite = newItem.GetComponent<SpriteRenderer>().sprite;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
