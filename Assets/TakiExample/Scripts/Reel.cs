using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
{
    /// <summary>
    /// ��]���郊�[�����������܂��B
    /// </summary>
    public class Reel : MonoBehaviour, IReelStopable, IReelStartable
    {
        enum ReelState
        {
            Stop,
            Roll,
        }

        ReelState reelState;


        public void StopReel()
        {
            if(reelState == ReelState.Roll)
            {
                Debug.Log("���[�����~�߂܂����B");
                reelState = ReelState.Stop;
            }
            else
            {
                Debug.Log("���[���͎~�܂��Ă���͂��ł�");

            }
        }

        public void StartReel()
        {
            if (reelState == ReelState.Roll)
            {
                Debug.Log("���[���͊��ɉ���Ă��܂�");
                reelState = ReelState.Stop;
            }
            else
            {
                Debug.Log("���[���͉��n�߂�");

            }
        }
    }
}