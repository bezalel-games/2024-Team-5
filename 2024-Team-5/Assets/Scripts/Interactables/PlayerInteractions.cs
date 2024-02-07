using System;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
   public static PlayerInteractions Instance { get; private set; }
   [SerializeField] private Vector2 checkSize;
   private bool _hasArm;


   private void Awake()
   {
      Instance = Instance == null ? this : Instance;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && _hasArm)
      {
         Interact();
      }
   }

   private void Interact()
   {
      var results = Physics2D.OverlapBoxAll(transform.position,
         new Vector2(checkSize.x, checkSize.y), 0, LayerMask.GetMask("Interactable"));
      
      if (results.Length == 0) return;
      
      results[0].GetComponent<Interactable>().Interact();
      
   }
   
   public void SetHasArm(bool value)
   {
      _hasArm = value;
   }

   private void OnDrawGizmosSelected()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawWireCube(transform.position, new Vector3(checkSize.x, checkSize.y, 1));
   }
}
