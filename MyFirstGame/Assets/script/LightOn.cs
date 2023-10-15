using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : TouchEvent2
{
    GameObject tempObj = null;
    GameObject scaleObj = null;
    Vector3 v, zero;
    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(5.5f, 5.5f, 4);
        zero = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (TouchEvent2.lightSwitch == true)
        {
            int i;
            for (i = 1; i <= canvasNumber; i++)
            {
                GameObject t, s;
                t = GameObject.Find("line" + i.ToString());
                t.transform.localScale = zero;
            }
            tempObj = GameObject.Find("line" + canvasIndex.ToString());
            tempObj.transform.localScale = v;
        }

    }
}
