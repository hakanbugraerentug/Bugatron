using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    public bool isFiring = false;
    public GameObject bullet;
    public float fireRate = 3;
    public float projectileSpeed = 200;
    public float projectileLifeTime = 5f;
    public ParticleSystem fireEffect;

    Coroutine shoot;

    public AudioSource fireSound;
    // Start is called before the first frame update
    void Start()
    {
        isFiring = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShootContinuously());
    }

    IEnumerator ShootContinuously()
    {
        while (true)
        {
            fireSound.Play();
            GameObject projectile = Instantiate(bullet, transform.GetChild(1).transform.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Vector3.down * projectileSpeed;
            Destroy(projectile, projectileLifeTime);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
