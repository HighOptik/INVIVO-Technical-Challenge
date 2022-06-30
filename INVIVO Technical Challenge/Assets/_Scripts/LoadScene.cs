using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadLevel(int sceneID)
    {

        Debug.Log("LOAD SCENE" + sceneID);
        if (TransitionManager.instance)
        {
            TransitionManager.instance.RandomTransition(sceneID);
        }
        else
        {

            SceneManager.LoadScene(sceneID);
        }    
    }
}
