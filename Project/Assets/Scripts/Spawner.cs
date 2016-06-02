using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Spawner : MonoBehaviour
{
    public EnemyBase enemy;
    public float spawnRate;
    public string timerParameter = "Timer";

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat(timerParameter, spawnRate);
    }

    void Update()
    {
        animator.SetFloat(timerParameter, animator.GetFloat(timerParameter) - Time.deltaTime);
    }

    public void Spawn()
    {
        animator.SetFloat(timerParameter, animator.GetFloat(timerParameter) + spawnRate);
        EnemyBase spawn = Instantiate(enemy);
        spawn.transform.position = transform.position;
    }
}
