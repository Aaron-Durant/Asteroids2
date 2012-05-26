using Microsoft.Xna.Framework;

namespace Uba_Engine
{
    public class Animator
    {
        /// <summary>
        /// The Sprite the Animator is Animating
        /// </summary>
        private Sprite AnimatingSprite;
        /// <summary>
        /// The Delegate to run when the Sprite is animated
        /// </summary>
        private Animation _onAnimate;
        /// <summary>
        /// The position of the Sprite last time the Animator updated
        /// </summary>
        private Vector2 _lastPostition;
        /// <summary>
        /// The Distance the Sprite can travel between animations
        /// </summary>
        private int _animationDistance;
        /// <summary>
        /// The total distance traveled by the Sprite since last animation
        /// </summary>
        private float _distanceTraveled;

        /// <summary>
        /// Default constructor for Animator
        /// </summary>
        /// <param name="s"> The Sprite associated with the Animator </param>
        public Animator(Sprite s)
        {
            AnimatingSprite = s;
        }

        /// <summary>
        /// Calls the _onAnimate delgate on the Sprite
        /// </summary>
        /// <param name="s"> Does nothing. Here to keep delegates happy </param>
        public void Animate(Sprite s)
        {
            _onAnimate();
        }

        /// <summary>
        /// Sets up animation according to distance on the Sprite
        /// </summary>
        /// <param name="distance"> The distance between animations </param>
        public void AnimateByDistance(int distance)
        {
            _lastPostition = AnimatingSprite.Position;
            _animationDistance = distance;
            _onAnimate = AnimateDistance;
            AnimatingSprite.OnUpdate += Animate;
            _distanceTraveled = 0f;
        }

        /// <summary>
        /// Checks distances and animates the Sprite is it has traveled far enough
        /// </summary>
        private void AnimateDistance()
        {
            _distanceTraveled += Vector2.Distance(_lastPostition, AnimatingSprite.Position);
            if (_distanceTraveled >= _animationDistance)
            {
                _distanceTraveled -= _animationDistance;
                AnimatingSprite.Frame.NextFrame();
            }
            _lastPostition = AnimatingSprite.Position;
        }
    }
}
