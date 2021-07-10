﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiphonSpawn : MonoBehaviour
{

    public GameObject AttackObject, MoveButtons;
    public string attackerName;

    public void SiphonAttack()
    {

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

        Creature self = this.gameObject.GetComponent<Creature>();
        attackerName = self.name;
        Debug.Log(attackerName + " used Siphon!");
        MoveButtons.SetActive(false);
        GameControllerScript.MoveListButton.SetActive(true);

    }

}
