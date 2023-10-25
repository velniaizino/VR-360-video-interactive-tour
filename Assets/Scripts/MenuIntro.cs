using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuIntro : MonoBehaviour
{
    public GameObject menu;
    public GameObject loadingBar;
    public Image loadingBarProg;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    
    public void StartGame()
    {
        HideMenu();
       // ShowLoadingScreen();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("MainScene"));
        StartCoroutine(LoadingScreen());
    }
    public void HideMenu()
	{
        menu.SetActive(false);
	}
    // Update is called once per frame
    public void ShowLoadingScreen()
	{
        loadingBar.SetActive(true);
	}
    IEnumerator LoadingScreen()
	{
        float totalProgress = 0;
        for(int i=0; i<scenesToLoad.Count; i++)
		{
            while(!scenesToLoad[i].isDone)
			{
                totalProgress += scenesToLoad[i].progress;
                loadingBarProg.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
			}
		}
	}

    public void ExitGame()
	{
        Application.Quit();
	}
}
