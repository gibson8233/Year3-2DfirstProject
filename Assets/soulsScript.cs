﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulsScript : MonoBehaviour {
    playerDataClass playerdataclass;
    GameObject targetPositionGameObject;
    
    Vector2 targetPosition;
    Vector2 viewportPoint;

    Vector2 startPoint;

    float t;
    // Use this for initialization
    void Start () {
        playerdataclass = GameObject.FindGameObjectsWithTag("backgroundScipt")[0].GetComponent<playerDataClass>();
        targetPositionGameObject = GameObject.FindGameObjectsWithTag("soulsTargetPoint")[0];
        startPoint = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        t += 0.5f * Time.deltaTime;

        targetPosition = targetPositionGameObject.transform.position;
        transform.position = new Vector2(Mathf.Lerp(startPoint.x ,  targetPosition.x,  t), Mathf.Lerp(startPoint.y ,   targetPosition.y, t ));

        viewportPoint = Camera.main.ViewportToWorldPoint(targetPosition);


        if (transform.position.x  >= targetPosition.x - 1 &&
            transform.position.x <= targetPosition.x + 1 &&

            transform.position.y >= targetPosition.y - 1 &&
            transform.position.y <= targetPosition.y + 1 

            ) {
            GetComponent<ParticleSystem>().startColor -= new Color(0,0,0, (float)(0.6 * Time.deltaTime));
            if (GetComponent<ParticleSystem>().startColor.a <= 0.0f) {
                destroySelf();
            }

        }
    }
    void destroySelf() {
        playerdataclass.playerSouls++;
        Destroy(gameObject);
    }

}