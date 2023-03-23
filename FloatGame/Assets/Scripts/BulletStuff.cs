using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletStuff : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI DuckCollect;
    [SerializeField] private GameObject imageWinPrefab;
    int numberCollect = 0;

    Rigidbody rigg;
    public float explForce, radius;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DuckCollect"))
        {
            numberCollect += 1;
            DuckCollect.text = numberCollect.ToString();
            if (numberCollect >= 7)
            {
                win();
            }
        }
        if(other.CompareTag("Enemy"))
        {
            rigg.AddExplosionForce(explForce, transform.position, radius);
        }
    }
    private void win()
    {
        imageWinPrefab.gameObject.SetActive(true);
    }
}
