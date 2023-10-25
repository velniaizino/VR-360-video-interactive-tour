using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainChangeScene : MonoBehaviour
{
    public bool isSelected;
    void Start()
    {
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
            isSelected = true;
		}
	}
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isSelected = false;
        }
    }

    public void EnterMainScene()
	{
            SceneManager.LoadScene(1);
	}
}
