using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Controller : MonoBehaviour
{
    public GameObject movingOb;
    public static bool fit;
    Vector3 InitPos;
    Vector3 PosNow;
    int frame;
    Vector3 speed = Vector3.zero;
    bool move = false;
    bool Init = false;
    bool framecount = false;
    bool isStart = false;

    public void BumpNStop3(bool fit, GameObject ob) //3단계의 조립
    {
        if (!fit) //충돌 전
        {
            speed = new Vector3(0, 0.2f, 0);
            ob.transform.localPosition -= speed;
        }
        else //충돌 후
        {
            movingOb.transform.localPosition = PosNow;
        }
    }

    public void OnClickRe3()
    {
        frame = 1;
        Level3Fit.count = 0;
        fit = false;
        move = false;
        Init = true;
        framecount = false;
        isStart = false;
        GameObject.Find("start3").GetComponentInChildren<Text>().text = "start";
    }

    public void OnClickStart3()
    {
        if (isStart == false) //start를 누름
        {
            GameObject.Find("start3").GetComponentInChildren<Text>().text = "stop";
            isStart = true;
            move = true;
            Init = false;
            framecount = true;
        }
        else //stop을 누름
        {
            GameObject.Find("start3").GetComponentInChildren<Text>().text = "start";
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
        fit = false;

        InitPos = movingOb.transform.localPosition;
        PosNow = movingOb.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (move)
        {
            BumpNStop3(fit, movingOb);

        }
        else if (!move && Init) //restart
        {
            speed.y = 0;
            movingOb.transform.localPosition = InitPos;   //각 파츠를 원위치로
        }
        else if (!move && !Init) //stop
        {
            speed.y = 0;
            movingOb.transform.localPosition = PosNow; //각 파츠의 위치를 stop을 누른 시점으로 고정
        }

        PosNow = movingOb.transform.localPosition; //각 파츠의 위치를 지속적으로 업데이트
        
    }

}