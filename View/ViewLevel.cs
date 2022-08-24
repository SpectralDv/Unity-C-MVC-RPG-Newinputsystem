using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Controller.Level;
namespace View
{
	public class ViewLevel : MonoBehaviour
	{
		ControllerLevel controllerLevel;

		void Awake()
        {
			controllerLevel = new ControllerLevel();
			Debug.Log("ViewLevel");

		}

		void Start()
        {
			//Debug.Log(controllerLevel.GetExpForNextLevel(99));
		}
	}
}