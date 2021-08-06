using System;
using System.Linq;
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
        ReelRoll[] reelRolls;//3�̕\���������

        [SerializeField] float topY;//���[���̈�ԏ�ƂȂ���W
        [SerializeField] float bottomY;//���[���̒�ƂȂ���W

        //���[���}�l�[�W���[����C�x���g���󂯎��̂��B
        //��̓I�ɂ́A���[�����~�߂邱�Ƃɐ��������ۂɔ��΂��ׂ��֐��B
        Action reelStopEvent;

        void Start()
        {

            reelRolls = new ReelRoll[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                reelRolls[i] = transform.GetChild(i).GetComponent<ReelRoll>();
                reelRolls[i].topY = topY;
                reelRolls[i].bottomY = bottomY;
                reelRolls[i].symbolCount = reelRolls.Length;
                reelRolls[i].stopAllIconRolling = StopAllReelRolling;
            }
        }

        void FixedUpdate()
        {
            bool isEndRolling = false;
            foreach (ReelRoll reelRoll in reelRolls)
            {
                //�}���̏ꏊ�����炷
                if (reelRoll.isRolling)
                {
                    reelRoll.ScrollReel();
                }
                else if (reelRoll.isStopping)
                {
                    isEndRolling = reelRoll.ScrollReel() || isEndRolling;
                }
            }
            if (isEndRolling)
            {
                StopAllReelRolling();
            }
        }




        /// <summary>
        /// ���g���Q�Ƃ��Ă��郊�[�����~�߂�֐�
        /// </summary>
        public void StopReel()
        {
            if (reelState == ReelState.Roll)
            {
                Debug.Log("���[�����~�߂܂����B");
                reelStopEvent();//�}�l�[�W���[����󂯎�����C�x���g�𔭉�
                reelState = ReelState.Stop;
                for (int i = 0; i < reelRolls.Length; i++)
                {
                    reelRolls[i].StopMainRolling();
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
            for (int i = 0; i < reelRolls.Length; i++)
            {
                returnArray[i] = reelRolls[i].GetZugara();
                //Debug.Log(reelRolls[i].GetZugara());
            }
            return returnArray;
        }


        void StopAllReelRolling()
        {
            for (int i = 0; i < reelRolls.Length; i++)
            {
                reelRolls[i].StopAllIconRolling();
            }
        }

    }
}
