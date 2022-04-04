using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour
{
    Transform currentTarget;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.position);
            FaceTarget();
        }

    }
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
    public void FollowTarget(Interactable i)
    {
        agent.stoppingDistance = i.radius * 0.8f;
        agent.updateRotation = false;
        currentTarget = i.transform;
    }
    public void ClearTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
        currentTarget = null;
    }
    void FaceTarget()
    {
        Vector3 dir = currentTarget.position - transform.position;
        dir = dir.normalized;
        Vector3 facing = new Vector3(dir.x, 0f, dir.z);
        Quaternion lookRotation = Quaternion.LookRotation(facing);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
