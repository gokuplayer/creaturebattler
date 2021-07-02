using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBladeScript : MonoBehaviour
{

    public int AttackSpeed = 1;
    public Vector3 AttackDirection = Vector3.right;
    public GameObject Attacker;

    private int attackPower;
    private int accuracy;
    private float totalPower;
    private float damage;

    public void Start()
    {

        Creature attacker = Attacker.gameObject.GetComponent<Creature>();
        attackPower = Random.Range(40, 60);
        accuracy = Random.Range(0, 100);
        totalPower = attackPower + attacker.physical;

    }

    public void Update()
    {

        transform.Translate(AttackDirection * AttackSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Creature")
        {

            if (accuracy <= 65)
            {

                Creature enemy = other.gameObject.GetComponent<Creature>();
                damage = totalPower - enemy.physDef;
                Debug.Log("Attack hit!");
                Destroy(this.gameObject);

                Creature attacker = Attacker.gameObject.GetComponent<Creature>();

                if (damage > 0)
                {

                    if (enemy.health - damage <= 0)
                    {

                        Destroy(other.gameObject);

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

}
