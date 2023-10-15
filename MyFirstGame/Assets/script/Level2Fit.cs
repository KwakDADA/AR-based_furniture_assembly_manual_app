using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Fit : MonoBehaviour
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
                Level2Controller.woodfit[0] = true; break;
            case 2:
                Level2Controller.woodfit[1] = true; break;
            case 3:
                Level2Controller.woodfit[2] = true; break;
            case 4:
                Level2Controller.woodfit[3] = true; break;
            case 5:
                Level2Controller.woodfit[4] = true; break;
        }
    }
}
