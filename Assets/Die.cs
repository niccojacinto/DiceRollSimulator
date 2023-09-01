using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DieSim
{
    public class Die : MonoBehaviour
    {

        public enum DieFace { ONE, TWO, THREE, FOUR, FIVE, SIX };

        Dictionary<Vector3, DieFace> faceDirectionDict;

        Rigidbody m_rigidbody;
        bool m_asleep;
        public bool Asleep { get { return m_asleep; } }
        [SerializeField]
        DieFace m_value;
        public DieFace Value {  get { return m_value;} }


        AudioSource source;
        [SerializeField] 
        AudioClip sfx;
        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            source = GetComponent<AudioSource>();
            faceDirectionDict = new Dictionary<Vector3, DieFace>()
        {
            { Vector3.up          ,   DieFace.ONE     },
            { Vector3.down         ,   DieFace.SIX    },
            { Vector3.left      ,   DieFace.TWO   },
            { Vector3.right       ,   DieFace.FIVE   },
            { Vector3.forward     ,   DieFace.THREE   },
            { Vector3.back    ,   DieFace.FOUR     }

        };
            m_asleep = false;
        }

        private void FixedUpdate()
        {

            if (m_rigidbody.IsSleeping() && !m_asleep)
            {
                m_value = GetFaceUpValue();
                m_asleep = true;
            }
        }

        private DieFace GetFaceUpValue()
        {
            DieFace currentBest = DieFace.ONE;
            float closestAngle = 360f;

            foreach (KeyValuePair<Vector3, DieFace> kvp in faceDirectionDict)
            {
                float currentAngle = Vector3.Angle(Vector3.up, transform.rotation * kvp.Key);
                if (currentAngle < closestAngle)
                {
                    closestAngle = currentAngle;
                    currentBest = kvp.Value;
                }

            }
            return currentBest;

        }

        private void OnCollisionEnter(Collision collision)
        {
            source.PlayOneShot(sfx);
        }

        public void Reset()
        {
            m_asleep = false;
        }
    }

}
