using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawn : MonoBehaviour
{

    public GameObject AttackObject, FransButtons, QuakeButtons, AttackButton;
    public string attackerName;


    public void Attack()
    {

        Creature self = this.gameObject.GetComponent<Creature>();
        attackerName = self.name;
        Debug.Log(attackerName + " attacked the enemy!");
        Instantiate(AttackObject, new Vector3(-0.5f, 0, 2), Quaternion.identity);

        FransButtons = GameObject.Find("FransMoves");
        QuakeButtons = GameObject.Find("QuakeMoves");
        AttackButton = GameObject.Find("AttackButton");
        FransButtons.SetActive(false);
        QuakeButtons.SetActive(false);
        AttackButton.SetActive(false);
        GameControllerScript.MoveListButton.SetActive(true);

    }

}
