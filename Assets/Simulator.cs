using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DieSim
{
    public class Simulator : MonoBehaviour
    {
        [SerializeField]
        InputField inputNumSimulations;
        [SerializeField]
        InputField inputNumDice;
        [SerializeField]
        Toggle randomizeRotationToggle;
        [SerializeField]
        Text textSimNumber;

        int numSimulations = 100;
        int simulationNumber = 0;
        int numDice = 1;
        int initialRotation = 0;

        [SerializeField]
        Transform m_dropPosition;

        [SerializeField]
        Die m_die;
        [SerializeField]
        Die[] m_dice;

        Data data;



        private void Awake()
        {
            data = GetComponent<Data>();
        }

        void ParseSettings()
        {
            numSimulations = int.Parse(inputNumSimulations.text);
            numDice = int.Parse(inputNumDice.text);
            initialRotation = randomizeRotationToggle.isOn ? 1 : 0;
        }

        public void RunSimulation()
        {
            ParseSettings();
            data.Clear();
            data.InitGraph(numDice * numSimulations);
            StartCoroutine(RunSimulationCR());
        }

        public void StopSimulation()
        {
            StopAllCoroutines();
        }

        IEnumerator RunSimulationCR()
        {
            // Clear old dice
            for (int i = 0; i < m_dice.Length; i++)
            {
                Destroy(m_dice[i].gameObject);
            }


            // New Dice Amount
            m_dice = new Die[numDice];
            for (int i = 0; i < numDice; i++)
            {
                Die die = Instantiate(m_die, m_dropPosition.position, Quaternion.identity) as Die;
                m_dice[i] = die;
            }

            simulationNumber = 0;
            while (simulationNumber < numSimulations)
            {
                simulationNumber++;
                textSimNumber.text = string.Format("Simulation #: {0}", simulationNumber);
                CoroutineWithData cd = new CoroutineWithData(this, RollOnce());
                yield return cd.coroutine;
                data.Record((Dictionary<Die.DieFace, int>)cd.result);
            }
        }

        public IEnumerator RollOnce()
        {

            Dictionary<Die.DieFace, int> resultsDict = new Dictionary<Die.DieFace, int>();
            foreach (Die die in m_dice)
            {
                if (initialRotation == 0)
                {
                    die.transform.rotation = Random.rotation;    
                }
                else if (initialRotation == 1)
                {
                    die.transform.rotation = Quaternion.identity;
                }

                die.transform.position = m_dropPosition.position;
                die.Reset();
            }


            while (!AllDiceAsleep())
            {
                yield return new WaitForSeconds(0.1f);
            }
            //// m_die.transform.rotation = Random.rotation;
            //Vector3 baseRotation = m_die.transform.rotation.eulerAngles;
            //Vector3 pea = new Vector3(Random.Range(-peaValue, peaValue), Random.Range(-peaValue, peaValue), Random.Range(-peaValue, peaValue));
            //m_die.transform.rotation = Quaternion.Euler(baseRotation + pea);
            //m_die.transform.position = m_dropPosition.position;
            //m_die.Reset();
            foreach (Die die in m_dice)
            {
                if (!resultsDict.ContainsKey(die.Value))
                {
                    resultsDict.Add(die.Value, 1);
                }
                else
                {
                    resultsDict[die.Value]++;
                }
            }
            
            yield return resultsDict;
        }

        bool AllDiceAsleep()
        {
            foreach (Die die in m_dice)
            {
                if (!die.Asleep)
                {
                    return false;
                }
            }
            return true;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                Time.timeScale += 0.1f;
            }
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                Time.timeScale -= 0.1f;
            }

            if (Input.GetKeyDown(KeyCode.Tilde))
            {
                Time.timeScale = 1f;
            }

        }
    }
}

