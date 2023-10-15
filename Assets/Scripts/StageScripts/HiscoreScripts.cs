
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine.Serialization;
using File = System.IO.File;

public class HiscoreScripts : MonoBehaviour
{
    [SerializeField] private ScoreVision _prefScore;
    [SerializeField] private string _pathSaveFile, _fileName="score.json";

    [FormerlySerializedAs("_scoreList")] [SerializeField] private int _scoreTop ;
    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _pathSaveFile = Path.Combine(Application.persistentDataPath, _fileName);
#else
        _pathSaveFile = Path.Combine(Application.dataPath, _fileName);
#endif

    }

    void Start()
    {
        LoadScore();
        int newscore;
        newscore = CanvasController.instance.currentScore;
        if (_scoreTop>newscore)
        {
            InstancePref(1, _scoreTop);
        }
        else
        {
            InstancePref(1, newscore);
            SaveScore(newscore);
        }
    }

    private void SaveScore(int score)
    {
        string json = score.ToString();
        File.WriteAllText(_pathSaveFile,json);
    }

    private void LoadScore()
    {
        if (!File.Exists(_pathSaveFile))
        {
            return;
        }
        else
        {
            string json = File.ReadAllText(_pathSaveFile);
           _scoreTop =  Int32.Parse(json);
        }
    }
    
    private void InstancePref(int i, int score)
    {
        var hiscore = Instantiate(_prefScore, transform);
        hiscore.position.text = i.ToString();
        hiscore.score.text = score.ToString();
    }
}

