﻿using System;
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
        public int HealthBoxWith {  get; set; }
        public int DeathSpriteIndex { get; set; }
        public int DeathTime { get; set; }//Переменная хранит в себе время смерти моба, используется для того чтобы мобы перерождались
        public int Experience { get; set; }//Сколько опыта получит персонаж при убийстве моба
        public Rectangle HitBox { get; set; }
        public Point Vector { get; set; }//Хранит сколько нужно сместиться по X и по Y чтобы дойти до персонажа 
        public Point Step { get; set; }
        public Point Shadow { get; set; }//Смещение для тени
        public abstract void CalculateVector(Player player);
        public abstract void NextStep();
        public abstract void DeathR();
        public abstract void DeathL();
        public abstract void StayR();
        public abstract void StayL();
        public abstract void MoveRight();
        public abstract void MoveLeft();
        public abstract void Rebith(int X,int Y);
    }
    class Bird : Enemy 
    {
        public Bird() 
        {
            MaxHealth = 110;
            Health = 110;
            Damage = 25;
            Speed = 4;
            DeathSpriteIndex = 0;
            Experience = 100;
            Shadow = new Point(-15, -6);
            HealthBoxWith = 65;
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
            Speed = 4;
            DeathSpriteIndex = 0;
            AttackTime = 0;
            HealthBoxWith = 65;
            Experience = 100;
            Shadow = new Point(-15, -6);
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
            double k = Math.Sqrt(Math.Pow(Vector.X, 2) + Math.Pow(Vector.Y, 2)) / Speed;
            if (k > 0.00000001) 
            {
                Step = new Point(Convert.ToInt32(Vector.X / k), Convert.ToInt32(Vector.Y / k));
            }
        }
        public override void DeathR()
        {
            Damage = 0;
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.brdeath1,70,60));
            Sprites.Enqueue(new Bitmap(Properties.Resources.brdeath2, 70, 60));
            Sprites.Enqueue(new Bitmap(Properties.Resources.brdeath3, 70, 60));
            Sprites.Enqueue(new Bitmap(Properties.Resources.brdeath4, 70, 60));
        }
        public override void DeathL()
        {
            Damage = 0;
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.bldeath1, 70, 60));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bldeath2, 70, 60));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bldeath3, 70, 60));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bldeath4, 70, 60));
        }
    
        public override void StayR()
        {
            Sprites.Clear();
            Shadow = new Point(-15, -20);
            EnemySprite = new Bitmap(Properties.Resources.bstanright,70, 50);
            Sprites.Enqueue(new Bitmap(EnemySprite));
        }
        public override void StayL()
        {
            Sprites.Clear();
            Shadow = new Point(-4, -20);
            EnemySprite = new Bitmap(Properties.Resources.bstanleft,70, 50);
            Sprites.Enqueue(new Bitmap(EnemySprite));
        }
        public override void MoveRight()
        {
            Sprites.Clear();
            Shadow = new Point(-15, -6);
            Sprites.Enqueue(new Bitmap(Properties.Resources.bright1,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bright2,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bright3,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bright4,70, 50));
        }
        public override void MoveLeft()
        {
            Sprites.Clear();
            Shadow = new Point(-10, -6);
            Sprites.Enqueue(new Bitmap(Properties.Resources.bleft1, 70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bleft2,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bleft3,70, 50));
            Sprites.Enqueue(new Bitmap(Properties.Resources.bleft4,70, 50));
        }
        public override void Rebith(int X,int Y)
        {
            MaxHealth = 110;
            Health = 110;
            Damage = 25;
            Speed = 4;
            DeathSpriteIndex = 0;
            AttackTime = 0;
            HealthBoxWith = 65;
            Shadow = new Point(-15, -6);
            Sprites = new Queue<Bitmap>();
            EnemySprite = new Bitmap(Properties.Resources.bstanright, 70, 50);
            Sprites.Enqueue(EnemySprite);
            HitBox = new Rectangle(X, Y, EnemySprite.Width, EnemySprite.Height);
        }
    }

    class Slime : Enemy
    {
        public Slime()
        {
            MaxHealth = 200;
            Health = 200;
            Damage = 15;
            Speed = 2;
            DeathSpriteIndex = 0;
            Experience = 75;
            Shadow = new Point(-10, -12);
            HealthBoxWith = 55;
            Sprites = new Queue<Bitmap>();
            AttackTime = 0;
            EnemySprite = new Bitmap(Properties.Resources.sstanright);
            Sprites.Enqueue(EnemySprite);
            HitBox = new Rectangle(0, 0, EnemySprite.Width, EnemySprite.Height);
        }
        public Slime(int X, int Y)
        {
            MaxHealth = 200;
            Health = 200;
            Damage = 15;
            Speed = 2;
            DeathSpriteIndex = 0;
            AttackTime = 0;
            Experience = 75;
            Shadow = new Point(-10, -12);
            HealthBoxWith = 55;
            Sprites = new Queue<Bitmap>();
            EnemySprite = new Bitmap(Properties.Resources.sstanright);
            Sprites.Enqueue(EnemySprite);
            HitBox = new Rectangle(X, Y, EnemySprite.Width, EnemySprite.Height);
        }
        public override void CalculateVector(Player player)
        {
            Vector = new Point(player.HitBox.X - HitBox.X, player.HitBox.Y - HitBox.Y);
        }
        public override void NextStep()
        {
            double k = Math.Sqrt(Math.Pow(Vector.X, 2) + Math.Pow(Vector.Y, 2)) / Speed;
            if (k > 0.00000001)
            {
                Step = new Point(Convert.ToInt32(Vector.X / k), Convert.ToInt32(Vector.Y / k));
            }
        }
        public override void DeathR()
        {
            Damage = 0;
            Shadow = new Point(-15, -20);
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.srdeath1));
            Sprites.Enqueue(new Bitmap(Properties.Resources.srdeath2));
            Sprites.Enqueue(new Bitmap(Properties.Resources.srdeath3));
            Sprites.Enqueue(new Bitmap(Properties.Resources.srdeath4));
        }
        public override void DeathL()
        {
            Damage = 0;
            Shadow = new Point(-20, -20);
            Sprites.Clear();
            Sprites.Enqueue(new Bitmap(Properties.Resources.sldeath1));
            Sprites.Enqueue(new Bitmap(Properties.Resources.sldeath2));
            Sprites.Enqueue(new Bitmap(Properties.Resources.sldeath3));
            Sprites.Enqueue(new Bitmap(Properties.Resources.sldeath4));
        }
        public override void StayR()
        {
            Sprites.Clear();
            Shadow = new Point(-20, -20);
            EnemySprite = new Bitmap(Properties.Resources.sstanright);
            Sprites.Enqueue(new Bitmap(EnemySprite));
        }
        public override void StayL()
        {
            Sprites.Clear();
            Shadow = new Point(-15, -20);
            EnemySprite = new Bitmap(Properties.Resources.sstanleft);
            Sprites.Enqueue(new Bitmap(EnemySprite));
        }
        public override void MoveRight()
        {
            Sprites.Clear();
            Shadow = new Point(-20, -12);
            Sprites.Enqueue(new Bitmap(Properties.Resources.sright1));
            Sprites.Enqueue(new Bitmap(Properties.Resources.sright2));
            Sprites.Enqueue(new Bitmap(Properties.Resources.sright3));
            Sprites.Enqueue(new Bitmap(Properties.Resources.sright4));
        }
        public override void MoveLeft()
        {
            Sprites.Clear();
            Shadow = new Point(-10, -12);
            Sprites.Enqueue(new Bitmap(Properties.Resources.sleft1));
            Sprites.Enqueue(new Bitmap(Properties.Resources.sleft2));
            Sprites.Enqueue(new Bitmap(Properties.Resources.sleft3));
            Sprites.Enqueue(new Bitmap(Properties.Resources.sleft4));
        }
        public override void Rebith(int X, int Y)
        {
            MaxHealth = 200;
            Health = 200;
            Damage = 15;
            Speed = 2;
            DeathSpriteIndex = 0;
            AttackTime = 0;
            Shadow = new Point(-10, -12);
            HealthBoxWith = 55;
            Sprites = new Queue<Bitmap>();
            EnemySprite = new Bitmap(Properties.Resources.sstanright);
            Sprites.Enqueue(EnemySprite);
            HitBox = new Rectangle(X, Y, EnemySprite.Width, EnemySprite.Height);
        }
    }
}
