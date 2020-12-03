using ajWebSite.Areas.AdminPanel.Models.attachments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.Enums;
using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Areas.AdminPanel.Controllers
{
    [AllowAnonymous]
    [Route("AdminPanel/[Controller]/[Action]/{id?}/{id2?}")]
    public class attachmentsController : Controller
    {
        private IHostingEnvironment Environment;
        IFileBinaryBiz _fileBinaryBiz;
        public attachmentsController(IFileBinaryBiz fileBinaryBiz, IHostingEnvironment _environment)
        {
            _fileBinaryBiz = fileBinaryBiz;
            Environment = _environment;
        }
        public ActionResult getAttachmentsList(int? id, int? id2)
        {
            var attachmentType = id2;
            var ownerId = id;
            var attachemntType = (AttachmentType)attachmentType;
            var attachments = _fileBinaryBiz.getAttachments(ownerId ?? 0, attachemntType);
            return Ok(attachments);
        }
        public ActionResult getAttachments(int id,int id2)
        {
            var attachmentType = id2;
            var ownerId = id;
            getAttachmentsModel model = new getAttachmentsModel(); 
            var attachemntType = (AttachmentType)attachmentType;
            model.attachments = _fileBinaryBiz.getAttachments(ownerId, attachemntType);
            model.isOwnerSet = ownerId > 0;
            model.ownerID = ownerId;
            return View("~/Areas/AdminPanel/Views/attachments/getAttachments.cshtml", model);
        }
        public ActionResult addAttachmentSalon(int id, string attachmentTitle, IFormFile postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            if (postedFiles == null)
            {
                if (Request.Form.Files.Count() < 1)
                {
                    return Ok(new { location = "" });
                }
                postedFiles = Request.Form.Files[0];

            }

            List<string> uploadedFiles = new List<string>();
            string fileName = "";
            fileName = Path.GetFileName(postedFiles.FileName);
            var newFileName = "";
            var webpath = "";
            string path = getFilePath(fileName, out newFileName, out webpath);
            using (FileStream stream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
            {
                postedFiles.CopyTo(stream);
                uploadedFiles.Add(newFileName);
            }
            _fileBinaryBiz.Insert(attachmentTitle, Path.Combine(webpath, newFileName), ajWebSite.Common.Enums.AttachmentType.salonAttachments, id);
            return Ok(new { location = Path.Combine(webpath, newFileName) });
        }
        public ActionResult addAttachmentArticle(int id,string attachmentTitle, IFormFile postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            if (postedFiles == null)
            {
                if (Request.Form.Files.Count() < 1)
                {
                    return Ok(new { location = "" });
                }
                postedFiles = Request.Form.Files[0];

            }

            List<string> uploadedFiles = new List<string>();
            string fileName = "";
            fileName = Path.GetFileName(postedFiles.FileName);
            var newFileName = "";
            var webpath = "";
            string path = getFilePath(fileName, out newFileName, out webpath);
            using (FileStream stream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
            {
                postedFiles.CopyTo(stream);
                uploadedFiles.Add(newFileName);
            }
            _fileBinaryBiz.Insert(attachmentTitle, Path.Combine(webpath, newFileName), ajWebSite.Common.Enums.AttachmentType.newsArticleGroup,id);
            return Ok(new { location = Path.Combine(webpath, newFileName) });
        }
        public ActionResult addAttachment(IFormFile postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            if (postedFiles==null)
            {
                if (Request.Form.Files.Count()<1)
                {
                    return Ok(new { location = "" });
                }
                postedFiles = Request.Form.Files[0];
                
            }
             
            List<string> uploadedFiles = new List<string>();
            string fileName = "";
            fileName = Path.GetFileName(postedFiles.FileName);
            var newFileName = "";
            var webpath = "";
            string path = getFilePath(fileName,out newFileName,out webpath);
            using (FileStream stream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
            {
                postedFiles.CopyTo(stream);
                uploadedFiles.Add(newFileName);
            }
            _fileBinaryBiz.Insert(newFileName, Path.Combine(path, newFileName),ajWebSite.Common.Enums.AttachmentType.articleBudy);
            return Ok(new { location = Path.Combine(webpath, newFileName) });
        }
        private string getFilePath(string fileName,out string newFileName,out string webPath)
        {
            var fileNameWithoutExtension = fileName.Substring(0, fileName.IndexOf('.'));
            var fileExtension = fileName.Substring(fileName.IndexOf('.')+1);
            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            webPath = "/Uploads";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path +=  "/" + DateTime.Now.Year;
            webPath +=  "/" + DateTime.Now.Year;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path +=  "/" + DateTime.Now.Month;
            webPath +=  "/" + DateTime.Now.Month;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path +=  "/" + DateTime.Now.Day;
            webPath +=  "/" + DateTime.Now.Day;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            } 
            var counter = 0;
            while (System.IO.File.Exists(path+"/"+ fileNameWithoutExtension+ counter.ToString()+ "."+fileExtension))
            {
                counter += 1;
            }
            webPath= webPath+ "/" ;
            newFileName = fileNameWithoutExtension + counter.ToString() + "." + fileExtension;
            return path ;
        }
    }
}
