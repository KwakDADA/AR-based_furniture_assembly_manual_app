using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Controller : MonoBehaviour
{
    public GameObject wood1, wood2, wood3, wood4, wood5;
    public static bool[] woodfit = new bool[5];
    Vector3[] woodInPos = new Vector3[5];
    Vector3[] woodNow = new Vector3[5];
    int frame, detailCount;
    int detailNum = 5; //디테일 단계 수
    Vector3 speed = Vector3.zero;
    bool move = false;
    bool Init = false;
    bool framecount = false;
    bool isStart = false;

    public void BumpNStop2(bool fit, GameObject ob) //2단계의 조립
    {
        if (!fit) //충돌 전
        {
            speed = new Vector3(0, 0.1f, 0);
            ob.transform.localPosition -= speed;
            GameObject.Find("detail2").GetComponent<Button>().interactable = false;
        }
        else //충돌 후
        {
            wood1.transform.localPosition = woodNow[0];
            wood2.transform.localPosition = woodNow[1];
            wood3.transform.localPosition = woodNow[2];
            wood4.transform.localPosition = woodNow[3];
            wood5.transform.localPosition = woodNow[4];
            GameObject.Find("detail2").GetComponent<Button>().interactable = true;
        }
    }

    public void OnClickRe2()
    {
        frame = 1;
        detailCount = 0;
        Level2Fit.count = 0;
        for (int i = 0; i < 5; i++)
        {
            woodfit[i] = false;
        }
        move = false;
        Init = true;
        framecount = false;
        isStart = false;
        GameObject.Find("detail2").GetComponent<Button>().interactable = true;
        GameObject.Find("detail2").GetComponentInChildren<Text>().text = "detail mode";
        GameObject.Find("start2").GetComponentInChildren<Text>().text = "start";
    }

    public void OnClickStart2()
    {
        if (isStart == false) //start를 누름
        {
            GameObject.Find("start2").GetComponentInChildren<Text>().text = "stop";
            isStart = true;
            move = true;
            Init = false;
            framecount = true;
        }
        else //stop을 누름
        {
            GameObject.Find("start2").GetComponentInChildren<Text>().text = "start";
            isStart = false;
            move = false;
            Init = false;
            framecount = false;
        }
    }


    public void onClickDetail2()
    {
        if (GameObject.Find("detail2").GetComponent<Button>().interactable == true)
        {
            detailCount++;
            if (detailCount == 1)
            {
                GameObject.Find("detail2").GetComponentInChildren<Text>().text = "next";
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
                GameObject.Find("detail2").GetComponentInChildren<Text>().text = "detail mode";
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        frame = 1;
        detailCount = 0;
        for (int i = 0; i < 5; i++)
        {
            woodfit[i] = false;
        }

        woodInPos[0] = wood1.transform.localPosition;
        woodInPos[1] = wood2.transform.localPosition;
        woodInPos[2] = wood3.transform.localPosition;
        woodInPos[3] = wood4.transform.localPosition;
        woodInPos[4] = wood5.transform.localPosition;
        woodNow[0] = wood1.transform.localPosition;
        woodNow[1] = wood2.transform.localPosition;
        woodNow[2] = wood3.transform.localPosition;
        woodNow[3] = wood4.transform.localPosition;
        woodNow[4] = wood5.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (framecount)
            frame++;

        if (move)
        {
            if (frame > 0 || (detailCount == 2 && GameObject.Find("detail2").GetComponent<Button>().interactable == true))
                BumpNStop2(woodfit[0], wood1);
            if (frame > 10 || (detailCount == 3 && woodfit[0] == true))
                BumpNStop2(woodfit[1], wood2);
            if (frame > 20 || (detailCount == 4 && woodfit[1] == true))
                BumpNStop2(woodfit[2], wood3);
            if (frame > 30 || (detailCount == 5 && woodfit[2] == true))
                BumpNStop2(woodfit[3], wood4);
            if (frame > 40 || (detailCount == 6 && woodfit[3] == true))
                BumpNStop2(woodfit[4], wood5);

        }
        else if (!move && Init) //restart
        {
            speed.x = 0;
            wood1.transform.localPosition = woodInPos[0];
            wood2.transform.localPosition = woodInPos[1];
            wood3.transform.localPosition = woodInPos[2];
            wood4.transform.localPosition = woodInPos[3];
            wood5.transform.localPosition = woodInPos[4];   //각 파츠를 원위치로
        }
        else if (!move && !Init) //stop
        {
            speed.x = 0;
            wood1.transform.localPosition = woodNow[0];
            wood2.transform.localPosition = woodNow[1];
            wood3.transform.localPosition = woodNow[2];
            wood4.transform.localPosition = woodNow[3];
            wood5.transform.localPosition = woodNow[4]; //각 파츠의 위치를 stop을 누른 시점으로 고정
        }

        woodNow[0] = wood1.transform.localPosition;
        woodNow[1] = wood2.transform.localPosition;
        woodNow[2] = wood3.transform.localPosition;
        woodNow[3] = wood4.transform.localPosition;
        woodNow[4] = wood5.transform.localPosition; //각 파츠의 위치를 지속적으로 업데이트

    }

}