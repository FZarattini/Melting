using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    public float lifePoints;
    public float maxLifePoints;
    public GameObject mask;
    private float initialpos;
    public bool isDead;

    private void Start()
    {
        isDead = false;

        mask = GameObject.Find("LifeBarMask");
        initialpos = mask.transform.position.x;
        Debug.Log("inicial " + initialpos);
    }


    public void Damage(float damage)
    {
        lifePoints -= damage;
        if (lifePoints < 0)
        {
            lifePoints = 0;
            isDead = true;
            
        }

        float ratio = 1 - (lifePoints / maxLifePoints);
        mask.transform.position = new Vector3(initialpos - (initialpos * ratio), mask.transform.position.y, mask.transform.position.z);
    }

    public void Heal(float heal)
    {
        lifePoints += heal;
        if (lifePoints > maxLifePoints)
        {
            lifePoints = maxLifePoints;
        }

        float ratio = heal / maxLifePoints;
        float amountGained = ratio * initialpos;
        mask.transform.position += new Vector3(amountGained, 0f, 0f);
    }


    public float GetLife()
    {
        return lifePoints;
    }
}
