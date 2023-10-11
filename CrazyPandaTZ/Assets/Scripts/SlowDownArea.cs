using System.Collections.Generic;
using UnityEngine;

public class SlowDownArea : MonoBehaviour
{
    [SerializeField] private float slowFactor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICanBeSlowedItem slowedElement = null;
        if (collision.TryGetComponent<ICanBeSlowedItem>(out slowedElement))
        {
            slowedElement.OnEnterIntoSlowedArea(slowFactor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ICanBeSlowedItem slowedElement = null;
        if (collision.TryGetComponent<ICanBeSlowedItem>(out slowedElement))
        {
            slowedElement.OnExitFromSlowedArea(slowFactor);
        }
    }
}

