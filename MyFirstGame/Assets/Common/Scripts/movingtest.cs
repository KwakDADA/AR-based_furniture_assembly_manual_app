using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingtest : MonoBehaviour
{
    public GameObject cube1;
    public float moveSpeed = 0.0005f;
    public Vector3 v3;
    public float x = 0;
    // Start is called before the first frame update
    void Start()
    {
        cube1.gameObject.transform.position = new Vector3(0, 0, 0);
    }


    // Update is called once per frame
    void Update()//Update함수는 프레임마다 호출
    {
        x = x + 1f;
        cube1.gameObject.transform.position += new Vector3(0.01f, 0, 0);
        cube1.gameObject.transform.rotation = Quaternion.Euler(x, 0, 0);
    }
}
