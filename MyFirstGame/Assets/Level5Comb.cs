using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Comb : MonoBehaviour
{
    public GameObject glass;
    private bool fit;

    // Start is called before the first frame update
    void Start()
    {
        fit = false;
    }

    // Update is called once per frame
    void Update()
    {
        BumpNStop5(fit, glass);   
    }

    private void OnCollisionEnter(Collision collision)
    {
        fit = true;
    }

    public void BumpNStop5(bool fit, GameObject plane)
    {
        if (fit == false)
        {
            plane.transform.localPosition -= new Vector3(0, 0, 0.08f);
        }
    }
}
