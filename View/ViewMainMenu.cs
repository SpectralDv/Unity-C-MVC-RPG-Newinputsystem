using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace View
{
	public class ViewMainMenu : MonoBehaviour
	{
		public void ActiveMenu()
		{
			gameObject.SetActive(true);
		}
		public void DisActiveMenu()
		{
			gameObject.SetActive(false);
		}
	}
}