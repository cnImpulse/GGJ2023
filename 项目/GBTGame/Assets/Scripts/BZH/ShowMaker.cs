using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning(TOOLS.GetPlayerHpState(0.0f));
        Debug.LogWarning(TOOLS.GetPlayerHpState(20.0f));
        Debug.LogWarning(TOOLS.GetPlayerHpState(120.0f));
        Debug.LogWarning(TOOLS.GetPlayerHpState(400.0f));
        Debug.LogWarning(TOOLS.GetPlayerHpState(568.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
