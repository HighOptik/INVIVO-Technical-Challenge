using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    public enum _type { FadeToBlack, Grow}
    public _type m_type;
    public Animator m_anim;
    public GameObject popUp;
    public Transform popUpContainer;
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
    private void Start()
    {
    }
    public void RandomTransition(int sceneID)
    {
        TransitionManager._type rand= (TransitionManager._type)Random.Range(0, System.Enum.GetValues(typeof(TransitionManager._type)).Length);
        Interaction(rand + " transition!");

        switch (rand)
        {
            case _type.FadeToBlack:
                FadeToBlack(sceneID);
                break;
            case _type.Grow:
                Grow(sceneID);
                break;
            default:
                break;
        }
    }
    public void FadeToBlack(int sceneID)
    {
        m_anim.SetTrigger("FadeToBlack");
        StartCoroutine(_LoadLevel(sceneID));
    }
    public void Grow(int sceneID)
    {
        m_anim.SetTrigger("Grow");
        StartCoroutine(_LoadLevel(sceneID));
    }
    public void Shrink()
    {
        m_anim.SetTrigger("Shrink");
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
        Shrink();
        FadeToClear();
    }
    public void Interaction(string txt)
    {
        GameObject popup= Instantiate(popUp, popUpContainer);
        popup.GetComponent<TextMeshProUGUI>().text = txt;
        StartCoroutine(RemovePopUp(popup));
    }
    IEnumerator RemovePopUp( GameObject popup)
    {
        yield return new WaitForSeconds(5);
        Destroy(popup);
    }
}
