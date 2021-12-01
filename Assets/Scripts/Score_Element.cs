using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Element : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text LevelText;

    public void NewScoreElement (string _username, int _level)
    {
        usernameText.text = _username;
        LevelText.text = _level.ToString();
    }
}
