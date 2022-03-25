using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameKit
{
    [CreateAssetMenu(fileName = "Colors", menuName = "ScriptableObjects/Colors", order = 1)]
    public class Colors : ScriptableObject
    {
        public ColorBlock colors;

        public ColorBlock.color_Piece GetRed()
        {
            return colors.colors.red;
        }
        public ColorBlock.color_Piece GetYellow()
        {
            return colors.colors.yellow;
        }
        public ColorBlock.color_Piece GetBlue()
        {
            return colors.colors.blue;
        }
        public ColorBlock.color_Piece GetGreen()
        {
            return colors.colors.green;
        }

        public ColorBlock.color_Piece GetRandom()
        {
            List<ColorBlock.color_Piece> colorsChosed = new List<ColorBlock.color_Piece>()
            {
                colors.colors.red,
                colors.colors.yellow,
                colors.colors.green,
                colors.colors.blue
            };

            return colorsChosed[UnityEngine.Random.Range(0, colorsChosed.Count)];
        }
    }
 
}