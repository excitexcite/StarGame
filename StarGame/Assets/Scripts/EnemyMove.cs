using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // объект который отвечает за параметры волны спауна врагов
    WaveConfig waveConfig;
    // список с нашими контрольными точками для движения
    // Transform - потому что координаты экрана
    List<Transform> waypoints;
    // текущий индекс списка контрольных точек
    int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        // получили из waveConfig контрольные точки (путь)
        waypoints = waveConfig.GetWaypoints();
        // где бы корабль врага не был при запуске игры, он переходит в первую контрольную точку
        // то есть то место, откуда он начнёт движение
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // метод-сетер для указания WaveConfig для этого врага
    public void SetWaveConfig(WaveConfig config)
    {
        this.waveConfig = config;
    }


    // функция, которая отвечает за движение врагов
    private void Move()
    {
        // если враг не прошел все контрольные точки
        if (waypointIndex <= waypoints.Count - 1)
        {
            // получили из списка точку, куда будем направлятся
            var targetPosition = waypoints[waypointIndex].transform.position;
            // сделали скорость одинаковой для слабого и сильного железа
            var moveSpeed = waveConfig.GetMoveSpeed() * Time.deltaTime;
            // Vector2.MoveTowards(текущее положение, положение-цель, скорость передвижения)
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
            // как только достигли одной из контрольных точек, увеличиваем идекс для доступа к след точке
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        // иначе уничтожаем GameObject
        else
        {
            switch (gameObject.tag){
                case "boss":
                    break;

                case "Enemy":
                    Destroy(gameObject);
                    break;

            }
            
        }
    }
}
