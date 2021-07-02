using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainingStrikeScript : MonoBehaviour
{

    public int AttackSpeed = 1;
    public Vector3 AttackDirection = Vector3.right;
    public GameObject Attacker;

    private int attackPower;
    private int accuracy;
    private float maxHealth;
    private float totalPower;
    private float damage;
    private float healthGain;

    public void Start()
    {

        Creature attacker = Attacker.gameObject.GetComponent<Creature>();
        attackPower = Random.Range(30, 50);
        accuracy = Random.Range(0, 100);
        totalPower = attackPower + attacker.physical;
        maxHealth = attacker.health;

    }

    public void Update()
    {

        transform.Translate(AttackDirection * AttackSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Creature")
        {

            if (accuracy <= 60)
            {

                Creature enemy = other.gameObject.GetComponent<Creature>();
                damage = totalPower - enemy.physDef;
                Debug.Log("Attack hit!");
                Destroy(this.gameObject);

                Creature attacker = Attacker.gameObject.GetComponent<Creature>();

                if (attacker.health < maxHealth)
                {

                    healthGain = damage / 2;
                    attacker.health += healthGain;
                    Debug.Log("Healed for " + healthGain + " health!");

                }
                else
                {

                    Debug.Log(attacker.name + " is already at max health and cannot heal any more!");

                }

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
