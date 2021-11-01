using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    bool healthReduced;
    Enemy enemy;
    public float InvulTime;
    float CurrentTime;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        CurrentTime = InvulTime;
    }

    void Update()
    {
        if (enemy.isDamaged)
        {
            CurrentTime = CurrentTime - (1 * Time.deltaTime);

            if (!healthReduced)
            {
                enemy.Health--;
                Debug.Log("Damaged");
                healthReduced = true;
            }

            if (CurrentTime <= 0)
            {
                CurrentTime = InvulTime;
                healthReduced = false;
                enemy.isDamaged = false;
            }
        }

        if (enemy.Health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
