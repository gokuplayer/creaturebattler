using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public GameObject PlayButton, CreatureAttackerButton, Player1, Player2, Move1Object, Move2Object, Move3Object, Move4Object, Move5Object, 
        Move6Object, Move7Object, Move8Object;

    public GameObject[] Creatures, MoveArray;

    public List<string> FransMoves, QuakeMoves;

    public static GameObject MoveListButton, Player1MovesObject, Player2MovesObject, ReplayButton, FightButton, 
        ChooseMovesButton, ChooseMovesNextButton, Move1ChoiceDropdown, Move2ChoiceDropdown, Move3ChoiceDropdown, 
        Move4ChoiceDropdown, PlayerTextObject, PlayerChoiceTextObject, WinnerTextObject, Player1HealthTextObject, 
        Player2HealthTextObject;
    public static Text PlayerText, PlayerCreatureChoiceText, WinnerText, Player1HealthText, Player2HealthText;
    public static Dropdown Move1DD, Move2DD, Move3DD, Move4DD;
    public static int playerTurn;
    public static float player1maxHealth, player2maxHealth;

    private int player1CreatureChoice, player2CreatureChoice, move1, move2, move3, move4, move5, move6, move7, move8;

    void Start()
    {

        Move1Object = GameObject.Find("Move1");
        Move2Object = GameObject.Find("Move2");
        Move3Object = GameObject.Find("Move3");
        Move4Object = GameObject.Find("Move4");
        Move5Object = GameObject.Find("Move5");
        Move6Object = GameObject.Find("Move6");
        Move7Object = GameObject.Find("Move7");
        Move8Object = GameObject.Find("Move8");
        MoveListButton = GameObject.Find("MoveListButton");
        Player1MovesObject = GameObject.Find("Player1Moves");
        Player2MovesObject = GameObject.Find("Player2Moves");
        ReplayButton = GameObject.Find("ReplayButton");
        CreatureAttackerButton = GameObject.Find("Creature List");
        FightButton = GameObject.Find("FightButton");
        ChooseMovesButton = GameObject.Find("ChooseMovesButton");
        ChooseMovesNextButton = GameObject.Find("ChooseMovesNextButton");
        PlayerTextObject = GameObject.Find("PlayerText");
        PlayerChoiceTextObject = GameObject.Find("PlayerCreatureChoiceText");
        Move1ChoiceDropdown = GameObject.Find("Move1ChoiceDropdown");
        Move2ChoiceDropdown = GameObject.Find("Move2ChoiceDropdown");
        Move3ChoiceDropdown = GameObject.Find("Move3ChoiceDropdown");
        Move4ChoiceDropdown = GameObject.Find("Move4ChoiceDropdown");
        WinnerTextObject = GameObject.Find("WinnerText");
        Player1HealthTextObject = GameObject.Find("Player1Health");
        Player2HealthTextObject = GameObject.Find("Player2Health");
        PlayerText = PlayerTextObject.GetComponent<Text>();
        PlayerCreatureChoiceText = PlayerChoiceTextObject.GetComponent<Text>();
        WinnerText = WinnerTextObject.GetComponent<Text>();
        Player1HealthText = Player1HealthTextObject.GetComponent<Text>();
        Player2HealthText = Player2HealthTextObject.GetComponent<Text>();
        Move1DD = Move1ChoiceDropdown.GetComponent<Dropdown>();
        Move2DD = Move2ChoiceDropdown.GetComponent<Dropdown>();
        Move3DD = Move3ChoiceDropdown.GetComponent<Dropdown>();
        Move4DD = Move4ChoiceDropdown.GetComponent<Dropdown>();

        PlayButton.SetActive(true);
        Player1MovesObject.SetActive(false);
        Player2MovesObject.SetActive(false);
        MoveListButton.SetActive(false);
        ReplayButton.SetActive(false);
        CreatureAttackerButton.SetActive(false);
        FightButton.SetActive(false);
        ChooseMovesButton.SetActive(false);
        ChooseMovesNextButton.SetActive(false);
        Move1ChoiceDropdown.SetActive(false);
        Move2ChoiceDropdown.SetActive(false);
        Move3ChoiceDropdown.SetActive(false);
        Move4ChoiceDropdown.SetActive(false);

        PlayerText.text = "";
        PlayerCreatureChoiceText.text = "";
        WinnerText.text = "";
        Player1HealthText.text = "";
        Player2HealthText.text = "";

        Move1DD.options.Clear();
        Move2DD.options.Clear();
        Move3DD.options.Clear();
        Move4DD.options.Clear();

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
            CreatureAttackerButton.SetActive(false);
            ChooseMovesButton.SetActive(true);
            PlayerCreatureChoiceText.text = "";
            playerTurn = 1;

        }

    }

    public void Move1DropdownChoice(int choice)
    {

        if (playerTurn == 2)
        {

            ChooseMovesNextButton.SetActive(true);
            Debug.Log(choice);

            switch (choice)
            {

                case 0:
                    move1 = 0;
                    break;
                case 1:
                    move1 = 1;
                    break;
                case 2:
                    move1 = 2;
                    break;
                case 3:
                    move1 = 3;
                    break;
                case 4:
                    move1 = 4;
                    break;
                case 5:
                    move1 = 5;
                    break;
                default:
                    Debug.Log("Move choice error");
                    break;

            }

        }
        else if (playerTurn == 1)
        {

            ChooseMovesNextButton.SetActive(false);

            switch (choice)
            {

                case 0:
                    move5 = 0;
                    break;
                case 1:
                    move5 = 1;
                    break;
                case 2:
                    move5 = 2;
                    break;
                case 3:
                    move5 = 3;
                    break;
                case 4:
                    move5 = 4;
                    break;
                case 5:
                    move5 = 5;
                    break;
                default:
                    Debug.Log("Move choice error");
                    break;

            }

        }

    }

    public void Move2DropdownChoice(int choice)
    {

        if (playerTurn == 2)
        {

            ChooseMovesNextButton.SetActive(true);
            Debug.Log(choice);

            switch (choice)
            {

                case 0:
                    move2 = 0;
                    break;
                case 1:
                    move2 = 1;
                    break;
                case 2:
                    move2 = 2;
                    break;
                case 3:
                    move2 = 3;
                    break;
                case 4:
                    move2 = 4;
                    break;
                case 5:
                    move2 = 5;
                    break;
                default:
                    Debug.Log("Move choice error");
                    break;

            }

        }
        else if (playerTurn == 1)
        {

            ChooseMovesNextButton.SetActive(false);

            switch (choice)
            {

                case 0:
                    move6 = 0;
                    break;
                case 1:
                    move6 = 1;
                    break;
                case 2:
                    move6 = 2;
                    break;
                case 3:
                    move6 = 3;
                    break;
                case 4:
                    move6 = 4;
                    break;
                case 5:
                    move6 = 5;
                    break;
                default:
                    Debug.Log("Move choice error");
                    break;

            }

        }

    }

    public void Move3DropdownChoice(int choice)
    {

        if (playerTurn == 2)
        {

            ChooseMovesNextButton.SetActive(true);
            Debug.Log(choice);

            switch (choice)
            {

                case 0:
                    move3 = 0;
                    break;
                case 1:
                    move3 = 1;
                    break;
                case 2:
                    move3 = 2;
                    break;
                case 3:
                    move3 = 3;
                    break;
                case 4:
                    move3 = 4;
                    break;
                case 5:
                    move3 = 5;
                    break;
                default:
                    Debug.Log("Move choice error");
                    break;

            }

        }
        else if (playerTurn == 1)
        {

            ChooseMovesNextButton.SetActive(false);

            switch (choice)
            {

                case 0:
                    move7 = 0;
                    break;
                case 1:
                    move7 = 1;
                    break;
                case 2:
                    move7 = 2;
                    break;
                case 3:
                    move7 = 3;
                    break;
                case 4:
                    move7 = 4;
                    break;
                case 5:
                    move7 = 5;
                    break;
                default:
                    Debug.Log("Move choice error");
                    break;

            }

        }

    }

    public void Move4DropdownChoice(int choice)
    {

        if (playerTurn == 2)
        {

            ChooseMovesNextButton.SetActive(true);
            Debug.Log(choice);

            switch (choice)
            {

                case 0:
                    move4 = 0;
                    break;
                case 1:
                    move4 = 1;
                    break;
                case 2:
                    move4 = 2;
                    break;
                case 3:
                    move4 = 3;
                    break;
                case 4:
                    move4 = 4;
                    break;
                case 5:
                    move4 = 5;
                    break;
                default:
                    Debug.Log("Move choice error");
                    break;

            }

        }
        else if (playerTurn == 1)
        {

            ChooseMovesNextButton.SetActive(false);

            switch (choice)
            {

                case 0:
                    move8 = 0;
                    break;
                case 1:
                    move8 = 1;
                    break;
                case 2:
                    move8 = 2;
                    break;
                case 3:
                    move8 = 3;
                    break;
                case 4:
                    move8 = 4;
                    break;
                case 5:
                    move8 = 5;
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
            Move2ChoiceDropdown.SetActive(true);
            Move3ChoiceDropdown.SetActive(true);
            Move4ChoiceDropdown.SetActive(true);
            playerTurn = 2;

            switch (player1CreatureChoice)
            {

                case 10:
                    foreach (string option in FransMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 21:
                    foreach (string option in QuakeMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                default:
                    Debug.Log("Creature choice error.");
                    break;

            }

        }
        else if (playerTurn == 2)
        {

            ChooseMovesNextButton.SetActive(false);
            FightButton.SetActive(true);
            PlayerCreatureChoiceText.text = "Player 2, choose your moves";
            playerTurn = 1;

            switch (player2CreatureChoice)
            {
                case 10:
                    break;
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
        Move2ChoiceDropdown.SetActive(false);
        Move3ChoiceDropdown.SetActive(false);
        Move4ChoiceDropdown.SetActive(false);
        PlayerCreatureChoiceText.text = "";
        MoveListButton.SetActive(true);
        GameObject clone1 = Instantiate(Creatures[player1CreatureChoice], new Vector3(-1, 0, 2), Quaternion.identity);
        clone1.transform.tag = "Player1";
        Player1 = GameObject.FindWithTag("Player1");
        Creature player1Creature = Player1.GetComponent<Creature>();
        player1maxHealth = player1Creature.health;
        clone1.name = "Player 1";
        GameObject clone2 = Instantiate(Creatures[player2CreatureChoice], new Vector3(1, 0, 2), Quaternion.identity);
        clone2.transform.tag = "Player2";
        Player2 = GameObject.FindWithTag("Player2");
        Creature player2Creature = Player2.GetComponent<Creature>();
        player2maxHealth = player2Creature.health;
        clone2.name = "Player 2";
        GameObject moveClone1 = Instantiate(MoveArray[move1], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone1.transform.SetParent(Move1Object.transform, false);
        GameObject moveClone2 = Instantiate(MoveArray[move2], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone2.transform.SetParent(Move2Object.transform, false);
        GameObject moveClone3 = Instantiate(MoveArray[move3], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone3.transform.SetParent(Move3Object.transform, false);
        GameObject moveClone4 = Instantiate(MoveArray[move4], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone4.transform.SetParent(Move4Object.transform, false);
        GameObject moveClone5 = Instantiate(MoveArray[move5], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone5.transform.SetParent(Move5Object.transform, false);
        GameObject moveClone6 = Instantiate(MoveArray[move6], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone6.transform.SetParent(Move6Object.transform, false);
        GameObject moveClone7 = Instantiate(MoveArray[move7], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone7.transform.SetParent(Move7Object.transform, false);
        GameObject moveClone8 = Instantiate(MoveArray[move8], new Vector3(0, 0, 0), Quaternion.identity);
        moveClone8.transform.SetParent(Move8Object.transform, false);

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
