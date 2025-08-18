using UnityEngine;
using UnityEngine.Serialization;

public class StartPlaying : MonoBehaviour
{
    [SerializeField] private float timeToWait;
    
    [FormerlySerializedAs("isPlayable")] public bool isEnabled;
    private float _startingTime;

    void Start()
    {
        _startingTime = Time.time;
        isEnabled = false;
    }
    
    void Update()
    {
        if (Time.time - _startingTime >= timeToWait)
        {
            isEnabled = true;
        }
    }
}
