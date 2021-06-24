using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private string name;
    private string type;
    private float health;
    private float physical;
    private float physDef;
    private float ranged;
    private float ranDef;
    private float speed;
    private float movement;

    public Creature(string name, string type, float health, float physical, float physDef, float ranged, float ranDef, float speed, float movement)
    {
        this.Name = name;
        this.Type = type;
        this.Health = health;
        this.Physical = physical;
        this.PhysDef = physDef;
        this.Ranged = ranged;
        this.RanDef = ranDef;
        this.Speed = speed;
        this.Movement = movement;
    }

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
