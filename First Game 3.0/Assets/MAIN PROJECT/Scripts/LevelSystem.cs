using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem 
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

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
            if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public int GetLevelNumber() {
        return level;
    }

    public float GetExperinceNormalized() {
        return (float)experience / experinceToNextLevel;
    }

}
