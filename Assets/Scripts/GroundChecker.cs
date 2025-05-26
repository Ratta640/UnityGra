using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    public bool isGrounded;
    public GroundChecker groundChecker;
    public BoxCollider2D collider;

    public void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        var collliders = Physics.OverlapBox(
            transform.position,
            collider.size/2);

    }
    //  private void OnCollisionEnter2D(Collision2D collision)
    //  {
    //    isGrounded = true;


   // private void OnCollisionExit2D(Collision2D collision)
   // {
     //   isGrounded = false;
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}