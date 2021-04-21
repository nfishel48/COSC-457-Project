using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("Death", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        GetComponent<EnemyMovementAI>().enabled = false;

        HeroKnight.levelSystem.AddExperience(50);

        StartCoroutine(Remove());
    }

    IEnumerator Remove() {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }
}
