using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string _name;
    private string Uid => _uid;
    private string _uid;
    private List<PlayerProfile> _players = new List<PlayerProfile>();

    public Room(string name) 
    {
        _uid = System.Guid.NewGuid().ToString();
        _name = name;
    }

    public string getID() { return _uid; }

    public List<PlayerProfile> getPlayers() { return _players; }

    public void AddPlayer(PlayerProfile player) {
        if (player == null)
            return;
        _players.Add(player);
    }

    public string getName() { return _name; }

}
