using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrevScene : MonoBehaviour
{
    // Start is called before the first frame update
public void LoadPrevScene()
    {
        TransitionManager.instance.FadeToBlack(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
