﻿/* ---------------------------------------
 * Author: Martin Pane (martintayx@gmail.com) (@tayx94)
 * Project: Graphy - Ultimate Stats Monitor
 * Date: 05-Mar-18
 * Studio: Tayx
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * -------------------------------------*/

using UnityEngine;
using UnityEngine.UI;

using System.Collections;

namespace Tayx.Graphy.CustomizationScene
{
	public class ForceSliderToMultipleOf3 : MonoBehaviour
	{
		[SerializeField] private Slider m_slider;
		
		void Start()
		{
			m_slider.onValueChanged.AddListener(UpdateValue);
		}

		private void UpdateValue(float value)
		{
			int roundedValue = (int)value;
			
			// Forces the value to be a multiple of 3, this way the audio graph is painted correctly

			if (roundedValue % 3 != 0 && roundedValue < 300)
			{
				roundedValue += 3 - roundedValue % 3;
			}

			m_slider.value = roundedValue;
		}
	}
}