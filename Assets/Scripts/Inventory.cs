using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public int coinsCount = 0;
   public static  Inventory instance;
   public Text coinsCountText;

   private void Start()
   {
      //initialisation du compteur
      coinsCountText.text = coinsCount.ToString();

   }

   private void Awake()
   {
      if (instance != null)
      {
         //on evite que l'inventaire ne soit pas unique pour eviter les duplication
         return;
      }
      instance = this;
   }

   public void AddCoins()
   {
      coinsCount++;
      coinsCountText.text = coinsCount.ToString();
   }
}
