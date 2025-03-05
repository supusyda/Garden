using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtn : BtnBase
{
    // Start is called before the first frame update
    protected override void OnClick()
    {
        base.OnClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
