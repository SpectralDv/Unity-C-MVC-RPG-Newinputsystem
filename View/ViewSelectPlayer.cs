using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


using Player;
namespace View
{

    public class ViewSelectPlayer : MonoBehaviour
    {
        public GameObject GrayPersonage;
        public GameObject YellowPersonage;
        public GameObject PurpurPersonage;
        public GameObject BlackPersonage;
        public GameObject RedPersonage;

        public ViewPlayer viewPlayer;


        void Start()
        {
            viewPlayer = transform.GetComponent<ViewPlayer>();
        }

        public void ButtonGrayPersonage()
        {
            viewPlayer.SetPersonage(GrayPersonage);
        }

        public void ButtonYellowPersonage()
        {
            viewPlayer.SetPersonage(YellowPersonage);
        }
        public void ButtonPurpurPersonage()
        {
            viewPlayer.SetPersonage(PurpurPersonage);
        }
        public void ButtonBlackPersonage()
        {
            viewPlayer.SetPersonage(BlackPersonage);
        }
        public void ButtonRedPersonage()
        {
            viewPlayer.SetPersonage(RedPersonage);
        }
    }

}
