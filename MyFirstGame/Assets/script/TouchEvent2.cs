using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvent2 : MonoBehaviour
{
    private GameObject target;
    public static int canvasIndex;
    public static int canvasNumber = 7;
    public static bool lightSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        int i;
        for (i = 1; i <= canvasNumber; i++)
        {
            GameObject.Find("Canvas" + i.ToString()).GetComponent<Canvas>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClikedObject();

            canvasIndex = int.Parse(target.name);
            

            if (target.Equals(gameObject))
            {
                int i;
                for (i = 1; i <= canvasNumber; i++)
                {
                    GameObject.Find("Canvas" + i.ToString()).GetComponent<Canvas>().enabled = false;
                }
                GameObject.Find("Canvas" + canvasIndex.ToString()).GetComponent<Canvas>().enabled = true;
                lightSwitch = GameObject.Find("Canvas" + canvasIndex.ToString()).GetComponent<Canvas>().enabled;
            }
        }
    }

    private GameObject GetClikedObject()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(true == (Physics.Raycast(ray.origin, ray.direction*10, out hit)))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}
