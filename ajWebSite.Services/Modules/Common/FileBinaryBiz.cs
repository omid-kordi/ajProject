using System;
using System.Collections.Generic;
using System.Linq;
using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Enums;
using ajWebSite.Core.DataAccess;
using ajWebSite.Core.Module;
using ajWebSite.Domain.Common;
using ajWebSite.Services.Contracts.Common;

namespace ajWebSite.Services.Modules.Common
{
    public class FileBinaryBiz : IFileBinaryBiz
    { 
        private IUnitOfWork unitOfWork;
        public FileBinaryBiz(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public string Insert(string name, byte[] data)
        {
            var fb = new FileBinary
            {
                GUId = Guid.NewGuid().ToString(),
                Binary = data,
                Name = name
            };
            unitOfWork.Repository<FileBinary>().Insert(fb);
            unitOfWork.Commit();
            return fb.GUId;
        }

        public List<FileBinaryDTO> getAttachments(int ownerId, AttachmentType attachmentType)
        {
            var attachementRep = unitOfWork.Repository<FileBinary>();
            var attachments=attachementRep.Get(p => p.attachmentType == attachmentType && p.ownerID == ownerId.ToString());
            return attachments.ToDTOList<FileBinaryDTO>();
        }
        public byte[] GetFile(string uid, out string name)
        {
            var data = unitOfWork.Repository<FileBinary>().Get(x => x.GUId == uid).FirstOrDefault();

            if (data == null)
            {
                name = "Not Found";
                return null;
            }

            name = data.Name;
            return data.Binary;
        }

        public string Insert(string name, string filePath, AttachmentType attachmentType, int? ownerId = 0)
        {
            var repFileBinary = unitOfWork.Repository<FileBinary>();
            FileBinaryType fileType = FileBinaryType.none;
            var fileExtension = filePath.Substring(filePath.Length - 3, 3);
            switch (fileExtension.ToLower())
            {
                case "jpg":
                    fileType = FileBinaryType.picture;
                    break;
                default:
                    fileType = FileBinaryType.other;
                    break;
            }
            FileBinary newItem = new FileBinary()
            {
                Binary = null,
                fileBinaryType = fileType,
                filePath = filePath,
                GUId = Guid.NewGuid().ToString(),
                Name = name,
                attachmentType=attachmentType,
                ownerID=ownerId.ToString()
            };
            repFileBinary.Insert(newItem);
            unitOfWork.Commit();
            return newItem.Id.ToString(); 
        }
         
    }
}
