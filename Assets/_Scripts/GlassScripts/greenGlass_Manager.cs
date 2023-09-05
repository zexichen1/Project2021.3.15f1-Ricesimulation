/*
 *   greenGlass_Manager主要负责GreenGlass的生成
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenGlass_Manager : MonoBehaviour
{
    //GreenGlass
    public GameObject greenGlass_inclination;

    void Start()
    {
    }

    void Update()
    {
        insGreenGlass();
    }

    private void insGreenGlass()
    {
        //开始游戏先创建一次GreenGlass
        if (GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            GameObject ins_greenGlass_inclination =
                Instantiate(greenGlass_inclination, transform);
        }

    }
}