using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreature
{

    string Name { get; set; }
    string Type1 { get; set; }
    string Type2 { get; set; }
    float Health { get; set; }
    float Physical { get; set; }
    float PhysDef { get; set; }
    float Ranged { get; set; }
    float RanDef { get; set; }
    float Speed { get; set; }
    float Movement { get; set; }

}