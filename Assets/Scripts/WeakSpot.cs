using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // le weakSpot est le collider placé au dessu de la tete de l'ennemi 
        //si le joueur entre dans le collider alors l'ennemie est detruit
        if (collision.CompareTag("Player"))
        {
           Destroy(objectToDestroy);
        }
    }
}
