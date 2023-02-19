using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class LoadSpecificScene : MonoBehaviour
{
    //le scene name permet de faire de cette classe une classe generique car elle pourra charger
    // n'importe quelle scene
    public string sceneName;
    public Animator fadeSystem;



    private void Awake()
    {
        // va se charger de trouver l'animation fadeSystem tout seul pour eviter de drag and drop
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si le joueur entre dans le trigger de la "porte" alors on lancer la coroutine 
        // qui se charge elle meme de lancer la nouvelle scene
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadNextScene());
        }
    }

    public IEnumerator LoadNextScene()
    {
        // lance la nouvelle scene apres avoir appelé l'animation FadeIn
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);

    }
}
