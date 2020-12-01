using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // переменная кол-во урона
    [SerializeField] int damage = 100;

    // функция-гетер для получения значения урока
    public int GetDamage()
    {
        return damage;
    }

    // функция для уничтожения объекта лазера
    public void Hit()
    {
        Destroy(gameObject);
    }
}
