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
    private PlayerStats pS;

    private void Awake() //setting ammo
    {
        currentAmmo = startingAmmo;      
    }

    private void Start()
    {
        rbPope = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        pS = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal"); //check for Input and move player
        rbPope.velocity = new Vector2(dirX * 8, rbPope.velocity.y);

        if (dirX > 0) //right
            transform.localScale = new Vector2(1, 1);
        else if (dirX < 0) //left
            transform.localScale = new Vector2(-1, 1);

        if (Input.GetButtonDown("Jump") && IsGrounded()) //jumping only enabled when player is touching ground
        {
            rbPope.velocity = new Vector2(rbPope.velocity.x, jumpSpeed);
        }

        if (transform.position.y < deathYCoordinate || Input.GetKeyDown(KeyCode.R)) //Restart level if R is pressed or the player fell beneath a threshold
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) //Quitting with Esc-Key
        {
               Application.Quit();
        }
        
    }

    private bool IsGrounded() //Check if player is touching terrain
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, .1f, jumpableGround);

    }


    private void RestartLevel() //Reloading level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool canAttack() //can only attack when ammo is more than 0
    {
        return currentAmmo > 0;
    }

    public int FindHolyWater() //access to pooled HolyWater
    {
        for (int i = 0; i < holyWater.Length; i++)
        {
            if (!holyWater[i].activeInHierarchy) return i;
        }
        return 0;
    }
    public void AddAmmo(float ammoValue) //adding ammo 
    {
        currentAmmo = Mathf.Clamp(currentAmmo + ammoValue, 0, 5);
    }
    public void SetJumpSpeed(float newJumpSpeed) //resetting jump speed
    {
        jumpSpeed = pS.newJumpSpeed;
    }
}
