using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRayScript : MonoBehaviour, IMove
{

    public int AttackSpeed = 1;
    public string AttackerName;
    public Vector3 AttackDirection;
    public GameObject Attacker, MoveButtons, AttackObject;
    public Creature attacker;

    private int attackPower;
    private int accuracy;
    private float totalPower;
    private float damage;

    [SerializeField]
    private string m_name;
    [SerializeField]
    private string m_type;
    [SerializeField]
    private int m_uses;

    public string m_Name
    {
        get { return name; }
        set { name = value; }
    }

    public string m_Type
    {
        get { return m_type; }
        set { m_type = value; }
    }

    public int m_Uses
    {

        get { return m_uses; }
        set { m_uses = value; }

    }

    public void Start()
    {

        if (GameControllerScript.playerTurn == 2)
        {

            Attacker = GameObject.FindWithTag("Player1");

        }
        else if (GameControllerScript.playerTurn == 1)
        {

            Attacker = GameObject.FindWithTag("Player2");

        }

        attacker = Attacker.gameObject.GetComponent<Creature>();
        attackPower = Random.Range(40, 60);
        accuracy = Random.Range(0, 100);
        totalPower = attackPower + attacker.ranged;

    }

    public void Update()
    {

        if (GameControllerScript.playerTurn == 1)
        {

            AttackDirection = Vector3.left;

        }
        else if (GameControllerScript.playerTurn == 2)
        {

            AttackDirection = Vector3.right;

        }

        transform.Translate(AttackDirection * AttackSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {

            if (accuracy <= 60)
            {

                Creature enemy = other.gameObject.GetComponent<Creature>();
                damage = totalPower - enemy.ranDef;

                if (m_type == attacker.type1 || m_type == attacker.type2)
                {

                    damage *= 1.5f;

                    Debug.Log("STAB damage!");

                }

                if (TypeChartScript.strengthDict[m_type].Contains(enemy.type1))
                {

                    damage *= 2f;

                    Debug.Log("It's Super Effective!");

                }

                Debug.Log("Attack hit!");
                Destroy(this.gameObject);

                if (damage > 0)
                {

                    if (enemy.health - damage <= 0)
                    {

                        Destroy(other.gameObject);
                        GameControllerScript.MoveListButton.SetActive(false);
                        GameControllerScript.ReplayButton.SetActive(true);

                        if (GameControllerScript.playerTurn == 1)
                        {

                            GameControllerScript.WinnerText.text = "Player 2 wins!";

                        }
                        else if (GameControllerScript.playerTurn == 2)
                        {

                            GameControllerScript.WinnerText.text = "Player 1 wins!";

                        }

                    }
                    else
                    {

                        enemy.health -= damage;
                        Debug.Log(enemy.health);

                    }

                }
                else
                {

                    Debug.Log("No damage!");

                }

            }
            else
            {

                Destroy(this.gameObject);
                Debug.Log("Attack missed!");

            }

        }

    }

    public void DarkRayAttack()
    {

        AttackObject = this.gameObject;

        if (GameControllerScript.playerTurn == 1)
        {

            Instantiate(AttackObject, new Vector3(-0.5f, 0, 2), Quaternion.identity);
            Attacker = GameObject.Find("Player 1");
            MoveButtons = GameObject.Find("Player1Moves");
            GameControllerScript.playerTurn = 2;

        }
        else if (GameControllerScript.playerTurn == 2)
        {

            Instantiate(AttackObject, new Vector3(0.5f, 0, 2), Quaternion.identity);
            Attacker = GameObject.Find("Player 2");
            MoveButtons = GameObject.Find("Player2Moves");
            GameControllerScript.playerTurn = 1;

        }

        Creature self = Attacker.gameObject.GetComponent<Creature>();
        AttackerName = self.c_name;
        Debug.Log(AttackerName + " used Dark Ray!");
        MoveButtons.SetActive(false);
        GameControllerScript.MoveListButton.SetActive(true);

    }

}
