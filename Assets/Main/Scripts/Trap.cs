using System;
using UnityEngine;


public class Trap : MonoBehaviour
{
    public event Action<int> GotDamage;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Health>(out var player) && transform.position.y < 0.14 )
        { 
            transform.Translate(Vector3.up * Time.deltaTime);
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Health>(out var player) && transform.position.y < 0.14)
        {
            GotDamage?.Invoke(-40);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, -0.2f, transform.position.z);
        
    }

    
}