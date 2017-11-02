using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jauge : MonoBehaviour
{
    public Image jauge;
    public bool charging = false;
    public float temps;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            charging = true;
        }
        else
        {
            charging = false;
        }

        if (charging == true)
        {
            jauge.fillAmount += Time.deltaTime * temps;
        }

        if (charging == false)
        {
            jauge.fillAmount = 0.01f;
        }
    }
}
