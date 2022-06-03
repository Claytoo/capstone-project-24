using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerController playerController;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] rocks;

    private PlayerHealth enemyHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    public void RangedAttack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

        rocks[CheckRock()].transform.position = firePoint.position;
        rocks[CheckRock()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

        Debug.Log("Attacking!");
    }

    private int CheckRock()
    {
        for (int i = 0; i < rocks.Length; i++)
        {
            if (!rocks[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}