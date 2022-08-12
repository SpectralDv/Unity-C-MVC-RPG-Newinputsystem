using System;
using System.Collections.Generic;
using UnityEngine;


using Model;
namespace Controller.MenuPanel
{
    enum eMenuPanel
    {
        SelectMenuPanel,
        VisiblePanel
    };


    public class ControllerMenuPanel
    {
        private List<ModelMenuPanel> _listMenuPanel;

        public ControllerMenuPanel()
        {
            _listMenuPanel = new List<ModelMenuPanel>();

            foreach (var i in Enum.GetValues(typeof(eMenuPanel)))
            {
                _listMenuPanel.Add(new ModelMenuPanel { 
                    _nameModel = i.ToString(), 
                    _position = new Vector3(0,0,0), 
                    _size = new Vector2(1920, 1080) });
            }
        }

        public void PositionMenuPanel(string nameMenuPanel , Vector3 position)
        {
            _listMenuPanel.Find(x => x._nameModel.Contains(nameMenuPanel))._position = position;
        }
        public void SizeMenuPanel(string nameMenuPanel, Vector3 size)
        {
            _listMenuPanel.Find(x => x._nameModel.Contains(nameMenuPanel))._size = size;
        }


    }
}

