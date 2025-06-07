using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepsi : MonoBehaviour
{
   
    public Transform pointA;    // Точка А
    public Transform pointB;    // Точка Б
    public float speed = 3f;    // Швидкість руху

    private Vector3 target;     // Поточна ціль

    void Start()
    {
        target = pointB.position;  // Починаємо рух до точки B
    }

    void Update()
    {
        // Рухаємося до цілі
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        // transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        // Якщо досягли точки, міняємо ціль
        if (Vector3.Distance(transform.position, target) < 0.3f)
        {
            if (target == pointB.position)
                target = pointA.position;
            else
                target = pointB.position;
        }
        //
        // Поворот ворога у напрямку руху
        Vector3 direction = target - transform.position;
        if (direction.x > 0)
            transform.localScale = new Vector3(0.07f, 0.08f, 1);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-0.07f, 0.08f, 1);
    }
}