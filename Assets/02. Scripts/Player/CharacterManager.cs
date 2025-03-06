using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // 싱글톤화
    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("CharacerManager").AddComponent<CharacterManager>();
            }
            return instance;
        }
    }

    public Player Player
    {
        get { return player; }
        set { player = value; }
    }
    private Player player;

    private void Awake()
    {
        if (instance == null)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (instance != this)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
