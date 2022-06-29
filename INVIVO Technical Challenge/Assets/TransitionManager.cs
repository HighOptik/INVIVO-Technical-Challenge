using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    public Animator m_anim;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
    }

    public void FadeToBlack(int sceneID)
    {
        m_anim.SetTrigger("FadeToBlack");
        StartCoroutine(_LoadLevel(sceneID));
    }
    public void FadeToClear()
    {
        m_anim.SetTrigger("FadeToClear");
    }

    public IEnumerator _LoadLevel(int sceneID)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneID);
        yield return new WaitForSeconds(1);
        FadeToClear();
    }
}
