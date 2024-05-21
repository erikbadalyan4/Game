using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    abstract class Player
    {
        public Queue<Bitmap> Sprites;
        public int Health { get; set; }
        public int Speed { get; set; }
        public int Regen { get; set; }
        public int Damage { get; set; }
        public int AttackInterval { get; set; }
        public Rectangle HitBox { get; set; }
        public abstract void StayR();
        public abstract void StayL();
        public abstract void MoveRight();
        public abstract void MoveLeft();
    }
    class Warrior : Player
    {
        public Warrior()
        {
            Health = 125;
            Damage = 100;
            Regen = 0;
            Speed = 3;
            Sprites = new Queue<Bitmap>();
            Bitmap PlayerSprite = new Bitmap(Properties.Resources.wstanright);
            Sprites.Enqueue(PlayerSprite);
            HitBox = new Rectangle(0,0,PlayerSprite.Width, PlayerSprite.Height);
        }
        public override void StayR()
        {
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.wstanright));
        }
        public override void StayL()
        {
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.wstanleft));
        }
        public override void MoveRight()
        {
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrrun1));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrrun2));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrrun3));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrrun4));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrrun5));
        }
        public override void MoveLeft()
        {
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.wlrun1));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wlrun2));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wlrun3));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wlrun4));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wlrun5));
        }
    }
}
