using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AutoBindItem
{
    public string name;
    public string typename;
    public GameObject obj;
}

public class AutoBind : MonoBehaviour
{
    public List<AutoBindItem> itemList = new List<AutoBindItem>();
}
