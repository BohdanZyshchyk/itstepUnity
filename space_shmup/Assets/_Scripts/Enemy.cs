using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f; // Скорость в м/с
    public float fireRate = 0.3f; // Секунд между выстрелами (не используется)
    public float health = 10;
    public int score = 100; // Очки за уничтожение этого корабля

    private BoundsCheck bndCheck;
    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (bndCheck != null && !bndCheck.isOnScreen)
        {
            // Убедиться, что корабль вышел за нижнюю границу экрана
            if (pos.y <bndCheck.camHeight - bndCheck.radius)
            {
                // Корабль за нижней границей, поэтому его нужно уничтожить
                Destroy(gameObject);
            }
        }
    }

    private void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }
}
