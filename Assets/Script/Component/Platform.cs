using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform
{
    public Vector2 pos = Vector2.zero;
    public string PlatformName = "";

    public Platform(Vector3 v2, string name)
    {
        pos = v2;
        PlatformName = name;
    }
}
