using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frans : MonoBehaviour, ICreature
{
    /*public string Name = "Frans";
    public string Type = "Dark";
    public float Health = 115f;
    public float Physical = 75f;
    public float PhysDef = 40f;
    public float Ranged = 25f;
    public float RanDef = 30f;
    public float Speed = 30f;
    public float Movement = 6f;

    string ICreature.CreatureName
    {
        get { return Name; }
        set { Name = value; }
    }

    string ICreature.CreatureType
    {
        get { return Type; }
        set { Type = value; }
    }

    float ICreature.CreatureHealth
    {
        get { return Health; }
        set { Health = value; }
    }

    float ICreature.CreaturePhysical
    {
        get { return Physical; }
        set { Physical = value; }
    }

    float ICreature.CreaturePhysDef
    {
        get { return PhysDef; }
        set { PhysDef = value; }
    }

    float ICreature.CreatureRanged
    {
        get { return Ranged; }
        set { Ranged = value; }
    }

    float ICreature.CreatureRanDef
    {
        get { return RanDef; }
        set { RanDef = value; }
    }

    float ICreature.CreatureSpeed
    {
        get { return Speed; }
        set { Speed = value; }
    }

    float ICreature.CreatureMovement
    {
        get { return Movement; }
        set { Movement = value; }
    }*/

    public void Attack()
    {

        Debug.Log("Frans attacked the enemy!");

    }

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
