using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    // Start is called before the first frame update
    Tower[] towers;
    void Start()
    {
        towers = GetComponentsInChildren<Tower>();

    }

    
}
