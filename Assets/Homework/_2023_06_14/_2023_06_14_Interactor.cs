using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class _2023_06_14_Interactor : MonoBehaviour
{
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private float range;
    public void Interact()
    {
        Collider[] colliders = Physics.OverlapSphere(hand.position, range);
        foreach (Collider collider in colliders)
        {
            _2023_06_14_Adaptor adaptor = collider.GetComponent<_2023_06_14_Adaptor>();
            if (adaptor != null)
            {
                adaptor.Interact(this);
                break;
            }
        }
    }
    private void OnInteract(InputValue value)
    {
        Interact();
    }
}
