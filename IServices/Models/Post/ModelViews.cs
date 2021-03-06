﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Модели интерфейса для поста.
/// </summary>
namespace IServices.Models.Post
{
    /// <summary>
    /// Модель просмотров поста
    /// </summary>
    public class ModelViews
    {

        /// <summary>
        /// Индификатор с типом данных Guid
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// Номер поста
        /// </summary>
        public int PostID { get; set; }


    }
}
