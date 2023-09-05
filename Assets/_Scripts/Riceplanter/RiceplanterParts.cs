using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceplanterParts : MonoBehaviour
{
    /// <summary>
    /// 碰撞事件当碰撞后判定是不是greenGlass_inclination
    /// </summary>
    /// <param name="Collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "greenGlass_inclination" ||
            collider.gameObject.name == "greenGlass_inclination(Clone)")
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(collider.gameObject);
        }
    }
}