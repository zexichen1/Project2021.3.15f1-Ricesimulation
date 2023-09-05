using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class steeringReturn : MonoBehaviour
{
    public bool isReturn;

    private void Start()
    {
        isReturn = false;
    }

    private void Update()
    {
        if (transform.localRotation.y != 0 && !isReturn)
        {
            isReturn = true;
            StartCoroutine(ReturnSteering(transform.localRotation.y));
        }
    }

    IEnumerator ReturnSteering(float lR)
    {
        if (transform.localRotation.y < 0 && lR == transform.localRotation.y)
        {
            for (float i = 0; i <= lR; i = i + .005f)
            {
                Debug.LogError(1111);
                yield return new WaitForSeconds(1);
                var tfl = new Vector3(transform.localRotation.x, transform.localRotation.y + i,
                    transform.localRotation.z);
                transform.eulerAngles += tfl;
            }
        }
        else if (transform.localRotation.y > 0 && lR == transform.localRotation.y)
        {
            for (float i = 0; i >= lR; i = i - .005f)
            {
                Debug.LogError(1111);
                yield return new WaitForSeconds(1);
                var tfl = new Vector3(transform.localRotation.x, transform.localRotation.y + i,
                    transform.localRotation.z);
                transform.eulerAngles += tfl;
            }
        }

        isReturn = false;
    }
}