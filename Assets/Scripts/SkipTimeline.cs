using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipTimeline : MonoBehaviour
{
    [SerializeField] private PlayableDirector t_TimeLine;

    bool t_CinematicSkip = false;

    // Start is called before the first frame update
    public void SkipCinematic(float time)
    {
        t_TimeLine.time = time;
        t_TimeLine.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && t_CinematicSkip == false) 
        {
            SkipCinematic(1040f);
            t_CinematicSkip = true;
        }
    }
}
