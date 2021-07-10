using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiphonSpawn : MonoBehaviour
{

    public GameObject AttackObject, MoveButtons, AttackerObject;
    public string attackerName;

    public void SiphonAttack()
    {

        AttackObject = this.gameObject;
        AttackerObject = GameObject.Find("Player 1");

        if (GameControllerScript.playerTurn == 1)
        {

            Instantiate(AttackObject, new Vector3(-0.5f, 0, 2), Quaternion.identity);
            MoveButtons = GameObject.Find("Player1Moves");
            GameControllerScript.playerTurn = 2;

        }
        else if (GameControllerScript.playerTurn == 2)
        {

            Instantiate(AttackObject, new Vector3(0.5f, 0, 2), Quaternion.identity);
            MoveButtons = GameObject.Find("Player2Moves");
            GameControllerScript.playerTurn = 1;

        }

        Creature self = AttackerObject.gameObject.GetComponent<Creature>();
        attackerName = self.c_name;
        Debug.Log(attackerName + " used Siphon!");
        MoveButtons.SetActive(false);
        GameControllerScript.MoveListButton.SetActive(true);

    }

}
