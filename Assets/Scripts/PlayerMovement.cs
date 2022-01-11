using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

[SerializeField] GameObject fpsCam;
 CharacterController controller;
  [SerializeField] float speed = 12f;
  [SerializeField] float gravity= -10f;
  [SerializeField] Transform groundCheck;
  [SerializeField] float groundDistance = 0.4f;
  [SerializeField] float jumpHeight = 15f;
  [SerializeField] LayerMask groundMask;
  float height;
  float halfHeight;

 

  public bool isGrounded;
 bool isCrouching = false;
  Vector3 velocity;



void Start() 
{
    controller = GetComponent<CharacterController>();
    height = controller.height;
    halfHeight = controller.height * 0.5f;
  
    
}
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move* speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            if(!isCrouching)
            {
                StartCoroutine(Crouch(.5f));
            }
            else StartCoroutine(Stand(.5f));

        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
    IEnumerator Crouch(float time)
    {
        if (isCrouching) yield break;
        while(controller.height > halfHeight)
        {
            controller.height -= Time.deltaTime / time;
            if (controller.height <= halfHeight)
            isCrouching = true;
            yield return null;
        }
    }
    IEnumerator Stand(float time)
    {
        if (!isCrouching) yield break;
        while(controller.height <= height)
        {
            controller.height += Time.deltaTime / time;
            if (controller.height >= height)
                isCrouching = false;
            yield return null;
        }
    }
    
}


