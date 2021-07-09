using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashSpawn : MonoBehaviour
{

    public GameObject AttackObject, MoveButtons;
    public string attackerName;

    public void SmashAttack()
    {

        if (GameControllerScript.playerTurn == 1)
        {

            Instantiate(AttackObject, new Vector3(-0.5f, 0, 2), Quaternion.identity);
            GameControllerScript.playerTurn = 2;

        }
        else if (GameControllerScript.playerTurn == 2)
        {

            Instantiate(AttackObject, new Vector3(0.5f, 0, 2), Quaternion.identity);
            GameControllerScript.playerTurn = 1;

        }

        Creature self = this.gameObject.GetComponent<Creature>();
        attackerName = self.name;
        Debug.Log(attackerName + " used Smash!");
        MoveButtons = GameObject.Find("QuakeMoves");
        MoveButtons.SetActive(false);
        GameControllerScript.MoveListButton.SetActive(true);

    }

}
