using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameLabel : MonoBehaviour
{
    public static NameLabel instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
public void UpdateName(string m_text)
    {
        GetComponent<TextMeshProUGUI>().text = m_text;
    }
}
