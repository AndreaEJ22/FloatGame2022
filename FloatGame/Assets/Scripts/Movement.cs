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

    private Vector3 movePlayer;
    public float turnSmooth=0f;
    public float turnSmoothTime = 0f;

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

        player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime);
        PlayerRotate();
    }
    private void PlayerRotate()
    {
        float _targetAngle = Mathf.Atan2(playerInput.x, playerInput.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref turnSmooth, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
   

}
