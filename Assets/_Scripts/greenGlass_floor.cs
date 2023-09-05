using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenGlass_floor : MonoBehaviour
{
    private Vector3 rPos = new Vector3(0, 1.71f, 0);
    private void Start()
    {
    }
    
    
    public GameObject barley_floor;
    private bool isDestroyThisGlass = true;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(collisionGlass(collision));
        destroyThisGlass(collision);
    }

    IEnumerator collisionGlass(Collision collision)
    {
        yield return new WaitForSeconds(1);
        isDestroyThisGlass = false;
    }

    void destroyThisGlass(Collision collision)
    {
        if (isDestroyThisGlass)
        {
            if (collision.gameObject.name != "PitchTerrain" || collision.gameObject.name == this.gameObject.name)
            {
                isDestroyThisGlass = false;
                Destroy(gameObject, 0);
            }
        }
    }

    public void replace()
    {
        GameObject barley_floor_clone = Instantiate(barley_floor, transform);
        barley_floor_clone.transform.position += rPos;
        barley_floor_clone.transform.parent = this.transform.parent;
        Destroy(gameObject, 1);
    }
}