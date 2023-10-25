using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProgress : MonoBehaviour
{
    public GameObject objectOn;
	public GameObject button;
    private Animator anim;

	private void Awake()
	{
		anim = button.GetComponent<Animator>();
	}
	public void Activate()
	{
        if(objectOn.activeInHierarchy)
		{
            objectOn.SetActive(false);
		}
        else if (!objectOn.activeInHierarchy)
		{
            objectOn.SetActive(true);
        }
		anim.SetTrigger("Clicked");

	}
    
   
}
