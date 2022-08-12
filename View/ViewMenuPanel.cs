using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Controller.MenuPanel;
namespace View
{
	public class ViewMenuPanel : MonoBehaviour
	{
		ControllerMenuPanel controllerMenuPanel;

		void Awake()
        {
			controllerMenuPanel = new ControllerMenuPanel();
		}

	}
}

