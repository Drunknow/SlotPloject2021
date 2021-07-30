using System;
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


        //���[���}�l�[�W���[����C�x���g���󂯎��̂��B
        //��̓I�ɂ́A���[�����~�߂邱�Ƃɐ��������ۂɔ��΂��ׂ��֐��B
        Action reelStopEvent;

        /// <summary>
        /// ���g���Q�Ƃ��Ă��郊�[�����~�߂�֐�
        /// </summary>
        public void StopReel()
        {
            if(reelState == ReelState.Roll)
            {
                Debug.Log("���[�����~�߂܂����B");
                reelStopEvent();//�}�l�[�W���[����󂯎�����C�x���g�𔭉�
                reelState = ReelState.Stop;
            }
            else
            {
                Debug.Log("���[���͎~�܂��Ă���͂��ł�");

            }
        }
        /// <summary>
        /// ���g���Q�Ƃ��Ă��郊�[�����񂷊֐�
        /// </summary>
        public void StartReel()
        {
            if (reelState == ReelState.Roll)
            {
                Debug.Log("���[���͊��ɉ���Ă��܂�");
            }
            else
            {
                Debug.Log("���[���͉��n�߂�");
                reelState = ReelState.Roll;

            }
        }

        public void SetStopEvent(Action action)
        {
            reelStopEvent = action;
        }
    }
}