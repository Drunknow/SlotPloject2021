using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    /// <summary>
    /// ���ۂɒl�����Ăǂ�Ȗ���������Ă��邩�m�F�����ڂ����B
    /// �����A��̓I�Ȗ���Ԃ��ƃA���Ȃ̂ŁA���Ԗڂ̐��l�����ł���������݂̂�Ԃ��Ɨǂ������H
    /// </summary>
    public class SlotRoleJudgement
    {

        //��ɓ��邱����(�f�o�b�O�p)
        int[] coin = { 1, 10, 100, 1000, 10000, 100000, 1000000 };


        int CheckSlotReel(int[][] reals)
        {
            
            int �X���b�g�ǂœ��Ɋ撣�������͂��׌N�Ɩx�c�N���Ǝv���܂� =0;

            //�A�z�z��I�Ȕ��z�ŁA�߂�ǂ�����������for���ɗ��Ƃ����ށB
            //���ۂ͂��ׂẴ��[�����Ǘ�����N���X������āA����������̌����悤��foreach��p����Ɨǂ������ł��B
            int[] reel1Index = { 0, 1, 2, 0, 2 };
            int[] reel2Index = { 0, 1, 2, 1, 1 };
            int[] reel3Index = { 0, 1, 2, 2, 0 };

            for(int i = 0; i < reel1Index.Length; i++)
            {
                if(reals[0][reel1Index[i]] == reals[1][reel2Index[i]] && reals[0][reel1Index[i]] == reals[2][reel3Index[i]])
                {
                    �X���b�g�ǂœ��Ɋ撣�������͂��׌N�Ɩx�c�N���Ǝv���܂� += coin[reals[0][reel1Index[i]]];
                }
            }

            return �X���b�g�ǂœ��Ɋ撣�������͂��׌N�Ɩx�c�N���Ǝv���܂� ;

        }

    }
}