using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedColor : MonoBehaviour
{
    public SpriteRenderer rend;
    Enemy enemy;

    [SerializeField]
    private Color damagedColor = Color.white;

    [SerializeField]
    private Color normalColor = Color.white;

    public void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
    }

    public void Update()
    {
        if (enemy.isDamaged)
        {
            rend.color = damagedColor;
        }
        else if (!enemy.isDamaged)
        {
            rend.color = normalColor;
        }
    }
}
