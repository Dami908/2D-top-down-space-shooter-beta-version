using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Assignment 1
//Emmanuel Ajayi 301050676
//Date last modified :October 5th,2019
//This script checks the unity controller and returns the float value of each bound set to be used by other classes
namespace Assets.Scripts
{
    [System.Serializable]
    public class Boundary
    {
        public float RightBounds;
        public float LeftBounds;
        public float TopBounds;
        public float BottomBounds;
    }
}
