using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Secrets.Movement;
using Secrets.Core;
using System;

namespace Secrets.Control
{
	public class PlayerController : MonoBehaviour
	{
        [SerializeField] Canvas winUI;
        [SerializeField] GameObject secret;
        [SerializeField] AudioClip[] footsteps;

        private AudioSource audioSource;
        Mover mover;

        private void Start()
        {
            mover = GetComponent<Mover>();
            audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (ProcessClick()) return;
        }

        private bool ProcessClick()
        {
            RaycastHit hit;
            if (Physics.Raycast(GetMouseRay(), out hit))
            {
                //if (hit.transform.GetComponent<TheSecret>() != null)
                //{
                   
                //} 
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point, 1f);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Secret")
            {
                winUI.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }

        // Animation Event
        void Step()
        {
            AudioClip step = footsteps[UnityEngine.Random.Range(0, footsteps.Length)];
            audioSource.PlayOneShot(step);
        }
    }
}

