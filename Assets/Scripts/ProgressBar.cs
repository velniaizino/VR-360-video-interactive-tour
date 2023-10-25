using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer vid;

    private Image progress;
    // Start is called before the first frame update
    void Awake()
    {
        progress = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    { if (vid.frameCount > 0)
            progress.fillAmount = (float)vid.frame / (float)vid.frameCount;
        
    }
}
