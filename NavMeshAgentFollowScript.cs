using UnityEngine;
using UnityEngine.AI;

public class MoveToTargetWithVisibility : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            Debug.LogError("Target is not assigned!");
        }
    }

    private void Update()
    {
        if (CanSeeTarget())
        {
            agent.SetDestination(target.position);
        }
    }

    private bool CanSeeTarget()
    {
        RaycastHit hit;
        Vector3 direction = target.position - transform.position;

        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.transform == target)
            {
                return true;
            }
        }

        return false;
    }
}
