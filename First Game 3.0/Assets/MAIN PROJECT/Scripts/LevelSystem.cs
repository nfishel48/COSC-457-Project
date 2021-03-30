using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem 
{
    private int level;
    private int experience;
    private int experinceToNextLevel;

    public LevelSystem(){
        level = 0;
        experience =0;
        experinceToNextLevel = 100;
    }

    public void AddExperience(int amount) {
        experience += amount;
        if (experience >= experinceToNextLevel) {
            // Enough experince to level up
            level++;
            experience -= experinceToNextLevel;
        }
    }

    
}
