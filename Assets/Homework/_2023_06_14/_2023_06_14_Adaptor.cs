using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class _2023_06_14_Adaptor : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent<_2023_06_14_Interactor> OnInvoked;

    public void Interact(_2023_06_14_Interactor interactor)
    {
        OnInvoked?.Invoke(interactor);
    }
}
