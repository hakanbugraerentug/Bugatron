using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float projectileDamage;
    public float projectileMaxHealthDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float CalculateDamage(float maxHealth)
    {
        return maxHealth * projectileMaxHealthDamage/100 + projectileDamage;
    }
}
