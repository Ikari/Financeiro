using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;

namespace Financeiro.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region -> Usuários <- 

        public ActionResult Usuarios()
        {
            var model = AutoMapper.Mapper.Map<IList<DAL.User>, IList<Models.Admin.User>>(new BLL.User().GetUsers());
            return View(model);
        }

        public ActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarUsuario(Models.Admin.User usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            new BLL.User().Save(null, usuario.UserName);

            return View(usuario);
        }

        public ActionResult EditarUsuario(int id)
        {
            var model = AutoMapper.Mapper.Map<DAL.User, Models.Admin.User>(new BLL.User().GetUserById(id));
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarUsuario(Models.Admin.User usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            new BLL.User().Save(usuario.UserId, usuario.UserName);

            return View(usuario);
        }

        #endregion

        #region -> Contas <-

        public ActionResult Contas()
        {
            var model = AutoMapper.Mapper.Map<IList<DAL.Account>, IList<Models.Admin.Account>>(new BLL.Account().GetAccounts());
            return View(model);
        }

        public ActionResult CriarConta()
        {;
            var model = new Models.Admin.Account(
                    new BLL.User().GetUsers().Select(u => new SelectListItem { Text = u.UserName, Value = Convert.ToString(u.UserId) }).ToList(),
                    new BLL.Bank().GetBanks().Select(b => new SelectListItem { Text = b.BankName, Value = Convert.ToString(b.BankId) }).ToList()
                );
            return View(model);
        }

        [HttpPost]
        public ActionResult CriarConta(Models.Admin.Account conta)
        {
            if (!ModelState.IsValid)
                return View(conta);

            new BLL.Account().Save(null, conta.BankId, conta.OwnerId);

            return View(conta);
        }

        public ActionResult EditarConta(int id)
        {
            var model = AutoMapper.Mapper.Map<DAL.Account, Models.Admin.Account>(new BLL.Account().GetById(id));
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarConta(Models.Admin.Account conta)
        {
            if (!ModelState.IsValid)
                return View(conta);

            new BLL.Account().Save(conta.AccountId, conta.BankId, conta.OwnerId);

            return View(conta);
        }

        #endregion

        #region -> Bancos <- 

        public ActionResult Bancos()
        {
            var model = AutoMapper.Mapper.Map<IList<DAL.Bank>, IList<Models.Admin.Bank>>(new BLL.Bank().GetBanks());
            return View(model);
        }

        public ActionResult CriarBanco()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarBanco(Models.Admin.Bank banco)
        {
            if (!ModelState.IsValid)
                return View(banco);

            new BLL.Bank().Save(null, banco.BankName, banco.BankNumber);

            return View(banco);
        }

        public ActionResult EditarBanco(int id)
        {
            var model = AutoMapper.Mapper.Map<DAL.Bank, Models.Admin.Bank>(new BLL.Bank().GetBankById(id));
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarBanco(Models.Admin.Bank banco)
        {
            if (!ModelState.IsValid)
                return View(banco);

            new BLL.Bank().Save(banco.BankId, banco.BankName, banco.BankNumber);

            return View(banco);
        }

        #endregion
    }
}