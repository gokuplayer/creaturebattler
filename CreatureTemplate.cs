using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreature
{

<<<<<<< HEAD
    string CreatureName { get; set; }
    string CreatureType { get; set; }
    float CreatureHealth { get; set; }
    float CreaturePhysical { get; set; }
    float CreaturePhysDef { get; set; }
    float CreatureRanged { get; set; }
    float CreatureRanDef { get; set; }
    float CreatureSpeed { get; set; }
    float CreatureMovement { get; set; }
=======
    string CreatureName { get; }
    string CreatureType { get; }
    float CreatureHealth { get; }
    float CreaturePhysical { get; }
    float CreaturePhysDef { get; }
    float CreatureRanged { get; }
    float CreatureRanDef { get; }
    float CreatureSpeed { get; }
    float CreatureMovement { get; }
>>>>>>> main

}