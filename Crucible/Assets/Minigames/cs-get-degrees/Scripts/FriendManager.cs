using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
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
    //public static void SpawnFriend(Player player)

    //public List<Friend> getFriends()
    //{
    //    return *_friends;
    //}
}

public class Friend
{
    public GameObject _player;
    GameObject friendObject;

    public Friend(GameObject friendObject, GameObject player)
    {
        _player = player;
    }
}
