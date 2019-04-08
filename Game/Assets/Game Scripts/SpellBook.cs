using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpellBook : MonoBehaviour
{
    public GameObject book;
    public GameObject defaultSpell;
    private bool active = false;
    private GameObject[] items;
    public InventorySlot[] slots;
    private int rand;
    // Start is called before the first frame update
    void Start()
    {
        book.SetActive(active);
        items = new GameObject[6];
        items[0] = defaultSpell;
        for (int i = 1; i < items.Length; i++)
        {
            items[i] = null;
            rand = Random.Range (0, 10);
            if (rand <= 5)
            {
                slots[i].AddItem(defaultSpell);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            active = !active;
            book.SetActive(active);
        }
    }

    public GameObject GetSpell(int slot)
    {
        return items[slot];
    }
    
    public void AddSpell(int slot, GameObject spell)
    {
        items[slot] = spell;
        slots[slot].AddItem(spell);
    }
}
