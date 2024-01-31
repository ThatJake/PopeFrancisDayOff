using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected float direction;
    protected bool hit;
    protected float lifetime;
    private Animator anim;
    protected BoxCollider2D boxCollider;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 2) Deactivate();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("hit");
    }

    public void SetDirection(float setDirection)
    {
        lifetime = 0;
        direction = setDirection;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = Mathf.Sign(setDirection);
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    protected virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
