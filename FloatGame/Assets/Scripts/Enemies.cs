using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount<70)
        {
            xPos = Random.Range(-1, 1000);
            zPos = Random.Range(-1, 1000);
            Instantiate(enemy, new Vector3(xPos, 5, zPos), Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            enemyCount += 1;
        }
    }
}
