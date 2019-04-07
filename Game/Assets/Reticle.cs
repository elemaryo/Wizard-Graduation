using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Hide mouse cursor
        Cursor.visible = false;   
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Input.mousePosition;
    }
}
