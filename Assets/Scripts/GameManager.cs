using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayDevice
{
    Standalone = 0,
    GearVR,
    Vive,
    Pico,
}

public enum PlayMode
{
    Standalone = 0,
    StandaloneWithLeapMotion,
    Mobile,
    VR,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private PlayDevice _playDevice;
    public PlayDevice PlayDevice { get { return _playDevice; } }

    [SerializeField]
    private bool _useLeap;
    public bool UseLeap { get { return _useLeap; } }

    [SerializeField]
    private bool _isDebug;
    public bool IsDebug { get { return _isDebug; } }

    [SerializeField]
    private PlayerController _player;
    public PlayerController Player { get { return _player; } }

    //[SerializeField]
    //private UIManager _ui;
    //public IUIBehavior UI { get { return _ui; } }

    [SerializeField]
    private ResourceUtility.ResourceLoader _resourceLoader { get { return _resourceLoader; } }

    void Awake()
    {
        if (_isDebug && Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }
}
