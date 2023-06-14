using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2023_06_13_Wolf : MonoBehaviour, IHittable, IListenable
{
    [SerializeField]
    private float range;
    [SerializeField, Range(0, 360)]
    private float angle;
    [SerializeField]
    private LayerMask targetMask;
    [SerializeField]
    private LayerMask obstacleMask;
    private GameObject detectedEnemy;

    private void Update()
    {
        VisuallyDetect();
    }

    private void DetectEnemy(GameObject enemy)
    {
        if (detectedEnemy == null)
        {
            return;
        }
        transform.LookAt(enemy.transform.position);
        if (Vector3.Distance(enemy.transform.position, transform.position) > range)
        {
            detectedEnemy = null;
        }
    }

    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }

    private void VisuallyDetect()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, range, targetMask);
        for (int i = 0; i < targets.Length; i++)
        {
            Vector3 dirToTarget = (targets[i].transform.position - transform.position).normalized;
            if (Vector3.Dot(transform.forward, dirToTarget) < Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad))
            {
                continue;
            }
            float distToTarget = Vector3.Distance(transform.position, targets[i].transform.position);
            if (Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
            {
                continue;
            }
            DetectEnemy(targets[i].gameObject);
            return;
        }
    }

    public void DetectSound(GameObject enemy)
    {
        DetectEnemy(enemy);
    }
}
