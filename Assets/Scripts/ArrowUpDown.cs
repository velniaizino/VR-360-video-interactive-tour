using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUpDown : MonoBehaviour
{
    public GameObject arrow;
    public float speed;
    public float height;
    private Transform arrowStartPos;
    private float startYPos;

	 void Awake()
	{
        arrowStartPos = arrow.GetComponent<Transform>();
        startYPos = arrowStartPos.position.y;

    }

	void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, height)+startYPos;
        arrow.transform.position = new Vector3(arrowStartPos.position.x, y, arrowStartPos.position.z);
    }
    
}
