using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashSpawn : MonoBehaviour
{

    public GameObject AttackObject;
    public string attackerName;

    public void SmashAttack()
    {

        Creature self = this.gameObject.GetComponent<Creature>();
        attackerName = self.name;
        Debug.Log(attackerName + " used Smash!");
        Instantiate(AttackObject, new Vector3(-0.5f, 0, 2), Quaternion.identity);

    }

}
