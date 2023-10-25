using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MainSelectLocation : MonoBehaviour
{
    
    public VideoPlayer vid;
    public GameObject selectLocationPrefab;
    public double startTimeSec;
    public double endTimeSec;
    public double timeDelta;
    private MainChangeScene change;
    private bool isCoroutineActive;
    private bool isDeactiveCoroutine;
    private bool isAnimCoroutine;
    private bool isSkipCoroutine;
    private Animator anim;
    private BackToMain backtomain;
    private long frame;
    
    void Awake()
    { 
        anim = selectLocationPrefab.GetComponent<Animator>();
        isCoroutineActive = false;
        isDeactiveCoroutine = false;
        isAnimCoroutine = false;
        
        
    }
	private void Start()
	{
        PlayVid();

    }

	// Update is called once per frame
	void Update()
    {
        if(vid.time>startTimeSec&&vid.time<(endTimeSec-timeDelta))
		{
          
           if(SceneChanged.isChangeScenePressed)
			{
                StartCoroutine(SkipCoroutine());                    

            }  
           else if(!isSkipCoroutine)
			{
                if (!isCoroutineActive)
                {
                    StartCoroutine(ActiveCoroutine());
                }
            }
            else if (isSkipCoroutine)
            {
                HideSelect();
            }


        }
       else if(vid.time>(endTimeSec-timeDelta)&&vid.time<endTimeSec)
		{
            if (!isAnimCoroutine&&!SceneChanged.isChangeScenePressed)
			{
                StartCoroutine(AnimCoroutine());
            }
                
        }
        else if (vid.time>(endTimeSec+timeDelta))
		{
            if (!isDeactiveCoroutine&&!SceneChanged.isChangeScenePressed)
            {
                StartCoroutine(DeactiveCoroutine());
            }
            
        }
        if((ulong)vid.frame>=vid.frameCount)
		{
            Application.Quit();
        }
        

    }
    public void SceneLoad(string sceneName)
    {
        SceneChanged.FrameOhWhichChanged = vid.frame;
        SceneManager.LoadScene(sceneName);
    }

    public void PlayVid()
	{
        if (SceneChanged.isChangeScenePressed)
        {
            vid.frame = SceneChanged.FrameOhWhichChanged;
            
        }
    }
    public void HideSelect()
	{
        DeactiveCoroutine();
    }

    IEnumerator ActiveCoroutine()
	{
        selectLocationPrefab.SetActive(true);
        anim.SetTrigger("Activate");
        isCoroutineActive = true;
        yield return null;
    }
    IEnumerator DeactiveCoroutine()
    {
        selectLocationPrefab.SetActive(false);
        isDeactiveCoroutine = true;
        yield return null;
    }
    IEnumerator AnimCoroutine()
	{
        anim.SetTrigger("Deactivate");
        isAnimCoroutine = true;
        yield return null;
    }
    IEnumerator SkipCoroutine()
    {
        SceneChanged.isChangeScenePressed = false;
        isSkipCoroutine = true;
        selectLocationPrefab.SetActive(false);
        yield return null;
    }


}
