
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

namespace SceneManagement
{
    public class Portal : MonoBehaviour
    {
        enum DestinationIdentifier
        {
            A,B,C,D,E,F
        }
        [SerializeField] int sceneToLead = -1;
        [SerializeField] DestinationIdentifier destination;
        [SerializeField] Transform spawnPoint;
        private void OnTriggerEnter(Collider other) 
        {
            if(other.tag == "Player")
            {
                    StartCoroutine(Tranition());
            }
        }
        private IEnumerator Tranition()
        {
            if (sceneToLead < 0)
            {
                Debug.LogError("Scene to load is not set");
                yield break;
            } 
            DontDestroyOnLoad(gameObject);
            yield return SceneManager.LoadSceneAsync(sceneToLead);

            Portal otherPortal= GetOtherPortal();
            UpdatePlayer(otherPortal);
            print("Scene Loaded");
            Destroy(gameObject);
        }

        private void UpdatePlayer(Portal otherPortal)
        {
           GameObject player = GameObject.FindWithTag("Player");
           player.transform.position = otherPortal.spawnPoint.position;
           player.transform.rotation = otherPortal.spawnPoint.rotation;
        }

        private Portal GetOtherPortal()
        {
           foreach(Portal portal in FindObjectsOfType<Portal>())
           {
                if (portal == this) continue;
                if(portal.destination != this.destination) continue;
                return portal;
           }
           return null;
        }
    }
   

}


