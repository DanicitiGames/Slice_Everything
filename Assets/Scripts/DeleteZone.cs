using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteZone : MonoBehaviour
{
    public Transform target;
    private float offsetZ;

    void Start()
    {
        offsetZ = transform.position.z - target.position.z;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(0, 0, target.position.z + offsetZ);
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "FIXED" || collider.gameObject.tag == "Knife") return;
        Destroy(collider.gameObject);
    }
}
