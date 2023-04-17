using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Easy;
    public Button Standard;
    public Button Random;
    public Button Impossible;
    public TMP_InputField input1;
    void Start()
    {
        Button btn_easy = Easy.GetComponent<Button>();
        btn_easy.onClick.AddListener(EasyClick);

        Button btn_standard = Standard.GetComponent<Button>();
        btn_standard.onClick.AddListener(StandardClick);

        Button btn_random = Random.GetComponent<Button>();
        btn_random.onClick.AddListener(RandomClick);

        Button btn_impossible = Impossible.GetComponent<Button>();
        btn_impossible.onClick.AddListener(ImpossibleClick);


    }

    void StandardClick()
    {
        PlayerPrefs.SetInt("mode", 0);
        SceneManager.LoadScene("Hra");
    }

    void EasyClick()
    {
        PlayerPrefs.SetInt("mode", 1);
        PlayerPrefs.SetInt("lives", int.Parse(input1.text));
        SceneManager.LoadScene("Hra");
    }
    void RandomClick()
    {
        PlayerPrefs.SetInt("mode", 2);
        SceneManager.LoadScene("Hra");
    }
    void ImpossibleClick()
    {
        PlayerPrefs.SetInt("mode", 3);
        SceneManager.LoadScene("Hra");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
