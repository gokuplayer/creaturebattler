using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreature
{

    /*string CreatureName { get; set; }
    string CreatureType { get; set; }
    float CreatureHealth { get; set; }
    float CreaturePhysical { get; set; }
    float CreaturePhysDef { get; set; }
    float CreatureRanged { get; set; }
    float CreatureRanDef { get; set; }
    float CreatureSpeed { get; set; }
    float CreatureMovement { get; set; }*/

    string Name { get; set; }
    string Type { get; set; }
    float Health { get; set; }
    float Physical { get; set; }
    float PhysDef { get; set; }
    float Ranged { get; set; }
    float RanDef { get; set; }
    float Speed { get; set; }
    float Movement { get; set; }

}