/*
 * Copyright (c) All Rights Reserved, VERGOSOFT LLC
 * Title: HypnoRem
 * Author: Scott Zastrow
 * 
 */
using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {



	void Update ()
    {
        this.transform.Rotate(Vector3.down * 1.75f * Time.deltaTime * 5f); /// rotates clockwise
	}
}
