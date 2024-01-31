using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int xp = 0;
    private int level = 1;
    private PlayerMovement pM;

    public int XP => xp;
    public int Level => level;

    private void Start()
    {
        pM = GetComponent<PlayerMovement>();
    }

    public void AddXP(int amount)
    {
        xp += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int xpToLevelUp = level;

        if (xp >= xpToLevelUp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;

        if (level == 2 && pM != null) 
        {
            pM.SetJumpSpeed(10f);
        }
    }
}
