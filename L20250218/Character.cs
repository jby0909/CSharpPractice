﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class Character : GameObject
    {
        public Character(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            shape = inShape;
        }
        public virtual void Move()
        {

        }
        public void Collide()
        {
            Console.WriteLine("충돌했습니다.");
        }
    }
}
