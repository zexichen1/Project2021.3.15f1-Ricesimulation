/*
 * 插秧机总管理器
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riceplanterManager : MonoBehaviour
{
    [Header("当前车辆移动的速度")]public float moveSpeed;
    [Header("当前车辆转向的角度")]public float angle;
    [Header("当前是否在运行插秧")] public bool isRedButton;
}
