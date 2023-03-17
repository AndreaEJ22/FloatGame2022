using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontalMove = 10f;
    public float verticalMove = 7f;
    private Vector3 playerInput;

    public CharacterController player;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;


    public float playerSpeed=10f;
    void Start()
    {
        player = GetComponent<CharacterController>();
    }
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        player.Move(playerInput * playerSpeed * Time.deltaTime);
    }
     void camDirection()
    {
        camForward = mainCamera.transform.forward;
    }
   

}
