using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesTrasitionManager : MonoBehaviour
{
    private static ScenesTrasitionManager instance;
    public static ScenesTrasitionManager Instance => instance;

    [SerializeField] private Animator animator;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


  
    public void NextLevel(string nameScenes)
    {
        StartCoroutine(WaitingLoadNextScenes(nameScenes));
    }


    public void BackLevel(string nameScenes)
    {
        StartCoroutine(WaitingLoadBackScenes(nameScenes));
    }

    IEnumerator WaitingLoadNextScenes(string nameScenes)
    {

        animator.SetTrigger("Start");
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadSceneAsync(nameScenes);
        animator.SetTrigger("End");

    }

    IEnumerator WaitingLoadBackScenes(string nameScenes)
    {

        animator.SetTrigger("Start");
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadSceneAsync(nameScenes);
        animator.SetTrigger("End");

    }


}
