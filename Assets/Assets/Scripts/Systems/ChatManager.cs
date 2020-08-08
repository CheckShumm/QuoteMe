using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Chat;

public class ChatManager : BaseManager
{
    private const string ChatAppId = "b9e31a47-c1d2-4f76-8ccb-f1ff76cb5791";
    private const string ChatAppVersion = "1.0.0";
    protected override void RegisterManager() { ServiceManager.ChatManager = this; }
    private ChatClient _chatClient;
    private float _reconnectionTimer = 0.0f;
    private AuthenticationValues _authValue;

    private void Start() 
    {
        _chatClient = new ChatClient(new ChatListener(this));
        _chatClient.ChatRegion = "US";
        _authValue = new AuthenticationValues(ServiceManager.PlayerManager.LocalPlayerProfile.Uid);
        _chatClient.Connect(ChatAppId, ChatAppVersion, _authValue);
    }

    private void Update() 
    {
        if(_chatClient != null) 
        {
            if(_chatClient.State == ChatState.Disconnected || _chatClient.State == ChatState.Uninitialized) 
            {
                _reconnectionTimer -= Time.deltaTime;
                if(_reconnectionTimer <= 0) 
                {
                    _chatClient.ConnectAndSetStatus(ChatAppId, ChatAppVersion, _authValue);
                    _reconnectionTimer = 5.0f;
                }
            }
            else
            {
                _chatClient.Service();
            }
        }
    }

    private void OnDisconnected() 
    {

    }
    
    private void OnConnected() 
    {

    }
    
    private void OnChatStateChange(ChatState state) 
    {

    }
    
    private void OnPrivateMessage(string sender, object message, string channelName) 
    {

    }
    
    private void OnSubscribed(string[] channels, bool[] results) 
    {

    }
    
    private void OnUnsubscribed(string[] channels) 
    {

    }
    
    private void OnStatusUpdate(string user, int status, bool gotMessage, object message) 
    {

    }
    
    private void OnUserSubscribed(string channel, string user) 
    {

    }
    
    private void OnUserUnsubscribed(string channel, string user) 
    {

    }
    
    private class ChatListener : IChatClientListener 
    {        
        private ChatManager _chatManager;

        public ChatListener(ChatManager chatManager) 
        {
            _chatManager = chatManager;
        }

        public void DebugReturn(DebugLevel level, string message) 
        {
            Debug.Log("PhotonChat: " + message);
        }
        
        public void OnDisconnected() 
        {
            //Handle connection state
            _chatManager._reconnectionTimer = 5.0f;
        }
        
        public void OnConnected() {}
        
        public void OnChatStateChange(ChatState state) 
        {
            //Handle connection state
        }
        
        public void OnGetMessages(string channelName, string[] senders, object[] messages) {}
        
        public void OnPrivateMessage(string sender, object message, string channelName) 
        {
            _chatManager.OnPrivateMessage(sender, message, channelName);
        }
        
        public void OnSubscribed(string[] channels, bool[] results) 
        {
            _chatManager.OnSubscribed(channels, results);
        }
        
        public void OnUnsubscribed(string[] channels) 
        {
            _chatManager.OnUnsubscribed(channels);
        }
        
        public void OnStatusUpdate(string user, int status, bool gotMessage, object message) {}
        
        public void OnUserSubscribed(string channel, string user) 
        {
            _chatManager.OnUserSubscribed(channel, user);
        }
        
        public void OnUserUnsubscribed(string channel, string user) 
        {
            _chatManager.OnUserUnsubscribed(channel, user);
        }
    }
}
