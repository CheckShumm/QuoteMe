using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanel : BasePanel
{

    private const int _roundTime = 20;
    private const int _totalRounds = 30;    
    
    private float _timeLeft = _roundTime;
    private int _currentRound = 0;

    private Color _lightRed = new Color32(250,122,122,100);
    private Color _lightGreen = new Color32(42, 190, 52, 100);
    private Color _white = new Color32(255, 255, 255, 50);

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
            _overlays[index].GetComponent<Image>().color = _lightGreen;
        }
        else
        {
            Debug.Log("Wrong!");
            _overlays[index].GetComponent<Image>().color = _lightRed;
        }
    }

    public void GetQuoteByAuthor(string authorName, int numberOfQuotesPerRequest)
    {
        string authorUri = "https://quote-garden.herokuapp.com/api/v2/authors/" + authorName + "?page=1&limit=" + numberOfQuotesPerRequest.ToString();
        Debug.Log(authorUri);
        StartCoroutine(RequestHandler.GetRequest(authorUri, QuoteResponse));
    }

    public void QuoteResponse(string response)
    {
        Debug.Log("in app manager received " + response);
        // parse response
        QuotesResult quoteResult = JsonUtility.FromJson<QuotesResult>(response);

        Debug.Log(quoteResult.quotes.Length);
        Debug.Log(quoteResult.quotes[0].quoteText);
        quote.SetText(quoteResult.quotes[0].quoteText);
    }

    override protected void OnActivate()
    {

        _correctAnswer = UnityEngine.Random.Range(0, 3);
       
        Dictionary<string, Sprite> authorSprites = ImageHandler.GetFourRandomAuthorPictures();
        int index = 0;
        foreach (var kvp in authorSprites)
        {
            if (index == _correctAnswer)
            {
                GetQuoteByAuthor(kvp.Key, 1);
            }

            authorImages[index].sprite = kvp.Value;
            _authorNames[index].SetText(kvp.Key);
            index++;
        }

        // TODO use callback


    }

    private void NextRound()
    {
        _currentRound += 1;
        _timeLeft = _roundTime;

        foreach (Image overlay in _overlays)
            overlay.GetComponent<Image>().color = _white;

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
            if (index == _correctAnswer)
            {
                GetQuoteByAuthor(kvp.Key, 1);
            }

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
