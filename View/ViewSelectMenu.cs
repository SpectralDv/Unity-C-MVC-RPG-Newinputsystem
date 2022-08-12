using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Space
{
	public class ViewSelectMenu : MonoBehaviour, IMenu
	{
		public void ActiveMenu()
		{
			gameObject.SetActive(true);
		}
		public void CancleMenu()
		{
			gameObject.SetActive(false);
		}
	}
}