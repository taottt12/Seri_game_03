using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 5;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpaner;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private Image energyBar;
    private bool bossCalled = false;

    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnergy(){
        if(bossCalled) return;
        currentEnergy += 1;
        UpdateEnergyBar();
        if(currentEnergy == energyThreshold){
            CallBoss();
        }
    }

    private void CallBoss(){
        bossCalled = true;
        boss.SetActive(true);
        enemySpaner.SetActive(false);
        gameUI.SetActive(false);
    }

    private void UpdateEnergyBar(){
        if(energyBar != null){
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }
}
