using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float explodeTime = 3f;
    public Animator animator;
    public void MoveToPlayer()
    {
        StartCoroutine(MoveToPlayerRoutine());
    }

    IEnumerator MoveToPlayerRoutine()
    {
        GameObject player = GameObject.FindWithTag("Player").gameObject;
        float time = 0f;
        explodeTime += Random.Range(0f, 1f);
        while (Vector3.Distance(transform.position, player.transform.position) > 0.3f && time < explodeTime)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            time += Time.deltaTime;
            yield return null;
        }
         animator.SetTrigger("Explode");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
