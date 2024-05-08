using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float unitMaxHealth;
    public float unitHealth;
    public int unitWorth;
    public bool isPlayer;
    Score score;

    public AudioSource playerDeath;
    bool gameOver = false;
    public ParticleSystem explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
        unitHealth = unitMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer)
        {
            score.healthText.text = string.Format($"HEALTH = {unitHealth.ConvertTo<Int32>()}/{unitMaxHealth}");
            if (unitHealth < 0)
            {
                unitHealth = 0;
                playerDeath.Play();
                gameOver = true;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            float damageTaken = other.GetComponent<Damage>().CalculateDamage(unitMaxHealth);
            unitHealth -= damageTaken;
            Destroy(other.gameObject);
            if (unitHealth <= 0)
            {
                var explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                explosion.Play();
                Destroy(explosionEffect,2f);
                gameObject.SetActive(false);
                Destroy(gameObject,2f);
                if (transform.tag == "Enemy")
                {
                    score.score += unitWorth;
                }
            }
            
            
        }
    }
}
