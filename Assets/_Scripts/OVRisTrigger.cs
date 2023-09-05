using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OVRisTrigger : MonoBehaviour
{
    public GameObject InteractionRigOVR_Synthetic;

    private Vector3 harvestersCameraPos = new Vector3(6.48999977f, 1.77999997f, -4.57999992f);
    private Vector3 riceplanterCameraPos = new Vector3(0.129999995f, 1.70000005f, -1.60000002f);


    //当玩家碰撞车辆后将会改变玩家位置并且将玩家归为车辆的子物体
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "harvesters")
        {
            this.transform.parent = other.transform;
            this.transform.localPosition = harvestersCameraPos;
        }
        else if (other.gameObject.name == "riceplanter")
        {
            this.transform.parent = other.transform;
            this.transform.localPosition = riceplanterCameraPos;
        }
    }
    
    //当玩家离开碰撞车辆后将玩家放回至InteractionRigOVR_Synthetic物体下
    private void OnTriggerExit(Collider other)
    {
        if (this.transform.parent.name == "harvesters" && this.transform.position != harvestersCameraPos)
        {
            this.transform.parent = InteractionRigOVR_Synthetic.transform;
        }
        else if (this.transform.parent.name == "riceplanter" && this.transform.position != riceplanterCameraPos)
        {
            this.transform.parent = InteractionRigOVR_Synthetic.transform;
        }
    }
    
}