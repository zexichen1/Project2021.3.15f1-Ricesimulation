using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestersState : MonoBehaviour
{
    [Header("收割部件动画")]
    public Animator reapanimation;
    [Header("收割粒子")]
    public ParticleSystem dust;

    private void Start()
    {
        PlayDust(false);
        ReapAnimation(true);
    }

    // 粒子效果播放控制
    private void PlayDust(bool IsPlay)
    {
        if (IsPlay)
            dust.Play();
        else
            dust.Stop();
    }

    //收割部件动画
    private void ReapAnimation(bool isReapAnimation)
    {
        reapanimation.SetBool("IsPlayReap",isReapAnimation);
        
    }

    //判断碰撞的是否为黄色的小麦
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "barley_floor(Clone)")
        {
            StartCoroutine(destroyBarley_floor(other));
        }
    }

    //使用一个协程播放粒子效果并将黄色小麦销毁，等待1s后停止播放粒子效果
    IEnumerator destroyBarley_floor(Collider other)
    {
        PlayDust(true);
        Destroy(other.gameObject,0);
        yield return new WaitForSeconds(1);
        PlayDust(false);
    }
}