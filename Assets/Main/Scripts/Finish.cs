using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Health>(out var player))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

}