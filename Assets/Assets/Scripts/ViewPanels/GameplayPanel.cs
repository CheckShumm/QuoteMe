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

    private Color _lightRed = new Color(250,122,122,100);
    private Color _lightGreen = new Color(250, 122, 122, 100);
    private Color _white = new Color(255, 255, 255, 255);

    private int _correctAnswer = 0;

    // UI elements
    [SerializeField] private Image timer = null;

    [SerializeField] private Image[] authorImages = new Image[4];
    private AuthorImage[] _authorImageElements = new AuthorImage[4];

    [SerializeField] private TextMeshProUGUI quote = null;

    public void ExtOnClickAuthor(int index)
    {
        Debug.Log(index);
        if (index == _correctAnswer)
            _authorImageElements[index].SetOverlayColor(_lightGreen);
        else
            _authorImageElements[index].SetOverlayColor(_lightRed);
    }

    override protected void OnActivate()
    {
        quote.SetText(fakeQuotes[_currentRound]);
        _correctAnswer = UnityEngine.Random.Range(0, 3);
    }

    private void NextRound()
    {
        _currentRound += 1;
        _timeLeft = _roundTime;

        foreach (AuthorImage authorImageElement in _authorImageElements)
            authorImageElement.SetOverlayColor(_white);

        quote.SetText(fakeQuotes[_currentRound]);
        _correctAnswer = UnityEngine.Random.Range(0, 3);
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
