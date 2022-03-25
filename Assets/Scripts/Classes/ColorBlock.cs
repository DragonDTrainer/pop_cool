using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorBlock 
{
    public ColorsBlock colors;

    [System.Serializable]
    public struct ColorsBlock
    {
        public color_Piece red;
        public color_Piece yellow;
        public color_Piece green;
        public color_Piece blue;
    }

    [System.Serializable]
    public struct color_Piece
    {
        public int ID;
        public Color color;
        public string colorName;
    }
}
