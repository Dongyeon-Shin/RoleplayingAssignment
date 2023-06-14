using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _2023_06_13 : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float range;
    [SerializeField, Range(0, 360)]
    private float angle;
    [SerializeField]
    private float soundRange;

    private void Update()
    {
        CreateSound();
    }
    public void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            Vector3 dirToTarget = (collider.transform.position - transform.position).normalized;
            if (Vector3.Dot(transform.forward, dirToTarget) < Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad))
            {
                continue;
            }
            IHittable hittable = collider.GetComponent<IHittable>();
            hittable?.TakeDamage(damage);
        }
    }
    private void CreateSound()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            IListenable listenable = collider.GetComponent<IListenable>();
            listenable?.DetectSound(gameObject);
        }
    }
}
