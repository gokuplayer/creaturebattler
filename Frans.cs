using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Frans : MonoBehaviour, ICreature
{
    public string Name = "Frans";
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
    }

}
