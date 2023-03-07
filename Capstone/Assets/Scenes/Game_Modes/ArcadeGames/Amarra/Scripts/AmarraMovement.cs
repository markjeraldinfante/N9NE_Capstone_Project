using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AmarraMovement : MonoBehaviour
{
    public float movesSpeed = 600f;
    float movement = 0f;
    [SerializeField] bool isfacingRight;
    [SerializeField] private ScoreSystem scoreSystem;
    public AmarraManager amarra;
    public MiniGameManager amarraManagerTanso;

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * -movesSpeed);

        if (movement > 0 && !isfacingRight)
        {
            isfacingRight = !isfacingRight;
            transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
        else if (movement < 0 && isfacingRight)
        {

            isfacingRight = !isfacingRight;
            transform.localScale = new Vector3(-0.05f, 0.05f, 0.05f);
        }
        else if (movement == 0)
        {

        };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int tansoReward = amarraManagerTanso.tansoAward;
        scoreSystem.SaveTanso(tansoReward);
        Time.timeScale = 0f;
        amarra.gameawardUI.GetComponent<popUp>().awardImage.sprite = scoreSystem.SOAmarra.awardImage;
        amarra.gameawardUI.GetComponent<popUp>().awardName.text = ("You got " + tansoReward + " tanso");
        scoreSystem.awardSystem(amarra.gameawardUI, amarra.gameOverUI);
    }


}
