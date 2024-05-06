using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sebuah Item. Ketika bersentuhan akan membuat perahu menjadi lambat sejenak.
/// </summary>

public class IDebuff : Item
{
    [SerializeField] float time = 2f;
    [SerializeField] float debuffSpeed = 2f;
    [SerializeField] string hitSFX = "Obstacle";

    public override void Acive(Movement collision)
    {
        coll2d.enabled = false;
        spriteRenderer.enabled = false;

        collision.GetDebuff(time, debuffSpeed);
        if (AudioManager.instance != null) AudioManager.instance.Play(hitSFX);
    }
}
