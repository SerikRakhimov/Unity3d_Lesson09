using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

   [SerializeField]
   private GamePanel gamePanel;

   [SerializeField]
   private ResultPanel resultPanel;

   // индекс/номер вопроса; по окончании вопросов/ответов в переменной i количество заданных вопросов (равно i + 1)
   private int i;

   // количество правильных ответов игрока
   private int countCorrect;

   // true - режим игры, false - режим вывода результатов
   private bool isGame;

   // список вопросов/ответов
   private IList<Question> list;

    public void Init(IList<Question> listValue)
    {
        list = listValue;
    }

    public void Start()
    {
	// обнулить переменные
        i = 0;
        countCorrect = 0;

	// включить игровую панель
        gamePanel.SetPanelActive(true);

	// включить режим игры
        isGame = true;
        
    }

    private void Update()
    {
	// режим игры
        if (isGame)
            {
                gamePanel.SetQuestionText(list[i].name_ru);
            }
	// режим вывода результатов
            else
            {
                resultPanel.SetText(i + 1, countCorrect);
            }
    }

    // проверка ответа игрока (переменная answer)
    public void SetAnswer(bool answer)
    {
	    // проверка "ответ правильный"
            if (answer == list[i].right_answer)
            {
                countCorrect++;
            }
	    
	    // проверка "последний вопрос"
            if( i == (list.Count - 1))
            {
                isGame = false;
                gamePanel.SetPanelActive(false);
                resultPanel.SetPanelActive(true);

            }
            else
            {
		// перейти к следующему вопросу
                i++;
            }

    }
}
