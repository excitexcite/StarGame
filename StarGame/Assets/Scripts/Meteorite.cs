using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] int damage = 100;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int health = 1000;
    // объект для связи Material`a с кодом
    [SerializeField] GameObject deathVFX;
    // длительность взрыва
    [SerializeField] float durationOfExplosion = 1f;

    // объект для связи аудиоэффекта с кодом
    [SerializeField] AudioClip deathSFV;
    // громкость звука смерти
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -Time.deltaTime * moveSpeed, 0);
    }

    public int GetDamage() { return damage; }

    public void DestroyMeteorite() { Die(); }

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
        // уменьшение кол-во здоровья метеорита на кол-во урона
        health -= damageDealer.GetDamage();
        // при попадании уничтожили лазер
        damageDealer.Hit();
        // если здоровье меньше нуля, уничтожаем метеорита
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
        // объект для создания эффекта взрыва
        explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        // эффект длится durationOfExplosion и уничтожается
        Destroy(explosion, durationOfExplosion);
        // проигрывает звук в момент уничтожение врага в позиции камеры (чтобы слышать все звуки одинакового)
        // с громкостью deathSoundVolume
        AudioSource.PlayClipAtPoint(deathSFV, Camera.main.transform.position, deathSoundVolume);
    }
}
