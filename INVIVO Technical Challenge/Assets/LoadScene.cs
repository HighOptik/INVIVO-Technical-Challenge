using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void Start() 
    {
        
    }
    public void LoadLevel(int sceneID)
    {
        TransitionManager.instance.FadeToBlack(sceneID);
    }
}
