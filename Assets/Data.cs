using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DieSim
{
    public class Data : MonoBehaviour
    {
        [SerializeField]
        Bars resultBars;

        Dictionary<Die.DieFace, int> dataDict = new Dictionary<Die.DieFace, int>();

        public void InitGraph(int maxValue)
        {
            CancelInvoke("UpdateGraph");
            dataDict = new Dictionary<Die.DieFace, int>()
            {
                    { Die.DieFace.ONE, 0 },
                    { Die.DieFace.TWO, 0 },
                    { Die.DieFace.THREE, 0 },
                    { Die.DieFace.FOUR, 0 },
                    { Die.DieFace.FIVE, 0 },
                    { Die.DieFace.SIX, 0 },
            };
            resultBars.SetMax(maxValue);
            InvokeRepeating("UpdateGraph", 0, 1f);
        }

        public void Record(Dictionary<Die.DieFace, int> results)
        {
            //Debug.Log(string.Format("{0},{1},{2},{3},{4},{5}",
            //    dataDict[Die.DieFace.ONE],
            //    dataDict[Die.DieFace.TWO],
            //    dataDict[Die.DieFace.THREE],
            //    dataDict[Die.DieFace.FOUR],
            //    dataDict[Die.DieFace.FIVE],
            //    dataDict[Die.DieFace.SIX]));
            results.ToList().ForEach(x => dataDict[x.Key] += x.Value);
        }

        public void Clear()
        {
            dataDict.Clear();
        }

        void UpdateGraph()
        {
            resultBars.SetValues(
                dataDict[Die.DieFace.ONE], 
                dataDict[Die.DieFace.TWO],
                dataDict[Die.DieFace.THREE],
                dataDict[Die.DieFace.FOUR],
                dataDict[Die.DieFace.FIVE], 
                dataDict[Die.DieFace.SIX]);
        }
    }
}

