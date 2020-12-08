using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // здоровье врага
    [SerializeField] float health = 100;
    // время между выстрелами
    [SerializeField] float shootTime;
    // минимальное время между выстрелами
    [SerializeField] float minShootTime = 0.2f;
    // максимальное время между выстрелами
    [SerializeField] float maxShootTime = 3f;
    // скорость лазера
    [SerializeField] float laserSpeed = 10f;
    // моделька лазера
    [SerializeField] GameObject laserPrefab;

    // объект для связи Material`a с кодом
    [SerializeField] GameObject deathVFX;
    // длительность взрыва
    [SerializeField] float durationOfExplosion = 1f;

    // объект для связи аудиоэффекта с кодом
    [SerializeField] AudioClip deathSFV;
    // громкость звука смерти
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.5f;
    // объект для связи аудиоэффекта с кодом
    [SerializeField] AudioClip shootSFV;
    // громкость звука стрельбы
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        // определили время между выстрелами из промежутка
        shootTime = UnityEngine.Random.Range(minShootTime, maxShootTime);
    }

    // Update is called once per frame
    void Update()
    {
        // запускает отсчёт времени и стреляем
        CountDownAndShoot();
    }

    // функция для отсчёта времени между выстрелами
    private void CountDownAndShoot()
    {
        shootTime -= Time.deltaTime;
        // как только счетчик достиг 0 - стреляем
        if (shootTime <= 0f)
        {
            Fire();
            // после выстрела получаем новое значение для отсчёта до след выстрела
            shootTime = UnityEngine.Random.Range(minShootTime, maxShootTime);
        }
    }

    // функция для стрельбы
    private void Fire()
    {
        // создали лазер
        GameObject laser = Instantiate(
            laserPrefab,
            transform.position,
            Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        // создание звука в момент стрыльбы игрока
        AudioSource.PlayClipAtPoint(shootSFV, Camera.main.transform.position, shootSoundVolume);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // во врага будет попадать лазер игрок, с ним у нас связан скрипт и соответственно объект DamageDealer
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        // если по какой-то причине лазер не имеет компонента DamageDealer - не обрабатывать выстрел
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    // функция для обработки попадания по врагу
    private void ProcessHit(DamageDealer damageDealer)
    {
        // уменьшение кол-во здоровья врага на кол-во урона
        health -= damageDealer.GetDamage();
        // при попадании уничтожили лазер
        damageDealer.Hit();
        // если здоровье меньше нуля, уничтожаем врага
        if (health <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        Destroy(gameObject);

        // объект для создания эффекта взрыва
        GameObject explosion;
        if (gameObject.tag == "boss")
        {
            foreach (Transform child in transform)
            {
                explosion = Instantiate(deathVFX, child.position, child.rotation);
                Destroy(explosion, durationOfExplosion);
            }
        }

        // объект для создания эффекта взрыва
        explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        // эффект длится durationOfExplosion и уничтожается
        Destroy(explosion, durationOfExplosion);
        // проигрывает звук в момент уничтожение врага в позиции камеры (чтобы слышать все звуки одинакового)
        // с громкостью deathSoundVolume
        AudioSource.PlayClipAtPoint(deathSFV, Camera.main.transform.position, deathSoundVolume);
    }
}
