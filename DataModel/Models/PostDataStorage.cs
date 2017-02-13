using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class PostDataStorage
    {
        /// <summary>
        /// Экземпляр хранилища товаров
        /// </summary>
        public static PostDataStorage Storage = new PostDataStorage();
        /// <summary>
        /// Метод, который убирает запятую в тэгах
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Возвращает коллекцию тэгов</returns>
        public List<string> TagsSplit(Post model)
        {
            return model.Tags.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public static List<string> collectionsTags = new List<string>();

        public static List<Category> Category = new List<Category>()
        {
            new Category
            {
                Id = 1,
                Name = "Кино",
                Childrens = new List<Category>()
                {
                        new Category
                    {
                        Name = "Драма"
                    },
                        new Category
                    {
                        Name = "Фантастика"
                    },
                            new Category
                    {
                        Name = "Ужасы"
                    },
                                new Category
                    {
                        Name = "Триллер"
                    }
                }
            },
             new Category
            {Id = 2,
                Name = "Сериалы",
                Childrens = new List<Category>()
                {
                        new Category
                    {
                        Name = "Драма"
                    },
                        new Category
                    {
                        Name = "Фантастика"
                    },
                            new Category
                    {
                        Name = "Ужасы"
                    },
                                new Category
                    {
                        Name = "Триллер"
                    }
                }
            },

            new Category
            {
                Id = 3,
                Name = "Новости",
                Childrens = new List<Category>()
                {
                    new Category
                    {
                        Name = "Спорт"
                    },
                    new Category
                    {
                        Name = "Политика"
                    }
                }
            }
        };

    }
}
