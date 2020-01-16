using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName { set; get; }
    public int ves { get; set; }
    public string description { set; get; }
    public int count { set; get; }
}
