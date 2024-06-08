using UnityEngine;
using UnityEngine.UI;

public class ButtonIndexTracker : MonoBehaviour
{
    public Button[] buttons; // Массив кнопок для выбора фона
    public Button changeBackgroundButton; // Кнопка для изменения фона
    public BackgroundChanger backgroundChanger; // Скрипт для изменения фона
    private int selectedBackgroundIndex = -1; // Выбранный индекс фона

    void Start()
    {
        if (buttons == null || buttons.Length == 0)
        {
            Debug.LogError("Buttons array is not assigned or empty.");
            return;
        }

        if (changeBackgroundButton == null)
        {
            Debug.LogError("ChangeBackgroundButton is not assigned.");
            return;
        }

        if (backgroundChanger == null)
        {
            Debug.LogError("BackgroundChanger is not assigned.");
            return;
        }

        // Добавляем слушатели к каждой кнопке выбора фона
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Локальная переменная для замыкания
            if (buttons[i] != null)
            {
                buttons[i].onClick.AddListener(() => OnButtonClicked(index));
            }
            else
            {
                Debug.LogWarning($"Button at index {i} is not assigned.");
            }
        }

        // Прячем кнопку изменения фона
        changeBackgroundButton.gameObject.SetActive(true);
        changeBackgroundButton.onClick.AddListener(ChangeBackground);
    }

    void OnButtonClicked(int buttonIndex)
    {
        selectedBackgroundIndex = buttonIndex; // Запоминаем индекс нажатой кнопки
        Debug.Log($"Button with index {buttonIndex} was clicked");

        // Показываем кнопку изменения фона
        changeBackgroundButton.gameObject.SetActive(true);
    }

    void ChangeBackground()
    {
        if (selectedBackgroundIndex >= 0)
        {
            backgroundChanger.ChangeBackground(selectedBackgroundIndex);
        }
        else
        {
            Debug.LogWarning("No background index selected.");
        }
    }
}
