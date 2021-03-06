using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject dieParticleEffect;

    private void Update()
    {
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(1);
            Debug.Log("Kuntilanak attack hit player!");
        }

        if (collision.gameObject.tag != "Player")
        {
            DestroyBullet();
            Debug.Log("Tidak kena!");
        }
    }

    IEnumerator Timer()
    {
        DestroyBullet();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        
    }

    void DestroyBullet()
    {
        if (dieParticleEffect != null)
        {
            Instantiate(dieParticleEffect, transform.position, Quaternion.identity);
        }
    }
}
