using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMapTile : MonoBehaviour {

    public Transform mapBackground;
    public Transform mapWallTile;
    public Transform monster;
	// Use this for initialization
	void Start () {
        //배경화면 생성
        Transform newMapBackground  = Instantiate(mapBackground);
        newMapBackground.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MapBackground/base");
        newMapBackground.transform.position = new Vector3(0, 0, (float)LayerType.backGround);
        newMapBackground.parent = transform;

        //벽 생성
        for (int i = 0; i < 2; i++)
        {
            Transform newWallTile = Instantiate(mapWallTile);
            newWallTile.name = "wallTile" + i;
            newWallTile.parent = transform;

            if (i == 0)
                newWallTile.transform.position = new Vector3(-3, 6.4f, (float)LayerType.tile);
            if (i == 1)
                newWallTile.transform.position = new Vector3(2.2f, 6.4f, (float)LayerType.tile);


        }

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
