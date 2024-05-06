using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sebuah Item. Ketika bersentuhan akan membuat perahu menjadi stunned/terhenti sejenak.
/// </summary>

public class IObstacle : Item
{
    [SerializeField] float time = 1f;

    public override void Acive(Movement collision)
    {
        coll2d.enabled = false;
        spriteRenderer.enabled = false;

        collision.GetStunned(time);
        if (AudioManager.instance != null) AudioManager.instance.Play("Obstacle");

    }
}
