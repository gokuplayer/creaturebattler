using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainingStrikeSpawn : MonoBehaviour
{

    public GameObject AttackObject;
    public string attackerName;

    public void DrainingStrikeAttack()
    {

        Creature self = this.gameObject.GetComponent<Creature>();
        attackerName = self.name;
        Debug.Log(attackerName + " used Draining Strike!");
        Instantiate(AttackObject, new Vector3(-0.5f, 0, 2), Quaternion.identity);

    }

}
