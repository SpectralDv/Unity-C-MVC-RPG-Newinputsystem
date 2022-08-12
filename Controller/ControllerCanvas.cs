using System;
using System.Collections.Generic;
using UnityEngine;


using Model;
namespace Controller.Canvas
{
    enum eListMenuPanel
    {
        _listSelectMenu,
        _listVisiblePanel
    }

    public class ControllerCanvas
    {
        private ModelCanvas _mCanvas;
        private List<ModelMenuPanel> _listMenuPanel;

        public ControllerCanvas()
        {

            _listMenuPanel = new List<ModelMenuPanel>();
            _mCanvas = new ModelCanvas();
        }

        public void SetCountPlayer(float value)
        {
            _mCanvas._countPlayer = value;
        }
        public float GetCountPlayer()
        {
            return _mCanvas._countPlayer;
        }

        public void AddListMenuPanel(string nameMenuPanel, Vector3 position, Vector2 size)
        {
            if (_mCanvas._countPlayer < 4)
            {
                _listMenuPanel.Add(new ModelMenuPanel
                {
                    _nameModel = nameMenuPanel,
                    _position = position,
                    _size = size
                });

                _mCanvas._countPlayer++;
            }
        }
        public void RemoveListMenuPanel(string nameMenuPanel)
        {
            if (_mCanvas._countPlayer > 0)
            {
                ModelMenuPanel mmp = _listMenuPanel.Find(x => x._nameModel.Contains(nameMenuPanel));
                _listMenuPanel.Remove(mmp);

                _mCanvas._countPlayer--;
            }
        }

    }
}

