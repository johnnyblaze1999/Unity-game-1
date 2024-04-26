using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public Animator animator;
    public float currentHealth { get; private set; }
    public AudioSource audioEffect;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        audioEffect.time = 0.6f;
        audioEffect.Play();
        animator.SetTrigger("IsHit");

        if (currentHealth > 0)
        {

        }
        else
        {
            GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
