﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Text[] buttonList;
	private string playerSide;
	public GameObject gameOverPanel;
	public Text gameOverText;
	private int moveCount;

	void Awake()
	{
		moveCount = 0;
		gameOverPanel.SetActive(false);
		SetGameControllerReferenceOnButtons();
		playerSide = "X";
	}

	public string GetPlayerSide()
	{
		return playerSide;
	}

	void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
	}

	public void EndTurn()
	{
		//Debug.Log ("EndTurn is not implemented!");
		moveCount++;

		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
		{
			GameOver();
		}

		if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
		{
			GameOver();
		}

		if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver();
		}

		if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver();
		}

		if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
		{
			GameOver();
		}

		if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver();
		}

		if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver();
		}

		if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver();
		}

		if (moveCount >= 9)
		{
			gameOverPanel.SetActive(true);
			gameOverText.text = "It's a draw!";
		}

		ChangeSides();
	}

	void GameOver()
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<Button>().interactable = false;
		}
		SetGameOverText(playerSide + " Wins!");
	}

	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive(true);
		gameOverText.text = value;
	}

	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
		}
	}
}
