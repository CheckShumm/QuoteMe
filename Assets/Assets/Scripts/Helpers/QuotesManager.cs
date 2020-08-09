using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * API doc for quotes 
 * https://pprathameshmore.github.io/QuoteGarden/
 * 
 */
[System.Serializable]
public static class QuotesManager
{

    public static IEnumerator GetQuoteByAuthor(string authorName, int numberOfQuotesPerRequest)
    {
    
        string authorUri = "https://quote-garden.herokuapp.com/api/v2/authors/" + authorName + "?page=1&limit=" + numberOfQuotesPerRequest;
        return RequestHandler.GetRequest(authorUri, QuoteResponse);
    }

    public static void QuoteResponse(string response)
    {
        Debug.Log("in app manager received " + response);
        // parse response
        QuotesResult quoteResult = JsonUtility.FromJson<QuotesResult>(response);

        Debug.Log(quoteResult.quotes.Length);
        Debug.Log(quoteResult.quotes[0].quoteText);
    }
}
