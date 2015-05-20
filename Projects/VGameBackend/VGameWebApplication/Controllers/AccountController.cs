﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Regulus.Extension;
using System.Threading.Tasks;
using Regulus.Extension;
namespace VGameWebApplication.Controllers
{

    [Authorize]
    public class AccountController : AsyncController
    {
        private VGame.Project.FishHunter.Data.Account[] _Accounts;


        
        //
        // GET: /Account/
        public ActionResult Index()
        {            
            
            VGame.Project.FishHunter.Storage.Service model = VGame.Project.FishHunter.Storage.Service.Create(HttpContext.Items["StorageId"]);
            var accounts = model.AccountManager.QueryAllAccount().WaitResult();
            model.Release();
            return View(accounts);
        }

        private void _GetAccounts(VGame.Project.FishHunter.Data.Account[] obj)
        {
            _Accounts = obj;            
        }

        public ActionResult Add()
        {
            return View(new VGame.Project.FishHunter.Data.Account());
        }

        async public System.Threading.Tasks.Task<ActionResult> AddHandle(VGame.Project.FishHunter.Data.Account account)
        {
            
            var model = VGame.Project.FishHunter.Storage.Service.Create(HttpContext.Items["StorageId"]);

            account.Id = Guid.NewGuid();
            var result = await model.AccountManager.Create(account).ToTask();

            model.Release();
            return RedirectToAction("Index");
        }

        public async System.Threading.Tasks.Task<ActionResult> Edit(string accountid)
        {
            Guid accountId;
            if (Guid.TryParse(accountid, out accountId) == false)
                return RedirectToAction("Index");



            var model = VGame.Project.FishHunter.Storage.Service.Create(HttpContext.Items["StorageId"]);
            var result = await model.AccountFinder.FindAccountById(accountId).ToTask();
            model.Release();
            if (result.Id != Guid.Empty)
            {
                var updateAccount = new VGameWebApplication.Models.UpdateAccount();
                updateAccount.TheAccount = result;
                return View(updateAccount);
            }

            return RedirectToAction("Index");
        }



        [AcceptVerbs(HttpVerbs.Post)]
        async public System.Threading.Tasks.Task<ActionResult> Edit( VGameWebApplication.Models.UpdateAccount account)
        {
            if(ModelState.IsValid)
            {                
                var model = VGame.Project.FishHunter.Storage.Service.Create(HttpContext.Items["StorageId"]);
                var result = await model.AccountManager.Update(account.TheAccount).ToTask();
                model.Release();
                return View(account);
            }
            return RedirectToAction("Index");
        }
        
	}
}