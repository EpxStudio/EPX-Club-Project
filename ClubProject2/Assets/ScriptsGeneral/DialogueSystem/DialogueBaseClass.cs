﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; protected set; }

        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound, float delayBetweenLines)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }
            
            // initiate next line with 'F' (can do automatically by changing to WaitForSeconds)
            //yield return new WaitForSeconds(delayBetweenLines);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
            finished = true;
        }
    }
}