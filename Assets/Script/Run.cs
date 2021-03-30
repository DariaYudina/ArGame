using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public CatScript CatScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CatScript.Open();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            CatScript.Save();
        }
    }
}
