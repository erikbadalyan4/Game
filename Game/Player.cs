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
        public Queue<Bitmap> AttackSprite;
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Speed { get; set; }
        public int Regen { get; set; }
        public int Damage { get; set; }
        public int AttackInterval { get; set; }
        public Rectangle HitBox { get; set; }
        public Rectangle AttackHitBox { get; set; }
        public abstract void StayR();
        public abstract void StayL();
        public abstract void DeathR();
        public abstract void DeathL();
        public abstract void MoveRight();
        public abstract void MoveLeft();
    }
    class Warrior : Player
    {
        public Warrior()
        {
            MaxHealth = 125;
            Health = 125;
            Damage = 3;
            Regen = 0;
            Speed = 3;
            AttackInterval = 3000;
            Sprites = new Queue<Bitmap>();
            Bitmap PlayerSprite = new Bitmap(Properties.Resources.wstanright);
            Sprites.Enqueue(PlayerSprite);
            HitBox = new Rectangle(0,0,PlayerSprite.Width, PlayerSprite.Height);
            AttackSprite = new Queue<Bitmap>();
            AttackSprite.Enqueue(new Bitmap(Properties.Resources.wattack8,150,75));
            AttackSprite.Enqueue(new Bitmap(Properties.Resources.wattack9, 150, 75));
            AttackSprite.Enqueue(new Bitmap(Properties.Resources.wattack10, 150, 75));
            AttackSprite.Enqueue(new Bitmap(Properties.Resources.wattack11, 150, 75));
            AttackSprite.Enqueue(new Bitmap(Properties.Resources.wattack12, 150, 75));
            AttackSprite.Enqueue(new Bitmap(Properties.Resources.wattack13, 150, 75));
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

        public override void DeathR()
        {
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrdeath11));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrdeath22));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrdeath33));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrdeath44));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wrdeath55));
        }
        public override void DeathL()
        {
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.wldeath11));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wldeath22));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wldeath33));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wldeath44));
            Sprites.Enqueue(new Bitmap(Properties.Resources.wldeath55));
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
