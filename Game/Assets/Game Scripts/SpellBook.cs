using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    public GameObject book;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        book.SetActive(active);
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
}
