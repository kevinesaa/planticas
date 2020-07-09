using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IHealthManager
{
    public event Action<int, int> OnHealthChange;
    public event Action<int> OnHealtZero;

    public float movementSpeed;
    public int maxEnergy;
    public float stunTime;

    public Vector2 FacingVector { get; private set; }

    private int playerId;
    private PlayerInput playerInput;
    private Rigidbody2D mRigidbody2D;
    private Vector2 currentVelocity;
    private int energy;
    private bool canPunch;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        mRigidbody2D = GetComponent<Rigidbody2D>();
        currentVelocity = mRigidbody2D.velocity;
        FacingVector = transform.right;
        energy = maxEnergy;
        canPunch = true;
    }


    void Update()
    {
        if (energy > 0)
        {
            currentVelocity.x = playerInput.AxisMoveX;
            currentVelocity.y = playerInput.AxisMoveY;
            Flip();
            currentVelocity.Normalize();
            mRigidbody2D.velocity = movementSpeed * currentVelocity;
            if (canPunch && playerInput.Punch)
            {
                Debug.Log("punch " + playerInput.inputPostfix);
            }
        }
    }

    void FixedUpdate()
    {
        Facing();
    }

    public int GetHealth()
    {
        return energy;
    }

    public int GetMaxHealth()
    {
        return maxEnergy;
    }

    public void ModifyHealt(int modifier)
    {
        energy += modifier;
        if (OnHealthChange != null)
            OnHealthChange(playerId, modifier);
        if (energy <= 0)
        {
            if (OnHealtZero != null)
                OnHealtZero(playerId);
        }
        else
        {
            if (energy > maxEnergy)
                energy = maxEnergy;
        }
    }

    private void Flip()
    {
        if ((currentVelocity.x * transform.right.x) < 0)
        {
            transform.Rotate(0, 180, 0);
        }

        if ((currentVelocity.y * transform.up.y) < 0)
        {
            transform.Rotate(180, 0, 0);
        }
    }

    private void Facing()
    {
        if (currentVelocity.x != 0 || currentVelocity.y != 0)
        {
            FacingVector = (currentVelocity.x * Vector2.right) + (currentVelocity.y * Vector2.up);
        }
        FacingVector.Normalize();
        Debug.DrawRay(transform.position, FacingVector * 3, Color.red);
    }

    internal void SetPlayerId(int id)
    {
        this.playerId = id;
    }

    public int GetId()
    {
        return this.playerId;
    }
}
