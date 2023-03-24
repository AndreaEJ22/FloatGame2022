using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public float forceBullet = -35;

    public float playerSpeed=40f;

    [SerializeField] private GameObject imageLostPrefab;
    [SerializeField] public TextMeshProUGUI Ducklife;
    int number = 3;
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.Move(new Vector3(horizontalMove, 0,forceBullet) * playerSpeed * Time.deltaTime);
        }
        PlayerRotate();
    }
    private void PlayerRotate()
    {
        float _targetAngle = Mathf.Atan2(playerInput.x, playerInput.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref turnSmooth, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enter");
            number -= 1;
            Ducklife.text = number.ToString();
            if (number <= 0)
            {
                dead();
            }
        }

    }
    private void dead()
    {
        imageLostPrefab.gameObject.SetActive(true);
    }
}
   
