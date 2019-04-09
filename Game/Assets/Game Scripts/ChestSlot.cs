using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChestSlot : MonoBehaviour
{
    public Image icon;
    private GameObject item;
    private GameObject book;
    void Start()
    {
        book = GameObject.FindGameObjectWithTag("Spellbook");
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

    public void chooseItem()
    {
        int rand = Random.Range (0, 5);
        for (int i = 0; i < 6; i++)
        {
            if (book.GetComponent<SpellBook>().GetSpell(i) == null)
            {
                book.GetComponent<SpellBook>().AddSpell(i, item);
                ClearSlot();
                return;
            }
        }
        GameObject temp = book.GetComponent<SpellBook>().GetSpell(rand);
        book.GetComponent<SpellBook>().AddSpell(rand, item);
        AddItem(temp);
    }
}
