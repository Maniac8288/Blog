using PostModel;
using PostModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PostModel.Models
{
    public class PostDataStorage
    {
        /// <summary>
        /// Экземпляр хранилища товаров
        /// </summary>
        public static PostDataStorage Storage = new PostDataStorage();

        public List<string> TagsSplit(Post model)
        {
            return model.Tags.Split(new string[] { ","}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public static List<string> collectionsTags = new List<string>();

        public static List<Category> Category = new List<Category>()
        {
            new Category
            {
                Id = 1,
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
            },
            new Category
            {
                Id = 2,
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
            {
                Id = 1,
                Name = "Медицниа",
                Childrens = new List<Category>()
                {
                    new Category
                    {
                        Name = "Народная медицина"
                    },
                    new Category
                    {
                        Name = "Советы от врачей"
                    }
                }
            },
        };

    }

}