using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace View
{
    public class ViewVisiblePanel : MonoBehaviour
    {

        private Slider sliderHealth;
        private Slider sliderMana;
        private Slider sliderExp;

        void Awake()
        {
            sliderHealth = transform.Find("HealthPlayer").GetComponent<Slider>();

            gameObject.SetActive(false);
        }

        void Update()
        {
            ViewHealth(100,100);
        }

        public void ActiveVisiblePanel()
        {
            gameObject.SetActive(true);
        }
        public void DisActiveVisiblePanel()
        {
            gameObject.SetActive(false);
        }

        public void ViewHealth(float maxHealth, float curHealth)
        {
            sliderHealth.maxValue = maxHealth;
            sliderHealth.value = curHealth;
        }
        public void ViewMana()
        {

        }
        public void ViewExp()
        {

        }

    }
}
