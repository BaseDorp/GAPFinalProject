using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    bool fireActiveRight = false;
    bool fireActiveLeft = false;
    int numFirballs = 0;

    int maxFireballs = 1;

    int i = 0;

    [SerializeField]
    ParticleSystem FireRight;
    [SerializeField]
    ParticleSystem FireLeft;
    [SerializeField]
    GameObject FireBall;
    [SerializeField]
    Transform LeftHandLoc;
    [SerializeField]
    Transform RightHandLoc;

    // Start is called before the first frame update
    void Start()
    {
        FireRight.Stop();
        FireLeft.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Fire Right Hand
        if (OVRInput.GetDown(OVRInput.Button.Two) && fireActiveRight == false)
        {
            FireRight.Play();
            fireActiveRight = true;
        }
        if (OVRInput.GetDown(OVRInput.Button.One) && fireActiveRight == true)
        {
            FireRight.Stop();
            fireActiveRight = false;
        }

        // Fire Left Hand
        if (OVRInput.GetDown(OVRInput.Button.Four) && fireActiveLeft == false)
        {
            FireLeft.Play();
            fireActiveLeft = true;
        }
        if (OVRInput.GetDown(OVRInput.Button.Three) && fireActiveLeft == true)
        {
            FireLeft.Stop();
            fireActiveLeft = false;
        }

        Debug.Log(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch));

        // Spawn fireball Right hand       
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) >= .5f)
        {
            if (Time.time > i)
            {
                i += 1;
                Instantiate(FireBall, RightHandLoc.position, new Quaternion(0,0,0,0));
            }
        }
        //Spawn fireball Left hand
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) >= .5f)
        {
            if (Time.time > i)
            {
                i += 1;
                Instantiate(FireBall, LeftHandLoc.position, new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
