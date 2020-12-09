using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // объект для связи объекта в юнити с кодом
    Text healthText;
    // объект для связи текущего скрипта с объектом игрока
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        // связли юнити с кодом
        healthText = GetComponent<Text>();
        // связали скрипт с объекто игрока
        player = FindObjectOfType<Player>();
    }


    void Update()
    {
        // при получении урона меняем значение здоровья на экране
        healthText.text = player.GetHealth().ToString();
    }

}
