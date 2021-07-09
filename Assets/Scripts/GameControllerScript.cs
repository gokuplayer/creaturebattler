using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public GameObject PlayButton, CreatureAttackerButton, Player1, Player2, Move1Object, Move5Object;

    public GameObject[] Creatures, MoveArray;

    public static GameObject MoveListButton, Player1MovesObject, Player2MovesObject,FransMovesButton, QuakeMovesButton, ReplayButton, FightButton, 
        ChooseMovesButton, ChooseMovesNextButton, Move1ChoiceDropdown, PlayerTextObject, PlayerChoiceTextObject, WinnerTextObject, 
        Player1HealthTextObject, Player2HealthTextObject;
    public static Text PlayerText, PlayerCreatureChoiceText, WinnerText, Player1HealthText, Player2HealthText;
    public static int playerTurn;
    public static float player1maxHealth, player2maxHealth;

    private int player1CreatureChoice, player2CreatureChoice, move1, move5;

    void Start()
    {

        Move1Object = GameObject.Find("Move1");
        Move5Object = GameObject.Find("Move5");
        MoveListButton = GameObject.Find("MoveListButton");
        Player1MovesObject = GameObject.Find("Player1Moves");
        Player2MovesObject = GameObject.Find("Player2Moves");
        FransMovesButton = GameObject.Find("FransMoves");
        QuakeMovesButton = GameObject.Find("QuakeMoves");
        ReplayButton = GameObject.Find("ReplayButton");
        CreatureAttackerButton = GameObject.Find("Creature List");
        FightButton = GameObject.Find("FightButton");
        ChooseMovesButton = GameObject.Find("ChooseMovesButton");
        ChooseMovesNextButton = GameObject.Find("ChooseMovesNextButton");
        PlayerTextObject = GameObject.Find("PlayerText");
        PlayerChoiceTextObject = GameObject.Find("PlayerCreatureChoiceText");
        Move1ChoiceDropdown = GameObject.Find("Move1ChoiceDropdown");
        WinnerTextObject = GameObject.Find("WinnerText");
        Player1HealthTextObject = GameObject.Find("Player1Health");
        Player2HealthTextObject = GameObject.Find("Player2Health");
        PlayerText = PlayerTextObject.GetComponent<Text>();
        PlayerCreatureChoiceText = PlayerChoiceTextObject.GetComponent<Text>();
        WinnerText = WinnerTextObject.GetComponent<Text>();
        Player1HealthText = Player1HealthTextObject.GetComponent<Text>();
        Player2HealthText = Player2HealthTextObject.GetComponent<Text>();

        PlayButton.SetActive(true);
        Player1MovesObject.SetActive(false);
        Player2MovesObject.SetActive(false);
        FransMovesButton.SetActive(false);
        QuakeMovesButton.SetActive(false);
        MoveListButton.SetActive(false);
        ReplayButton.SetActive(false);
        CreatureAttackerButton.SetActive(false);
        FightButton.SetActive(false);
        ChooseMovesButton.SetActive(false);
        ChooseMovesNextButton.SetActive(false);
        Move1ChoiceDropdown.SetActive(false);

        PlayerText.text = "";
        PlayerCreatureChoiceText.text = "";
        WinnerText.text = "";
        Player1HealthText.text = "";
        Player2HealthText.text = "";

    }

    void Update()
    {

        Creature player1Creature = Player1.GetComponent<Creature>();
        Creature player2Creature = Player2.GetComponent<Creature>();

        if (player1Creature.health > 0)
        {

            Player1HealthText.text = "HP: " + player1Creature.health;

        }
        else
        {

            Player1HealthText.text = "HP: 0";

        }

        if (player2Creature.health > 0)
        {

            Player2HealthText.text = "HP: " + player2Creature.health;

        }
        else
        {

            Player2HealthText.text = "HP: 0";

        }

        if (playerTurn > 0)
        {

            PlayerText.text = "Player " + playerTurn + "'s turn.";

        }
        else
        {

            PlayerText.text = "";

        }

    }

    public void Play()
    {

        PlayButton.SetActive(false);
        CreatureAttackerButton.SetActive(true);

        PlayerCreatureChoiceText.text = "Player 1, choose your creature.";

        playerTurn = 1;

    }

    public void CreatureChoice(int creature)
    {

        if (playerTurn == 1)
        {

            player1CreatureChoice = creature;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            playerTurn = 2;

        }
        else if (playerTurn == 2)
        {

            player2CreatureChoice = creature;
            playerTurn = 1;
            CreatureAttackerButton.SetActive(false);
            ChooseMovesButton.SetActive(true);
            PlayerCreatureChoiceText.text = "";

        }

    }

    public void MoveDropdownChoice(int choice)
    {

        ChooseMovesNextButton.SetActive(true);

        if (playerTurn == 1)
        {

            playerTurn = 2;

            switch (choice)
            {

                case 1:
                    move1 = 1;
                    break;
                case 6:
                    move1 = 2;
                    break;
                case 7:
                    move1 = 0;
                    break;
                default:
                    Debug.Log("Move choice error");
                    break;

            }

        }
        else if (playerTurn == 2)
        {

            playerTurn = 1;

            switch (choice)
            {

                case 1:
                    move5 = 1;
                    break;
                default:
                    Debug.Log("Move choice error");
                    break;

            }

        }

    }

    public void MoveChoice()
    {

        if (playerTurn == 1)
        {

            ChooseMovesButton.SetActive(false);
            PlayerCreatureChoiceText.text = "Player 1, choose your moves";
            Move1ChoiceDropdown.SetActive(true);

            switch (player1CreatureChoice)
            {
                

                default:
                    Debug.Log("Creature choice error.");
                    break;

            }

        }
        else if (playerTurn == 2)
        {

            ChooseMovesNextButton.SetActive(false);
            FightButton.SetActive(true);
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "Player 2, choose your moves";

            switch (player2CreatureChoice)
            {

                default:
                    Debug.Log("Creature choice error.");
                    break;

            }

        }

    }

    public void FightStart()
    {

        FightButton.SetActive(false);
        Move1ChoiceDropdown.SetActive(false);
        PlayerCreatureChoiceText.text = "";
        MoveListButton.SetActive(true);
        GameObject clone1 = Instantiate(Creatures[player1CreatureChoice], new Vector3(-1, 0, 2), Quaternion.identity);
        clone1.transform.tag = "Player1";
        Player1 = GameObject.FindWithTag("Player1");
        Creature player1Creature = Player1.GetComponent<Creature>();
        player1maxHealth = player1Creature.health;
        clone1.name = player1Creature.name + " 1";
        GameObject clone2 = Instantiate(Creatures[player2CreatureChoice], new Vector3(1, 0, 2), Quaternion.identity);
        clone2.transform.tag = "Player2";
        Player2 = GameObject.FindWithTag("Player2");
        Creature player2Creature = Player2.GetComponent<Creature>();
        player2maxHealth = player2Creature.health;
        clone2.name = player2Creature.name + " 2";
        GameObject moveClone1 = Instantiate(MoveArray[move1], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone1.transform.SetParent(Move1Object.transform, false);
        GameObject moveClone5 = Instantiate(MoveArray[move5], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone5.transform.SetParent(Move5Object.transform, false);

    }

    public void Moves()
    {

        MoveListButton.SetActive(false);

        if (playerTurn == 1)
        {

            Player1MovesObject.SetActive(true);

        }
        else if (playerTurn == 2)
        {

            Player2MovesObject.SetActive(true);

            /*switch (player2CreatureChoice)
            {

                case 10:
                    FransMovesButton.SetActive(true);
                    break;
                case 21:
                    QuakeMovesButton.SetActive(true);
                    break;
                default:
                    Debug.Log("Attacker not chosen. Error.");
                    break;

            }*/

        }

    }

    public void Replay()
    {

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

}
