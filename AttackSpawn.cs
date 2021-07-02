using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawn : MonoBehaviour
{

    public GameObject AttackObject;
    public string attackerName;


    public void Attack()
    {

        Creature self = this.gameObject.GetComponent<Creature>();
        attackerName = self.name;
        Debug.Log(attackerName + " attacked the enemy!");
        Instantiate(AttackObject, new Vector3(-0.5f, 0, 2), Quaternion.identity);

    }

}
