using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GamePauseUI : MonoBehaviour
    {
        #region Contents

        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button optionsButton;
        

        #endregion

        #region Unity: Awake | Start

        private void Awake()
        {
            resumeButton.onClick.AddListener(() => { KitchenGameManager.Instance.TogglePauseGame(); });
            mainMenuButton.onClick.AddListener(() => { Loader.Load(Scene.MainMenuScene); });
            optionsButton.onClick.AddListener(() =>
            {
                Hide();
                OptionsUI.Instance.Show(Show);
            });
        }

        private void Start()
        {
            AddEvents();
            
            Hide();
        }

        #endregion


        #region Show | Hide

        private void Show()
        {
            gameObject.SetActive(true);

            resumeButton.Select();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        #endregion


        #region Event: OnGameUnpaused

        private void OnGameUnpaused(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion

        #region Event: OnGamePaused

        private void OnGamePaused(object sender, EventArgs e)
        {
            Show();
        }

        #endregion

        #region Events: Add | Remove

        private void AddEvents()
        {
            KitchenGameManager.Instance.OnGamePaused += OnGamePaused;
            KitchenGameManager.Instance.OnGameUnpaused += OnGameUnpaused;
        }

        private void RemoveEvents()
        {
            KitchenGameManager.Instance.OnGamePaused -= OnGamePaused;
            KitchenGameManager.Instance.OnGameUnpaused -= OnGameUnpaused;
        }

        #endregion
    }
}