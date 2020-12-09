using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> meteors;
    [SerializeField] float padding = 1.5f;
    [SerializeField] float timeBeteewnSpawns = 2f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(true)
        {
            yield return StartCoroutine(SpawnMeteors());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMeteors()
    {
        int chance = Random.Range(0, 11);
        if (chance > 8)
        {
            Debug.Log("FUCKING RANDOM HERE!!!");
            yield return StartCoroutine(CreateMeteors());
            
        }
    }

    IEnumerator CreateMeteors()
    {
        Camera camera = Camera.main;
        int meteorNumber = Random.Range(0, meteors.Count);
        Vector3 position = new Vector3(Random.Range(-5.5f, 5.5f), 11, 0);
        //float xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        //float xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        GameObject meteor = Instantiate(meteors[meteorNumber], 
            position, 
            Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(timeBeteewnSpawns);
    }

}

