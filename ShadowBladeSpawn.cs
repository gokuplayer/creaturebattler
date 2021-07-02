using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBladeSpawn : MonoBehaviour
{

    public GameObject AttackObject;
    public string attackerName;

    public void ShadowBladeAttack()
    {

        Creature self = this.gameObject.GetComponent<Creature>();
        attackerName = self.name;
        Debug.Log(attackerName + " used Shadow Blade!");
        Instantiate(AttackObject, new Vector3(-0.5f, 0, 2), Quaternion.identity);

    }

}
