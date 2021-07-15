using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    enum Controller { LeftControler, RightController};

    SphereCollider GrabSphere;
    GameObject collidedObject;
    
    Vector3 HoldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks for input updates
        OVRInput.Update();

        if (collidedObject != null)
        {
            collidedObject.transform.position = HoldPosition;

            //if button released
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) <= .1 && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) <= .1 && !collidedObject.HoldToGrab)
            {
                collidedObject = null;
            }
            else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= .9 && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= .9)
            {
                collidedObject = null;
            }
        }

        
    }


    void OnCollisionEnter (Collider collider)
    {
        if (collider as IGrabbable != null && collidedObject == null)
        {
            // Light up material effect

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= .9 && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= .9)
            {
                collidedObject = collider.gameObject;
            }
        }

        
    }

    void Grab()
    {

    }
}
