﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Fit : MonoBehaviour
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
        Level5Controller.glassfit = true;
    }
}
