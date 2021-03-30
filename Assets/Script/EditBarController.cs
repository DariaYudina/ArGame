using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBarController : MonoBehaviour
{
    public Button HealthButton;
    public ProgressBarScript ProgressBarScript;
    public CatScript catScript;

    // Start is called before the first frame update
    void Start()
    {
        //HealthButton = GetComponent<Button>();
        HealthButton.onClick.AddListener(AddHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (CatScript.PlayerCat)
        {
            catScript.health.value -= Time.deltaTime * 0.02f;
            ProgressBarScript.HealthBar.fillAmount = catScript.health.value;
        }
    }

    public void AddHealth()
    {
        catScript.health.value += 0.1f;
    }
}
