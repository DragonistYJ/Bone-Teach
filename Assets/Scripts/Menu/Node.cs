using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public string name = null;
    public string englishName = null;
    public Node firstNext = null;
    public Node secondNext = null;
    public bool hasThirdChild = false;
    public Node thirdNext = null;
    public Node pre = null;
    public bool hasChild = true;
}