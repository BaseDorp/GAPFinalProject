using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGrabbable
{
    public bool isGrabbed { get; set; }
    public Vector3 GrabPositionOffset { get; set; }
    SphereCollider IGrabbable.collider { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckIfGrabbed()
    {

    }
}
