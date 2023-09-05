using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isBlueButton : MonoBehaviour
{
    private GameObject riceplanter;
    private bool isbluebutton;

    private void Start()
    {
        riceplanter = this.transform.parent.parent.gameObject;
        isbluebutton = false;
    }

    public void clickButton()
    {
        if (isbluebutton)
        {
            riceplanter.GetComponent<riceplanterState>().moveHeader(5f);
            isbluebutton = false;
        }
        else
        {
            riceplanter.GetComponent<riceplanterState>().moveHeader(-5f);
            isbluebutton = true;
        }
    }
}