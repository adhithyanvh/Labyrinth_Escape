using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateCutScene : MonoBehaviour
{
    
   

    [SerializeField] private PlayableDirector playableDirector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            playableDirector.Play();
            GetComponent<BoxCollider>().enabled = false;

            
        }
    }
}
