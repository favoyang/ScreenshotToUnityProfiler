﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTJ.SS2Profiler
{
    public class ScreenShotBehaviour : MonoBehaviour
    {
        public System.Action captureFunc { get; set; }
        public System.Action updateFunc { get; set; }
        private WaitForEndOfFrame waitForEndOfFrame;
        // Start is called before the first frame update
        void Start()
        {
            this.StartCoroutine(Execute());
        }

        private void Update()
        {
            updateFunc?.Invoke();
        }

        // Update is called once per frame
        IEnumerator Execute()
        {
            while (true)
            {
                if (waitForEndOfFrame == null)
                {
                    waitForEndOfFrame = new WaitForEndOfFrame();
                }
                yield return waitForEndOfFrame;
                captureFunc?.Invoke(); 
            }
        }
    }
}