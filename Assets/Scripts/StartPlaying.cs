using UnityEngine;
using UnityEngine.Serialization;

public class StartPlaying : MonoBehaviour
{
    [SerializeField] private float timeToWait;
    
    [FormerlySerializedAs("isPlayable")] public bool isEnabled;
    
    void Update()
    {
        if (Time.time >= timeToWait)
        {
            isEnabled = true;
        }
    }
}
