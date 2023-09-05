/*
 * RedButton是否为ON/OFF
 */
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class isRedButton : MonoBehaviour
{
    private GameObject riceplanter;
    private bool isredbutton;

    private void Start()
    {
        riceplanter = this.transform.parent.parent.gameObject;
        isredbutton = false;
    }

    public void clickButton()
    {
        if (isredbutton)
            isredbutton = false;
        else
            isredbutton = true;
        //回传
        riceplanter.GetComponent<riceplanterState>().GetIsRedButton(isredbutton);
    }
}