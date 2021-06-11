using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreature
{

    string CreatureName { get; }
    string CreatureType { get; }
    float CreatureHealth { get; }
    float CreaturePhysical { get; }
    float CreaturePhysDef { get; }
    float CreatureRanged { get; }
    float CreatureRanDef { get; }
    float CreatureSpeed { get; }
    float CreatureMovement { get; }

}