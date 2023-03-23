using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyDucksSpawn : MonoBehaviour
{
    public GameObject luckyDuck;
    public int xPos;
    public int zPos;
    public int luckyDuckCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(luckyDuckDrop());
    }

    IEnumerator luckyDuckDrop()
    {
        while(luckyDuckCount<7)
        {
            xPos = Random.Range(-1, 1000);
            zPos = Random.Range(-1, 1000);
            Instantiate(luckyDuck, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            luckyDuckCount += 1;
        }
    }
}
