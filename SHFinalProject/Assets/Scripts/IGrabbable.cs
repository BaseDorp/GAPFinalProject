using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    bool isGrabbed { get; set; }

    // If true, player will have to hold the button down to hold onto the object instead of a toggle
    [SerializeField]
    bool HoldToGrab { get; set; }

    Vector3 GrabPositionOffset { get; set; }

    SphereCollider collider { get; set; }

    void CheckIfGrabbed();
}
