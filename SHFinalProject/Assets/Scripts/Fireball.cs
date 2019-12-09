using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Rigidbody Fireballrb;

    // Start is called before the first frame update
    void Start()
    {
        Fireballrb = GetComponent<Rigidbody>();
        Fireballrb.AddForce(transform.forward * 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -5)
        {
            Destroy(this.gameObject);
        }
    }
}
