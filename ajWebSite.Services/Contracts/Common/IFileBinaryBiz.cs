using ajWebSite.Common.DTOs.Common;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Biz;
using System.Collections.Generic;

namespace ajWebSite.Services.Contracts.Common
{
    public interface IFileBinaryBiz
    {
        List<FileBinaryDTO> getAttachments(int ownerId, AttachmentType attachmentType);
        string Insert(string name, byte[] data);
        string Insert(string name, string filePath, AttachmentType attachmentType,int? ownerId=0);
        byte[] GetFile(string uid, out string name); 
    }
}