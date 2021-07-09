using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public GameObject PlayButton, CreatureAttackerButton, Player1, Player2;

    public GameObject[] Creatures;

    public static GameObject MoveListButton, FransMovesButton, QuakeMovesButton, ReplayButton, FightButton, PlayerTextObject, PlayerChoiceTextObject, 
        WinnerTextObject, Player1HealthTextObject, Player2HealthTextObject;
    public static Text PlayerText, PlayerCreatureChoiceText, WinnerText, Player1HealthText, Player2HealthText;
    public static int playerTurn;
    public static float player1maxHealth, player2maxHealth;

    private int player1CreatureChoice, player2CreatureChoice;

    void Start()
    {

        MoveListButton = GameObject.Find("MoveListButton");
        FransMovesButton = GameObject.Find("FransMoves");
        QuakeMovesButton = GameObject.Find("QuakeMoves");
        ReplayButton = GameObject.Find("ReplayButton");
        CreatureAttackerButton = GameObject.Find("Creature List");
        FightButton = GameObject.Find("FightButton");
        PlayerTextObject = GameObject.Find("PlayerText");
        PlayerChoiceTextObject = GameObject.Find("PlayerCreatureChoiceText");
        WinnerTextObject = GameObject.Find("WinnerText");
        Player1HealthTextObject = GameObject.Find("Player1Health");
        Player2HealthTextObject = GameObject.Find("Player2Health");
        PlayerText = PlayerTextObject.GetComponent<Text>();
        PlayerCreatureChoiceText = PlayerChoiceTextObject.GetComponent<Text>();
        WinnerText = WinnerTextObject.GetComponent<Text>();
        Player1HealthText = Player1HealthTextObject.GetComponent<Text>();
        Player2HealthText = Player2HealthTextObject.GetComponent<Text>();

        PlayButton.SetActive(true);
        FransMovesButton.SetActive(false);
        QuakeMovesButton.SetActive(false);
        MoveListButton.SetActive(false);
        ReplayButton.SetActive(false);
        CreatureAttackerButton.SetActive(false);
        FightButton.SetActive(false);

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
            FightButton.SetActive(true);
            PlayerCreatureChoiceText.text = "";

        }

    }

    public void FightStart()
    {

        FightButton.SetActive(false);
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

    }

    /*public void AngeelaAttacker()
    {

        if (playerTurn == 1)
        {

            attacker1 = "angeela";
            playerTurn = 2;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            GameObject clone = Instantiate(Creatures[0], new Vector3(-1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player1";
            Player1 = GameObject.FindWithTag("Player1");
            clone.name = "Angeela 1";
            Creature player1Creature = Player1.GetComponent<Creature>();
            player1maxHealth = player1Creature.health;

        }
        else if (playerTurn == 2)
        {

            attacker2 = "angeela";
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "";
            CreatureAttackerButton.SetActive(false);
            MoveListButton.SetActive(true);
            GameObject clone = Instantiate(Creatures[0], new Vector3(1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player2";
            Player2 = GameObject.FindWithTag("Player2");
            clone.name = "Angeela 2";
            Creature player2Creature = Player2.GetComponent<Creature>();
            player2maxHealth = player2Creature.health;

        }

    }

    public void BlazzeruseAttacker()
    {

        if (playerTurn == 1)
        {

            attacker1 = "blazzeruse";
            playerTurn = 2;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            GameObject clone = Instantiate(Creatures[1], new Vector3(-1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player1";
            Player1 = GameObject.FindWithTag("Player1");
            clone.name = "Blazzeruse 1";
            Creature player1Creature = Player1.GetComponent<Creature>();
            player1maxHealth = player1Creature.health;

        }
        else if (playerTurn == 2)
        {

            attacker2 = "blazzeruse";
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "";
            CreatureAttackerButton.SetActive(false);
            MoveListButton.SetActive(true);
            GameObject clone = Instantiate(Creatures[1], new Vector3(1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player2";
            Player2 = GameObject.FindWithTag("Player2");
            clone.name = "Blazzeruse 2";
            Creature player2Creature = Player2.GetComponent<Creature>();
            player2maxHealth = player2Creature.health;

        }

    }

    public void CavenardAttacker()
    {

        if (playerTurn == 1)
        {

            attacker1 = "cavenard";
            playerTurn = 2;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            GameObject clone = Instantiate(Creatures[2], new Vector3(-1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player1";
            Player1 = GameObject.FindWithTag("Player1");
            clone.name = "Cavenard 1";
            Creature player1Creature = Player1.GetComponent<Creature>();
            player1maxHealth = player1Creature.health;

        }
        else if (playerTurn == 2)
        {

            attacker2 = "cavenard";
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "";
            CreatureAttackerButton.SetActive(false);
            MoveListButton.SetActive(true);
            GameObject clone = Instantiate(Creatures[2], new Vector3(1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player2";
            Player2 = GameObject.FindWithTag("Player2");
            clone.name = "Cavenard 2";
            Creature player2Creature = Player2.GetComponent<Creature>();
            player2maxHealth = player2Creature.health;

        }

    }

    public void CharrageAttacker()
    {

        if (playerTurn == 1)
        {

            attacker1 = "charrage";
            playerTurn = 2;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            GameObject clone = Instantiate(Creatures[3], new Vector3(-1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player1";
            Player1 = GameObject.FindWithTag("Player1");
            clone.name = "Angeela 1";
            Creature player1Creature = Player1.GetComponent<Creature>();
            player1maxHealth = player1Creature.health;

        }
        else if (playerTurn == 2)
        {

            attacker2 = "charrage";
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "";
            CreatureAttackerButton.SetActive(false);
            MoveListButton.SetActive(true);
            GameObject clone = Instantiate(Creatures[3], new Vector3(1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player2";
            Player2 = GameObject.FindWithTag("Player2");
            clone.name = "Charrage 2";
            Creature player2Creature = Player2.GetComponent<Creature>();
            player2maxHealth = player2Creature.health;

        }

    }

    public void ContrelaAttacker()
    {

        if (playerTurn == 1)
        {

            attacker1 = "contrela";
            playerTurn = 2;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            GameObject clone = Instantiate(Creatures[4], new Vector3(-1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player1";
            Player1 = GameObject.FindWithTag("Player1");
            clone.name = "Contrela 1";
            Creature player1Creature = Player1.GetComponent<Creature>();
            player1maxHealth = player1Creature.health;

        }
        else if (playerTurn == 2)
        {

            attacker2 = "contrela";
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "";
            CreatureAttackerButton.SetActive(false);
            MoveListButton.SetActive(true);
            GameObject clone = Instantiate(Creatures[4], new Vector3(1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player2";
            Player2 = GameObject.FindWithTag("Player2");
            clone.name = "Contrela 2";
            Creature player2Creature = Player2.GetComponent<Creature>();
            player2maxHealth = player2Creature.health;

        }

    }

    public void DivaneceAttacker()
    {

        if (playerTurn == 1)
        {

            attacker1 = "divanece";
            playerTurn = 2;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            GameObject clone = Instantiate(Creatures[5], new Vector3(-1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player1";
            Player1 = GameObject.FindWithTag("Player1");
            clone.name = "Divanece 1";
            Creature player1Creature = Player1.GetComponent<Creature>();
            player1maxHealth = player1Creature.health;

        }
        else if (playerTurn == 2)
        {

            attacker2 = "divanece";
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "";
            CreatureAttackerButton.SetActive(false);
            MoveListButton.SetActive(true);
            GameObject clone = Instantiate(Creatures[5], new Vector3(1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player2";
            Player2 = GameObject.FindWithTag("Player2");
            clone.name = "Divanece 2";
            Creature player2Creature = Player2.GetComponent<Creature>();
            player2maxHealth = player2Creature.health;

        }

    }

    public void DrafskaAttacker()
    {

        if (playerTurn == 1)
        {

            attacker1 = "drafska";
            playerTurn = 2;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            GameObject clone = Instantiate(Creatures[6], new Vector3(-1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player1";
            Player1 = GameObject.FindWithTag("Player1");
            clone.name = "Drafska 1";
            Creature player1Creature = Player1.GetComponent<Creature>();
            player1maxHealth = player1Creature.health;

        }
        else if (playerTurn == 2)
        {

            attacker2 = "drafska";
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "";
            CreatureAttackerButton.SetActive(false);
            MoveListButton.SetActive(true);
            GameObject clone = Instantiate(Creatures[6], new Vector3(1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player2";
            Player2 = GameObject.FindWithTag("Player2");
            clone.name = "Drafska 2";
            Creature player2Creature = Player2.GetComponent<Creature>();
            player2maxHealth = player2Creature.health;

        }

    }

    public void FransAttacker()
    {

        if (playerTurn == 1)
        {

            attacker1 = "frans";
            playerTurn = 2;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            GameObject clone = Instantiate(Creatures[10], new Vector3(-1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player1";
            Player1 = GameObject.FindWithTag("Player1");
            Creature player1Creature = Player1.GetComponent<Creature>();
            player1maxHealth = player1Creature.health;

        }
        else if (playerTurn == 2)
        {

            attacker2 = "frans";
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "";
            CreatureAttackerButton.SetActive(false);
            MoveListButton.SetActive(true);
            GameObject clone = Instantiate(Creatures[10], new Vector3(1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player2";
            Player2 = GameObject.FindWithTag("Player2");
            clone.name = "Frans 2";
            Creature player2Creature = Player2.GetComponent<Creature>();
            player2maxHealth = player2Creature.health;

        }

    }

    public void QuakeAttacker()
    {

        if (playerTurn == 1)
        {

            attacker1 = "quake";
            playerTurn = 2;
            PlayerCreatureChoiceText.text = "Player 2, choose your creature.";
            GameObject clone = Instantiate(Creatures[21], new Vector3(-1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player1";
            Player1 = GameObject.FindWithTag("Player1");
            clone.name = "Quake 1";
            Creature player1Creature = Player1.GetComponent<Creature>();
            player1maxHealth = player1Creature.health;

        }
        else if (playerTurn == 2)
        {

            attacker2 = "quake";
            playerTurn = 1;
            PlayerCreatureChoiceText.text = "";
            CreatureAttackerButton.SetActive(false);
            MoveListButton.SetActive(true);
            GameObject clone = Instantiate(Creatures[21], new Vector3(1, 0, 2), Quaternion.identity);
            clone.transform.tag = "Player2";
            Player2 = GameObject.FindWithTag("Player2");
            clone.name = "Quake 2";
            Creature player2Creature = Player2.GetComponent<Creature>();
            player2maxHealth = player2Creature.health;

        }

    }*/

    public void Moves()
    {

        MoveListButton.SetActive(false);

        if (playerTurn == 1)
        {

            switch (player1CreatureChoice)
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

            }

        }
        else if (playerTurn == 2)
        {

            switch (player2CreatureChoice)
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

            }

        }

    }

    public void Replay()
    {

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    /*public void DarkStrikeAttack()
    {

        if (playerTurn == 1)
        {

            playerTurn = 2;

        }
        else if (playerTurn == 2)
        {

            playerTurn = 1;

        }

    }*/

}
