using UnityEngine;

//INCOMPLETE
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

    public void AddXP(int amount) //adding xp and checking if level up has been reached
    {
        xp += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp() //actually checking for level up
    {
        int xpToLevelUp = level;

        if (xp >= xpToLevelUp)
        {
            LevelUp();
        }
    }

    private void LevelUp() //levelling up
    {
        level++;

        if (level == 2 && pM != null) 
        {
            pM.SetJumpSpeed(10f);
        }
    }
}
