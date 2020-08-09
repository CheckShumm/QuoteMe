using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanel : BasePanel
{

    private const int _roundTime = 5;
    private const int _totalRounds = 8;    
    
    private float _timeLeft = _roundTime;
    private int _currentRound = 0;

    List<string> fakeQuotes = new List<string>(new string[] { "kitkat 1", "kitkat 2", "quote 3", "quote 4", "quote 5", "quote 5", "quote 5", "quote 5", "quote 5" });

    private Color _lightRed = new Color(250,122,122,100);
    private Color _lightGreen = new Color(250, 122, 122, 100);
    private Color _white = new Color(255, 255, 255, 255);

    private int _correctAnswer = 0;

    // UI elements
    [SerializeField] private Image timer = null;

    [SerializeField] private Image[] authorImages = new Image[4];
    [SerializeField] private Image[] _overlays = new Image[4];
    [SerializeField] private TextMeshProUGUI[] _authorNames = new TextMeshProUGUI[4];

    [SerializeField] private TextMeshProUGUI quote = null;

    public void ExtOnClickAuthor(int index)
    {
        Debug.Log(index);
        if (index == _correctAnswer)
        {
            Debug.Log("Correct!");
            //_overlays[index].color = _lightGreen;
        }
        else
        {
            Debug.Log("Wrong!");
            //_overlays[index].color = _lightRed;
        }
    }
    override protected void OnActivate()
    {

        quote.SetText(fakeQuotes[_currentRound]);
        _correctAnswer = UnityEngine.Random.Range(0, 3);
        QuotesManager.GetQuoteByAuthor("Donald Trump", 1);
        Dictionary<string, Sprite> authorSprites = ImageHandler.GetFourRandomAuthorPictures();
        int index = 0;
        foreach (var kvp in authorSprites)
        {
            authorImages[index].sprite = kvp.Value;
            _authorNames[index].SetText(kvp.Key);
            index++;
        }

    }

    private void NextRound()
    {
        _currentRound += 1;
        _timeLeft = _roundTime;

        //foreach (Image overlay in _overlays)
        //    overlay.color = _lightRed;

        quote.SetText(fakeQuotes[_currentRound]);
        _correctAnswer = UnityEngine.Random.Range(0, 3);
        if (_currentRound == _totalRounds)
        {
            // TODO transit to post game lobby panel
            ServiceManager.ViewManager.TransitToRoom();
        }

        Dictionary<string, Sprite> authorSprites = ImageHandler.GetFourRandomAuthorPictures();
        int index = 0;
        foreach (var kvp in authorSprites)
        {
            authorImages[index].sprite = kvp.Value;
            _authorNames[index].SetText(kvp.Key);
            index++;
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
