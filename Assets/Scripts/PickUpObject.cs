using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //chaque objets qui possede cette class pourras etre recuperé par un joueur 
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //quand le joueur entre dans le collider de la piece alors une piece est ajouté en plus 
        // dans so inventaire et on detruit celle-ci
        if (collision.CompareTag("Player"))
        {
            
            Inventory
                .instance.AddCoins();
            Destroy(gameObject);
            
        }
    }
}
