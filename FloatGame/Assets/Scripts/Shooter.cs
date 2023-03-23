using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Bullet;
    public Transform spawn;
    public float bulletForce = 5000;
    public float shootRate = .5f;
    private float shootRateTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("si");
            if(Time.deltaTime>shootRateTime)
            {
                Debug.Log("operando");
                GameObject newBullet;
                newBullet = Instantiate(Bullet, spawn.position, spawn.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawn.forward * bulletForce);
                Destroy(newBullet, 2);
            }
        }
    }
}
