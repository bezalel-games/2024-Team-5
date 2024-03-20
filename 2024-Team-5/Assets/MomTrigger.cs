using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MomTrigger : MonoBehaviour
{
    [SerializeField] private GameObject mom;
    [SerializeField] private GameObject player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mom.gameObject.SetActive(true);
            StartCoroutine(PlayMomAnimation(16.667f));
        }
    }

    private IEnumerator PlayMomAnimation(float duration)
    {
        yield return new WaitForSeconds(duration);
        mom.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
