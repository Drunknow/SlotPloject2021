using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
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

        [SerializeField] GameObject[] Reels;


        /// <summary>
        /// ���g���Q�Ƃ��Ă���S�Ẵ��[�����񂷊֐�
        /// </summary>
        public void StartAllReel()
        {            
            for(int i = 0; i < Reels.Length; i++)
            {
                Reels[i].GetComponent<IReelStartable>().StartReel();
            }
        }


        

    }
}