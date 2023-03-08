using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    public Animator transition;
    public float transitionTime = 1f;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadNamedLevel(levelName));
    }

    IEnumerator LoadNamedLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(levelName);
        
        transition.SetTrigger("End");
        
    }
}
