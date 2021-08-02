using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    public class ReelsManager : MonoBehaviour
    {


        //神からイベントを受け取るのだ。
        //具体的には、全てのリールが止まった時に発火すべき関数。
        Action allReelStopEvent;
        //一応プロパティ化
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

        [SerializeField] GameObject[] Reels;//リールへの参照
        int stopedReelCount;//止まっているリールのカウント。


        /// <summary>
        /// 自身が参照している全てのリールを回す関数
        /// </summary>
        public void StartAllReel()
        {            
            for(int i = 0; i < Reels.Length; i++)
            {
                Reels[i].GetComponent<IReelStartable>().StartReel();
                Reels[i].GetComponent<IReelStartable>().SetStopEvent(StopOneReel);
            }
            stopedReelCount = 0;//全てのリールは回り始める
        }

        void StopOneReel()
        {
            //止まっている数を+1する
            stopedReelCount = stopedReelCount + 1;

            //もし、止まっているリールの数が参照の数といっしょなら、神から受け取ったイベントを発火する。
            if(stopedReelCount == Reels.Length)
            {
                allReelStopEvent();
            }
        }



        

    }
}