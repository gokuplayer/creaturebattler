using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Creature : MonoBehaviour, ICreature
{

    [SerializeField]
    public string c_name;
    [SerializeField]
    public string type1;
    [SerializeField]
    public string type2;
    [SerializeField]
    public float health;
    [SerializeField]
    public float physical;
    [SerializeField]
    public float physDef;
    [SerializeField]
    public float ranged;
    [SerializeField]
    public float ranDef;
    [SerializeField]
    public float speed;
    [SerializeField]
    public float movement;

    public Creature(string name, string type1, string type2, float health, float physical, float physDef, float ranged, float ranDef, float speed, float movement)
    {
        this.Name = name;
        this.Type1 = type1;
        this.Type2 = type2;
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

    public string Type1
    {
        get { return type1; }
        set { type1 = value; }
    }

    public string Type2
    {
        get { return type2; }
        set { type2 = value; }
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
