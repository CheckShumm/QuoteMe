using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string _name;
    public string Uid => _uid;
    private string _uid;
    private string _password = "";
    private PlayerProfile _hostPlayer = null;
    private List<PlayerProfile> _players = new List<PlayerProfile>();

    public Room(string name, PlayerProfile host) 
    {
        _uid = System.Guid.NewGuid().ToString();
        _name = name;
        _hostPlayer = host;
        Debug.Log("playerName " + _hostPlayer.PlayerName);
        _players.Add(_hostPlayer);
    }

    public List<PlayerProfile> getPlayers() { return _players; }

    public string getHostName() { return _hostPlayer.PlayerName; }

    public int getPlayerCount() { return _players.Count; }

    public string getName() { return _name; }

    public void setPassword(string password) { _password = password; }

    public string getPassword() { return _password; }

    public void AddPlayer(PlayerProfile player) {
        if (player == null)
            return;
        _players.Add(player);
    }


}
