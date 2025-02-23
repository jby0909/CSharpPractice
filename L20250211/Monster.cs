using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Monster
    {
        protected int hp;
        public int Hp
        {
            get { return hp; }
            //set { hp = value; }
        }
        protected int gold;

        public Monster()
        {
            Console.WriteLine("몬스터 생성자");
        }
        ~Monster()
        {
            Console.WriteLine("몬스터 소멸자");
        }
        
        public int GetHp()
        {
            return hp;
        }

        public void SetHp(int value)
        {
            if(value >= 0)
            {
                hp = value;
            }
            
        }

        public void ApplyDamage(int damage)
        {
            if(hp < 0)
            {
                Die();
            }
            else
            {
                hp -= damage;
            }
            
        }
        public void Attack()
        {
        }
        public virtual void Move()
        {
            Console.WriteLine("몬스터 이동");
        }
        public void Die()
        {
            
        }
    }
}
