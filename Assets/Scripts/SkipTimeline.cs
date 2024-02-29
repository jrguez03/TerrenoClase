using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipTimeline : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector playableDirector;
    public float skip = 1040f;
    /*Skips animation*/

    public void Skip(float time)
    {
        playableDirector.Play();
        playableDirector.time = time;
        playableDirector.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Skip(skip);
        }
    }
}
