using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private float InteractRange = 2.6f;

    public InteractBehaviour playerInteractBehaviour;

    [SerializeField]
    private GameObject InteractText;

    [SerializeField]
    private LayerMask layerMask;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, InteractRange, layerMask))
        {
            InteractText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(hit.transform.CompareTag("Item"))
                {
                playerInteractBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
                
                if(hit.transform.CompareTag("Harvestable"))
                {
                
                    playerInteractBehaviour.DoHarvest(hit.transform.gameObject.GetComponent<Harvestable>());
                }
          
            }

        }
        else
        {
            InteractText.SetActive(false);
        }
    }
}

