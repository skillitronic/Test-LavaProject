﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneRestart : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
