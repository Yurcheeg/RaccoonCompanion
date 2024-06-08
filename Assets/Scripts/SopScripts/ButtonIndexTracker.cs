using UnityEngine;
using UnityEngine.UI;

public class ButtonIndexTracker : MonoBehaviour
{
    public Button[] buttons; // Массив кнопок для выбора фона
    
    //public Image imagge;
    public Button changeBackgroundButton; // Кнопка для изменения фона
    public BackgroundChanger backgroundChanger; // Скрипт для изменения фона
    private int selectedBackgroundIndex = -1; // Выбранный индекс фона

    void Awake()
    {
        
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Локальная переменная для замыкания
            if (buttons[i] != null)
            {
                buttons[i].image.sprite = backgroundChanger.backgroundSprites[i];
                buttons[i].onClick.AddListener(() => OnButtonClicked(index));
            }
            else
            {
                Debug.LogWarning($"Button at index {i} is not assigned.");
            }
        }
    }
    void Start()
    {
        
        // Добавляем слушатели к каждой кнопке выбора фона
        

        // Прячем кнопку изменения фона
        changeBackgroundButton.gameObject.SetActive(true);
        changeBackgroundButton.onClick.AddListener(ChangeBackground);
    }

    void OnButtonClicked(int buttonIndex)
    {
        selectedBackgroundIndex = buttonIndex; // Запоминаем индекс нажатой кнопки

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
