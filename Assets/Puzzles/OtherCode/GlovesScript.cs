using UnityEngine;
using System;

public class GlovesScript : MonoBehaviour
{
      public static event Action GlovesOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            GlovesOn?.Invoke();
            // Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
