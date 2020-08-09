using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanel : BasePanel
{

    private const int _roundTime = 10;
    private const int _totalRounds = 5;    
    
    private float _timeLeft = _roundTime;
    private int _currentRound = 0;

    List<string> fakeQuotes = new List<string>(new string[] { "quote 1", "quote 2", "quote 3", "quote 4", "quote 5" });

    private int correctAuthor = 0;

    // UI elements
    [SerializeField] private Image timer = null;

    [SerializeField] private Image author1 = null;
    [SerializeField] private Image author2 = null;
    [SerializeField] private Image author3 = null;
    [SerializeField] private Image author4 = null;
    [SerializeField] private TextMeshProUGUI quote = null;


    override protected void OnActivate()
    {
        quote.SetText(fakeQuotes[_currentRound]);
    }

    private void NextRound()
    {
        _currentRound += 1;
        _timeLeft = _roundTime;
        quote.SetText(fakeQuotes[_currentRound]);

        if (_currentRound == _totalRounds)
        {
            ServiceManager.ViewManager.TransitToRoom();
        }

    }

    private void Update()
    {
        timer.fillAmount = _timeLeft / _roundTime;
        _timeLeft -= Time.deltaTime;
        if (_timeLeft < 0)
        {
            NextRound();
        }
    }

}
