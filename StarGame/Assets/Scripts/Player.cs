using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // SerializeField позволяет увидить атрибут приватного поля объекта класса в инспекторе
    // иначе такаая возможность доступна только для публичных полей 
    [SerializeField] float moveSpeed = 10f;
    // отступ для корабля
    [SerializeField] float padding = 1f;
    // скорость движения лазера
    [SerializeField] float laserSpeed = 20f;
    // время между созданием копий лазера
    [SerializeField] float laserFiringPeriod = 0.1f;
    // объект для управления копиями лазера
    [SerializeField] GameObject laserPrefab;

    // объект-корутин для управления остановкой стрельбы игрока
    Coroutine firingCoroutine;
    // определили переменные, которые будут хранить точки-границы экрана
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // функция, которая в момент запуска игры инициализирует крайние точки границ по Х и по У
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    // фуекция-корутин для стрельбы
    IEnumerator FireContinuously()
    {
        while (true)
        {
            // Instantiate(что создаем, позиция в момент создания, вращение)
            // laserPrefab - копия лазера, transform.position - создаем в том месте, где находится игрок
            // Quaternion.identity - при создании не вращаем объект
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            // говорим элементу Rigidbody2D принять в качестве своей скорости вектор Vector2(0, projectileSpeed),
            // где projectileSpeed - скорость движения лазера (изменение координаты У)
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            yield return new WaitForSeconds(laserFiringPeriod);
        }
    }

    // функция для стрельбы
    private void Fire()
    {
        
        // если нажали на кнопку Fire1, то есть в нашем случае - пробел
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        // если отпустили клавишу пробел
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    public void FireOn(){
        firingCoroutine = StartCoroutine(FireContinuously());
    }
    public void FireOff(){
        StopCoroutine(firingCoroutine);
    }

    // метод, который отвечает за движение игрока
    private void Move()
    {
        /*         "дельта", на которую происходит движение в лево/право
                 Input.GetAxis - использование горизонтальной оси (оси Х) для движения
                 Time.deltaTime - фича, которая необходима, чтобы движение происходило с одинаковой скоростью как на быстрых
                 машинах, так и на медленных
                 Все вышеперечисленное справедливо и для движения по оси У
        */
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        // Mathf.Clamp() возращает значение между min и max; благодаря этому мы никогда не выйдем за границы 
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    public void MoveJoys(Vector2 vec)
    {
        /*         "дельта", на которую происходит движение в лево/право
                 Input.GetAxis - использование горизонтальной оси (оси Х) для движения
                 Time.deltaTime - фича, которая необходима, чтобы движение происходило с одинаковой скоростью как на быстрых
                 машинах, так и на медленных
                 Все вышеперечисленное справедливо и для движения по оси У
        */
        float deltaX = vec.x * Time.deltaTime * moveSpeed;
        // Mathf.Clamp() возращает значение между min и max; благодаря этому мы никогда не выйдем за границы 
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float deltaY = vec.y * Time.deltaTime * moveSpeed;
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
}
