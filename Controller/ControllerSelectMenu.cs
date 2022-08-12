using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Space
{
    public class ControllerSelectMenu : MonoBehaviour
    {
        //список меню для выбора персонажей
        List<ModelSelectMenu> listSelectMenu = new List<ModelSelectMenu>();

        ControllerSelectMenu(float widthWindow, float heightWindow)
        {
            ModelSelectMenu SelectMenu = new ModelSelectMenu();
        }
        public void SizeSelectMenu()
        {
            //rectTransfrom1.sizeDelta = new Vector2(-ScreenWidth / 2, -150);
            
        }
        public void PositionSelectMenu()
        {
            //rectTransfrom1.anchoredPosition = new Vector3(-ScreenWidth / 4, 0, 0);
        }

    }
}
