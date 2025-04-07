using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CalculatorButton : MonoBehaviour
{
    public void LoadSceneOnClick(string sceneName)
    {
        SceneManager.LoadScene("plot5_2");
    }
}