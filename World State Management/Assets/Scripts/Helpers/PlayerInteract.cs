/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform raycastOrigin;
    public float raycastLength;

    [Header("Interact prompt object")]
    public GameObject interactPrompt;

    private void Update()
    {
        RaycastHit ray;

        Vector3 direction = Vector3.Normalize(raycastOrigin.position - transform.position);

        if (Physics.Raycast(raycastOrigin.position, direction, out ray, raycastLength))
        {
            if(ray.collider.tag == "Interactable")
            {
                interactPrompt.SetActive(true);
            }
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                print(ray.collider.name);
                if (ray.collider.GetComponent<AreaEventTrigger>())
                {
                    ray.collider.GetComponent<AreaEventTrigger>().TriggerAreaEvent();
                }
                if (ray.collider.GetComponent<WorldEventTrigger>())
                {
                    ray.collider.GetComponent<WorldEventTrigger>().TriggerWorldEvent();
                }
            }      
           
        }
        else
        {
            interactPrompt.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 direction = raycastOrigin.position - transform.position;
        Gizmos.DrawRay(raycastOrigin.position, direction);
    }
}
