using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5Controller : MonoBehaviour
{
    public GameObject glass;
    public static bool glassfit;
    Vector3 glassInPos;
    Vector3 glassNow;
    int frame;
    Vector3 speed = Vector3.zero;
    bool move = false;
    bool Init = false;
    bool framecount = false;
    bool isStart = false;

    public void BumpNStop5(bool fit, GameObject ob) //5단계의 조립
    {
        if (!fit) //충돌 전
        {
            speed = new Vector3(0, 0, 0.2f);
            ob.transform.localPosition -= speed;
        }
        else //충돌 후
        {
            glass.transform.localPosition = glassNow;
        }
    }

    public void OnClickRe5()
    {
        frame = 1;
        Level5Fit.count = 0;
        for (int i = 0; i < 5; i++)
        {
            glassfit = false;
        }
        move = false;
        Init = true;
        framecount = false;
        isStart = false;
        GameObject.Find("start5").GetComponentInChildren<Text>().text = "start";
    }

    public void OnClickStart5()
    {
        if (isStart == false) //start를 누름
        {
            GameObject.Find("start5").GetComponentInChildren<Text>().text = "stop";
            isStart = true;
            move = true;
            Init = false;
            framecount = true;
        }
        else //stop을 누름
        {
            GameObject.Find("start5").GetComponentInChildren<Text>().text = "start";
            isStart = false;
            move = false;
            Init = false;
            framecount = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        frame = 1;
        glassfit = false;

        glassInPos = glass.transform.localPosition;
        glassNow = glass.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (move)
        {
            BumpNStop5(glassfit, glass);

        }
        else if (!move && Init) //restart
        {
            speed.x = 0;
            glass.transform.localPosition = glassInPos;   //각 파츠를 원위치로
        }
        else if (!move && !Init) //stop
        {
            speed.x = 0;
            glass.transform.localPosition = glassNow; //각 파츠의 위치를 stop을 누른 시점으로 고정
        }

        glassNow = glass.transform.localPosition; //각 파츠의 위치를 지속적으로 업데이트

       
    }

}