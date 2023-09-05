    using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlassManager : MonoBehaviour
{
    [Header("倒计时UI")] public GameObject UI;
    [Header("倒计时")] public int countDown = 200;
    [Header("Water")] public GameObject Water;
    [Header("GreenGlassManager")] public GameObject GreenGlassManager;
    public bool cd = false;
    Transform[] replaceArray;

    void Start()
    {
        StartCoroutine(CountDown_Start(countDown));
    }

    private void Update()
    {
        //当倒计时的时间为0是
        if (countDown == 0)
        {
            if (cd == false)
            {
                //会将水隐藏
                Water.gameObject.SetActive(false);
                //会将绿色小麦替换成黄色小麦
                Cd();
            }
        }
    }

    private void Cd()
    {
        //获取到此物体下所有的子物体包括自己
        replaceArray = GetComponentsInChildren<Transform>(false);
        for (int i = 0; i < replaceArray.Length; i++)
        {
            // 判断子物体下的绿色小麦
            if (replaceArray[i].gameObject.name == "greenGlass_floor(Clone)" ||
                replaceArray[i].gameObject.name == "greenGlass_floor")
            {
                //调用绿色小麦当中的replace()方法将绿色小麦变成黄色小麦
                replaceArray[i].GetComponent<greenGlass_floor>().replace();
            }
        }

        cd = true;
    }

    //倒计时协程方法
    IEnumerator CountDown_Start(int time)
    {
        for (int i = time; i > 0; i--)
        {
            countDown--;
            //等待1秒
            yield return new WaitForSeconds(1);
            //将当前倒计时的时间给房子旁边的UI
            UI.transform.GetComponent<TextMeshProUGUI>().text = "CountDown:" + countDown + "s";
        }
    }
}