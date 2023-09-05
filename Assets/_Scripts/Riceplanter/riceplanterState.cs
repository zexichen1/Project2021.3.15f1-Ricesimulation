/*
 * 判断车辆当前状态
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riceplanterState : MonoBehaviour
{
    //主管理器
    [Header("主管理器")] private GameObject riceplanterl;

    //关于按钮
    [Header("redButton状态")] public bool isredbutton;
    
    //关于协程
    [Header("isInsGreenGlassn状态")] public bool isOnInsGreenGlass;

    [Header("GreenGlass")] public GameObject GreenGlass;

    [Header("glassManger")] public GameObject glassManger;

    [Header("Header")] public GameObject Header;

    private void Start()
    {
        riceplanterl = this.gameObject;
    }

    void Update()
    {
        isInsGreenGlass();
    }

    private void isInsGreenGlass()
    {
        //当时isredbutton值改变时会触发OnInsGreenGlass()这个协程方法
        if (isredbutton && !isOnInsGreenGlass)
        {
            //开启协程
            StartCoroutine(OnInsGreenGlass());
            isOnInsGreenGlass = true;
        }
        else if (!isredbutton)
        {
            //停止协程
            StopCoroutine(OnInsGreenGlass());
            isOnInsGreenGlass = false;
        }
        //此步仅仅是回传到主管理器
        riceplanterl.GetComponent<riceplanterManager>().isRedButton = isredbutton;
    }

    //isredbutton脚本回传的值
    public void GetIsRedButton(bool local_isredbutto)
    {
        // 改变此脚本中的isredbutton
        isredbutton = local_isredbutto;
    }


    IEnumerator OnInsGreenGlass()
    {
        //无限循环
        while (true)
        {
            //生成绿色的草
            GameObject greenglass = Instantiate(GreenGlass, this.transform);
            greenglass.transform.parent = glassManger.transform;
            yield return new WaitForSeconds(5);
        }
    }

    //此方法为移动header上下（当按下蓝色按键时触发）
    public void moveHeader(float val)
    {
        for (int i = 0; i < 10; i++)
        {
            Header.transform.Translate(0, val * Time.deltaTime, 0);
        }
    }
}