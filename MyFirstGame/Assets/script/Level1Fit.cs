using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Fit : MonoBehaviour
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
                Level1Controller.fit[0] = true; break;
            case 2:
                Level1Controller.fit[1] = true; break;
            case 3:
                Level1Controller.fit[2] = true; break;
            case 4:
                Level1Controller.fit[3] = true; break;
        }
    }
}
