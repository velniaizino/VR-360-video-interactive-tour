using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class MainSceneManager : MonoBehaviour
{
    public VideoPlayer vid;

    private Transform trackPivot;
    private Transform startPivot;
    private Transform onePivot;
    private Transform endPivot;
    private float oneToEnd;

    // Start is called before the first frame update
    void Start()
    {
        trackPivot = GameObject.Find("TrackPivot").transform;
        startPivot = GameObject.Find("StartPoint").transform;
        onePivot = GameObject.Find("OnePoint").transform;
        endPivot = GameObject.Find("EndPoint").transform;
        oneToEnd = Mathf.Abs(endPivot.position.z - onePivot.position.z);
        vid.Play();
        /* load = GameObject.Find("VideoLoad");
        load.GetComponent<VideoLoader>().LoadVideo();
        sound.Play();*/

    }

    // Update is called once per frame
    void Update()
    {
        if (trackPivot.position.z >= startPivot.position.z && trackPivot.position.z <= endPivot.position.z)
        {
            SetVideoPS((endPivot.position.z - trackPivot.position.z));
        }
        else if (trackPivot.position.z > endPivot.position.z)
        {
            vid.playbackSpeed = 2f;
        }
        else
            vid.playbackSpeed = 0f;


    }

    void SetVideoPS(float currentDist)
    {

        float deltaDist = oneToEnd;
        float nrInterva = 0;
        if (currentDist >= oneToEnd)
        {
            vid.playbackSpeed = 1.0f;
        }
        else if (currentDist > 0)
        {
            for (int i = 1; i < 6; i++)
            {
                deltaDist = deltaDist - (oneToEnd / 5);
                if (currentDist > deltaDist)
                {
                    nrInterva = i * 2;
                    vid.playbackSpeed = 1f + nrInterva / 10;
                    break;

                }

            }

        }

    }
}
