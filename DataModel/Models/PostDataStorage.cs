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
                Сhild = new List<Category>()
                {
                        new Category
                    {
                        Name = "Драма", ParentId =1
                    },
                        new Category
                    {
                        Name = "Фантастика",ParentId =1
                    },
                            new Category
                    {
                        Name = "Ужасы",ParentId =1
                    },
                                new Category
                    {
                        Name = "Триллер",ParentId =1
                    }
                }
            },
             new Category
            {Id = 2,
                Name = "Сериалы",
                Сhild = new List<Category>()
                {
                        new Category
                    {
                        Name = "Драма",ParentId =2
                    },
                        new Category
                    {
                        Name = "Фантастика",ParentId =2
                    },
                            new Category
                    {
                        Name = "Ужасы",ParentId =2
                    },
                                new Category
                    {
                        Name = "Триллер",ParentId =2
                    }
                }
            },

            new Category
            {
                Id = 3,
                Name = "Новости",
                Сhild = new List<Category>()
                {
                    new Category
                    {
                        Name = "Спорт",ParentId =3
                    },
                    new Category
                    {
                        Name = "Политика",ParentId =3
                    }
                }
            }
        };

    }
}
