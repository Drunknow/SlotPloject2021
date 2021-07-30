using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
{
    /// <summary>
    /// スロットの状態を何でも管理しちゃう神クラス。
    /// 様々なクラスのインスタンスを実際に持ち、外部インスタンスからのメッセージと自身の状態に応じて、
    /// 様々な動作をする命令をする。
    /// なお、約束された神クラス。
    /// </summary>
    public class GameState : MonoBehaviour
    {
        /// <summary>
        /// スロットの当たる確率の状態
        /// </summary>
        enum ProbabilityState
        {
            Normal,//通常状態
            Fluctuation,//いわゆる確率変動状態
        }

        /// <summary>
        /// スロットの動作状態
        /// </summary>
        enum SlotActivityState
        {
            WaitForStart,//現在動いておらず、レバーからのスタート入力待ち
            Roll,//いずれかのリールが回っている状態
            Performance,//お金を払うなどの演出中
        }

        SlotRoleDeteminer slotRoleDeteminer;
        SlotRoleJudgement slotRoleJudgement;
        [SerializeField]SlotStartLever startLever;
        [SerializeField] ReelsManager reelsManager;//全てのリールを管理する者


        ProbabilityState probabilityState;//今の確率状況
        SlotActivityState activityState;//今何の状態か


        private void Awake()
        {
            startLever.SlotStartEvent = SlotStartLever;
        }



        /// <summary>
        /// レバーを引いてすろっとがスタートするときの関数。
        /// </summary>
        void SlotStartLever()
        {
            if (activityState == SlotActivityState.WaitForStart)
            {
                Debug.Log("スロットが回り始めました");
                reelsManager.StartAllReel();//全てのリールを回す
                activityState = SlotActivityState.Roll;//回り始めた状態に変更する
            }
            else
            {
                Debug.Log("今の状態が" + activityState.ToString() +"のため、回せません。");
            }
        }


    }
}