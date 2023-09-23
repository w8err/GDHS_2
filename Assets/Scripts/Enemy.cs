using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent nmAgent;
    [SerializeField]
    private ParticleSystem deathEffect;
    private AudioSource audioSource;
    private bool isDeath = false;
    private int score = 10;
  
    private void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        nmAgent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (isDeath != true && col.gameObject.CompareTag("Bullet"))
        {
            isDeath = true;
            GameManager.Instance.SetScore(score);
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        audioSource.Play();
        deathEffect.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 0.1f);

        Destroy(gameObject);
    }
}
