using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    public GameObject PlayButton;
    public GameObject AttackButton;

    public GameObject FransObject;

    void Start()
    {

        PlayButton.SetActive(true);
        AttackButton.SetActive(false);

    }

    public void Play()
    {

        PlayButton.SetActive(false);
        AttackButton.SetActive(true);
        Instantiate(FransObject, new Vector3(1, 0, 2), Quaternion.identity);
        Instantiate(FransObject, new Vector3(-1, 0, 2), Quaternion.identity);

    }

}
