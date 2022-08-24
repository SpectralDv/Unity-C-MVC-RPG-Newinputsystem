using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace View
{
    public class ViewVisiblePanel : MonoBehaviour
    {
        public float numPlayer;
        private Slider sliderHealth;
        private Slider sliderMana;
        private Slider sliderExp;

        void Awake()
        {
            sliderHealth = transform.Find("HealthPlayer").GetComponent<Slider>();

            //gameObject.SetActive(false); //it make Player
        }

        void Update()
        {
            //ViewHealth(100,100);
        }

        public float GetNumPlayer()
        {
            return numPlayer;
        }

        public void ActiveVisiblePanel()
        {
            gameObject.SetActive(true);
        }
        public void DisActiveVisiblePanel()
        {
            gameObject.SetActive(false);
        }

        public void ViewHealth(float maxHealth, float health)
        {
            sliderHealth.maxValue = maxHealth;
            sliderHealth.value = health;
        }
        public void ViewMana()
        {

        }
        public void ViewExp()
        {

        }
    }
}
