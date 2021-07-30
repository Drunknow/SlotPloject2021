using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
{
    /// <summary>
    /// �X���b�g�̏�Ԃ����ł��Ǘ������Ⴄ�_�N���X�B
    /// �l�X�ȃN���X�̃C���X�^���X�����ۂɎ����A�O���C���X�^���X����̃��b�Z�[�W�Ǝ��g�̏�Ԃɉ����āA
    /// �l�X�ȓ�������閽�߂�����B
    /// �Ȃ��A�񑩂��ꂽ�_�N���X�B
    /// </summary>
    public class GameState : MonoBehaviour
    {
        /// <summary>
        /// �X���b�g�̓�����m���̏��
        /// </summary>
        enum ProbabilityState
        {
            Normal,//�ʏ���
            Fluctuation,//������m���ϓ����
        }

        /// <summary>
        /// �X���b�g�̓�����
        /// </summary>
        enum SlotActivityState
        {
            WaitForStart,//���ݓ����Ă��炸�A���o�[����̃X�^�[�g���͑҂�
            Roll,//�����ꂩ�̃��[��������Ă�����
            Performance,//�����𕥂��Ȃǂ̉��o��
        }

        SlotRoleDeteminer slotRoleDeteminer;
        SlotRoleJudgement slotRoleJudgement;
        [SerializeField]SlotStartLever startLever;
        [SerializeField] ReelsManager reelsManager;//�S�Ẵ��[�����Ǘ������


        ProbabilityState probabilityState;//���̊m����
        SlotActivityState activityState;//�����̏�Ԃ�


        private void Awake()
        {
            startLever.SlotStartEvent = SlotStartLever;
        }



        /// <summary>
        /// ���o�[�������Ă�����Ƃ��X�^�[�g����Ƃ��̊֐��B
        /// </summary>
        void SlotStartLever()
        {
            if (activityState == SlotActivityState.WaitForStart)
            {
                Debug.Log("�X���b�g�����n�߂܂���");
                reelsManager.StartAllReel();//�S�Ẵ��[������
                activityState = SlotActivityState.Roll;//���n�߂���ԂɕύX����
            }
            else
            {
                Debug.Log("���̏�Ԃ�" + activityState.ToString() +"�̂��߁A�񂹂܂���B");
            }
        }


    }
}