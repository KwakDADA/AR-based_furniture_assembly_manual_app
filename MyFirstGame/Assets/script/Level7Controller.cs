using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level7Controller : MonoBehaviour
{
    public GameObject ob1, ob2, ob3, ob4;
    public static bool[] fit = new bool[4];
    Vector3[] InitPos = new Vector3[4];
    Vector3[] PosNow = new Vector3[4];
    int frame, detailCount;
    int detailNum = 4; //디테일 단계 수
    Vector3 speed = Vector3.zero;
    bool move = false;
    bool Init = false;
    bool framecount = false;
    bool isStart = false;

    public void BumpNStop7(bool fit, GameObject ob) //7단계의 조립
    {
        if (!fit) //충돌 전
        {
            speed = new Vector3(0, 0, -0.2f);
            ob.transform.localPosition -= speed;
            GameObject.Find("detail7").GetComponent<Button>().interactable = false;
        }
        else //충돌 후
        {
            ob1.transform.localPosition = PosNow[0];
            ob2.transform.localPosition = PosNow[1];
            ob3.transform.localPosition = PosNow[2];
            ob4.transform.localPosition = PosNow[3];
            GameObject.Find("detail7").GetComponent<Button>().interactable = true;
        }
    }

    public void OnClickRe7()
    {
        frame = 1;
        detailCount = 0;
        Level7Fit.count = 0;
        for (int i = 0; i < detailNum; i++)
        {
            fit[i] = false;
        }
        move = false;
        Init = true;
        framecount = false;
        isStart = false;
        GameObject.Find("detail7").GetComponent<Button>().interactable = true;
        GameObject.Find("detail7").GetComponentInChildren<Text>().text = "detail mode";
        GameObject.Find("start7").GetComponentInChildren<Text>().text = "start";
    }

    public void OnClickStart7()
    {
        if (isStart == false) //start를 누름
        {
            GameObject.Find("start7").GetComponentInChildren<Text>().text = "stop";
            isStart = true;
            move = true;
            Init = false;
            framecount = true;
        }
        else //stop을 누름
        {
            GameObject.Find("start7").GetComponentInChildren<Text>().text = "start";
            isStart = false;
            move = false;
            Init = false;
            framecount = false;
        }
    }


    public void onClickDetail7()
    {
        if (GameObject.Find("detail7").GetComponent<Button>().interactable == true)
        {
            detailCount++;
            if (detailCount == 1)
            {
                GameObject.Find("detail7").GetComponentInChildren<Text>().text = "next";
                move = false;
                Init = true;
                framecount = false;
            }
            else if (detailCount <= detailNum + 1)
            {
                move = true;
            }
            else
            {
                GameObject.Find("detail7").GetComponentInChildren<Text>().text = "detail mode";
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        frame = 1;
        detailCount = 0;
        for (int i = 0; i < detailNum; i++)
        {
            fit[i] = false;
        }

        InitPos[0] = ob1.transform.localPosition;
        InitPos[1] = ob2.transform.localPosition;
        InitPos[2] = ob3.transform.localPosition;
        InitPos[3] = ob4.transform.localPosition;
        PosNow[0] = ob1.transform.localPosition;
        PosNow[1] = ob2.transform.localPosition;
        PosNow[2] = ob3.transform.localPosition;
        PosNow[3] = ob4.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (framecount)
            frame++;

        if (move)
        {
            if (frame > 0 || (detailCount == 2 && GameObject.Find("detail7").GetComponent<Button>().interactable == true))
                BumpNStop7(fit[0], ob1);
            if (frame > 10 || (detailCount == 3 && fit[0] == true))
                BumpNStop7(fit[1], ob2);
            if (frame > 20 || (detailCount == 4 && fit[1] == true))
                BumpNStop7(fit[2], ob3);
            if (frame > 30 || (detailCount == 5 && fit[2] == true))
                BumpNStop7(fit[3], ob4);

        }
        else if (!move && Init) //restart
        {
            speed.x = 0;
            ob1.transform.localPosition = InitPos[0];
            ob2.transform.localPosition = InitPos[1];
            ob3.transform.localPosition = InitPos[2];
            ob4.transform.localPosition = InitPos[3];   //각 파츠를 원위치로
        }
        else if (!move && !Init) //stop
        {
            speed.x = 0;
            ob1.transform.localPosition = PosNow[0];
            ob2.transform.localPosition = PosNow[1];
            ob3.transform.localPosition = PosNow[2];
            ob4.transform.localPosition = PosNow[3]; //각 파츠의 위치를 stop을 누른 시점으로 고정
        }

        PosNow[0] = ob1.transform.localPosition;
        PosNow[1] = ob2.transform.localPosition;
        PosNow[2] = ob3.transform.localPosition;
        PosNow[3] = ob4.transform.localPosition; //각 파츠의 위치를 지속적으로 업데이트

    }

}