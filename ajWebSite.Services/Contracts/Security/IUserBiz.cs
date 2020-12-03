using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using ajWebSite.Common.DTOs.Security;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Biz;
using ajWebSite.Core.Contracts.Entities;

namespace ajWebSite.Services.Contracts.Security
{
    public interface IUserBiz : IBiz<UserDTO>
    {
        List<UserInfoDTO> getUsers();
        UserInfoDTO Login(LoginDTO loginDto, out List<Claim> claims);
        UserDTO getAdminOfWebSite();
        UserDTO getUserById(int Id);

        UserInfoDTO Register(RegisterDTO dto, out string errorMessage, out List<Claim> claims);

        bool RegisterSendCode(string mobile, out string errorMessage);
        bool RegisterCheckCode(string mobile, string code);

        PaginatedResult<UserInfoDTO> UserPaginated(UserSearch search);
        bool CreateUser(UserInfoDTO user, out string errorMessage);
        bool CreateUser(UserDTO user, out string errorMessage);
        bool UpdateUser(UserInfoDTO user, out string errorMessage);

        void DeleteUser(int userId, UserType userType);
    }
}
