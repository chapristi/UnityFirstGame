using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Slider slider;
   public Gradient gradient;
   public Image fill;

   public void SetMaxHealth(int health)
   {
      //appelé lors de l'inisialisation des données
      slider.maxValue = health;
      slider.value = health;
      fill.color = gradient.Evaluate(1f);
   }

   public void SetHealth(int health)
   {
      //appelé pour changer le nombre de points de vie à afficher
      slider.value = health;
      fill.color = gradient.Evaluate(slider.normalizedValue);

   }
}
