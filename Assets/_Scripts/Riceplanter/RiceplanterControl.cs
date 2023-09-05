using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceplanterControl : MonoBehaviour
{
    private float angle;
    public float angleSpeed;
    public float moveSpeed;

    private GameObject riceplanter;
    [Header("方向盘")] public GameObject steeringWheel;
    [Header("挡杆")] public GameObject gearLever;
    
    //注意这八个变量，四个是获取车轮碰撞器的，四个是获取车轮模型的
    public WheelCollider leftF;
    public WheelCollider leftB;
    public WheelCollider rightF;
    public WheelCollider rightB;

    public Transform model_leftF;
    public Transform model_leftB;
    public Transform model_rightF;
    public Transform model_rightB;

    void Update()
    {
        riceplanter = this.gameObject;
        WheelsControl_Update();
    }
    
    //控制移动 转向
    void WheelsControl_Update()
    {
        //垂直轴和水平轴
        // float h = Input.GetAxisRaw("Horizontal");
        // float v = Input.GetAxisRaw("Vertical");
        float h = steeringWheel.transform.localRotation.y;
        float v = gearLever.transform.localRotation.x;

        //前轮角度，后轮驱动
        //steerAngle:转向角度，总是围绕自身Y轴，转向
        //motorTorque:转矩，驱动车轮
        angle = angleSpeed * h;
        leftF.steerAngle = angle;
        rightF.steerAngle = angle;
        
        leftB.motorTorque = v * -moveSpeed;
        rightB.motorTorque = v * -moveSpeed;

        //return到Manage
        riceplanter.GetComponent<riceplanterManager>().moveSpeed = v * moveSpeed;
        riceplanter.GetComponent<riceplanterManager>().angle = angle;
        
        //当车轮碰撞器位置角度改变，随之也变更车轮模型的位置角度
        WheelsModel_Update(model_leftF, leftF);
        WheelsModel_Update(model_leftB, leftB);
        WheelsModel_Update(model_rightF, rightF);
        WheelsModel_Update(model_rightB, rightB);
    }

    //控制车轮模型移动 转向
    void WheelsModel_Update(Transform t, WheelCollider wheel)
    {
        Vector3 pos = t.position;
        Quaternion rot = t.rotation;

        wheel.GetWorldPose(out pos, out rot);

        t.position = pos;
        t.rotation = rot;
    }
    
}