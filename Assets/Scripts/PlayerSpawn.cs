using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
   private void Awake()
   {
      //on recupere le joueur et on modifie sa position actuelle par la position de l'objet spawn
      GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
   }
}
