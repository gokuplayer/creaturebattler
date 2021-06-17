using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frans : MonoBehaviour, ICreature
{

    string ICreature.CreatureName
    {
        get { return Name; }
        set { Name = value; }
    }

}
