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

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 0f;
        amarra.gameawardUI.GetComponent<popUp>().awardImage.sprite = scoreSystem.SOAmarra.awardImage;
        string tempScore = scoreSystem.SOAmarra.tansoAward.ToString();
        amarra.gameawardUI.GetComponent<popUp>().awardName.text = ("You got " + tempScore + " tanso");
        scoreSystem.awardSystem(amarra.gameawardUI, amarra.gameOverUI);
        // awardContainer.gameObject.SetActive(true);
        //Managers.instance.GetComponentInChildren<popUp>().awardName.text = ("You got" + tansoAward + "tanso");
        // PlayerPrefs.SetInt("Tanso", PlayerPrefs.GetInt("Tanso") + tansoAward);
        //Managers.instance.GetComponentInChildren<popUp>().gameObject.SetActive(true);
    }
}
