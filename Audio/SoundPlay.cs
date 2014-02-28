﻿using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

namespace M8.PlayMaker {
    [ActionCategory("Mate Audio")]
    [Tooltip("Play SoundPlayer.")]
    public class SoundPlay : FSMActionComponentBase<SoundPlayer> {
        public FsmBool wait;
        
        [Tooltip("If set, wait for sound to end before finishing, then enter event. Make sure to set wait to true")]
        public FsmEvent onEndEvent;
        
        public override void Reset() {
            base.Reset();

            wait = null;
            onEndEvent = null;
        }

        public override void OnEnter() {
            base.OnEnter();

            mComp.Play();

            if(!wait.Value) {
                Finish();
            }
        }
        
        public override void OnUpdate() {
            if(!mComp.isPlaying) {
                Fsm.Event(onEndEvent);
                Finish();
            }
        }
    }
}