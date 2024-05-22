using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Game
{
    abstract class Enemy
    {
        public Queue<Bitmap> Sprites;
        public Bitmap EnemySprite;//Спрайт выбранный на данный момент
        public double Health { get; set; }
        public double MaxHealth { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public int AttackTime { get; set; }
        public Rectangle HitBox { get; set; }
        public Point Vector { get; set; }//Хранит сколько нужно сместиться по X и по Y чтобы дойти до персонажа 
        public Point Step { get; set; }
        public abstract void CalculateVector(Player player);
        public abstract void NextStep();
        public abstract void StayR();
        public abstract void StayL();
        public abstract void MoveRight();
        public abstract void MoveLeft();
    }
    class Bird : Enemy 
    {
        public Bird() 
        {
            MaxHealth = 110;
            Health = 110;
            Damage = 25;
            Speed = 2;
            Sprites = new Queue<Bitmap>();
            AttackTime = 0;
            EnemySprite = new Bitmap(Properties.Resources.bstanright,70, 50);
            Sprites.Enqueue(EnemySprite);
            HitBox = new Rectangle(0, 0, EnemySprite.Width, EnemySprite.Height);
        }
        public Bird(int X,int Y) 
        {
            MaxHealth = 110;
            Health = 110;
            Damage = 25;
            Speed = 2;
            AttackTime = 0;
            Sprites = new Queue<Bitmap>();
            EnemySprite = new Bitmap(Properties.Resources.bstanright,70, 50);
            Sprites.Enqueue(EnemySprite);
            HitBox = new Rectangle(X, Y, EnemySprite.Width, EnemySprite.Height);
        }
        public override void CalculateVector(Player player) 
        {
            Vector = new Point(player.HitBox.X - HitBox.X, player.HitBox.Y - HitBox.Y);
        }
        public override void NextStep()
        {
            try
            {
                double k = Math.Sqrt(Math.Pow(Vector.X, 2) + Math.Pow(Vector.Y, 2)) / Speed;
                Step = new Point(Convert.ToInt32(Vector.X / k), Convert.ToInt32(Vector.Y / k));
            }
            catch { }
        }
        public override void StayR()
        {
            Sprites.Clear();
            EnemySprite = new Bitmap(Properties.Resources.bstanright,70, 50);
            Sprites.Enqueue(new Bitmap(EnemySprite));
        }
        public override void StayL()
        {
            Sprites.Clear();
            EnemySprite = new Bitmap(Properties.Resources.bstanleft,70, 50);
            Sprites.Enqueue(new Bitmap(EnemySprite));
        }
        public override void MoveRight()
        {
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.bright1,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bright2,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bright3,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bright4,70, 50));
        }
        public override void MoveLeft()
        {
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.bleft1, 70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bleft2,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bleft3,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bleft4,70, 50));
        }
    }

}
