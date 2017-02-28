using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.IO;
using DataModel;

namespace Images
{
    public class Class1
    {
        public string ProcessRequest(HttpPostedFileBase upload, string CKEditorFuncNum, string mapPath)
        {

            if (upload.ContentLength <= 0)
                return null;
            using (var db = new DataContext())
            {
                var NewPost = db.Posts.Max(x => x.PostID);
                NewPost++;
                const string uploadFolder = "img";
                // сохраняем файл в папку img в проекте
                Directory.CreateDirectory(mapPath + NewPost);
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(mapPath + "/" + NewPost, fileName);
                upload.SaveAs(path);
                var url = string.Format("{0}/{1}/{2}/{3}", "http://localhost:62712/", uploadFolder, NewPost, fileName);
                const string message = "Ваше изображение успешно сохраненно";
                // Ajax запрос для передачи изображение
                var output = string.Format(
                    "<html><body><script>window.parent.CKEDITOR.tools.callFunction({0}, \"{1}\", \"{2}\");</script></body></html>",
                    CKEditorFuncNum, url, message);
                return output;
            }
        }
    }
}
