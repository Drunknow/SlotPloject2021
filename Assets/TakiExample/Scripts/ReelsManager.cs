using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    public class ReelsManager : MonoBehaviour
    {


        //�_����C�x���g���󂯎��̂��B
        //��̓I�ɂ́A�S�Ẵ��[�����~�܂������ɔ��΂��ׂ��֐��B
        Action allReelStopEvent;
        //�ꉞ�v���p�e�B��
        public Action AllReelStopEvent
        {
            get
            {
                return allReelStopEvent;
            }
            set
            {
                allReelStopEvent = value;
            }
        }

        [SerializeField] GameObject[] Reels;//���[���ւ̎Q��
        int stopedReelCount;//�~�܂��Ă��郊�[���̃J�E���g�B


        /// <summary>
        /// ���g���Q�Ƃ��Ă���S�Ẵ��[�����񂷊֐�
        /// </summary>
        public void StartAllReel()
        {            
            for(int i = 0; i < Reels.Length; i++)
            {
                Reels[i].GetComponent<IReelStartable>().StartReel();
                Reels[i].GetComponent<IReelStartable>().SetStopEvent(StopOneReel);
            }
            stopedReelCount = 0;//�S�Ẵ��[���͉��n�߂�
        }

        void StopOneReel()
        {
            //�~�܂��Ă��鐔��+1����
            stopedReelCount = stopedReelCount + 1;

            //�����A�~�܂��Ă��郊�[���̐����Q�Ƃ̐��Ƃ�������Ȃ�A�_����󂯎�����C�x���g�𔭉΂���B
            if(stopedReelCount == Reels.Length)
            {
                //�܂��͂��ׂẴ��[���̏����擾����B
                GetCurrentZugara();

                //

                //�Ō�Ɏ󂯎�����֐��𔭉΂���B
                allReelStopEvent();
            }
        }


        public int[][] GetCurrentZugara()
        {
            int[][] reals = new int[3][];
            reals[0] = new int[3];
            reals[1] = new int[3];
            reals[2] = new int[3];

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    reals[i][j] = Reels[i].GetComponent<Reel>().GetAllReel()[j];
                }
            }

            return reals;
        }
        

    }
}