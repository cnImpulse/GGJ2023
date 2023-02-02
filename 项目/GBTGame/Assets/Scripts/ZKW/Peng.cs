using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peng : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("DD");
        }
    }
}
