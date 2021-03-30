using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    private Text levelText;
    private Image experienceBarImage;

    private void Awake() {
        levelText = transform.Find("levelText").GetComponent<Text>();
        experienceBarImage = transform.Find("ExpBar").GetComponent<Image>();

        SetExperienceBarSize(.5f);
        SetLevelNumber(7);
    }

    private void SetExperienceBarSize(float experienceNormalized){
        experienceBarImage.fillAmount = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber) {
        levelText.text = "Level "+ (levelNumber + 1);
    }
}
