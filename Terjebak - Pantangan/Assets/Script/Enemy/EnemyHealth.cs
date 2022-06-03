using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }
    private Animator anim;

    private void Awake()
    {
        currHealth = startingHealth;
        anim = GetComponent<Animator>();
        Debug.Log("Current Health: " + currHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TakeDamage(1);
            Debug.Log("Dev Mode: Press 2 for Enemy Taking Damage!");
        }
    }

    public void TakeDamage(float _damage)
    {
        currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);

        if (currHealth > 0)
        {
            anim.SetTrigger("Stun");
        }
        else
        {
            //UI Game Complete here
            anim.SetTrigger("Die");
        }
    }

    public void AddHealth(float _value)
    {
        currHealth = Mathf.Clamp(currHealth + _value, 0, startingHealth);
    }
}