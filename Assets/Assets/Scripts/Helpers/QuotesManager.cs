using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * API doc for quotes 
 * https://pprathameshmore.github.io/QuoteGarden/
 * 
 */
[System.Serializable]
public class QuotesManager
{
    private int numberOfQuotesPerRequestPage;
    private List <string> authorNames = new List <string>();

    public IEnumerator GetQuoteByAuthor(string authorName, int numberOfQuotesPerRequest)
    {
        this.numberOfQuotesPerRequestPage = numberOfQuotesPerRequest;
        string authorUri = "https://quote-garden.herokuapp.com/api/v2/authors/" + authorName + "?page=1&limit=" + numberOfQuotesPerRequestPage;
        return RequestHandler.GetRequest(authorUri, QuoteResponse);
    }

    public void QuoteResponse(string response)
    {
        Debug.Log("in app manager received " + response);
    }
}
