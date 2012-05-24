using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Uba_Engine
{
    public class Animator
    {
        private Sprite AnimatingSprite;

        private Animation onAnimate;

        private Vector2 LastPostition;

        private int AnimationDistance;

        private float DistanceTraveled;

        public Animator(Sprite s)
        {
            AnimatingSprite = s;
        }

        public void Animate(Sprite s)
        {
            onAnimate();
        }

        public void AnimateByDistance(int distance)
        {
            LastPostition = AnimatingSprite.position;
            AnimationDistance = distance;
            onAnimate = AnimateDistance;
            AnimatingSprite.onUpdate += Animate;
            DistanceTraveled = 0f;
        }

        private void AnimateDistance()
        {
            DistanceTraveled += Vector2.Distance(LastPostition, AnimatingSprite.position);
            if (DistanceTraveled >= AnimationDistance)
            {
                DistanceTraveled -= AnimationDistance;
                AnimatingSprite.frame.NextFrame();
            }
            LastPostition = AnimatingSprite.position;
        }
    }
}
