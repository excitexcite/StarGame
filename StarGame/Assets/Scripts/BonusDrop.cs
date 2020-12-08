using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDrop : MonoBehaviour
{

    [SerializeField] List<GameObject> pills;
    private Transform enemyPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBonus()
    {
        int chance = Random.Range(1, 101);
        GameObject pill;
        if (chance <= 40)
        {
            pill = Instantiate(pills[0], enemyPosition.position, Quaternion.identity) as GameObject;
        }
        else if (chance > 40 && chance <= 70)
        {
            pill = Instantiate(pills[1], enemyPosition.position, Quaternion.identity) as GameObject;
        }
        else if (chance > 70 && chance <= 90)
        {
            pill = Instantiate(pills[2], enemyPosition.position, Quaternion.identity) as GameObject;
        }
        else
        {
            pill = Instantiate(pills[3], enemyPosition.position, Quaternion.identity) as GameObject;
        }
    }

    public void SetEnemyPosition(Transform transform)
    {
        enemyPosition = transform;
    }

}
