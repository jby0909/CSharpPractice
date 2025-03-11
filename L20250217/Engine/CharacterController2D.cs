using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class CharacterController2D : Collider2D
    {
        public void Move(int addX, int addY)
        {
            int futureX = transform.X + addX;
            int futureY = transform.Y + addY;
            foreach(var choiceObject in Engine.Instance.world.GetAllGameObjects)
            {
                
                if(choiceObject.GetComponent<Collider2D>() != null)
                {
                    //충돌정보(collider2D)를 가지고 있는 객체와 이동하려는 좌표가 일치하면서 isTrigger가 true일경우
                    if(choiceObject.transform.X == futureX && choiceObject.transform.Y == futureY)
                    {
                        if(choiceObject.GetComponent<Collider2D>().isTrigger == true)
                        {
                            Object[] parameters = { choiceObject.GetComponent<Collider2D>()};
                            gameObject.ExecuteMethod("OnTriggerEnter2D", parameters);
                            Object[] parameters2 = { gameObject.GetComponent<Collider2D>() };
                            choiceObject.ExecuteMethod("OnTriggerEnter2D", parameters2);
                            break;
                            
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            //충돌정보를 가지고 있는 모든 객체들과 이동하려는 좌표가 일치하는게 없으면 간다
            transform.Translate(addX, addY);
        }
    }
}
