using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool isFiring = false;
    public GameObject bullet;
    public float fireRate = 3;
    public float projectileSpeed = 200;
    public float projectileLifeTime = 5f;
    public ParticleSystem fireEffect;

    Coroutine shoot;

    public AudioSource fireSound;

    [SerializeField] bool useAI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring)
        {
            if (shoot == null)
            {
                fireEffect.Play();
                print("1");
                shoot = StartCoroutine(ShootContinuously());
            }
        }
        else
        {
            if (shoot != null)
            {
                StopCoroutine(shoot);
                print("2");
                shoot = null;
            }
        }
        
    }

    IEnumerator ShootContinuously()
    {
        while (true)
        {
            fireSound.Play();
            GameObject projectile = Instantiate(bullet, transform.Find("ProjectileSpawnPoint").transform.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = (useAI? Vector3.down:Vector3.up) * projectileSpeed;
            Destroy(projectile, projectileLifeTime);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
