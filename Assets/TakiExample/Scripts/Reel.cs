using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
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
        [SerializeField] ReelRoll[] reelRolls;//3�̕\���������
        float realPos;//���[�����ǂ̒��x���������\���B

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
                for(int i = 0; i < reelRolls.Length; i++)
                {
                    reelRolls[i].isRolling = false;
                }
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
                for (int i = 0; i < reelRolls.Length; i++)
                {
                    reelRolls[i].isRolling = true;
                }
            }
        }

        public void SetStopEvent(Action action)
        {
            reelStopEvent = action;
        }


        
        /// <summary>
        /// ���[���̏��Ԃ������̏��Ɏ��
        /// </summary>
        /// <returns></returns>
        public int[] GetAllReel()
        {

            int[] returnArray = new int[reelRolls.Length];
            reelRolls = reelRolls.OrderByDescending(a => a.transform.position.y).ToArray();
            for(int i = 0; i < reelRolls.Length; i++)
            {
                returnArray[i] = reelRolls[i].GetZugara();
                //Debug.Log(reelRolls[i].GetZugara());
            }
            return returnArray;
        }


    }
}
