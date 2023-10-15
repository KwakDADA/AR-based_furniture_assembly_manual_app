using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Fit : MonoBehaviour
{
    public static int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        count++;
        switch (count)
        {
            case 1:
                Level4Controller.fit[0] = true; break;
            case 2:
                Level4Controller.fit[1] = true; break;
            case 3:
                Level4Controller.fit[2] = true; break;
        }
    }
}
