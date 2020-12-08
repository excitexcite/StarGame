using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{

    [SerializeField] int health = 100;
    [SerializeField] float moveSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -Time.deltaTime * moveSpeed, 0);
    }

    public int GetHealth() { return health; }

    public void PickUpBonus() { Destroy(gameObject); }
}
