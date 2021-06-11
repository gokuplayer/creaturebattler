using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Frans : MonoBehaviour, ICreature
{

    public string Name = "Frans";
    public string Type { get; set; }
    public float Physical { get; set; }
    public float PhysDef { get; set; }
    public float Ranged { get; set; }
    public float RanDef { get; set; }
    public float Speed { get; set; }
    public float Movement { get; set; }

}
