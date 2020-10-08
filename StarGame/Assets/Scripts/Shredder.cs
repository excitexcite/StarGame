using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    // функция, которая срабатывает как только срабатывает триггер на столкновение (соприкасание) лазера и шредера
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision.gameObject - уничтожанием столкнувшийся с шредером gameObject
        Destroy(collision.gameObject);
    }

}
