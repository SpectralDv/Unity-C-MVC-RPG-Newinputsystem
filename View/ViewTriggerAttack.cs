using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace View
{
    public class ViewTriggerAttack : MonoBehaviour
    {
        private float _damage;
        private string _nameAttacker;

        public Material[] defaultMaterial;
        public Material[] hitMaterialRed;

        void Start()
        {
            if (transform.GetComponent<BoxCollider>() != null)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
            }
        }

        public void SetDamage(float damage)
        {
            _damage = damage;
        }
        public void SetNameAttacker(string nameAttacker)
        {
            _nameAttacker = nameAttacker;
        }

        public void ActiveCollider()
        {
            if (transform.GetComponent<BoxCollider>() != null)
            {
                transform.GetComponent<BoxCollider>().enabled = true;
                transform.Find("Weapon").gameObject.GetComponent<SkinnedMeshRenderer>().materials = hitMaterialRed;
            }
        }
        public void DisActiveCollider()
        {
            if (transform.GetComponent<BoxCollider>() != null)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
                transform.Find("Weapon").gameObject.GetComponent<SkinnedMeshRenderer>().materials = defaultMaterial;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.transform.GetComponent<ViewTakeDamage>() != null)
            {
                Debug.Log(_damage);
                other.gameObject.transform.GetComponent<ViewTakeDamage>().TakeDamage(_nameAttacker, _damage);
            }
        }

    }
}
