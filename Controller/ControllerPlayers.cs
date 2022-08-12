using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Space;
using Model.Player;
namespace Controller.Players
{
    public class ControllerPlayers : MonoBehaviour
    {
        //[SerializeField]
        private List<ModelPlayer> listPlayer;

        public ControllerPlayers()
        {
            listPlayer = new List<ModelPlayer>();
        }

        public void AddPlayer()
        {
            float count = listPlayer.Count;

            for (int i = 0; i < count; i++)
            {
                listPlayer.Add(new ModelPlayer());
            }
        }

        public void RemovePlayer(ModelPlayer mp)
        {
            listPlayer.Remove(mp);
        }
    }
}
