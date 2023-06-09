﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection.Emit;

public class PlayerRight : MonoBehaviour {
	public Rigidbody2D rb;
	public float jumpforce = 10f;
	public enum State
	{
		normal,
		jumping
	}
	public State s;
	void Update () {
		if(Input.GetMouseButtonDown (0) && Input.mousePosition.x > Screen.width/2  && s==State.normal)
		{
			rb.velocity = Vector2.right * jumpforce;
			s = State.jumping;
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag=="Ground")
		{
			s = State.normal;

		}
		if(col.gameObject.tag=="Block" || col.gameObject.tag=="Danger")
		{   FindObjectOfType<AudioManager> ().Play ("Gameover");
			FindObjectOfType<GameManager> ().EndGame();
		}
	}
}
     