using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimScript : MonoBehaviour
{
  private Animator animator;

  private void Awake()
  {
    animator = GetComponent<Animator>();
  }

  private void Update()
  {
      if (Input.GetKeyDown(KeyCode.Space))
      {
          animator.SetTrigger("isRun");
      }
  }
  
}
