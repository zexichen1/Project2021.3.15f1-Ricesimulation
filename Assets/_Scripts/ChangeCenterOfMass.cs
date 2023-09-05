using UnityEngine;

public class ChangeCenterOfMass : MonoBehaviour
{
    public Transform center;
    private Rigidbody r;
    
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        r.centerOfMass = center.localPosition;
    }
}