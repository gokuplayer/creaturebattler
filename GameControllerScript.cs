using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    public GameObject PlayButton, FransAttackerButton, QuakeAttackerButton, MoveListButton, AttackButton, DrainingStrikeButton, ShadowBladeButton, SmashButton, FransObject, QuakeObject;

    private string attacker;

    void Start()
    {

        PlayButton.SetActive(true);
        AttackButton.SetActive(false);
        DrainingStrikeButton.SetActive(false);
        ShadowBladeButton.SetActive(false);
        SmashButton.SetActive(false);
        FransAttackerButton.SetActive(false);
        QuakeAttackerButton.SetActive(false);
        MoveListButton.SetActive(false);

    }

    public void Play()
    {

        PlayButton.SetActive(false);
        FransAttackerButton.SetActive(true);
        QuakeAttackerButton.SetActive(true);

    }

    public void Moves()
    {

        MoveListButton.SetActive(false);
        AttackButton.SetActive(true);

        switch (attacker)
        {

            case "frans":
                DrainingStrikeButton.SetActive(true);
                ShadowBladeButton.SetActive(true);
                break;
            case "quake":
                SmashButton.SetActive(true);
                break;
            default:
                Debug.Log("Attacker not chosen. Error.");
                break;

        }

    }

    public void FransAttacker()
    {

        attacker = "frans";
        FransAttackerButton.SetActive(false);
        QuakeAttackerButton.SetActive(false);
        MoveListButton.SetActive(true);
        Instantiate(FransObject, new Vector3(1, 0, 2), Quaternion.identity);
        Instantiate(FransObject, new Vector3(-1, 0, 2), Quaternion.identity);

    }

    public void QuakeAttacker()
    {

        attacker = "quake";
        FransAttackerButton.SetActive(false);
        QuakeAttackerButton.SetActive(false);
        MoveListButton.SetActive(true);
        Instantiate(FransObject, new Vector3(1, 0, 2), Quaternion.identity);
        Instantiate(QuakeObject, new Vector3(-1, 0, 2), Quaternion.identity);

    }

}
