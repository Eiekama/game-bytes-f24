using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager
{
    public List<Friend> _friends;
    [SerializeField] List<GameObject> players;
    [SerializeField] GameObject friendPrehab;
    // Start is called before the first frame update
    void Start()
    {
        _friends = new List<Friend>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject getFriendPrehab()
    {
        return friendPrehab;
    }

    //public List<Friend> getFriends()
    //{
    //    return *_friends;
    //}
}

public class Friend : FriendManager
{
    private int _friendCount;
    private GameObject _player;
    
    public Friend(GameObject player)
    {
        _player = player;
        _friends.Add(this);
    }
    public void SpawnFriend()
    {
        Instantiate(getFriendPrehab(), _player.transform);
    }
}
