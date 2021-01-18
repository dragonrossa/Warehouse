using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Models;
using Warehouse.Repository;
using PagedList;

namespace Warehouse.Controllers
{
    public class AdminController : Controller
    {
        private WarehouseContext _db = new WarehouseContext();
    
        //Get Admin Repository
        AdminRepository adminRepository = new AdminRepository();

        //Create Admin object
        AdminModels admin = new AdminModels();

        //Create User object
        UserModels user = new UserModels();


        // GET: Admin
        public async Task<ActionResult> Index(string searchString, string sortOrder, int? page)
        {

                try
                {

                //Paging and search

                ViewBag.CurrentSort = sortOrder;
                ViewBag.pageNumber = page ?? 1;


                int pageSize = 10;
                int pageNumber = page ?? 1;



                //Get ViewBag.pageCount
                ViewBag.pageCount = await adminRepository.pageCount(pageSize);


                //Session for controllers

                Session["pageNumber"] = pageNumber;
                Session["pageSize"] = pageSize;

           
                //Search box

                if (!String.IsNullOrEmpty(searchString))
                {

                    return View( new UserModels { userAccess = await adminRepository.userSearch(page, searchString) });
                }




                return View( new UserModels { 
                    userAccess = await adminRepository.pagedUserList(page)
                }
                );
                  //  return View(users());
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);

                    //redirect if there are no Laptopmodels in list
                    if (e.Message == "Sequence contains no elements")
                    {

                        //throw new UserNotFoundException();
                        // throw;
                        return RedirectToAction("NotFound");

                    }

                }
                finally
                {

                }
          
            return View();
        }

        //Exception - UserNotFound

        public async Task<ActionResult> NotFound()
        {
            return View();
        }


        public async Task<ActionResult> ChangeRole(int id)
        {

            TempData["UserID"] = id;
            var thisUsername = await adminRepository.findUser(id);
            ViewBag.user = thisUsername.Name + " " + thisUsername.LastName;
            ViewBag.username = thisUsername.UserName;
            ViewBag.currentRole = await adminRepository.currentRole(thisUsername);
            TempData["currentRole"] = ViewBag.currentRole;
            TempData["username"] = ViewBag.username;
            //List of available roles
            ViewData["roles"] = await adminRepository.listOfRoles();
           // listOfRoles();

            return View(await adminRepository.findUser(id));
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeRole(FormCollection form)
        {
          

            try
            {

                if (ModelState.IsValid)
                {
                    string roleID = form["Roles"]; 
                    admin.RoleID = Convert.ToInt32(roleID);
                    admin.Username = TempData["username"].ToString();

                    //if username is already in table update
                    //if username is not already in table create record

                    var username = await adminRepository.findUsername(admin);
                    var user =  await adminRepository.user1(admin);
                    
                    if (admin.Username == username)
                    {

                        user.RoleID = Convert.ToInt32(roleID);
                        //Save db

                        await adminRepository.SaveData();

                        //Create new log

                        var currentRole = await adminRepository.getCurrentRole(user.RoleID);

                        await adminRepository.log6(user.Username, currentRole);
                    }
                    else
                    {
                      //  _db.AdminModels.Add(admin);
                         //adminRepository.Data(_db).AdminModels.Add(admin);

                        //Save db

                        await adminRepository.SaveData();

                        //Create log

                        await adminRepository.log6(user.Username, admin.RoleID);

                        return RedirectToAction("Index", "Admin", new { });
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }

            return RedirectToAction("Index", "Admin", new { });

        }

        public async Task<ActionResult> ChangeDetails(int id)
        {
            try
            {

                TempData["UserID"] = id;


                if (ModelState.IsValid)
                {

                    UserModels user = _db.UserModels.Find(id);

                    return View(user);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {

            }

            return View();
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeDetails(UserModels user)
        {
            try
            {

            if (ModelState.IsValid)
            {


                    adminRepository.Data(_db).Entry(user).State = EntityState.Modified;

                    //Save db
                    await adminRepository.SaveData();
                    return RedirectToAction("Index", "Admin", user);

            }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return View();
        }



        //Access for all users

        public async Task<ActionResult> Access2( string username)

        {

            // Check access

            List<AdminModels> list = await adminRepository.access(username);

            if (list.Count == 0)
            {

                await adminRepository.adminListOfAccess(username);
            }

            return View(new AdminModels { access = list });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Access2(FormCollection form)
        {

            int userID = Convert.ToInt32(form["item.ID"]);

            var user = await adminRepository.adminUser(userID);

            //Save changes for user and create new log 

            await adminRepository.log7(form, userID, user.Username);
 

            return RedirectToAction("Index","Admin");
        }

        //Dispose DB
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }


}