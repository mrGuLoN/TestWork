using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int _scene;

    [SerializeField] private Button _start;
    [SerializeField] private Button _exit;

    private void Start()
    {
        _start.onClick.AddListener(LoadScene);
        if (_exit!=null)
            _exit.onClick.AddListener(Exit);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_scene);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
