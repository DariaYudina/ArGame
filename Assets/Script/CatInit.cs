using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CatScript.PlayerCat = this.gameObject;
        //Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CatScript.PlayerCat)
        {
            CatScript.PlayerCat = this.gameObject;
            Destroy(this);
        }
    }
}
