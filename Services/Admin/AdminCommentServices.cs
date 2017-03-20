using DataModel;
using DataModel.Models;
using IServices.Models.Post;
using IServices.Models.User;
using IServices.Sublntefac.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Admin
{
    public class AdminCommentServices : IAdminCommentServices
    {
        /// <summary>
        /// Вывод всех комментериев
        /// </summary>
        /// <returns></returns>
        public List<ModelComment> GetComments(string user)
        {
            using (var db = new DataContext())
            {
                var commentCollection = db.Comments;
                if (user == null)
                {

                    var comment = commentCollection.Select(ConvertComment()).ToList();
                    return comment;
                }
                else
                {
                    var commentUser = commentCollection.Where(x => x.User.FirstOrDefault(xc => xc.UserName == user).UserName == user);
                    return commentUser.Select(ConvertComment()).ToList();
                }
            }
        }
        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <param name="Id">Ид комментария</param>
        public void DeleteComment(int Id, int? PareantId)
        {
            using (var db = new DataContext())
            {
                if (PareantId != null)
                {
                    var Child = db.Comments.FirstOrDefault(x => x.PareantId == PareantId);
                    if (Child != null)
                    {
                        var Pareant = db.Comments.FirstOrDefault(x => x.Id == Child.PareantId);
                        Pareant.Answer = true;
                        db.Comments.Remove(Child);
                    }
                }
                else
                {
                    var Child = db.Comments.FirstOrDefault(x => x.PareantId == Id);
                    var comment = db.Comments.FirstOrDefault(x => x.Id == Id);
                    db.Comments.Remove(comment);
                    if (Child != null)
                    {
                        db.Comments.Remove(Child);
                    }
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Редактирование содержимого коментария
        /// </summary>
        /// <param name="id">Ид комментария</param>
        /// <param name="content">Содержимое комментария</param>
        public void EditComment(int id, string content)
        {
            using (var db = new DataContext())
            {
                var comment = db.Comments.FirstOrDefault(x => x.Id == id);
                comment.ContetntComment = content;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Выполняет поиск пользователей
        /// </summary>
        /// <param name="term">Ввод</param>
        /// <returns></returns>
        public List<ModelUser> Search(string term)
        {
            using (var db = new DataContext())
            {

                var user = db.Users.Select(ConvertUser());
                var models = user.Where(a => a.UserName.Contains(term)).ToList();
                return models;
            }
        }
        /// <summary>
        /// Конверт модели комментариев
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<Comment, ModelComment>> ConvertComment()
        {
            return comment => new ModelComment()
            {
                Id = comment.Id,
                PareantId = comment.PareantId,
                ContentComment = comment.ContetntComment,
                DateAddPost = comment.DateAddComment,
                Answer = comment.Answer,
                User = comment.User.Select(u => new ModelUserComment { Id = u.Id, UserName = u.UserName, Photo = u.Photo }).ToList(),
                Post = comment.Post.Select(u => new ModelPost { PostID = u.PostID, NamePost = u.NamePost }).ToList()

            };
        }
        public static Expression<Func<User, ModelUser>> ConvertUser()
        {
            return user => new ModelUser()
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }

    }
}
