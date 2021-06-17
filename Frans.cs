using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frans : MonoBehaviour, ICreature
{
    public string Name;
    public string Type;
    public float Health;
    public float Physical;
    public float PhysDef;
    public float Ranged;
    public float RanDef;
    public float Speed;
    public float Movement;

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
    }

}
