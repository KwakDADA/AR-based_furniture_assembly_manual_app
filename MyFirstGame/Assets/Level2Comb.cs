using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Comb : MonoBehaviour
{
    public GameObject[] plane;
    private bool planefit1, planefit2, planefit3, planefit4, planefit5;
    int frame = 0;
    int count;

    public void BumpNStop2(bool fit, GameObject plane)
    {
        if (fit == false)
        {
            plane.transform.localPosition -= new Vector3(0, 0.08f, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            planefit1 = false;
            planefit2 = false;
            planefit3 = false;
            planefit4 = false;
            planefit5 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        frame++;
            if (frame > 0)
            {
                BumpNStop2(planefit1, plane[0]);
            }
            if (frame > 30)
            {
                BumpNStop2(planefit2, plane[1]);
            }
            if (frame > 60)
            {
                BumpNStop2(planefit3, plane[2]);
            }
        }
    void OnCollisionEnter(Collision collision)
    {
        count++;
        Debug.Log("count: " + count);
        switch (count)
        {
            case 1:
                planefit1 = true; break;
            case 2:
                planefit2 = true; break;
            case 3:
                planefit3 = true; break;
            case 4:
                planefit4 = true; break;
            case 5:
                planefit5 = true; break;
        }

    }

   
}


