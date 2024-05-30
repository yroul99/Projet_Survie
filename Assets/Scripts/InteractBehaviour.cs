using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    [SerializeField]
    private MoveBehaviour playerMoveBehaviour;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField] //Permet d'y accéder via l'inspector 
    private Inventory inventory;

    private Item currentItem;
    private Harvestable currentHarvestable; 
    [SerializeField]
    private GameObject pickaxeVisual;

    public void DoPickup(Item item)
    {
        if(inventory.IsFull())
        {
            Debug.Log("Inventaire plein, ne peut pas ajouter :" + item.name);
            return;
        }
        currentItem = item;

        playerAnimator.SetTrigger("Pickup");
        playerMoveBehaviour.canMove = false;
    
        //Ajouter l'objet passé à l'inventaire du joueur
        //Jouer l'animation du personnage pour ramasser l'objet
        // Bloquer le déplacement du joueur pendant qu'on ramasse un objet
    }
    public void DoHarvest(Harvestable harvestable)
    {
        pickaxeVisual.SetActive(true);
        currentHarvestable = harvestable;
        playerAnimator.SetTrigger("Harvest");
        playerMoveBehaviour.canMove = false;
    }
    public void BreakHarvestable()
    {
        for (int i=0; i<currentHarvestable.harvestableItems.Length; i++)
        {
            Ressource ressource = currentHarvestable.harvestableItems[i];
            for (int y=0; y< Random.Range(ressource.minAmountSpawned, (float)ressource.maxAmountSpawned); y++)
            {
                GameObject instantiatedRessource = GameObject.Instantiate(ressource.itemData.prefab);
                instantiatedRessource.transform.position = currentHarvestable.transform.position;
            }
        }
        Destroy(currentHarvestable.gameObject);
    }
    public void AddItemToInventory()
    {
       inventory.AddItem(currentItem.itemData); 
       Destroy(currentItem.gameObject);


    }

    public void ReEnablePlayerMovement()
    {
        pickaxeVisual.SetActive(false);
        playerMoveBehaviour.canMove = true;
    }
}
