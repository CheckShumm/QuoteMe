using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class RoomPanel : BasePanel
{
    [SerializeField] private TextMeshProUGUI _roomName = null;
    [SerializeField] private TextMeshProUGUI _playerCountText = null;
    [SerializeField] private ScrollRect _playerScroll = null;
    [SerializeField] private PlayerDisplayWidget _displayWidget;
    private Dictionary<string, PlayerDisplayWidget> _playerWidgets = new Dictionary<string, PlayerDisplayWidget>();
    private string _roomId;
    private ChatManager _chatManger;
    private int _playerCount = 0;

    public void ExtOnBack() 
    {
        PhotonNetwork.LeaveRoom();
        ServiceManager.ViewManager.TransitToMainMenu();
    }

    protected override void OnActivate()
    {
        Debug.Log("Room Panel onActive!");
        ServiceManager.ChatManager.OnChannelMessageReceived += OnChannelMessageReceived;
    }

    protected override void OnDeactivate() 
    {
        ServiceManager.ChatManager.OnChannelMessageReceived -= OnChannelMessageReceived;
    }

    private void Start()
    {
        _chatManger = ServiceManager.ChatManager;
    }

    private void Update()
    {
        if(string.IsNullOrEmpty(_roomId) && PhotonNetwork.InRoom) 
        {
            _roomId = PhotonNetwork.CurrentRoom.Name;
            _roomName.SetText(PhotonNetwork.CurrentRoom.CustomProperties[RoomManager.RoomNameKey] as string);
            _chatManger.Subscribe(_roomId);
            _chatManger.SendChannelMessage(_roomId, new ChatManager.PlayerInfoMessage() {
                PlayerName = ServiceManager.PlayerManager.LocalPlayerProfile.PlayerName
            });

            PlayerDisplayWidget newWidget = Instantiate(_displayWidget, _playerScroll.content.transform);
            newWidget.Initialize(ServiceManager.PlayerManager.LocalPlayerProfile.PlayerName);
            _playerWidgets.Add(ServiceManager.PlayerManager.LocalPlayerProfile.Uid, newWidget);
            _playerCount++;
            _playerCountText.SetText($"{_playerCount}/{PhotonNetwork.CurrentRoom.MaxPlayers}");
        } 
    }
    private void OnChannelMessageReceived(string channelName, string[] senders, object[] messages)
    {
        if(channelName != _roomId)
            return;
        
        foreach(string sender in senders) 
        {
            if(sender == ServiceManager.PlayerManager.LocalPlayerProfile.Uid)
                continue;
            
            ChatManager.PlayerInfoMessage playerInfo = ChatManager.GetLatestMessage<ChatManager.PlayerInfoMessage>(sender, senders, messages);
            if(playerInfo != null && !_playerWidgets.ContainsKey(sender)) 
            {
                // Create player item with info
                PlayerDisplayWidget newWidget = Instantiate(_displayWidget, _playerScroll.content.transform);
                newWidget.Initialize(playerInfo.PlayerName);
                _playerWidgets.Add(sender, newWidget);
                _playerCount++;
                _playerCountText.SetText($"{_playerCount}/{PhotonNetwork.CurrentRoom.MaxPlayers}");
            }
        }
    }
}
