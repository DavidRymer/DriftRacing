using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPhysics : MonoBehaviour
{
    void Start()
    {
        foreach (var building in transform.GetComponentsInChildren<Transform>())
        {
            building.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            building.gameObject.AddComponent<BoxCollider>();
        }
    }


}
