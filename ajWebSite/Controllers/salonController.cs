using ajWebSite.Areas.AdminPanel.Controllers;
using ajWebSite.Models.salon;
using Microsoft.AspNetCore.Mvc;
using ajWebSite.Common.DTOs.ajWebSite;
using ajWebSite.Core.Module;
using ajWebSite.Services.Contracts.Common;
using ajWebSite.Services.Contracts.ajWebSite;
using ajWebSite.Services.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ajWebSite.Controllers
{
    public class salonController : BaseControllerClass
    {
        IsalonBiz _salonBiz;
        CurrentUser _currentUser;
        IFileBinaryBiz _FileBinaryBiz;
        IUserBiz _Userbiz;
        public salonController(IsalonBiz salonBiz,CurrentUser currentUser, IFileBinaryBiz fileBinaryBiz, IUserBiz Userbiz)
        {
            _currentUser = currentUser;
            _salonBiz = salonBiz;
            _FileBinaryBiz = fileBinaryBiz;
            _Userbiz = Userbiz;
        }
        public async Task<ActionResult> registerSalon()
        {
            return View();
        }
        public async Task<ActionResult> Salon(int Id)
        {
            var model = new salonModel();

            var selectedSalon = _salonBiz.GetAll().FirstOrDefault(p => p.Id == Id);
            if (selectedSalon==null)
            {
                return Ok(new NotFoundResult());
            }
            var managedBy = _Userbiz.GetAll().FirstOrDefault(p => p.CreatorId == selectedSalon.CreatorId);
            if (managedBy!=null)
            {
                selectedSalon.managementBy = managedBy.LastName+" "+managedBy.Name;
            }
            model.selectedSalon = selectedSalon;
            model.pictures = _FileBinaryBiz.getAttachments(Id,ajWebSite.Common.Enums.AttachmentType.salonAttachments);
            return View(model);
        }
        public async Task<ActionResult> getMySalon(salonDTO data)
        {
            var result = await runTaskAsync<salonDTO>(async () =>
            {
                var maySalon = _salonBiz.GetAll().FirstOrDefault(p => p.CreatorId == _currentUser.ID);
                return maySalon;

            });
            return Ok(result);
        }
        public async Task<ActionResult> getSalons()
        {
            var result = await runTaskAsync<List<salonDTO>>(async () =>{
                var listOfsalons = _salonBiz.GetAll();
                return listOfsalons;
            });
            return Ok(result);
        }
        public async Task<ActionResult> adminSalonManagement()
        {
            return View();
        }
        public async Task<ActionResult> updateStateOfSalon(updateStateOfSalonModel model)
        {
            var result = await runTaskAsync<string>(async () => {
                _salonBiz.changeSalonState(model.salonId,model.salonState);
                return "true";
            });
            return Ok(result);
        }
        public async Task<ActionResult> registerSalonData(salonDTO data)
        {
            var result = await runTaskAsync<salonDTO>(async () =>
              {
                  try
                  {

                      var resultModel =new salonDTO();
                      var maySalon = _salonBiz.GetAll().FirstOrDefault(p => p.CreatorId == _currentUser.ID); 
                      if (maySalon==null)
                      {
                          data.state = ajWebSite.Common.Enums.saloonState.registered;
                          resultModel = _salonBiz.InsertAndReturn(data);
                      }
                      else
                      {
                          data.Id = maySalon.Id;
                          maySalon.CreatorId = _currentUser.ID;
                          maySalon.addressCity = data.addressCity;
                          maySalon.addressDetails = data.addressDetails;
                          maySalon.addressState = data.addressState;
                          maySalon.locationLan = data.locationLan;
                          maySalon.locationLat = data.locationLat;
                          maySalon.packages = data.packages;
                          maySalon.seriveses = data.seriveses;
                          maySalon.state = data.state;
                          maySalon.salonPhone = data.salonPhone;
                          maySalon.salonStateTitle = data.salonStateTitle;
                          maySalon.saloonName = data.saloonName;
                          _salonBiz.Update(maySalon);
                          resultModel=_salonBiz.GetAll().FirstOrDefault(p => p.CreatorId == _currentUser.ID);
                      }
                       
                      return resultModel;
                  }
                  catch (Exception ex)
                  {
                      throw new Exception("عملیات ثبت سالن نا موفق بود");
                  }
              });
            return Ok(result);
        }
    }
}
