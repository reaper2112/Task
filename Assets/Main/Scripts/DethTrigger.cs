using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Health>(out var player))
        {
            player?.Death();
        }
    }
}
