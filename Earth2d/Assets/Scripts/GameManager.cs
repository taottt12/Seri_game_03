using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.Cinemachine;

public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 15;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpaner;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private Image energyBar;
    private bool bossCalled = false;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseGameMenu;
    [SerializeField] private GameObject winGameMenu;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CinemachineCamera cam;

    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
        MainMenu();
        audioManager.StopAudioGame();
        cam.Lens.OrthographicSize = 7.5f;
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
        audioManager.PlayBossAudio();
        cam.Lens.OrthographicSize = 11f;
    }

    private void UpdateEnergyBar(){
        if(energyBar != null){
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }

    public void MainMenu(){
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        winGameMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void GameOverMenu(){
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        pauseGameMenu.SetActive(false);
        winGameMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void PauseGameMenu(){
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseGameMenu.SetActive(true);
        winGameMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StartGame(){
         mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        winGameMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultAudio();
    }

    public void ResumeGame(){
         mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        winGameMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void WinGameMenu(){
        winGameMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        WaitForWinAnimation();
    }

    private IEnumerator WaitForWinAnimation() {
    Animator animator = winGameMenu.GetComponent<Animator>();
    
    if (animator != null) {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
    }

    Time.timeScale = 0f;
}
}
