using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] GameObject masterTimeline;
    [SerializeField] float timeToWait = 3f;

    private PlayableDirector _playableDirector;

    void Start()
    {
        _playableDirector = masterTimeline.GetComponent<PlayableDirector>();
    }
    
    
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }

    IEnumerator ReloadLevelRoutine()
    {
        _playableDirector.enabled = false;
        yield return new WaitForSeconds(timeToWait);
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
}
