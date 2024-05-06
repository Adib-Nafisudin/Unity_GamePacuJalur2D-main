using UnityEngine;

/// <summary>
/// Jenis movement AI. Pergerakan perahu akan bergantung pada kesempatan acak.
/// </summary>

public class MovementAI2 : MovementUser
{
    [Header("Movement AI 2")]
    [Tooltip("Rentang nilai maximal dari nilai kesempatan dayung perahu. Nilai minimal adalah 0.")]
    [SerializeField] private int maxRandomRange = 100;
    [Tooltip("Nilai tengah yang digunakan untuk menghitung kesempatan perahu berhasil. Ex: [chanceIndex]/[maxRandomRange] atau [50]/[100]")]
    [SerializeField] private int chanceIndex = 40;
    [SerializeField] private float dayungInterval = 1;
    private float timer = 0.0f;
    float dayungMoveChange;

    protected override void FixedUpdate()
    {
        if (!isStart)
            return;

        if (isEnd)
        {
            Move();
            AnimCheck();
            return;
        }

        if (isStunned)
        {
            AnimCheck();
            return;
        }

        Velocity();
        Move();
        AnimCheck();
    }

    protected override void Init()
    {
        base.Init();

        isPlayer = false;

        ZeroPower();
        AnimCheck();

        DayungPower(1f, 1f);
    }


    protected override void Update()
    {
        if (!isEnd || (isEnd && isMoveAfterEnd))
        {
            timer += Time.deltaTime;
            DayungAI();

            if (timer > dayungInterval)
            {
                timer = 0f;
                DayungPower();
            }
        }
    }

    private void DayungAI()
    {
        if (dayungMoveChange <= chanceIndex)
        {
            DayungPower(22,22);
        }
    }
    private void DayungPower()
    {
        dayungMoveChange = Random.Range(0, maxRandomRange);
    }
}
