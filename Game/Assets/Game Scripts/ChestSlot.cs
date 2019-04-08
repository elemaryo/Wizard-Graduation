using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlot : MonoBehaviour
{
    public Image icon;
    private GameObject item;

    void Start()
    {
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
