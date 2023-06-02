using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private Transform playerLook;
    //[SerializeField] private GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(playerLook.position, playerLook.forward, out var hit))
            {
               var hittedDoor = hit.transform.GetComponent<doorChange>();
               if (hittedDoor != null)
               {
                    Quaternion.Euler(0.531f, 0f, 0.497f);
                
               }
            }
            
        }
        
        
        
        
    }
}
