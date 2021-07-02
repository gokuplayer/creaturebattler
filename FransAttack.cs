using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FransAttack : MonoBehaviour
{

    public int AttackSpeed = 1;
    public Vector3 AttackDirection = Vector3.right;
    public GameObject Attacker;
    private float attackPower;
    private float Damage;

    public void Start()
    {

        Creature attacker = Attacker.gameObject.GetComponent<Creature>();
        attackPower = attacker.physical;

    }

    public void Update()
    {

        transform.Translate(AttackDirection * AttackSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Creature")
        {

            Creature enemy = other.gameObject.GetComponent<Creature>();
            Damage = attackPower - enemy.physDef;
            Debug.Log("Attack hit!");
            Destroy(this.gameObject);

            if (Damage > 0)
            {

                if (enemy.health - Damage <= 0)
                {

                    Destroy(other.gameObject);

                }
                else
                {

                    enemy.health -= Damage;
                    Debug.Log(enemy.health);

                }

            }
            else
            {

                Debug.Log("No damage!");

            }

        }

    }

}
