using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public GameObject PlayButton, CreaturesPage1, CreaturesPage2, Player1, Player2, Move1Object, Move2Object, Move3Object, Move4Object, Move5Object, 
        Move6Object, Move7Object, Move8Object, CreaturePage1Button, CreaturePage2Button;

    public GameObject[] Creatures, MoveArray;

    public List<string> AngeelaMoves, ArtilerestMoves, BalanceaMoves, BlazzeruseMoves, CavenardMoves, CharrageMoves, ContrelaMoves, CrestMoves, CrokaraMoves,
        CrotainMoves, DivaneceMoves, DrafskaMoves, EurrupterMoves, FearulesMoves, FlamernaMoves, FlamewingMoves, FransMoves, GalektyMoves, GraferMoves, GregerMoves,
        GugonsenMoves, HairretMoves, HarstMoves, HonsenMoves, HypersolMoves, InfernoMoves, InfsuceMoves, LichterMoves, LightgenMoves, LingerusMoves, LioughtMoves,
        NatureaMoves, OrkasMoves, OverhaulMoves, PengunMoves, PoisentaMoves, QuakeMoves, RevelMoves, RockestMoves, RowlerMoves, SanardMoves, SirgeruseMoves,
        SteamerMoves, StelargeMoves, SunelaMoves, TerraionMoves, TimeronMoves, WatkenMoves, WatresMoves, YaunMoves;

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
        CreaturesPage1 = GameObject.Find("CreaturesPage1");
        CreaturesPage2 = GameObject.Find("CreaturesPage2");
        FightButton = GameObject.Find("FightButton");
        ChooseMovesButton = GameObject.Find("ChooseMovesButton");
        ChooseMovesNextButton = GameObject.Find("ChooseMovesNextButton");
        CreaturePage1Button = GameObject.Find("Page1Button");
        CreaturePage2Button = GameObject.Find("Page2Button");
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
        CreaturesPage1.SetActive(false);
        CreaturesPage2.SetActive(false);
        FightButton.SetActive(false);
        ChooseMovesButton.SetActive(false);
        ChooseMovesNextButton.SetActive(false);
        CreaturePage1Button.SetActive(false);
        CreaturePage2Button.SetActive(false);
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
        CreaturesPage1.SetActive(true);
        CreaturePage2Button.SetActive(true);

        PlayerCreatureChoiceText.text = "Player 1, choose your creature.";

        playerTurn = 1;

    }

    public void ToCreaturePage1()
    {

        CreaturesPage1.SetActive(true);
        CreaturesPage2.SetActive(false);
        CreaturePage1Button.SetActive(false);
        CreaturePage2Button.SetActive(true);

    }

    public void ToCreaturePage2()
    {

        CreaturesPage1.SetActive(false);
        CreaturesPage2.SetActive(true);
        CreaturePage1Button.SetActive(true);
        CreaturePage2Button.SetActive(false);

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
            CreaturesPage1.SetActive(false);
            CreaturesPage2.SetActive(false);
            CreaturePage1Button.SetActive(false);
            CreaturePage2Button.SetActive(false);
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

            switch (player1CreatureChoice)
            {
                case 0:
                    switch (choice)
                    {
                        case 0:
                            move1 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 61;
                            break;
                        case 3:
                            move1 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 29;
                            break;
                        case 9:
                            move1 = 12;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 1:
                    switch (choice)
                    {
                        case 0:
                            move1 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 28;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 35;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 37;
                            break;
                        case 8:
                            move1 = 38;
                            break;
                        case 9:
                            move1 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 2:
                    switch (choice)
                    {
                        case 0:
                            move1 = 39;
                            break;
                        case 1:
                            move1 = 40;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 5;
                            break;
                        case 6:
                            move1 = 43;
                            break;
                        case 7:
                            move1 = 12;
                            break;
                        case 8:
                            move1 = 56;
                            break;
                        case 9:
                            move1 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 3:
                    switch (choice)
                    {
                        case 0:
                            move1 = 13;
                            break;
                        case 1:
                            move1 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 16;
                            break;
                        case 5:
                            move1 = 20;
                            break;
                        case 6:
                            move1 = 24;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 4:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move1 = 61;
                            break;
                        case 2:
                            move1 = 34;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 8;
                            break;
                        case 6:
                            move1 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 5:
                    switch (choice)
                    {
                        case 0:
                            move1 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 15;
                            break;
                        case 3:
                            move1 = 16;
                            break;
                        case 4:
                            move1 = 22;
                            break;
                        case 5:
                            move1 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 38;
                            break;
                        case 8:
                            move1 = 31;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 6:
                    switch (choice)
                    {
                        case 0:
                            move1 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 26;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 7:
                    switch (choice)
                    {
                        case 0:
                            move1 = 39;
                            break;
                        case 1:
                            move1 = 60;
                            break;
                        case 2:
                            move1 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 37;
                            break;
                        case 8:
                            move1 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 8:
                    switch (choice)
                    {
                        case 0:
                            move1 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 4;
                            break;
                        case 7:
                            move1 = 48;
                            break;
                        case 8:
                            move1 = 12;
                            break;
                        case 9:
                            move1 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 9:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 0;
                            break;
                        case 4:
                            move1 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 49;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move1 = 56;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 10:
                    switch (choice)
                    {
                        case 0:
                            move1 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 53;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 54;
                            break;
                        case 8:
                            move1 = 27;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 11:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move1 = 3;
                            break;
                        case 2:
                            move1 = 1;
                            break;
                        case 3:
                            move1 = 2;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 12:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 6;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 21;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 13:
                    switch (choice)
                    {
                        case 0:
                            move1 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 22;
                            break;
                        case 4:
                            move1 = 20;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 28;
                            break;
                        case 7:
                            move1 = 24;
                            break;
                        case 8:
                            move1 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 14:
                    switch (choice)
                    {
                        case 0:
                            move1 = 13;
                            break;
                        case 1:
                            move1 = 45;
                            break;
                        case 2:
                            move1 = 19;
                            break;
                        case 3:
                            move1 = 46;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 20;
                            break;
                        case 6:
                            move1 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move1 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 15:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move1 = 19;
                            break;
                        case 2:
                            move1 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 61;
                            break;
                        case 5:
                            move1 = 21;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move1 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 16:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move1 = 2;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 3;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 4;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 11;
                            break;
                        case 8:
                            move1 = 17;
                            break;
                        case 9:
                            move1 = 48;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 17:
                    switch (choice)
                    {
                        case 0:
                            move1 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 17;
                            break;
                        case 3:
                            move1 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 64;
                            break;
                        case 6:
                            move1 = 41;
                            break;
                        case 7:
                            move1 = 55;
                            break;
                        case 8:
                            move1 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 18:
                    switch (choice)
                    {
                        case 0:
                            move1 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 1;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 47;
                            break;
                        case 5:
                            move1 = 17;
                            break;
                        case 6:
                            move1 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 19:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move1 = 46;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 50;
                            break;
                        case 9:
                            move1 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 20:
                    switch (choice)
                    {
                        case 0:
                            move1 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 64;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 5;
                            break;
                        case 7:
                            move1 = 48;
                            break;
                        case 8:
                            move1 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 21:
                    switch (choice)
                    {
                        case 0:
                            move1 = 60;
                            break;
                        case 1:
                            move1 = 32;
                            break;
                        case 2:
                            move1 = 33;
                            break;
                        case 3:
                            move1 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 64;
                            break;
                        case 6:
                            move1 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move1 = 37;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 22:
                    switch (choice)
                    {
                        case 0:
                            move1 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 2;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 11;
                            break;
                        case 8:
                            move1 = 50;
                            break;
                        case 9:
                            move1 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 23:
                    switch (choice)
                    {
                        case 0:
                            move1 = 45;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 47;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 27;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 4;
                            break;
                        case 8:
                            move1 = 29;
                            break;
                        case 9:
                            move1 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 24:
                    switch (choice)
                    {
                        case 0:
                            move1 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 18;
                            break;
                        case 8:
                            move1 = 50;
                            break;
                        case 9:
                            move1 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 25:
                    switch (choice)
                    {
                        case 0:
                            move1 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 22;
                            break;
                        case 6:
                            move1 = 20;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 29;
                            break;
                        case 9:
                            move1 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 26:
                    switch (choice)
                    {
                        case 0:
                            move1 = 59;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 32;
                            break;
                        case 3:
                            move1 = 33;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 24;
                            break;
                        case 9:
                            move1 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 27:
                    switch (choice)
                    {
                        case 0:
                            move1 = 45;
                            break;
                        case 1:
                            move1 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 0;
                            break;
                        case 5:
                            move1 = 16;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 28:
                    switch (choice)
                    {
                        case 0:
                            move1 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 16;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 28;
                            break;
                        case 5:
                            move1 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move1 = 43;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 29:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move1 = 13;
                            break;
                        case 2:
                            move1 = 60;
                            break;
                        case 3:
                            move1 = 61;
                            break;
                        case 4:
                            move1 = 41;
                            break;
                        case 5:
                            move1 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 42;
                            break;
                        case 8:
                            move1 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 30:
                    switch (choice)
                    {
                        case 0:
                            move1 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 20;
                            break;
                        case 4:
                            move1 = 27;
                            break;
                        case 5:
                            move1 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 11;
                            break;
                        case 8:
                            move1 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 31:
                    switch (choice)
                    {
                        case 0:
                            move1 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 50;
                            break;
                        case 7:
                            move1 = 43;
                            break;
                        case 8:
                            move1 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 32:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 16;
                            break;
                        case 3:
                            move1 = 17;
                            break;
                        case 4:
                            move1 = 62;
                            break;
                        case 5:
                            move1 = 64;
                            break;
                        case 6:
                            move1 = 41;
                            break;
                        case 7:
                            move1 = 18;
                            break;
                        case 8:
                            move1 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 33:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move1 = 47;
                            break;
                        case 2:
                            move1 = 33;
                            break;
                        case 3:
                            move1 = 35;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 37;
                            break;
                        case 7:
                            move1 = 50;
                            break;
                        case 8:
                            move1 = 38;
                            break;
                        case 9:
                            move1 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 34:
                    switch (choice)
                    {
                        case 0:
                            move1 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 53;
                            break;
                        case 3:
                            move1 = 63;
                            break;
                        case 4:
                            move1 = 34;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 54;
                            break;
                        case 7:
                            move1 = 49;
                            break;
                        case 8:
                            move1 = 56;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 35:
                    switch (choice)
                    {
                        case 0:
                            move1 = 46;
                            break;
                        case 1:
                            move1 = 2;
                            break;
                        case 2:
                            move1 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 48;
                            break;
                        case 6:
                            move1 = 50;
                            break;
                        case 7:
                            move1 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move1 = 44;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 36:
                    switch (choice)
                    {
                        case 0:
                            move1 = 6;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 7;
                            break;
                        case 3:
                            move1 = 8;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 11;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 17;
                            break;
                        case 8:
                            move1 = 46;
                            break;
                        case 9:
                            move1 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 37:
                    switch (choice)
                    {
                        case 0:
                            move1 = 13;
                            break;
                        case 1:
                            move1 = 19;
                            break;
                        case 2:
                            move1 = 39;
                            break;
                        case 3:
                            move1 = 32;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 36;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 38:
                    switch (choice)
                    {
                        case 0:
                            move1 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 15;
                            break;
                        case 4:
                            move1 = 16;
                            break;
                        case 5:
                            move1 = 22;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 36;
                            break;
                        case 8:
                            move1 = 38;
                            break;
                        case 9:
                            move1 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 39:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 17;
                            break;
                        case 3:
                            move1 = 9;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 10;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 5;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 40:
                    switch (choice)
                    {
                        case 0:
                            move1 = 61;
                            break;
                        case 1:
                            move1 = 21;
                            break;
                        case 2:
                            move1 = 63;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 27;
                            break;
                        case 5:
                            move1 = 7;
                            break;
                        case 6:
                            move1 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 41:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move1 = 6;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 54;
                            break;
                        case 4:
                            move1 = 7;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 37;
                            break;
                        case 7:
                            move1 = 5;
                            break;
                        case 8:
                            move1 = 50;
                            break;
                        case 9:
                            move1 = 55;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 42:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 22;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 35;
                            break;
                        case 8:
                            move1 = 56;
                            break;
                        case 9:
                            move1 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 43:
                    switch (choice)
                    {
                        case 0:
                            move1 = 32;
                            break;
                        case 1:
                            move1 = 22;
                            break;
                        case 2:
                            move1 = 17;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 36;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 8;
                            break;
                        case 7:
                            move1 = 37;
                            break;
                        case 8:
                            move1 = 38;
                            break;
                        case 9:
                            move1 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 44:
                    switch (choice)
                    {
                        case 0:
                            move1 = 39;
                            break;
                        case 1:
                            move1 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 18;
                            break;
                        case 8:
                            move1 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 45:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 2;
                            break;
                        case 3:
                            move1 = 6;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move1 = 54;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move1 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 46:
                    switch (choice)
                    {
                        case 0:
                            move1 = 45;
                            break;
                        case 1:
                            move1 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move1 = 54;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move1 = 5;
                            break;
                        case 9:
                            move1 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 47:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move1 = 15;
                            break;
                        case 3:
                            move1 = 16;
                            break;
                        case 4:
                            move1 = 52;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move1 = 18;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 48:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 52;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move1 = 29;
                            break;
                        case 8:
                            move1 = 56;
                            break;
                        case 9:
                            move1 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 49:
                    switch (choice)
                    {
                        case 0:
                            move1 = 59;
                            break;
                        case 1:
                            move1 = 19;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move1 = 1;
                            break;
                        case 4:
                            move1 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move1 = 27;
                            break;
                        case 7:
                            move1 = 28;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                default:
                    Debug.Log("Creature choice error on move selection.");
                    break;

            }

        }
        else if (playerTurn == 1)
        {

            ChooseMovesNextButton.SetActive(false);

            switch (player2CreatureChoice)
            {
                case 0:
                    switch (choice)
                    {
                        case 0:
                            move5 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 61;
                            break;
                        case 3:
                            move5 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 29;
                            break;
                        case 9:
                            move5 = 12;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 1:
                    switch (choice)
                    {
                        case 0:
                            move5 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 28;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 35;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 37;
                            break;
                        case 8:
                            move5 = 38;
                            break;
                        case 9:
                            move5 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 2:
                    switch (choice)
                    {
                        case 0:
                            move5 = 39;
                            break;
                        case 1:
                            move5 = 40;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 5;
                            break;
                        case 6:
                            move5 = 43;
                            break;
                        case 7:
                            move5 = 12;
                            break;
                        case 8:
                            move5 = 56;
                            break;
                        case 9:
                            move5 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 3:
                    switch (choice)
                    {
                        case 0:
                            move5 = 13;
                            break;
                        case 1:
                            move5 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 16;
                            break;
                        case 5:
                            move5 = 20;
                            break;
                        case 6:
                            move5 = 24;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 4:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move5 = 61;
                            break;
                        case 2:
                            move5 = 34;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 8;
                            break;
                        case 6:
                            move5 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 5:
                    switch (choice)
                    {
                        case 0:
                            move5 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 15;
                            break;
                        case 3:
                            move5 = 16;
                            break;
                        case 4:
                            move5 = 22;
                            break;
                        case 5:
                            move5 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 38;
                            break;
                        case 8:
                            move5 = 31;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 6:
                    switch (choice)
                    {
                        case 0:
                            move5 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 26;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 7:
                    switch (choice)
                    {
                        case 0:
                            move5 = 39;
                            break;
                        case 1:
                            move5 = 60;
                            break;
                        case 2:
                            move5 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 37;
                            break;
                        case 8:
                            move5 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 8:
                    switch (choice)
                    {
                        case 0:
                            move5 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 4;
                            break;
                        case 7:
                            move5 = 48;
                            break;
                        case 8:
                            move5 = 12;
                            break;
                        case 9:
                            move5 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 9:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 0;
                            break;
                        case 4:
                            move5 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 49;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 56;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 10:
                    switch (choice)
                    {
                        case 0:
                            move5 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 53;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 54;
                            break;
                        case 8:
                            move5 = 27;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 11:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move5 = 3;
                            break;
                        case 2:
                            move5 = 1;
                            break;
                        case 3:
                            move5 = 2;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 12:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 6;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 21;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 13:
                    switch (choice)
                    {
                        case 0:
                            move5 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 22;
                            break;
                        case 4:
                            move5 = 20;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 28;
                            break;
                        case 7:
                            move5 = 24;
                            break;
                        case 8:
                            move5 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 14:
                    switch (choice)
                    {
                        case 0:
                            move5 = 13;
                            break;
                        case 1:
                            move5 = 45;
                            break;
                        case 2:
                            move5 = 19;
                            break;
                        case 3:
                            move5 = 46;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 20;
                            break;
                        case 6:
                            move5 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 15:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move5 = 19;
                            break;
                        case 2:
                            move5 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 61;
                            break;
                        case 5:
                            move5 = 21;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 16:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move5 = 2;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 3;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 4;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 11;
                            break;
                        case 8:
                            move5 = 17;
                            break;
                        case 9:
                            move5 = 48;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 17:
                    switch (choice)
                    {
                        case 0:
                            move5 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 17;
                            break;
                        case 3:
                            move5 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 64;
                            break;
                        case 6:
                            move5 = 41;
                            break;
                        case 7:
                            move5 = 55;
                            break;
                        case 8:
                            move5 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 18:
                    switch (choice)
                    {
                        case 0:
                            move5 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 1;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 47;
                            break;
                        case 5:
                            move5 = 17;
                            break;
                        case 6:
                            move5 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 19:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move5 = 46;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 50;
                            break;
                        case 9:
                            move5 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 20:
                    switch (choice)
                    {
                        case 0:
                            move5 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 64;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 5;
                            break;
                        case 7:
                            move5 = 48;
                            break;
                        case 8:
                            move5 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 21:
                    switch (choice)
                    {
                        case 0:
                            move5 = 60;
                            break;
                        case 1:
                            move5 = 32;
                            break;
                        case 2:
                            move5 = 33;
                            break;
                        case 3:
                            move5 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 64;
                            break;
                        case 6:
                            move5 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 37;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 22:
                    switch (choice)
                    {
                        case 0:
                            move5 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 2;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 11;
                            break;
                        case 8:
                            move5 = 50;
                            break;
                        case 9:
                            move5 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 23:
                    switch (choice)
                    {
                        case 0:
                            move5 = 45;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 47;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 27;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 4;
                            break;
                        case 8:
                            move5 = 29;
                            break;
                        case 9:
                            move5 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 24:
                    switch (choice)
                    {
                        case 0:
                            move5 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 18;
                            break;
                        case 8:
                            move5 = 50;
                            break;
                        case 9:
                            move5 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 25:
                    switch (choice)
                    {
                        case 0:
                            move5 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 22;
                            break;
                        case 6:
                            move5 = 20;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 29;
                            break;
                        case 9:
                            move5 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 26:
                    switch (choice)
                    {
                        case 0:
                            move5 = 59;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 32;
                            break;
                        case 3:
                            move5 = 33;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 24;
                            break;
                        case 9:
                            move5 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 27:
                    switch (choice)
                    {
                        case 0:
                            move5 = 45;
                            break;
                        case 1:
                            move5 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 0;
                            break;
                        case 5:
                            move5 = 16;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 28:
                    switch (choice)
                    {
                        case 0:
                            move5 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 16;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 28;
                            break;
                        case 5:
                            move5 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 43;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 29:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move5 = 13;
                            break;
                        case 2:
                            move5 = 60;
                            break;
                        case 3:
                            move5 = 61;
                            break;
                        case 4:
                            move5 = 41;
                            break;
                        case 5:
                            move5 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 42;
                            break;
                        case 8:
                            move5 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 30:
                    switch (choice)
                    {
                        case 0:
                            move5 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 20;
                            break;
                        case 4:
                            move5 = 27;
                            break;
                        case 5:
                            move5 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 11;
                            break;
                        case 8:
                            move5 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 31:
                    switch (choice)
                    {
                        case 0:
                            move5 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 50;
                            break;
                        case 7:
                            move5 = 43;
                            break;
                        case 8:
                            move5 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 32:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 16;
                            break;
                        case 3:
                            move5 = 17;
                            break;
                        case 4:
                            move5 = 62;
                            break;
                        case 5:
                            move5 = 64;
                            break;
                        case 6:
                            move5 = 41;
                            break;
                        case 7:
                            move5 = 18;
                            break;
                        case 8:
                            move5 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 33:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move5 = 47;
                            break;
                        case 2:
                            move5 = 33;
                            break;
                        case 3:
                            move5 = 35;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 37;
                            break;
                        case 7:
                            move5 = 50;
                            break;
                        case 8:
                            move5 = 38;
                            break;
                        case 9:
                            move5 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 34:
                    switch (choice)
                    {
                        case 0:
                            move5 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 53;
                            break;
                        case 3:
                            move5 = 63;
                            break;
                        case 4:
                            move5 = 34;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 54;
                            break;
                        case 7:
                            move5 = 49;
                            break;
                        case 8:
                            move5 = 56;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 35:
                    switch (choice)
                    {
                        case 0:
                            move5 = 46;
                            break;
                        case 1:
                            move5 = 2;
                            break;
                        case 2:
                            move5 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 48;
                            break;
                        case 6:
                            move5 = 50;
                            break;
                        case 7:
                            move5 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 44;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 36:
                    switch (choice)
                    {
                        case 0:
                            move5 = 6;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 7;
                            break;
                        case 3:
                            move5 = 8;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 11;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 17;
                            break;
                        case 8:
                            move5 = 46;
                            break;
                        case 9:
                            move5 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 37:
                    switch (choice)
                    {
                        case 0:
                            move5 = 13;
                            break;
                        case 1:
                            move5 = 19;
                            break;
                        case 2:
                            move5 = 39;
                            break;
                        case 3:
                            move5 = 32;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 36;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 38:
                    switch (choice)
                    {
                        case 0:
                            move5 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 15;
                            break;
                        case 4:
                            move5 = 16;
                            break;
                        case 5:
                            move5 = 22;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 36;
                            break;
                        case 8:
                            move5 = 38;
                            break;
                        case 9:
                            move5 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 39:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 17;
                            break;
                        case 3:
                            move5 = 9;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 10;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 5;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 40:
                    switch (choice)
                    {
                        case 0:
                            move5 = 61;
                            break;
                        case 1:
                            move5 = 21;
                            break;
                        case 2:
                            move5 = 63;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 27;
                            break;
                        case 5:
                            move5 = 7;
                            break;
                        case 6:
                            move5 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 41:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move5 = 6;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 54;
                            break;
                        case 4:
                            move5 = 7;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 37;
                            break;
                        case 7:
                            move5 = 5;
                            break;
                        case 8:
                            move5 = 50;
                            break;
                        case 9:
                            move5 = 55;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 42:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 22;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 35;
                            break;
                        case 8:
                            move5 = 56;
                            break;
                        case 9:
                            move5 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 43:
                    switch (choice)
                    {
                        case 0:
                            move5 = 32;
                            break;
                        case 1:
                            move5 = 22;
                            break;
                        case 2:
                            move5 = 17;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 36;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 8;
                            break;
                        case 7:
                            move5 = 37;
                            break;
                        case 8:
                            move5 = 38;
                            break;
                        case 9:
                            move5 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 44:
                    switch (choice)
                    {
                        case 0:
                            move5 = 39;
                            break;
                        case 1:
                            move5 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 18;
                            break;
                        case 8:
                            move5 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 45:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 2;
                            break;
                        case 3:
                            move5 = 6;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move5 = 54;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 46:
                    switch (choice)
                    {
                        case 0:
                            move5 = 45;
                            break;
                        case 1:
                            move5 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move5 = 54;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move5 = 5;
                            break;
                        case 9:
                            move5 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 47:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move5 = 15;
                            break;
                        case 3:
                            move5 = 16;
                            break;
                        case 4:
                            move5 = 52;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 18;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 48:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 52;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move5 = 29;
                            break;
                        case 8:
                            move5 = 56;
                            break;
                        case 9:
                            move5 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 49:
                    switch (choice)
                    {
                        case 0:
                            move5 = 59;
                            break;
                        case 1:
                            move5 = 19;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move5 = 1;
                            break;
                        case 4:
                            move5 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move5 = 27;
                            break;
                        case 7:
                            move5 = 28;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                default:
                    Debug.Log("Creature choice error on move selection.");
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

            switch (player1CreatureChoice)
            {
                case 0:
                    switch (choice)
                    {
                        case 0:
                            move2 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 61;
                            break;
                        case 3:
                            move2 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 29;
                            break;
                        case 9:
                            move2 = 12;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 1:
                    switch (choice)
                    {
                        case 0:
                            move2 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 28;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 35;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 37;
                            break;
                        case 8:
                            move2 = 38;
                            break;
                        case 9:
                            move2 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 2:
                    switch (choice)
                    {
                        case 0:
                            move2 = 39;
                            break;
                        case 1:
                            move2 = 40;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 5;
                            break;
                        case 6:
                            move2 = 43;
                            break;
                        case 7:
                            move2 = 12;
                            break;
                        case 8:
                            move2 = 56;
                            break;
                        case 9:
                            move2 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 3:
                    switch (choice)
                    {
                        case 0:
                            move2 = 13;
                            break;
                        case 1:
                            move2 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 16;
                            break;
                        case 5:
                            move2 = 20;
                            break;
                        case 6:
                            move2 = 24;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 4:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move2 = 61;
                            break;
                        case 2:
                            move2 = 34;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 8;
                            break;
                        case 6:
                            move2 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 5:
                    switch (choice)
                    {
                        case 0:
                            move2 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 15;
                            break;
                        case 3:
                            move2 = 16;
                            break;
                        case 4:
                            move2 = 22;
                            break;
                        case 5:
                            move2 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 38;
                            break;
                        case 8:
                            move2 = 31;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 6:
                    switch (choice)
                    {
                        case 0:
                            move2 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 26;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 7:
                    switch (choice)
                    {
                        case 0:
                            move2 = 39;
                            break;
                        case 1:
                            move2 = 60;
                            break;
                        case 2:
                            move2 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 37;
                            break;
                        case 8:
                            move2 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 8:
                    switch (choice)
                    {
                        case 0:
                            move2 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 4;
                            break;
                        case 7:
                            move2 = 48;
                            break;
                        case 8:
                            move2 = 12;
                            break;
                        case 9:
                            move2 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 9:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 0;
                            break;
                        case 4:
                            move2 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 49;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move2 = 56;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 10:
                    switch (choice)
                    {
                        case 0:
                            move2 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 53;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 54;
                            break;
                        case 8:
                            move2 = 27;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 11:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move2 = 3;
                            break;
                        case 2:
                            move2 = 1;
                            break;
                        case 3:
                            move2 = 2;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 12:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 6;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 21;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 13:
                    switch (choice)
                    {
                        case 0:
                            move2 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 22;
                            break;
                        case 4:
                            move2 = 20;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 28;
                            break;
                        case 7:
                            move2 = 24;
                            break;
                        case 8:
                            move2 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 14:
                    switch (choice)
                    {
                        case 0:
                            move2 = 13;
                            break;
                        case 1:
                            move2 = 45;
                            break;
                        case 2:
                            move2 = 19;
                            break;
                        case 3:
                            move2 = 46;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 20;
                            break;
                        case 6:
                            move2 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move2 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 15:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move2 = 19;
                            break;
                        case 2:
                            move2 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 61;
                            break;
                        case 5:
                            move2 = 21;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move2 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 16:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move2 = 2;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 3;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 4;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 11;
                            break;
                        case 8:
                            move2 = 17;
                            break;
                        case 9:
                            move2 = 48;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 17:
                    switch (choice)
                    {
                        case 0:
                            move2 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 17;
                            break;
                        case 3:
                            move2 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 64;
                            break;
                        case 6:
                            move2 = 41;
                            break;
                        case 7:
                            move2 = 55;
                            break;
                        case 8:
                            move2 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 18:
                    switch (choice)
                    {
                        case 0:
                            move2 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 1;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 47;
                            break;
                        case 5:
                            move2 = 17;
                            break;
                        case 6:
                            move2 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 19:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move2 = 46;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 50;
                            break;
                        case 9:
                            move2 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 20:
                    switch (choice)
                    {
                        case 0:
                            move2 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 64;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 5;
                            break;
                        case 7:
                            move2 = 48;
                            break;
                        case 8:
                            move2 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 21:
                    switch (choice)
                    {
                        case 0:
                            move2 = 60;
                            break;
                        case 1:
                            move2 = 32;
                            break;
                        case 2:
                            move2 = 33;
                            break;
                        case 3:
                            move2 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 64;
                            break;
                        case 6:
                            move2 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move2 = 37;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 22:
                    switch (choice)
                    {
                        case 0:
                            move2 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 2;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 11;
                            break;
                        case 8:
                            move2 = 50;
                            break;
                        case 9:
                            move2 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 23:
                    switch (choice)
                    {
                        case 0:
                            move2 = 45;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 47;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 27;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 4;
                            break;
                        case 8:
                            move2 = 29;
                            break;
                        case 9:
                            move2 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 24:
                    switch (choice)
                    {
                        case 0:
                            move2 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 18;
                            break;
                        case 8:
                            move2 = 50;
                            break;
                        case 9:
                            move2 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 25:
                    switch (choice)
                    {
                        case 0:
                            move2 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 22;
                            break;
                        case 6:
                            move2 = 20;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 29;
                            break;
                        case 9:
                            move2 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 26:
                    switch (choice)
                    {
                        case 0:
                            move2 = 59;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 32;
                            break;
                        case 3:
                            move2 = 33;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 24;
                            break;
                        case 9:
                            move2 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 27:
                    switch (choice)
                    {
                        case 0:
                            move2 = 45;
                            break;
                        case 1:
                            move2 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 0;
                            break;
                        case 5:
                            move2 = 16;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 28:
                    switch (choice)
                    {
                        case 0:
                            move2 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 16;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 28;
                            break;
                        case 5:
                            move2 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move2 = 43;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 29:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move2 = 13;
                            break;
                        case 2:
                            move2 = 60;
                            break;
                        case 3:
                            move2 = 61;
                            break;
                        case 4:
                            move2 = 41;
                            break;
                        case 5:
                            move2 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 42;
                            break;
                        case 8:
                            move2 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 30:
                    switch (choice)
                    {
                        case 0:
                            move2 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 20;
                            break;
                        case 4:
                            move2 = 27;
                            break;
                        case 5:
                            move2 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 11;
                            break;
                        case 8:
                            move2 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 31:
                    switch (choice)
                    {
                        case 0:
                            move2 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 50;
                            break;
                        case 7:
                            move2 = 43;
                            break;
                        case 8:
                            move2 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 32:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 16;
                            break;
                        case 3:
                            move2 = 17;
                            break;
                        case 4:
                            move2 = 62;
                            break;
                        case 5:
                            move2 = 64;
                            break;
                        case 6:
                            move2 = 41;
                            break;
                        case 7:
                            move2 = 18;
                            break;
                        case 8:
                            move2 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 33:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move2 = 47;
                            break;
                        case 2:
                            move2 = 33;
                            break;
                        case 3:
                            move2 = 35;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 37;
                            break;
                        case 7:
                            move2 = 50;
                            break;
                        case 8:
                            move2 = 38;
                            break;
                        case 9:
                            move2 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 34:
                    switch (choice)
                    {
                        case 0:
                            move2 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 53;
                            break;
                        case 3:
                            move2 = 63;
                            break;
                        case 4:
                            move2 = 34;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 54;
                            break;
                        case 7:
                            move2 = 49;
                            break;
                        case 8:
                            move2 = 56;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 35:
                    switch (choice)
                    {
                        case 0:
                            move2 = 46;
                            break;
                        case 1:
                            move2 = 2;
                            break;
                        case 2:
                            move2 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 48;
                            break;
                        case 6:
                            move2 = 50;
                            break;
                        case 7:
                            move2 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move2 = 44;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 36:
                    switch (choice)
                    {
                        case 0:
                            move2 = 6;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 7;
                            break;
                        case 3:
                            move2 = 8;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 11;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 17;
                            break;
                        case 8:
                            move2 = 46;
                            break;
                        case 9:
                            move2 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 37:
                    switch (choice)
                    {
                        case 0:
                            move2 = 13;
                            break;
                        case 1:
                            move2 = 19;
                            break;
                        case 2:
                            move2 = 39;
                            break;
                        case 3:
                            move2 = 32;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 36;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 38:
                    switch (choice)
                    {
                        case 0:
                            move2 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 15;
                            break;
                        case 4:
                            move2 = 16;
                            break;
                        case 5:
                            move2 = 22;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 36;
                            break;
                        case 8:
                            move2 = 38;
                            break;
                        case 9:
                            move2 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 39:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 17;
                            break;
                        case 3:
                            move2 = 9;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 10;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 5;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 40:
                    switch (choice)
                    {
                        case 0:
                            move2 = 61;
                            break;
                        case 1:
                            move2 = 21;
                            break;
                        case 2:
                            move2 = 63;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 27;
                            break;
                        case 5:
                            move2 = 7;
                            break;
                        case 6:
                            move2 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 41:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move2 = 6;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 54;
                            break;
                        case 4:
                            move2 = 7;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 37;
                            break;
                        case 7:
                            move2 = 5;
                            break;
                        case 8:
                            move2 = 50;
                            break;
                        case 9:
                            move2 = 55;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 42:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 22;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 35;
                            break;
                        case 8:
                            move2 = 56;
                            break;
                        case 9:
                            move2 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 43:
                    switch (choice)
                    {
                        case 0:
                            move2 = 32;
                            break;
                        case 1:
                            move2 = 22;
                            break;
                        case 2:
                            move2 = 17;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 36;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 8;
                            break;
                        case 7:
                            move2 = 37;
                            break;
                        case 8:
                            move2 = 38;
                            break;
                        case 9:
                            move2 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 44:
                    switch (choice)
                    {
                        case 0:
                            move2 = 39;
                            break;
                        case 1:
                            move2 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 18;
                            break;
                        case 8:
                            move2 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 45:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 2;
                            break;
                        case 3:
                            move2 = 6;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move2 = 54;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move2 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 46:
                    switch (choice)
                    {
                        case 0:
                            move2 = 45;
                            break;
                        case 1:
                            move2 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move2 = 54;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move2 = 5;
                            break;
                        case 9:
                            move2 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 47:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move2 = 15;
                            break;
                        case 3:
                            move2 = 16;
                            break;
                        case 4:
                            move2 = 52;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move2 = 18;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 48:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 52;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move2 = 29;
                            break;
                        case 8:
                            move2 = 56;
                            break;
                        case 9:
                            move2 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 49:
                    switch (choice)
                    {
                        case 0:
                            move2 = 59;
                            break;
                        case 1:
                            move2 = 19;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move2 = 1;
                            break;
                        case 4:
                            move2 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move2 = 27;
                            break;
                        case 7:
                            move2 = 28;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                default:
                    Debug.Log("Creature choice error on move selection.");
                    break;

            }

        }
        else if (playerTurn == 1)
        {

            ChooseMovesNextButton.SetActive(false);

            switch (player2CreatureChoice)
            {
                case 0:
                    switch (choice)
                    {
                        case 0:
                            move6 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 61;
                            break;
                        case 3:
                            move6 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 29;
                            break;
                        case 9:
                            move6 = 12;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 1:
                    switch (choice)
                    {
                        case 0:
                            move6 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 28;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 35;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 37;
                            break;
                        case 8:
                            move6 = 38;
                            break;
                        case 9:
                            move6 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 2:
                    switch (choice)
                    {
                        case 0:
                            move6 = 39;
                            break;
                        case 1:
                            move6 = 40;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 5;
                            break;
                        case 6:
                            move6 = 43;
                            break;
                        case 7:
                            move6 = 12;
                            break;
                        case 8:
                            move6 = 56;
                            break;
                        case 9:
                            move6 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 3:
                    switch (choice)
                    {
                        case 0:
                            move6 = 13;
                            break;
                        case 1:
                            move6 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 16;
                            break;
                        case 5:
                            move6 = 20;
                            break;
                        case 6:
                            move6 = 24;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 4:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move6 = 61;
                            break;
                        case 2:
                            move6 = 34;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 8;
                            break;
                        case 6:
                            move6 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 5:
                    switch (choice)
                    {
                        case 0:
                            move6 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 15;
                            break;
                        case 3:
                            move6 = 16;
                            break;
                        case 4:
                            move6 = 22;
                            break;
                        case 5:
                            move6 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 38;
                            break;
                        case 8:
                            move6 = 31;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 6:
                    switch (choice)
                    {
                        case 0:
                            move6 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 26;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 7:
                    switch (choice)
                    {
                        case 0:
                            move6 = 39;
                            break;
                        case 1:
                            move6 = 60;
                            break;
                        case 2:
                            move6 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 37;
                            break;
                        case 8:
                            move6 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 8:
                    switch (choice)
                    {
                        case 0:
                            move6 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 4;
                            break;
                        case 7:
                            move6 = 48;
                            break;
                        case 8:
                            move6 = 12;
                            break;
                        case 9:
                            move6 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 9:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 0;
                            break;
                        case 4:
                            move6 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 49;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move6 = 56;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 10:
                    switch (choice)
                    {
                        case 0:
                            move6 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 53;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 54;
                            break;
                        case 8:
                            move6 = 27;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 11:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move6 = 3;
                            break;
                        case 2:
                            move6 = 1;
                            break;
                        case 3:
                            move6 = 2;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 12:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 6;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 21;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 13:
                    switch (choice)
                    {
                        case 0:
                            move6 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 22;
                            break;
                        case 4:
                            move6 = 20;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 28;
                            break;
                        case 7:
                            move6 = 24;
                            break;
                        case 8:
                            move6 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 14:
                    switch (choice)
                    {
                        case 0:
                            move6 = 13;
                            break;
                        case 1:
                            move6 = 45;
                            break;
                        case 2:
                            move6 = 19;
                            break;
                        case 3:
                            move6 = 46;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 20;
                            break;
                        case 6:
                            move6 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 15:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move6 = 19;
                            break;
                        case 2:
                            move6 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 61;
                            break;
                        case 5:
                            move6 = 21;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move6 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 16:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move6 = 2;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 3;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 4;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 11;
                            break;
                        case 8:
                            move6 = 17;
                            break;
                        case 9:
                            move6 = 48;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 17:
                    switch (choice)
                    {
                        case 0:
                            move6 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 17;
                            break;
                        case 3:
                            move6 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 64;
                            break;
                        case 6:
                            move6 = 41;
                            break;
                        case 7:
                            move6 = 55;
                            break;
                        case 8:
                            move6 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 18:
                    switch (choice)
                    {
                        case 0:
                            move6 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 1;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 47;
                            break;
                        case 5:
                            move6 = 17;
                            break;
                        case 6:
                            move6 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 19:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move6 = 46;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 50;
                            break;
                        case 9:
                            move6 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 20:
                    switch (choice)
                    {
                        case 0:
                            move6 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 64;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 5;
                            break;
                        case 7:
                            move6 = 48;
                            break;
                        case 8:
                            move6 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 21:
                    switch (choice)
                    {
                        case 0:
                            move6 = 60;
                            break;
                        case 1:
                            move6 = 32;
                            break;
                        case 2:
                            move6 = 33;
                            break;
                        case 3:
                            move6 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 64;
                            break;
                        case 6:
                            move6 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move6 = 37;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 22:
                    switch (choice)
                    {
                        case 0:
                            move6 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 2;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 11;
                            break;
                        case 8:
                            move6 = 50;
                            break;
                        case 9:
                            move6 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 23:
                    switch (choice)
                    {
                        case 0:
                            move6 = 45;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 47;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 27;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 4;
                            break;
                        case 8:
                            move6 = 29;
                            break;
                        case 9:
                            move6 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 24:
                    switch (choice)
                    {
                        case 0:
                            move6 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 18;
                            break;
                        case 8:
                            move6 = 50;
                            break;
                        case 9:
                            move6 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 25:
                    switch (choice)
                    {
                        case 0:
                            move6 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 22;
                            break;
                        case 6:
                            move6 = 20;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 29;
                            break;
                        case 9:
                            move6 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 26:
                    switch (choice)
                    {
                        case 0:
                            move6 = 59;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 32;
                            break;
                        case 3:
                            move6 = 33;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 24;
                            break;
                        case 9:
                            move6 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 27:
                    switch (choice)
                    {
                        case 0:
                            move6 = 45;
                            break;
                        case 1:
                            move6 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 0;
                            break;
                        case 5:
                            move6 = 16;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 28:
                    switch (choice)
                    {
                        case 0:
                            move6 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 16;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 28;
                            break;
                        case 5:
                            move6 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move6 = 43;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 29:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move6 = 13;
                            break;
                        case 2:
                            move6 = 60;
                            break;
                        case 3:
                            move6 = 61;
                            break;
                        case 4:
                            move6 = 41;
                            break;
                        case 5:
                            move6 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 42;
                            break;
                        case 8:
                            move6 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 30:
                    switch (choice)
                    {
                        case 0:
                            move6 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 20;
                            break;
                        case 4:
                            move6 = 27;
                            break;
                        case 5:
                            move6 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 11;
                            break;
                        case 8:
                            move6 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 31:
                    switch (choice)
                    {
                        case 0:
                            move6 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 50;
                            break;
                        case 7:
                            move6 = 43;
                            break;
                        case 8:
                            move6 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 32:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 16;
                            break;
                        case 3:
                            move6 = 17;
                            break;
                        case 4:
                            move6 = 62;
                            break;
                        case 5:
                            move6 = 64;
                            break;
                        case 6:
                            move6 = 41;
                            break;
                        case 7:
                            move6 = 18;
                            break;
                        case 8:
                            move6 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 33:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move6 = 47;
                            break;
                        case 2:
                            move6 = 33;
                            break;
                        case 3:
                            move6 = 35;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 37;
                            break;
                        case 7:
                            move6 = 50;
                            break;
                        case 8:
                            move6 = 38;
                            break;
                        case 9:
                            move6 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 34:
                    switch (choice)
                    {
                        case 0:
                            move6 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 53;
                            break;
                        case 3:
                            move6 = 63;
                            break;
                        case 4:
                            move6 = 34;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 54;
                            break;
                        case 7:
                            move6 = 49;
                            break;
                        case 8:
                            move6 = 56;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 35:
                    switch (choice)
                    {
                        case 0:
                            move6 = 46;
                            break;
                        case 1:
                            move6 = 2;
                            break;
                        case 2:
                            move6 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 48;
                            break;
                        case 6:
                            move6 = 50;
                            break;
                        case 7:
                            move6 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move6 = 44;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 36:
                    switch (choice)
                    {
                        case 0:
                            move6 = 6;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 7;
                            break;
                        case 3:
                            move6 = 8;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 11;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 17;
                            break;
                        case 8:
                            move6 = 46;
                            break;
                        case 9:
                            move6 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 37:
                    switch (choice)
                    {
                        case 0:
                            move6 = 13;
                            break;
                        case 1:
                            move6 = 19;
                            break;
                        case 2:
                            move6 = 39;
                            break;
                        case 3:
                            move6 = 32;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 36;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 38:
                    switch (choice)
                    {
                        case 0:
                            move6 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 15;
                            break;
                        case 4:
                            move6 = 16;
                            break;
                        case 5:
                            move6 = 22;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 36;
                            break;
                        case 8:
                            move6 = 38;
                            break;
                        case 9:
                            move6 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 39:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 17;
                            break;
                        case 3:
                            move6 = 9;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 10;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 5;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 40:
                    switch (choice)
                    {
                        case 0:
                            move6 = 61;
                            break;
                        case 1:
                            move6 = 21;
                            break;
                        case 2:
                            move6 = 63;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 27;
                            break;
                        case 5:
                            move6 = 7;
                            break;
                        case 6:
                            move6 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 41:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move6 = 6;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 54;
                            break;
                        case 4:
                            move6 = 7;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 37;
                            break;
                        case 7:
                            move6 = 5;
                            break;
                        case 8:
                            move6 = 50;
                            break;
                        case 9:
                            move6 = 55;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 42:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 22;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 35;
                            break;
                        case 8:
                            move6 = 56;
                            break;
                        case 9:
                            move6 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 43:
                    switch (choice)
                    {
                        case 0:
                            move6 = 32;
                            break;
                        case 1:
                            move6 = 22;
                            break;
                        case 2:
                            move6 = 17;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 36;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 8;
                            break;
                        case 7:
                            move6 = 37;
                            break;
                        case 8:
                            move6 = 38;
                            break;
                        case 9:
                            move6 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 44:
                    switch (choice)
                    {
                        case 0:
                            move6 = 39;
                            break;
                        case 1:
                            move6 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 18;
                            break;
                        case 8:
                            move6 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 45:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 2;
                            break;
                        case 3:
                            move6 = 6;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move6 = 54;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move6 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 46:
                    switch (choice)
                    {
                        case 0:
                            move6 = 45;
                            break;
                        case 1:
                            move6 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move6 = 54;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move6 = 5;
                            break;
                        case 9:
                            move6 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 47:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move6 = 15;
                            break;
                        case 3:
                            move6 = 16;
                            break;
                        case 4:
                            move6 = 52;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move6 = 18;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 48:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 52;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move6 = 29;
                            break;
                        case 8:
                            move6 = 56;
                            break;
                        case 9:
                            move6 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 49:
                    switch (choice)
                    {
                        case 0:
                            move6 = 59;
                            break;
                        case 1:
                            move6 = 19;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move6 = 1;
                            break;
                        case 4:
                            move6 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move6 = 27;
                            break;
                        case 7:
                            move6 = 28;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                default:
                    Debug.Log("Creature choice error on move selection.");
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

            switch (player1CreatureChoice)
            {
                case 0:
                    switch (choice)
                    {
                        case 0:
                            move3 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 61;
                            break;
                        case 3:
                            move3 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 29;
                            break;
                        case 9:
                            move3 = 12;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 1:
                    switch (choice)
                    {
                        case 0:
                            move3 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 28;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 35;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 37;
                            break;
                        case 8:
                            move3 = 38;
                            break;
                        case 9:
                            move3 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 2:
                    switch (choice)
                    {
                        case 0:
                            move3 = 39;
                            break;
                        case 1:
                            move3 = 40;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 5;
                            break;
                        case 6:
                            move3 = 43;
                            break;
                        case 7:
                            move3 = 12;
                            break;
                        case 8:
                            move3 = 56;
                            break;
                        case 9:
                            move3 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 3:
                    switch (choice)
                    {
                        case 0:
                            move3 = 13;
                            break;
                        case 1:
                            move3 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 16;
                            break;
                        case 5:
                            move3 = 20;
                            break;
                        case 6:
                            move3 = 24;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 4:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move3 = 61;
                            break;
                        case 2:
                            move3 = 34;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 8;
                            break;
                        case 6:
                            move3 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 5:
                    switch (choice)
                    {
                        case 0:
                            move3 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 15;
                            break;
                        case 3:
                            move3 = 16;
                            break;
                        case 4:
                            move3 = 22;
                            break;
                        case 5:
                            move3 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 38;
                            break;
                        case 8:
                            move3 = 31;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 6:
                    switch (choice)
                    {
                        case 0:
                            move3 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 26;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 7:
                    switch (choice)
                    {
                        case 0:
                            move3 = 39;
                            break;
                        case 1:
                            move3 = 60;
                            break;
                        case 2:
                            move3 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 37;
                            break;
                        case 8:
                            move3 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 8:
                    switch (choice)
                    {
                        case 0:
                            move3 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 4;
                            break;
                        case 7:
                            move3 = 48;
                            break;
                        case 8:
                            move3 = 12;
                            break;
                        case 9:
                            move3 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 9:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 0;
                            break;
                        case 4:
                            move3 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 49;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move3 = 56;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 10:
                    switch (choice)
                    {
                        case 0:
                            move3 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 53;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 54;
                            break;
                        case 8:
                            move3 = 27;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 11:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move3 = 3;
                            break;
                        case 2:
                            move3 = 1;
                            break;
                        case 3:
                            move3 = 2;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 12:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 6;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 21;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 13:
                    switch (choice)
                    {
                        case 0:
                            move3 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 22;
                            break;
                        case 4:
                            move3 = 20;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 28;
                            break;
                        case 7:
                            move3 = 24;
                            break;
                        case 8:
                            move3 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 14:
                    switch (choice)
                    {
                        case 0:
                            move3 = 13;
                            break;
                        case 1:
                            move3 = 45;
                            break;
                        case 2:
                            move3 = 19;
                            break;
                        case 3:
                            move3 = 46;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 20;
                            break;
                        case 6:
                            move3 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move3 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 15:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move3 = 19;
                            break;
                        case 2:
                            move3 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 61;
                            break;
                        case 5:
                            move3 = 21;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move3 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 16:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move3 = 2;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 3;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 4;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 11;
                            break;
                        case 8:
                            move3 = 17;
                            break;
                        case 9:
                            move3 = 48;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 17:
                    switch (choice)
                    {
                        case 0:
                            move3 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 17;
                            break;
                        case 3:
                            move3 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 64;
                            break;
                        case 6:
                            move3 = 41;
                            break;
                        case 7:
                            move3 = 55;
                            break;
                        case 8:
                            move3 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 18:
                    switch (choice)
                    {
                        case 0:
                            move3 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 1;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 47;
                            break;
                        case 5:
                            move3 = 17;
                            break;
                        case 6:
                            move3 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 19:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move3 = 46;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 50;
                            break;
                        case 9:
                            move3 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 20:
                    switch (choice)
                    {
                        case 0:
                            move3 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 64;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 5;
                            break;
                        case 7:
                            move3 = 48;
                            break;
                        case 8:
                            move3 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 21:
                    switch (choice)
                    {
                        case 0:
                            move3 = 60;
                            break;
                        case 1:
                            move3 = 32;
                            break;
                        case 2:
                            move3 = 33;
                            break;
                        case 3:
                            move3 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 64;
                            break;
                        case 6:
                            move3 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move3 = 37;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 22:
                    switch (choice)
                    {
                        case 0:
                            move3 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 2;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 11;
                            break;
                        case 8:
                            move3 = 50;
                            break;
                        case 9:
                            move3 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 23:
                    switch (choice)
                    {
                        case 0:
                            move3 = 45;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 47;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 27;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 4;
                            break;
                        case 8:
                            move3 = 29;
                            break;
                        case 9:
                            move3 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 24:
                    switch (choice)
                    {
                        case 0:
                            move3 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 18;
                            break;
                        case 8:
                            move3 = 50;
                            break;
                        case 9:
                            move3 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 25:
                    switch (choice)
                    {
                        case 0:
                            move3 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 22;
                            break;
                        case 6:
                            move3 = 20;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 29;
                            break;
                        case 9:
                            move3 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 26:
                    switch (choice)
                    {
                        case 0:
                            move3 = 59;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 32;
                            break;
                        case 3:
                            move3 = 33;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 24;
                            break;
                        case 9:
                            move3 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 27:
                    switch (choice)
                    {
                        case 0:
                            move3 = 45;
                            break;
                        case 1:
                            move3 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 0;
                            break;
                        case 5:
                            move3 = 16;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 28:
                    switch (choice)
                    {
                        case 0:
                            move3 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 16;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 28;
                            break;
                        case 5:
                            move3 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move3 = 43;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 29:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move3 = 13;
                            break;
                        case 2:
                            move3 = 60;
                            break;
                        case 3:
                            move3 = 61;
                            break;
                        case 4:
                            move3 = 41;
                            break;
                        case 5:
                            move3 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 42;
                            break;
                        case 8:
                            move3 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 30:
                    switch (choice)
                    {
                        case 0:
                            move3 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 20;
                            break;
                        case 4:
                            move3 = 27;
                            break;
                        case 5:
                            move3 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 11;
                            break;
                        case 8:
                            move3 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 31:
                    switch (choice)
                    {
                        case 0:
                            move3 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 50;
                            break;
                        case 7:
                            move3 = 43;
                            break;
                        case 8:
                            move3 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 32:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 16;
                            break;
                        case 3:
                            move3 = 17;
                            break;
                        case 4:
                            move3 = 62;
                            break;
                        case 5:
                            move3 = 64;
                            break;
                        case 6:
                            move3 = 41;
                            break;
                        case 7:
                            move3 = 18;
                            break;
                        case 8:
                            move3 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 33:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move3 = 47;
                            break;
                        case 2:
                            move3 = 33;
                            break;
                        case 3:
                            move3 = 35;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 37;
                            break;
                        case 7:
                            move3 = 50;
                            break;
                        case 8:
                            move3 = 38;
                            break;
                        case 9:
                            move3 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 34:
                    switch (choice)
                    {
                        case 0:
                            move3 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 53;
                            break;
                        case 3:
                            move3 = 63;
                            break;
                        case 4:
                            move3 = 34;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 54;
                            break;
                        case 7:
                            move3 = 49;
                            break;
                        case 8:
                            move3 = 56;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 35:
                    switch (choice)
                    {
                        case 0:
                            move3 = 46;
                            break;
                        case 1:
                            move3 = 2;
                            break;
                        case 2:
                            move3 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 48;
                            break;
                        case 6:
                            move3 = 50;
                            break;
                        case 7:
                            move3 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move3 = 44;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 36:
                    switch (choice)
                    {
                        case 0:
                            move3 = 6;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 7;
                            break;
                        case 3:
                            move3 = 8;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 11;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 17;
                            break;
                        case 8:
                            move3 = 46;
                            break;
                        case 9:
                            move3 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 37:
                    switch (choice)
                    {
                        case 0:
                            move3 = 13;
                            break;
                        case 1:
                            move3 = 19;
                            break;
                        case 2:
                            move3 = 39;
                            break;
                        case 3:
                            move3 = 32;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 36;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 38:
                    switch (choice)
                    {
                        case 0:
                            move3 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 15;
                            break;
                        case 4:
                            move3 = 16;
                            break;
                        case 5:
                            move3 = 22;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 36;
                            break;
                        case 8:
                            move3 = 38;
                            break;
                        case 9:
                            move3 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 39:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 17;
                            break;
                        case 3:
                            move3 = 9;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 10;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 5;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 40:
                    switch (choice)
                    {
                        case 0:
                            move3 = 61;
                            break;
                        case 1:
                            move3 = 21;
                            break;
                        case 2:
                            move3 = 63;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 27;
                            break;
                        case 5:
                            move3 = 7;
                            break;
                        case 6:
                            move3 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 41:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move3 = 6;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 54;
                            break;
                        case 4:
                            move3 = 7;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 37;
                            break;
                        case 7:
                            move3 = 5;
                            break;
                        case 8:
                            move3 = 50;
                            break;
                        case 9:
                            move3 = 55;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 42:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 22;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 35;
                            break;
                        case 8:
                            move3 = 56;
                            break;
                        case 9:
                            move3 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 43:
                    switch (choice)
                    {
                        case 0:
                            move3 = 32;
                            break;
                        case 1:
                            move3 = 22;
                            break;
                        case 2:
                            move3 = 17;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 36;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 8;
                            break;
                        case 7:
                            move3 = 37;
                            break;
                        case 8:
                            move3 = 38;
                            break;
                        case 9:
                            move3 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 44:
                    switch (choice)
                    {
                        case 0:
                            move3 = 39;
                            break;
                        case 1:
                            move3 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 18;
                            break;
                        case 8:
                            move3 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 45:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 2;
                            break;
                        case 3:
                            move3 = 6;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move3 = 54;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move3 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 46:
                    switch (choice)
                    {
                        case 0:
                            move3 = 45;
                            break;
                        case 1:
                            move3 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move3 = 54;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move3 = 5;
                            break;
                        case 9:
                            move3 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 47:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move3 = 15;
                            break;
                        case 3:
                            move3 = 16;
                            break;
                        case 4:
                            move3 = 52;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move3 = 18;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 48:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 52;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move3 = 29;
                            break;
                        case 8:
                            move3 = 56;
                            break;
                        case 9:
                            move3 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 49:
                    switch (choice)
                    {
                        case 0:
                            move3 = 59;
                            break;
                        case 1:
                            move3 = 19;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move3 = 1;
                            break;
                        case 4:
                            move3 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move3 = 27;
                            break;
                        case 7:
                            move3 = 28;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                default:
                    Debug.Log("Creature choice error on move selection.");
                    break;

            }

        }
        else if (playerTurn == 1)
        {

            ChooseMovesNextButton.SetActive(false);

            switch (player2CreatureChoice)
            {
                case 0:
                    switch (choice)
                    {
                        case 0:
                            move7 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 61;
                            break;
                        case 3:
                            move7 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 29;
                            break;
                        case 9:
                            move7 = 12;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 1:
                    switch (choice)
                    {
                        case 0:
                            move7 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 28;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 35;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 37;
                            break;
                        case 8:
                            move7 = 38;
                            break;
                        case 9:
                            move7 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 2:
                    switch (choice)
                    {
                        case 0:
                            move7 = 39;
                            break;
                        case 1:
                            move7 = 40;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 5;
                            break;
                        case 6:
                            move7 = 43;
                            break;
                        case 7:
                            move7 = 12;
                            break;
                        case 8:
                            move7 = 56;
                            break;
                        case 9:
                            move7 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 3:
                    switch (choice)
                    {
                        case 0:
                            move7 = 13;
                            break;
                        case 1:
                            move7 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 16;
                            break;
                        case 5:
                            move7 = 20;
                            break;
                        case 6:
                            move7 = 24;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 4:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move7 = 61;
                            break;
                        case 2:
                            move7 = 34;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 8;
                            break;
                        case 6:
                            move7 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 5:
                    switch (choice)
                    {
                        case 0:
                            move7 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 15;
                            break;
                        case 3:
                            move7 = 16;
                            break;
                        case 4:
                            move7 = 22;
                            break;
                        case 5:
                            move7 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 38;
                            break;
                        case 8:
                            move7 = 31;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 6:
                    switch (choice)
                    {
                        case 0:
                            move7 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 26;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 7:
                    switch (choice)
                    {
                        case 0:
                            move7 = 39;
                            break;
                        case 1:
                            move7 = 60;
                            break;
                        case 2:
                            move7 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 37;
                            break;
                        case 8:
                            move7 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 8:
                    switch (choice)
                    {
                        case 0:
                            move7 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 4;
                            break;
                        case 7:
                            move7 = 48;
                            break;
                        case 8:
                            move7 = 12;
                            break;
                        case 9:
                            move7 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 9:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 0;
                            break;
                        case 4:
                            move7 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 49;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move7 = 56;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 10:
                    switch (choice)
                    {
                        case 0:
                            move7 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 53;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 54;
                            break;
                        case 8:
                            move7 = 27;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 11:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move7 = 3;
                            break;
                        case 2:
                            move7 = 1;
                            break;
                        case 3:
                            move7 = 2;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 12:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 6;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 21;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 13:
                    switch (choice)
                    {
                        case 0:
                            move7 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 22;
                            break;
                        case 4:
                            move7 = 20;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 28;
                            break;
                        case 7:
                            move7 = 24;
                            break;
                        case 8:
                            move7 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 14:
                    switch (choice)
                    {
                        case 0:
                            move7 = 13;
                            break;
                        case 1:
                            move7 = 45;
                            break;
                        case 2:
                            move7 = 19;
                            break;
                        case 3:
                            move7 = 46;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 20;
                            break;
                        case 6:
                            move7 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 15:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move7 = 19;
                            break;
                        case 2:
                            move7 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 61;
                            break;
                        case 5:
                            move7 = 21;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move7 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 16:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move7 = 2;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 3;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 4;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 11;
                            break;
                        case 8:
                            move7 = 17;
                            break;
                        case 9:
                            move7 = 48;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 17:
                    switch (choice)
                    {
                        case 0:
                            move7 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 17;
                            break;
                        case 3:
                            move7 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 64;
                            break;
                        case 6:
                            move7 = 41;
                            break;
                        case 7:
                            move7 = 55;
                            break;
                        case 8:
                            move7 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 18:
                    switch (choice)
                    {
                        case 0:
                            move7 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 1;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 47;
                            break;
                        case 5:
                            move7 = 17;
                            break;
                        case 6:
                            move7 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 19:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move7 = 46;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 50;
                            break;
                        case 9:
                            move7 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 20:
                    switch (choice)
                    {
                        case 0:
                            move7 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 64;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 5;
                            break;
                        case 7:
                            move7 = 48;
                            break;
                        case 8:
                            move7 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 21:
                    switch (choice)
                    {
                        case 0:
                            move7 = 60;
                            break;
                        case 1:
                            move7 = 32;
                            break;
                        case 2:
                            move7 = 33;
                            break;
                        case 3:
                            move7 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 64;
                            break;
                        case 6:
                            move7 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move7 = 37;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 22:
                    switch (choice)
                    {
                        case 0:
                            move7 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 2;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 11;
                            break;
                        case 8:
                            move7 = 50;
                            break;
                        case 9:
                            move7 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 23:
                    switch (choice)
                    {
                        case 0:
                            move7 = 45;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 47;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 27;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 4;
                            break;
                        case 8:
                            move7 = 29;
                            break;
                        case 9:
                            move7 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 24:
                    switch (choice)
                    {
                        case 0:
                            move7 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 18;
                            break;
                        case 8:
                            move7 = 50;
                            break;
                        case 9:
                            move7 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 25:
                    switch (choice)
                    {
                        case 0:
                            move7 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 22;
                            break;
                        case 6:
                            move7 = 20;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 29;
                            break;
                        case 9:
                            move7 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 26:
                    switch (choice)
                    {
                        case 0:
                            move7 = 59;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 32;
                            break;
                        case 3:
                            move7 = 33;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 24;
                            break;
                        case 9:
                            move7 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 27:
                    switch (choice)
                    {
                        case 0:
                            move7 = 45;
                            break;
                        case 1:
                            move7 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 0;
                            break;
                        case 5:
                            move7 = 16;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 28:
                    switch (choice)
                    {
                        case 0:
                            move7 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 16;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 28;
                            break;
                        case 5:
                            move7 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move7 = 43;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 29:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move7 = 13;
                            break;
                        case 2:
                            move7 = 60;
                            break;
                        case 3:
                            move7 = 61;
                            break;
                        case 4:
                            move7 = 41;
                            break;
                        case 5:
                            move7 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 42;
                            break;
                        case 8:
                            move7 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 30:
                    switch (choice)
                    {
                        case 0:
                            move7 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 20;
                            break;
                        case 4:
                            move7 = 27;
                            break;
                        case 5:
                            move7 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 11;
                            break;
                        case 8:
                            move7 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 31:
                    switch (choice)
                    {
                        case 0:
                            move7 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 50;
                            break;
                        case 7:
                            move7 = 43;
                            break;
                        case 8:
                            move7 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 32:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 16;
                            break;
                        case 3:
                            move7 = 17;
                            break;
                        case 4:
                            move7 = 62;
                            break;
                        case 5:
                            move7 = 64;
                            break;
                        case 6:
                            move7 = 41;
                            break;
                        case 7:
                            move7 = 18;
                            break;
                        case 8:
                            move7 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 33:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move7 = 47;
                            break;
                        case 2:
                            move7 = 33;
                            break;
                        case 3:
                            move7 = 35;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 37;
                            break;
                        case 7:
                            move7 = 50;
                            break;
                        case 8:
                            move7 = 38;
                            break;
                        case 9:
                            move7 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 34:
                    switch (choice)
                    {
                        case 0:
                            move7 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 53;
                            break;
                        case 3:
                            move7 = 63;
                            break;
                        case 4:
                            move7 = 34;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 54;
                            break;
                        case 7:
                            move7 = 49;
                            break;
                        case 8:
                            move7 = 56;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 35:
                    switch (choice)
                    {
                        case 0:
                            move7 = 46;
                            break;
                        case 1:
                            move7 = 2;
                            break;
                        case 2:
                            move7 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 48;
                            break;
                        case 6:
                            move7 = 50;
                            break;
                        case 7:
                            move7 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move7 = 44;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 36:
                    switch (choice)
                    {
                        case 0:
                            move7 = 6;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 7;
                            break;
                        case 3:
                            move7 = 8;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 11;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 17;
                            break;
                        case 8:
                            move7 = 46;
                            break;
                        case 9:
                            move7 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 37:
                    switch (choice)
                    {
                        case 0:
                            move7 = 13;
                            break;
                        case 1:
                            move7 = 19;
                            break;
                        case 2:
                            move7 = 39;
                            break;
                        case 3:
                            move7 = 32;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 36;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 38:
                    switch (choice)
                    {
                        case 0:
                            move7 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 15;
                            break;
                        case 4:
                            move7 = 16;
                            break;
                        case 5:
                            move7 = 22;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 36;
                            break;
                        case 8:
                            move7 = 38;
                            break;
                        case 9:
                            move7 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 39:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 17;
                            break;
                        case 3:
                            move7 = 9;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 10;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 5;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 40:
                    switch (choice)
                    {
                        case 0:
                            move7 = 61;
                            break;
                        case 1:
                            move7 = 21;
                            break;
                        case 2:
                            move7 = 63;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 27;
                            break;
                        case 5:
                            move7 = 7;
                            break;
                        case 6:
                            move7 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 41:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move7 = 6;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 54;
                            break;
                        case 4:
                            move7 = 7;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 37;
                            break;
                        case 7:
                            move7 = 5;
                            break;
                        case 8:
                            move7 = 50;
                            break;
                        case 9:
                            move7 = 55;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 42:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 22;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 35;
                            break;
                        case 8:
                            move7 = 56;
                            break;
                        case 9:
                            move7 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 43:
                    switch (choice)
                    {
                        case 0:
                            move7 = 32;
                            break;
                        case 1:
                            move7 = 22;
                            break;
                        case 2:
                            move7 = 17;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 36;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 8;
                            break;
                        case 7:
                            move7 = 37;
                            break;
                        case 8:
                            move7 = 38;
                            break;
                        case 9:
                            move7 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 44:
                    switch (choice)
                    {
                        case 0:
                            move7 = 39;
                            break;
                        case 1:
                            move7 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 18;
                            break;
                        case 8:
                            move7 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 45:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 2;
                            break;
                        case 3:
                            move7 = 6;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move7 = 54;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move7 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 46:
                    switch (choice)
                    {
                        case 0:
                            move7 = 45;
                            break;
                        case 1:
                            move7 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move7 = 54;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move7 = 5;
                            break;
                        case 9:
                            move7 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 47:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move7 = 15;
                            break;
                        case 3:
                            move7 = 16;
                            break;
                        case 4:
                            move7 = 52;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move7 = 18;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 48:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 52;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move7 = 29;
                            break;
                        case 8:
                            move7 = 56;
                            break;
                        case 9:
                            move7 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 49:
                    switch (choice)
                    {
                        case 0:
                            move7 = 59;
                            break;
                        case 1:
                            move7 = 19;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move7 = 1;
                            break;
                        case 4:
                            move7 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move7 = 27;
                            break;
                        case 7:
                            move7 = 28;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                default:
                    Debug.Log("Creature choice error on move selection.");
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

            switch (player1CreatureChoice)
            {
                case 0:
                    switch (choice)
                    {
                        case 0:
                            move4 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 61;
                            break;
                        case 3:
                            move4 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 29;
                            break;
                        case 9:
                            move4 = 12;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 1:
                    switch (choice)
                    {
                        case 0:
                            move4 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 28;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 35;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 37;
                            break;
                        case 8:
                            move4 = 38;
                            break;
                        case 9:
                            move4 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 2:
                    switch (choice)
                    {
                        case 0:
                            move4 = 39;
                            break;
                        case 1:
                            move4 = 40;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 5;
                            break;
                        case 6:
                            move4 = 43;
                            break;
                        case 7:
                            move4 = 12;
                            break;
                        case 8:
                            move4 = 56;
                            break;
                        case 9:
                            move4 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 3:
                    switch (choice)
                    {
                        case 0:
                            move4 = 13;
                            break;
                        case 1:
                            move4 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 16;
                            break;
                        case 5:
                            move4 = 20;
                            break;
                        case 6:
                            move4 = 24;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 4:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move4 = 61;
                            break;
                        case 2:
                            move4 = 34;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 8;
                            break;
                        case 6:
                            move4 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 5:
                    switch (choice)
                    {
                        case 0:
                            move4 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 15;
                            break;
                        case 3:
                            move4 = 16;
                            break;
                        case 4:
                            move4 = 22;
                            break;
                        case 5:
                            move4 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 38;
                            break;
                        case 8:
                            move4 = 31;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 6:
                    switch (choice)
                    {
                        case 0:
                            move4 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 26;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 7:
                    switch (choice)
                    {
                        case 0:
                            move4 = 39;
                            break;
                        case 1:
                            move4 = 60;
                            break;
                        case 2:
                            move4 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 37;
                            break;
                        case 8:
                            move4 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 8:
                    switch (choice)
                    {
                        case 0:
                            move4 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 4;
                            break;
                        case 7:
                            move4 = 48;
                            break;
                        case 8:
                            move4 = 12;
                            break;
                        case 9:
                            move4 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 9:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 0;
                            break;
                        case 4:
                            move4 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 49;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move4 = 56;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 10:
                    switch (choice)
                    {
                        case 0:
                            move4 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 53;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 54;
                            break;
                        case 8:
                            move4 = 27;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 11:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move4 = 3;
                            break;
                        case 2:
                            move4 = 1;
                            break;
                        case 3:
                            move4 = 2;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 12:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 6;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 21;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 13:
                    switch (choice)
                    {
                        case 0:
                            move4 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 22;
                            break;
                        case 4:
                            move4 = 20;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 28;
                            break;
                        case 7:
                            move4 = 24;
                            break;
                        case 8:
                            move4 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 14:
                    switch (choice)
                    {
                        case 0:
                            move4 = 13;
                            break;
                        case 1:
                            move4 = 45;
                            break;
                        case 2:
                            move4 = 19;
                            break;
                        case 3:
                            move4 = 46;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 20;
                            break;
                        case 6:
                            move4 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move4 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 15:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move4 = 19;
                            break;
                        case 2:
                            move4 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 61;
                            break;
                        case 5:
                            move4 = 21;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move4 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 16:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move4 = 2;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 3;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 4;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 11;
                            break;
                        case 8:
                            move4 = 17;
                            break;
                        case 9:
                            move4 = 48;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 17:
                    switch (choice)
                    {
                        case 0:
                            move4 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 17;
                            break;
                        case 3:
                            move4 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 64;
                            break;
                        case 6:
                            move4 = 41;
                            break;
                        case 7:
                            move4 = 55;
                            break;
                        case 8:
                            move4 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 18:
                    switch (choice)
                    {
                        case 0:
                            move4 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 1;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 47;
                            break;
                        case 5:
                            move4 = 17;
                            break;
                        case 6:
                            move4 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 19:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move4 = 46;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 50;
                            break;
                        case 9:
                            move4 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 20:
                    switch (choice)
                    {
                        case 0:
                            move4 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 64;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 5;
                            break;
                        case 7:
                            move4 = 48;
                            break;
                        case 8:
                            move4 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 21:
                    switch (choice)
                    {
                        case 0:
                            move4 = 60;
                            break;
                        case 1:
                            move4 = 32;
                            break;
                        case 2:
                            move4 = 33;
                            break;
                        case 3:
                            move4 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 64;
                            break;
                        case 6:
                            move4 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move4 = 37;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 22:
                    switch (choice)
                    {
                        case 0:
                            move4 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 2;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 11;
                            break;
                        case 8:
                            move4 = 50;
                            break;
                        case 9:
                            move4 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 23:
                    switch (choice)
                    {
                        case 0:
                            move4 = 45;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 47;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 27;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 4;
                            break;
                        case 8:
                            move4 = 29;
                            break;
                        case 9:
                            move4 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 24:
                    switch (choice)
                    {
                        case 0:
                            move4 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 18;
                            break;
                        case 8:
                            move4 = 50;
                            break;
                        case 9:
                            move4 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 25:
                    switch (choice)
                    {
                        case 0:
                            move4 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 22;
                            break;
                        case 6:
                            move4 = 20;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 29;
                            break;
                        case 9:
                            move4 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 26:
                    switch (choice)
                    {
                        case 0:
                            move4 = 59;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 32;
                            break;
                        case 3:
                            move4 = 33;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 24;
                            break;
                        case 9:
                            move4 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 27:
                    switch (choice)
                    {
                        case 0:
                            move4 = 45;
                            break;
                        case 1:
                            move4 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 0;
                            break;
                        case 5:
                            move4 = 16;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 28:
                    switch (choice)
                    {
                        case 0:
                            move4 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 16;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 28;
                            break;
                        case 5:
                            move4 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move4 = 43;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 29:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move4 = 13;
                            break;
                        case 2:
                            move4 = 60;
                            break;
                        case 3:
                            move4 = 61;
                            break;
                        case 4:
                            move4 = 41;
                            break;
                        case 5:
                            move4 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 42;
                            break;
                        case 8:
                            move4 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 30:
                    switch (choice)
                    {
                        case 0:
                            move4 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 20;
                            break;
                        case 4:
                            move4 = 27;
                            break;
                        case 5:
                            move4 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 11;
                            break;
                        case 8:
                            move4 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 31:
                    switch (choice)
                    {
                        case 0:
                            move4 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 50;
                            break;
                        case 7:
                            move4 = 43;
                            break;
                        case 8:
                            move4 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 32:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 16;
                            break;
                        case 3:
                            move4 = 17;
                            break;
                        case 4:
                            move4 = 62;
                            break;
                        case 5:
                            move4 = 64;
                            break;
                        case 6:
                            move4 = 41;
                            break;
                        case 7:
                            move4 = 18;
                            break;
                        case 8:
                            move4 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 33:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move4 = 47;
                            break;
                        case 2:
                            move4 = 33;
                            break;
                        case 3:
                            move4 = 35;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 37;
                            break;
                        case 7:
                            move4 = 50;
                            break;
                        case 8:
                            move4 = 38;
                            break;
                        case 9:
                            move4 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 34:
                    switch (choice)
                    {
                        case 0:
                            move4 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 53;
                            break;
                        case 3:
                            move4 = 63;
                            break;
                        case 4:
                            move4 = 34;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 54;
                            break;
                        case 7:
                            move4 = 49;
                            break;
                        case 8:
                            move4 = 56;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 35:
                    switch (choice)
                    {
                        case 0:
                            move4 = 46;
                            break;
                        case 1:
                            move4 = 2;
                            break;
                        case 2:
                            move4 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 48;
                            break;
                        case 6:
                            move4 = 50;
                            break;
                        case 7:
                            move4 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move4 = 44;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 36:
                    switch (choice)
                    {
                        case 0:
                            move4 = 6;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 7;
                            break;
                        case 3:
                            move4 = 8;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 11;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 17;
                            break;
                        case 8:
                            move4 = 46;
                            break;
                        case 9:
                            move4 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 37:
                    switch (choice)
                    {
                        case 0:
                            move4 = 13;
                            break;
                        case 1:
                            move4 = 19;
                            break;
                        case 2:
                            move4 = 39;
                            break;
                        case 3:
                            move4 = 32;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 36;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 38:
                    switch (choice)
                    {
                        case 0:
                            move4 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 15;
                            break;
                        case 4:
                            move4 = 16;
                            break;
                        case 5:
                            move4 = 22;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 36;
                            break;
                        case 8:
                            move4 = 38;
                            break;
                        case 9:
                            move4 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 39:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 17;
                            break;
                        case 3:
                            move4 = 9;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 10;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 5;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 40:
                    switch (choice)
                    {
                        case 0:
                            move4 = 61;
                            break;
                        case 1:
                            move4 = 21;
                            break;
                        case 2:
                            move4 = 63;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 27;
                            break;
                        case 5:
                            move4 = 7;
                            break;
                        case 6:
                            move4 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 41:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move4 = 6;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 54;
                            break;
                        case 4:
                            move4 = 7;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 37;
                            break;
                        case 7:
                            move4 = 5;
                            break;
                        case 8:
                            move4 = 50;
                            break;
                        case 9:
                            move4 = 55;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 42:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 22;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 35;
                            break;
                        case 8:
                            move4 = 56;
                            break;
                        case 9:
                            move4 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 43:
                    switch (choice)
                    {
                        case 0:
                            move4 = 32;
                            break;
                        case 1:
                            move4 = 22;
                            break;
                        case 2:
                            move4 = 17;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 36;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 8;
                            break;
                        case 7:
                            move4 = 37;
                            break;
                        case 8:
                            move4 = 38;
                            break;
                        case 9:
                            move4 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 44:
                    switch (choice)
                    {
                        case 0:
                            move4 = 39;
                            break;
                        case 1:
                            move4 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 18;
                            break;
                        case 8:
                            move4 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 45:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 2;
                            break;
                        case 3:
                            move4 = 6;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move4 = 54;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move4 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 46:
                    switch (choice)
                    {
                        case 0:
                            move4 = 45;
                            break;
                        case 1:
                            move4 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move4 = 54;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move4 = 5;
                            break;
                        case 9:
                            move4 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 47:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move4 = 15;
                            break;
                        case 3:
                            move4 = 16;
                            break;
                        case 4:
                            move4 = 52;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move4 = 18;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 48:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 52;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move4 = 29;
                            break;
                        case 8:
                            move4 = 56;
                            break;
                        case 9:
                            move4 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 49:
                    switch (choice)
                    {
                        case 0:
                            move4 = 59;
                            break;
                        case 1:
                            move4 = 19;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move4 = 1;
                            break;
                        case 4:
                            move4 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move4 = 27;
                            break;
                        case 7:
                            move4 = 28;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                default:
                    Debug.Log("Creature choice error on move selection.");
                    break;

            }

        }
        else if (playerTurn == 1)
        {

            ChooseMovesNextButton.SetActive(false);

            switch (player2CreatureChoice)
            {
                case 0:
                    switch (choice)
                    {
                        case 0:
                            move8 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 61;
                            break;
                        case 3:
                            move8 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 29;
                            break;
                        case 9:
                            move8 = 12;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 1:
                    switch (choice)
                    {
                        case 0:
                            move8 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 28;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 35;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 37;
                            break;
                        case 8:
                            move8 = 38;
                            break;
                        case 9:
                            move8 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 2:
                    switch (choice)
                    {
                        case 0:
                            move8 = 39;
                            break;
                        case 1:
                            move8 = 40;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 5;
                            break;
                        case 6:
                            move8 = 43;
                            break;
                        case 7:
                            move8 = 12;
                            break;
                        case 8:
                            move8 = 56;
                            break;
                        case 9:
                            move8 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 3:
                    switch (choice)
                    {
                        case 0:
                            move8 = 13;
                            break;
                        case 1:
                            move8 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 16;
                            break;
                        case 5:
                            move8 = 20;
                            break;
                        case 6:
                            move8 = 24;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 4:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move8 = 61;
                            break;
                        case 2:
                            move8 = 34;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 8;
                            break;
                        case 6:
                            move8 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 5:
                    switch (choice)
                    {
                        case 0:
                            move8 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 15;
                            break;
                        case 3:
                            move8 = 16;
                            break;
                        case 4:
                            move8 = 22;
                            break;
                        case 5:
                            move8 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 38;
                            break;
                        case 8:
                            move8 = 31;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 6:
                    switch (choice)
                    {
                        case 0:
                            move8 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 26;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 7:
                    switch (choice)
                    {
                        case 0:
                            move8 = 39;
                            break;
                        case 1:
                            move8 = 60;
                            break;
                        case 2:
                            move8 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 37;
                            break;
                        case 8:
                            move8 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 8:
                    switch (choice)
                    {
                        case 0:
                            move8 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 4;
                            break;
                        case 7:
                            move8 = 48;
                            break;
                        case 8:
                            move8 = 12;
                            break;
                        case 9:
                            move8 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 9:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 0;
                            break;
                        case 4:
                            move8 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 49;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move8 = 56;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 10:
                    switch (choice)
                    {
                        case 0:
                            move8 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 53;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 54;
                            break;
                        case 8:
                            move8 = 27;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 11:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move8 = 3;
                            break;
                        case 2:
                            move8 = 1;
                            break;
                        case 3:
                            move8 = 2;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 12:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 6;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 21;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 13:
                    switch (choice)
                    {
                        case 0:
                            move8 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 22;
                            break;
                        case 4:
                            move8 = 20;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 28;
                            break;
                        case 7:
                            move8 = 24;
                            break;
                        case 8:
                            move8 = 37;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 14:
                    switch (choice)
                    {
                        case 0:
                            move8 = 13;
                            break;
                        case 1:
                            move8 = 45;
                            break;
                        case 2:
                            move8 = 19;
                            break;
                        case 3:
                            move8 = 46;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 20;
                            break;
                        case 6:
                            move8 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move5 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 15:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move8 = 19;
                            break;
                        case 2:
                            move8 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 61;
                            break;
                        case 5:
                            move8 = 21;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move8 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 16:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move8 = 2;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 3;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 4;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 11;
                            break;
                        case 8:
                            move8 = 17;
                            break;
                        case 9:
                            move8 = 48;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 17:
                    switch (choice)
                    {
                        case 0:
                            move8 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 17;
                            break;
                        case 3:
                            move8 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 64;
                            break;
                        case 6:
                            move8 = 41;
                            break;
                        case 7:
                            move8 = 55;
                            break;
                        case 8:
                            move8 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 18:
                    switch (choice)
                    {
                        case 0:
                            move8 = 13;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 1;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 47;
                            break;
                        case 5:
                            move8 = 17;
                            break;
                        case 6:
                            move8 = 34;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 19:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move8 = 46;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 50;
                            break;
                        case 9:
                            move8 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 20:
                    switch (choice)
                    {
                        case 0:
                            move8 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 60;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 64;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 5;
                            break;
                        case 7:
                            move8 = 48;
                            break;
                        case 8:
                            move8 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 21:
                    switch (choice)
                    {
                        case 0:
                            move8 = 60;
                            break;
                        case 1:
                            move8 = 32;
                            break;
                        case 2:
                            move8 = 33;
                            break;
                        case 3:
                            move8 = 63;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 64;
                            break;
                        case 6:
                            move8 = 27;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move8 = 37;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 22:
                    switch (choice)
                    {
                        case 0:
                            move8 = 46;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 2;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 47;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 11;
                            break;
                        case 8:
                            move8 = 50;
                            break;
                        case 9:
                            move8 = 51;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 23:
                    switch (choice)
                    {
                        case 0:
                            move8 = 45;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 47;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 27;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 4;
                            break;
                        case 8:
                            move8 = 29;
                            break;
                        case 9:
                            move8 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 24:
                    switch (choice)
                    {
                        case 0:
                            move8 = 60;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 18;
                            break;
                        case 8:
                            move8 = 50;
                            break;
                        case 9:
                            move8 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 25:
                    switch (choice)
                    {
                        case 0:
                            move8 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 15;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 22;
                            break;
                        case 6:
                            move8 = 20;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 29;
                            break;
                        case 9:
                            move8 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 26:
                    switch (choice)
                    {
                        case 0:
                            move8 = 59;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 32;
                            break;
                        case 3:
                            move8 = 33;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 20;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 24;
                            break;
                        case 9:
                            move8 = 11;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 27:
                    switch (choice)
                    {
                        case 0:
                            move8 = 45;
                            break;
                        case 1:
                            move8 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 0;
                            break;
                        case 5:
                            move8 = 16;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 49;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 28:
                    switch (choice)
                    {
                        case 0:
                            move8 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 16;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 28;
                            break;
                        case 5:
                            move8 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move8 = 43;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 29:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move8 = 13;
                            break;
                        case 2:
                            move8 = 60;
                            break;
                        case 3:
                            move8 = 61;
                            break;
                        case 4:
                            move8 = 41;
                            break;
                        case 5:
                            move8 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 42;
                            break;
                        case 8:
                            move8 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 30:
                    switch (choice)
                    {
                        case 0:
                            move8 = 25;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 20;
                            break;
                        case 4:
                            move8 = 27;
                            break;
                        case 5:
                            move8 = 7;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 11;
                            break;
                        case 8:
                            move8 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 31:
                    switch (choice)
                    {
                        case 0:
                            move8 = 39;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 50;
                            break;
                        case 7:
                            move8 = 43;
                            break;
                        case 8:
                            move8 = 12;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 32:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 16;
                            break;
                        case 3:
                            move8 = 17;
                            break;
                        case 4:
                            move8 = 62;
                            break;
                        case 5:
                            move8 = 64;
                            break;
                        case 6:
                            move8 = 41;
                            break;
                        case 7:
                            move8 = 18;
                            break;
                        case 8:
                            move8 = 38;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 33:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move8 = 47;
                            break;
                        case 2:
                            move8 = 33;
                            break;
                        case 3:
                            move8 = 35;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 37;
                            break;
                        case 7:
                            move8 = 50;
                            break;
                        case 8:
                            move8 = 38;
                            break;
                        case 9:
                            move8 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 34:
                    switch (choice)
                    {
                        case 0:
                            move8 = 58;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 53;
                            break;
                        case 3:
                            move8 = 63;
                            break;
                        case 4:
                            move8 = 34;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 54;
                            break;
                        case 7:
                            move8 = 49;
                            break;
                        case 8:
                            move8 = 56;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 35:
                    switch (choice)
                    {
                        case 0:
                            move8 = 46;
                            break;
                        case 1:
                            move8 = 2;
                            break;
                        case 2:
                            move8 = 41;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 48;
                            break;
                        case 6:
                            move8 = 50;
                            break;
                        case 7:
                            move8 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move8 = 44;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 36:
                    switch (choice)
                    {
                        case 0:
                            move8 = 6;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 7;
                            break;
                        case 3:
                            move8 = 8;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 11;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 17;
                            break;
                        case 8:
                            move8 = 46;
                            break;
                        case 9:
                            move8 = 49;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 37:
                    switch (choice)
                    {
                        case 0:
                            move8 = 13;
                            break;
                        case 1:
                            move8 = 19;
                            break;
                        case 2:
                            move8 = 39;
                            break;
                        case 3:
                            move8 = 32;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 36;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 38:
                    switch (choice)
                    {
                        case 0:
                            move8 = 14;
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 15;
                            break;
                        case 4:
                            move8 = 16;
                            break;
                        case 5:
                            move8 = 22;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 36;
                            break;
                        case 8:
                            move8 = 38;
                            break;
                        case 9:
                            move8 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 39:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 17;
                            break;
                        case 3:
                            move8 = 9;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 10;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 5;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 40:
                    switch (choice)
                    {
                        case 0:
                            move8 = 61;
                            break;
                        case 1:
                            move8 = 21;
                            break;
                        case 2:
                            move8 = 63;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 27;
                            break;
                        case 5:
                            move8 = 7;
                            break;
                        case 6:
                            move8 = 9;
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 41:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            move8 = 6;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 54;
                            break;
                        case 4:
                            move8 = 7;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 37;
                            break;
                        case 7:
                            move8 = 5;
                            break;
                        case 8:
                            move8 = 50;
                            break;
                        case 9:
                            move8 = 55;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 42:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 22;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 27;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 35;
                            break;
                        case 8:
                            move8 = 56;
                            break;
                        case 9:
                            move8 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 43:
                    switch (choice)
                    {
                        case 0:
                            move8 = 32;
                            break;
                        case 1:
                            move8 = 22;
                            break;
                        case 2:
                            move8 = 17;
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 36;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 8;
                            break;
                        case 7:
                            move8 = 37;
                            break;
                        case 8:
                            move8 = 38;
                            break;
                        case 9:
                            move8 = 31;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 44:
                    switch (choice)
                    {
                        case 0:
                            move8 = 39;
                            break;
                        case 1:
                            move8 = 25;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 18;
                            break;
                        case 8:
                            move8 = 43;
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 45:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 2;
                            break;
                        case 3:
                            move8 = 6;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            move8 = 54;
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 12;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move8 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 46:
                    switch (choice)
                    {
                        case 0:
                            move8 = 45;
                            break;
                        case 1:
                            move8 = 60;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 4:
                            move8 = 54;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            move8 = 5;
                            break;
                        case 9:
                            move8 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 47:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            move8 = 15;
                            break;
                        case 3:
                            move8 = 16;
                            break;
                        case 4:
                            move8 = 52;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            move8 = 18;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 48:
                    switch (choice)
                    {
                        case 0:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 1:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 52;
                            break;
                        case 4:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 7:
                            move8 = 29;
                            break;
                        case 8:
                            move8 = 56;
                            break;
                        case 9:
                            move8 = 57;
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                case 49:
                    switch (choice)
                    {
                        case 0:
                            move8 = 59;
                            break;
                        case 1:
                            move8 = 19;
                            break;
                        case 2:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 3:
                            move8 = 1;
                            break;
                        case 4:
                            move8 = 3;
                            break;
                        case 5:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 6:
                            move8 = 27;
                            break;
                        case 7:
                            move8 = 28;
                            break;
                        case 8:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        case 9:
                            Debug.Log("Not implemented, choose a different move");
                            break;
                        default:
                            Debug.Log("Move choice error");
                            break;

                    }
                    break;
                default:
                    Debug.Log("Creature choice error on move selection.");
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
                case 0:
                    foreach (string option in AngeelaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 1:
                    foreach (string option in ArtilerestMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 2:
                    foreach (string option in BalanceaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 3:
                    foreach (string option in BlazzeruseMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 4:
                    foreach (string option in CavenardMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 5:
                    foreach (string option in CharrageMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 6:
                    foreach (string option in ContrelaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 7:
                    foreach (string option in CrestMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 8:
                    foreach (string option in CrokaraMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 9:
                    foreach (string option in CrotainMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 10:
                    foreach (string option in DivaneceMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 11:
                    foreach (string option in DrafskaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 12:
                    foreach (string option in EurrupterMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 13:
                    foreach (string option in FearulesMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 14:
                    foreach (string option in FlamernaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 15:
                    foreach (string option in FlamewingMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 16:
                    foreach (string option in FransMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 17:
                    foreach (string option in GalektyMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 18:
                    foreach (string option in GraferMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 19:
                    foreach (string option in GregerMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 20:
                    foreach (string option in GugonsenMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 21:
                    foreach (string option in HairretMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 22:
                    foreach (string option in HarstMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 23:
                    foreach (string option in HonsenMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 24:
                    foreach (string option in HypersolMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 25:
                    foreach (string option in InfernoMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 26:
                    foreach (string option in InfsuceMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 27:
                    foreach (string option in LichterMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 28:
                    foreach (string option in LightgenMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 29:
                    foreach (string option in LingerusMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 30:
                    foreach (string option in LioughtMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 31:
                    foreach (string option in NatureaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 32:
                    foreach (string option in OrkasMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 33:
                    foreach (string option in OverhaulMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 34:
                    foreach (string option in PengunMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 35:
                    foreach (string option in PoisentaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 36:
                    foreach (string option in QuakeMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 37:
                    foreach (string option in RevelMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 38:
                    foreach (string option in RockestMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 39:
                    foreach (string option in RowlerMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 40:
                    foreach (string option in SanardMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 41:
                    foreach (string option in SirgeruseMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 42:
                    foreach (string option in SteamerMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 43:
                    foreach (string option in StelargeMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 44:
                    foreach (string option in SunelaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 45:
                    foreach (string option in TerraionMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 46:
                    foreach (string option in TimeronMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 47:
                    foreach (string option in WatkenMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 48:
                    foreach (string option in WatresMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 49:
                    foreach (string option in YaunMoves)
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
            Move1DD.ClearOptions();
            Move2DD.ClearOptions();
            Move3DD.ClearOptions();
            Move4DD.ClearOptions();
            PlayerCreatureChoiceText.text = "Player 2, choose your moves";
            playerTurn = 1;

            switch (player2CreatureChoice)
            {
                case 0:
                    foreach (string option in AngeelaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 1:
                    foreach (string option in ArtilerestMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 2:
                    foreach (string option in BalanceaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 3:
                    foreach (string option in BlazzeruseMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 4:
                    foreach (string option in CavenardMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 5:
                    foreach (string option in CharrageMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 6:
                    foreach (string option in ContrelaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 7:
                    foreach (string option in CrestMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 8:
                    foreach (string option in CrokaraMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 9:
                    foreach (string option in CrotainMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 10:
                    foreach (string option in DivaneceMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 11:
                    foreach (string option in DrafskaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 12:
                    foreach (string option in EurrupterMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 13:
                    foreach (string option in FearulesMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 14:
                    foreach (string option in FlamernaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 15:
                    foreach (string option in FlamewingMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 16:
                    foreach (string option in FransMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 17:
                    foreach (string option in GalektyMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 18:
                    foreach (string option in GraferMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 19:
                    foreach (string option in GregerMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 20:
                    foreach (string option in GugonsenMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 21:
                    foreach (string option in HairretMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 22:
                    foreach (string option in HarstMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 23:
                    foreach (string option in HonsenMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 24:
                    foreach (string option in HypersolMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 25:
                    foreach (string option in InfernoMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 26:
                    foreach (string option in InfsuceMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 27:
                    foreach (string option in LichterMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 28:
                    foreach (string option in LightgenMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 29:
                    foreach (string option in LingerusMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 30:
                    foreach (string option in LioughtMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 31:
                    foreach (string option in NatureaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 32:
                    foreach (string option in OrkasMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 33:
                    foreach (string option in OverhaulMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 34:
                    foreach (string option in PengunMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 35:
                    foreach (string option in PoisentaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 36:
                    foreach (string option in QuakeMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 37:
                    foreach (string option in RevelMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 38:
                    foreach (string option in RockestMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 39:
                    foreach (string option in RowlerMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 40:
                    foreach (string option in SanardMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 41:
                    foreach (string option in SirgeruseMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 42:
                    foreach (string option in SteamerMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 43:
                    foreach (string option in StelargeMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 44:
                    foreach (string option in SunelaMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 45:
                    foreach (string option in TerraionMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 46:
                    foreach (string option in TimeronMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 47:
                    foreach (string option in WatkenMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 48:
                    foreach (string option in WatresMoves)
                    {

                        Move1DD.options.Add(new Dropdown.OptionData(option));
                        Move2DD.options.Add(new Dropdown.OptionData(option));
                        Move3DD.options.Add(new Dropdown.OptionData(option));
                        Move4DD.options.Add(new Dropdown.OptionData(option));

                    }
                    break;
                case 49:
                    foreach (string option in YaunMoves)
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
