using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
{
    public class SlotStartLever : MonoBehaviour
    {
        Action slotStartEvent;//�_����C�x���g���󂯎��̂��B

        //�ꉞ�v���p�e�B��
        public Action SlotStartEvent
        {
            get
            {
                return slotStartEvent;
            }
            set
            {
                slotStartEvent = value;
            }
        }

        /// <summary>
        /// Unity�̃{�^���Ȃǂ̃C�x���g����Ăяo���Ƃ��p
        /// </summary>
        public void UseLever()
        {
            slotStartEvent();//�C�x���g�����s����B
        }

    }
}