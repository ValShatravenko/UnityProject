using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour {
	//[0, 1] - 0-фон стоїть на місці як платформи
	//1 - фон рухається так само як кролик
	public float slowdown = 0.5f;
	Vector3 lastPosition;
	void Awake() {
		lastPosition = Camera.main.transform.position;
	}
	void LateUpdate() {
		Vector3 newPosition = Camera.main.transform.position;
		Vector3 diff = newPosition - lastPosition;
		lastPosition = newPosition;
		Vector3 myPosition = this.transform.position;
		//Рухаємо фон в туж сторону що й камера але з іншою
		//швидкістю
		myPosition += slowdown * diff;
		this.transform.position = myPosition;
	}
}
