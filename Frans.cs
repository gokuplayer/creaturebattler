using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Frans : MonoBehaviour, ICreature
{
    private string name = "Frans";
    private string type = "Dark";
    private float health = 115f;
    private float physical = 75f;
    private float physDef = 40f;
    private float ranged = 25f;
    private float ranDef = 30f;
    private float speed = 30f;
    private float movement = 6f;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float Physical
    {
        get { return physical; }
        set { physical = value; }
    }

    public float PhysDef
    {
        get { return physDef; }
        set { physDef = value; }
    }

    public float Ranged
    {
        get { return ranged; }
        set { ranged = value; }
    }

    public float RanDef
    {
        get { return ranDef; }
        set { ranDef = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float Movement
    {
        get { return movement; }
        set { movement = value; }
    }

}
