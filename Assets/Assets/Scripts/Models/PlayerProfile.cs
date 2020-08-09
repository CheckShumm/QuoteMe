using UnityEngine;

public class PlayerProfile
{
    public string PlayerName;
    public Color PlayerColor;
    public string Uid => _uid;

    private string _uid;

    public PlayerProfile() 
    {
        _uid = System.Guid.NewGuid().ToString();
    }

    public PlayerProfile(string uid, string playerName, Color playerColor) 
    {
        _uid = System.Guid.NewGuid().ToString();
        PlayerName = playerName;
        PlayerColor = playerColor;
    }
}