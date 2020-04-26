using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object
{
    public enum ObjectType
    {
        giver,
        getter,
        other
    }

    public Vector2 pos = Vector2.zero;
    public string ObjectName = "";
    public ObjectType objectType = ObjectType.other;
    public int connectID = -1;


    public Object(Vector2 v2, string name)
    {
        pos = v2;
        ObjectName = name;
    }

    public Object(Vector2 v2, string name, int type, int id)
    {
        pos = v2;
        ObjectName = name;
        objectType = (ObjectType)type;
        connectID = id;
    }
}
