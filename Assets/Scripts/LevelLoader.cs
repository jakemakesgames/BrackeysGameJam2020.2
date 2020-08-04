using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;

    public string levelToLoad;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(levelToLoad));
    }

    IEnumerator LoadLevel(string level)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }
}
