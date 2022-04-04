using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float smoothTime = 0.1f;

    NavMeshAgent agent;
    Animator charAnimator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        charAnimator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        charAnimator.SetFloat("speedPercent", speedPercent, smoothTime, Time.deltaTime);
    }
}
