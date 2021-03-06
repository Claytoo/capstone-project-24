using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }
    public AudioClip enemydie;

    private Animator anim;
    private BoxCollider2D bc2;
    private AudioSource audioSfx;
    

    private void Awake()
    {
        currHealth = startingHealth;
        anim = GetComponent<Animator>();
        audioSfx = GetComponent<AudioSource>();
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
            //anim.SetTrigger("Stun");
        }
        else
        {
            //UI Game Complete here
            anim.SetTrigger("Die");
            //AI_Patrol.instance.DeactivatePatrol();
            StartCoroutine(Die());
        }
    }

    public void AddHealth(float _value)
    {
        currHealth = Mathf.Clamp(currHealth + _value, 0, startingHealth);
    }

    private void EnemyDieSFX()
    {
        audioSfx.PlayOneShot(enemydie);
    }

    IEnumerator Die()
    {
        EnemyDieSFX();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
