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







    }
}