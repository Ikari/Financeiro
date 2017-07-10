using System.Collections.Generic;
using System.Web.Mvc;

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

        #region -> Account <-

        public ActionResult Conta(int userId)
        {
            var model = AutoMapper.Mapper.Map<IList<DAL.User>, IList<Models.Admin.User>>(new BLL.User().GetUsers());
            return View(model);
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