using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class World
    {
        public delegate int SortCompare(GameObject first, GameObject second);
        public SortCompare sortCompare;

        //DynamicArray 
        List<GameObject> gameObjects = new List<GameObject>();
        public List<GameObject> GetAllGameObjects
        {
            get
            {
                return gameObjects;
            }
            set
            {
                gameObjects = value;
            }
        }

        public void Instantiate(GameObject gameObject)
        {
            gameObjects.Add(gameObject);

        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                foreach (Component component in gameObjects[i].components)
                {
                    component.Update();
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                Renderer render = gameObjects[i].GetComponent<Renderer>();
                if (render != null)
                {
                    render.Render();
                }
            }
        }


        public void Sort()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = i + 1; j < gameObjects.Count; j++)
                {

                    //SpriteRenderer spriteRenderer1 = gameObjects[i].GetComponent<SpriteRenderer>();
                    //SpriteRenderer spriteRenderer2 = gameObjects[j].GetComponent<SpriteRenderer>();
                    //if (spriteRenderer1 == null || spriteRenderer2 == null)
                    //{
                    //    continue;
                    //}

                    if (sortCompare(gameObjects[i], gameObjects[j]) > 0)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }
            }

        }

        public void Awake()
        {
            foreach(var choiceObject in gameObjects)
            {
                foreach(Component component in choiceObject.components)
                {
                    component.Awake();
                }
            }
        }
    }
}
