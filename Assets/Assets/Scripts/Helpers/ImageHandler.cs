using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class ImageHandler
{
    public static string[] authors = {
"Confucius",
"Buddha",
"Benjamin Franklin",
"Abraham Lincoln",
"Christopher Reeve",
"John Lennon",
"Dalai Lama",
"Donald Trump",
"Socrates",
"Yoda",
"Leonardo da Vinci",
"Thomas Edison",
"Albert Einstein",
"William Shakespeare",
"Aristotle",
"Sigmund Freud",
"Winston Churchill",
"Eleanor Roosevelt",
"Sun Tzu",
"Maya Angelou",
"Liberace",
"Mike Ditka",
"Joseph Stalin",
"Princess Diana",
"Immanuel Kant",
"Oscar Wilde",
"Marcus Aurelius",
"Napoleon Bonaparte",
"Tony Robbins",
"Mahatma Gandhi",
"Walt Disney",
"Michelangelo",
"Pablo Picasso",
"Charles Darwin",
"Bruce Lee",
"Oprah Winfrey",
"Vince Lombardi",
"Anne Frank",
"John Astin",
"Nikola Tesla",
"Thomas Jefferson",
"Marie Curie",
"Lucille Ball",
"Nelson Mandela",
"Barack Obama",
"Mother Teresa",
"Arthur Conan Doyle",
"Plato",
"Niels Bohr",
"Mark Twain",
"Janis Joplin",
"Saint Augustine",
"Henry Ford",
"Lily Tomlin",
"Michael Jordan",
"Elizabeth Arden",
"Babe Ruth",
"Andy Warhol",
"Franklin Roosevelt",
"Charles Dickens",
"Henry Moore",
"Dr. Seuss",
"David Seamans",
"Rene Descartes",
"Arnold Schwarzenegger",
"Sylvester Stallone",
"Liam Neeson"
};
    public static List<Sprite> GetAuthorPictures(string name)
    {
        List<Sprite> spriteList = new List<Sprite>();
            spriteList.Add(Resources.Load<Sprite>("AuthorData/authorsPhotos/" + name));
        return spriteList;
    }

    public static Dictionary<string, Sprite> GetFourRandomAuthorPictures()
    {
        randomizeArray(authors,authors.Length);
        Dictionary<string, Sprite> AuthorSpriteDictionary = new Dictionary<string, Sprite>();
        for (int i = 0; i <4; i++)
            AuthorSpriteDictionary[authors[i]] = Resources.Load<Sprite>("AuthorData/authorsPhotos/" + authors[i]);

        return AuthorSpriteDictionary;
    }

    public static void randomizeArray(string[] arr, int n)
    {
        System.Random random = new System.Random();
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            string temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
