using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextScene()
    {
        int sceneID;
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount)
        {
             sceneID = SceneManager.GetActiveScene().buildIndex + 1;

        }else
        {
            sceneID = 0;
        }
        if (TransitionManager.instance)
        {
            TransitionManager.instance.FadeToBlack(sceneID);
        }
        else
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}
