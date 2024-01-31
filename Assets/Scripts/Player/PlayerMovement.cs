using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbPope;
    private BoxCollider2D coll;
    public float jumpSpeed = 7f;
    public float deathYCoordinate = -7f;
    [SerializeField] public float startingAmmo;
    public float currentAmmo { get; set; }
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject[] holyWater;

    private void Awake()
    {
        currentAmmo = startingAmmo;
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        rbPope = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rbPope.velocity = new Vector2(dirX * 8, rbPope.velocity.y);

        if (dirX > 0)
            transform.localScale = new Vector2(1, 1);
        else if (dirX < 0)
            transform.localScale = new Vector2(-1, 1);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rbPope.velocity = new Vector2(rbPope.velocity.x, jumpSpeed);
        }

        if (transform.position.y < deathYCoordinate || Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
               Application.Quit();
        }
        
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, .1f, jumpableGround);

    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool canAttack()
    {
        return currentAmmo > 0;
    }

    public int FindHolyWater()
    {
        for (int i = 0; i < holyWater.Length; i++)
        {
            if (!holyWater[i].activeInHierarchy) return i;
        }
        return 0;
    }
    public void AddAmmo(float ammoValue)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + ammoValue, 0, 5);
    }
    public void SetJumpSpeed(float newJumpSpeed)
    {
        jumpSpeed = newJumpSpeed;
    }
}
