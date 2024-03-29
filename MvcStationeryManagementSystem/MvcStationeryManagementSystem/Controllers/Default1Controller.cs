﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStationeryManagementSystem.Models;
using System.Net.Mail;
using System.Text;

namespace MvcStationeryManagementSystem.Controllers
{
    public class Default1Controller : Controller
    {
       //lop chua cac method mahoa va giai ma
        private DescyptandEnscryt de = new DescyptandEnscryt();
        private DataClassesStationeryDataContext dc = new DataClassesStationeryDataContext();

        //private bool result = false;
        public ActionResult Help()
        {

            return View();
        }
       
        public ActionResult Search(string id)
        {
         

                RequestModel22 rq22 = new RequestModel22();
                Employee e = (Employee)Session["Employee"];
                if (id != null)
                {
                    List<RequestModel22> ls = rq22.search(id).Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == true) || (r1.Stte1.Equals("5") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
                    string chuoi = "";

                    foreach (RequestModel22 s in ls)
                    {
                        chuoi += "<tr>";
                        // chuoi += "<td>" + s.RId1 + "</td>";
                        chuoi += "<td>" + s.Rname1 + "</td>";
                        chuoi += "<td>" + s.CRQName1 + "</td>";
                        chuoi += "<td>" + s.DDispatch1 + "</td>";
                        //  chuoi += "<td>" + s.Arise + "</td>";
                        chuoi += "<td>" + s.DApprove1 + "</td>";
                        chuoi += "<td>" + s.RContent1 + "</td>";
                        //("Select","DetailRQ4/"+rq.RId1,"Default1")
                        chuoi += "<td><a href='/Default1/DetailRQ4/" + s.RId1 + "'>Select</a></td>";
                        chuoi += "</tr>";
                    }

                    Response.Write(chuoi);
                }
                else
                {
                    List<RequestModel22> ls = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == true) || (r1.Stte1.Equals("5") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
                    string chuoi = "";

                    foreach (RequestModel22 s in ls)
                    {
                        chuoi += "<tr>";
                        // chuoi += "<td>" + s.RId1 + "</td>";
                        chuoi += "<td>" + s.Rname1 + "</td>";
                        chuoi += "<td>" + s.CRQName1 + "</td>";
                        chuoi += "<td>" + s.DDispatch1 + "</td>";
                        //  chuoi += "<td>" + s.Arise + "</td>";
                        chuoi += "<td>" + s.DApprove1 + "</td>";
                        chuoi += "<td>" + s.RContent1 + "</td>";
                        //("Select","DetailRQ4/"+rq.RId1,"Default1")
                        chuoi += "<td><a href='/Default1/DetailRQ4/" + s.RId1 + "'>Select</a></td>";
                        chuoi += "</tr>";
                    }

                    Response.Write(chuoi);
                }
           
            return null;
        }
        //
        public ActionResult Search1(string id)
        {


            RequestModel22 rq22 = new RequestModel22();
            Employee e = (Employee)Session["Employee"];
            if (id != null)
            {
                List<RequestModel22> ls = rq22.search(id).Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
                string chuoi = "";

                foreach (RequestModel22 s in ls)
                {
                    chuoi += "<tr>";
                    // chuoi += "<td>" + s.RId1 + "</td>";
                    chuoi += "<td>" + s.Rname1 + "</td>";
                    chuoi += "<td>" + s.CRQName1 + "</td>";
                    chuoi += "<td>" + s.DDispatch1 + "</td>";
                    //  chuoi += "<td>" + s.Arise + "</td>";
                    chuoi += "<td>" + s.DApprove1 + "</td>";
                    chuoi += "<td>" + s.RContent1 + "</td>";
                    //("Select","DetailRQ4/"+rq.RId1,"Default1")
                    chuoi += "<td><a href='/Default1/DetailRQ4/" + s.RId1 + "'>Select</a></td>";
                    chuoi += "</tr>";
                }

                Response.Write(chuoi);
            }
            else
            {
                List<RequestModel22> ls = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
                string chuoi = "";

                foreach (RequestModel22 s in ls)
                {
                    chuoi += "<tr>";
                    // chuoi += "<td>" + s.RId1 + "</td>";
                    chuoi += "<td>" + s.Rname1 + "</td>";
                    chuoi += "<td>" + s.CRQName1 + "</td>";
                    chuoi += "<td>" + s.DDispatch1 + "</td>";
                    //  chuoi += "<td>" + s.Arise + "</td>";
                    chuoi += "<td>" + s.DApprove1 + "</td>";
                    chuoi += "<td>" + s.RContent1 + "</td>";
                    //("Select","DetailRQ4/"+rq.RId1,"Default1")
                    chuoi += "<td><a href='/Default1/DetailRQ4/" + s.RId1 + "'>Select</a></td>";
                    chuoi += "</tr>";
                }

                Response.Write(chuoi);
            }

            return null;
        }
        //
        //
       
        //
        public ActionResult MyRequest10()
        {
            //Session["ac"] = id;
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Login");
            }
            RequestModel rq = new RequestModel();
            RequestModel22 rq22 = new RequestModel22();
            Employee e = (Employee)Session["Employee"];
            //my newrequest/
            ViewData["lst"] = rq22.Listrq2().Where(r => (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("1") && r.Acc1 == true || (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("5") && r.Acc1==true)) || (e.EmployeeNumber.Equals(r.RNumber1) && r.Stte1.Equals("5")&& r.Acc1==true)).OrderByDescending(r => r.DDispatch1).ToList();
            //Request Approved/
            ViewData["lst1"] = rq22.Listrq2().Where(r => (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("2")) ||(e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("9") && r.Acc1==false)|| (e.EmployeeNumber.Equals(r.RNumber1) && r.Stte1.Equals("6") && r.Acc1 == true) || (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("6") && r.Acc1 == true) || (e.EmployeeNumber.Equals(r.RNumber1) && r.Stte1.Equals("66") && r.Acc1 == true) || (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("66") && r.Acc1 == true) || (e.EmployeeNumber.Equals(r.RNumber1) && r.Stte1.Equals("7") && r.Acc1 == false) || (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("7") && r.Acc1 == false)).OrderByDescending(r => r.DDispatch1).ToList();
           
            //My Accept/
            ViewData["lst2"] = rq.ListRQ().Where(r => (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("4") && r.Acc1 == true) || (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("7") && r.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
           //My Reject/
            ViewData["lst3"] = rq.ListRQ().Where(r => (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("4") && r.Acc1 == false) || (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("8") && r.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
          
            //Request No Approved/
            ViewData["lst4"] = rq22.Listrq2().Where(r => (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("3")) || (e.EmployeeNumber.Equals(r.RNumber1) && r.Stte1.Equals("6") && r.Acc1 == false) || (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("6") && r.Acc1 == false)).OrderByDescending(r => r.DDispatch1).ToList();
            //New Request
            ViewData["lst5"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
            //
            ViewData["lst55"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == true) || (r1.Stte1.Equals("5") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
            //Withdraw Request/
            ViewData["lst6"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == false) || (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("5") && r1.Acc1 == false)).OrderByDescending(r => r.DDispatch1).ToList();
            //
            ViewData["lst66"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == false) || (r1.Stte1.Equals("5") && r1.Acc1 == false)).OrderByDescending(r => r.DDispatch1).ToList();
           //Cancel Request/
            ViewData["lst7"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("2") && r1.Acc1 == false) || (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("7") && r1.Acc1 == false)).OrderByDescending(r => r.DDispatch1).ToList();
            //
            ViewData["lst77"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("2") && r1.Acc1 == false) || (r1.Stte1.Equals("7") && r1.Acc1 == false)).OrderByDescending(r => r.DDispatch1).ToList();
            //Accept Request/
            ViewData["lst8"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("4") && r1.Acc1 == true) || (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("7") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
            // 
            ViewData["lst88"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("4") && r1.Acc1 == true) || (r1.Stte1.Equals("7") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
         
        
            return View("myrequest10");
        }
        public ActionResult Back()
        {
            return RedirectToAction("Myrequest10");
        }
        //bat dau
        public ActionResult DetailRQ(int id)
        {
            RequestModel rm = new RequestModel();
            Request_StationeryModel rm1 = new Request_StationeryModel();
            ViewData["if"] = rm.Infomation(id);
            ViewData["if1"] = rm1.ListR_S(id);
            Employee el = (Employee)Session["Employee"];
            ViewData["em"] = dc.Employees.Where(i => i.EmployeeNumber.Equals(el.RegistrationNumber)).ToList().First();
            
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult update11()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult update11(FormCollection form)
        {
                Config cf = dc.Configs.OrderByDescending(c => c.BuildDate).ToList().First();
                RequestModel rq = new RequestModel();
                Employee e = (Employee)Session["Employee"];
                Employee e1 = dc.Employees.Where(ee => ee.EmployeeNumber == e.RegistrationNumber).ToList().First();
                Employee e2 = dc.Employees.Where(ee=>ee.RoleId==1).ToList().First();
                ViewData["lst"] = rq.ListRQ().Where(r => e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("1")).OrderByDescending(r => r.DDispatch1).ToList();

                string From = cf.MailName;
                string To = e1.Email;
                string cc = e2.Email;
                string type = cf.Type;
                int post = Convert.ToInt32(cf.Ports);
                string mailnetword = cf.MailNetwork;
                string pass = cf.Password;
                string Subject = "Withdraw Request " + form["rname"].ToString();
                string Message = "<span><b>From:</b> " + e.FullName + "</span><br/>" + "<b>Date Dispatch:</b> " + form["dd"].ToString() + "<br/>" + "<b>Content: </b>" + form["rc"].ToString() + "<br/>" + "<b>Description:</b> " + form["dt"].ToString();
                if (form["st"].Equals("5"))
                {
                    if (rq.Send1(From, To, cc, Subject, Message, type, post, mailnetword, pass))
                    {
                        rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                        Session["email"] = 1;
                    }
                    else
                        Session["email"] = 2;
                }
                else
                {
                    if (rq.Send(From, To, Subject, Message, type, post, mailnetword, pass))
                    {
                        rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                        Session["email"] = 1;
                    }
                    else
                        Session["email"] = 2;
                }
              
             return RedirectToAction("MyRequest10");
            
        }
        //ket thuc
        //2
        public ActionResult DetailRQ2(int id)
        {
            RequestModel rm = new RequestModel();
            Request_StationeryModel rm1 = new Request_StationeryModel();
            ViewData["if"] = rm.Infomation(id);
            ViewData["if1"] = rm1.ListR_S(id);

            return View();
        }
        public ActionResult DetailRQ22(int id)
        {
            RequestModel rm = new RequestModel();
            Request_StationeryModel rm1 = new Request_StationeryModel();
            ViewData["if"] = rm.Infomation(id);
            ViewData["if1"] = rm1.ListR_S(id);

            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult update2()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult update2(FormCollection form)
        {
            Config cf = dc.Configs.OrderByDescending(c => c.BuildDate).ToList().First();
            RequestModel rq = new RequestModel();
            RequestModel22 rq22 = new RequestModel22();
            Employee e = (Employee)Session["Employee"];
            Employee e1 = dc.Employees.Where(ee => ee.EmployeeNumber == e.RegistrationNumber).ToList().First();
            Employee e2 = dc.Employees.Where(ee => ee.RoleId == 1).ToList().First();
            ViewData["lst1"] = rq22.Listrq2().Where(r => (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("2")) || (e.EmployeeNumber.Equals(r.RNumber1) && r.Stte1.Equals("6") && r.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
            //
            string From = cf.MailName;
            string To = e1.Email;
            string cc = e2.Email;
            string type = cf.Type;
            int post = Convert.ToInt32(cf.Ports);
            string mailnetword = cf.MailNetwork;
            string pass = cf.Password;
            string Subject = "Accept Request " + form["rname"].ToString();
            string Message = "<span><b>From:</b> " + e.FullName + "</span><br/>" + "<b>Date Dispatch:</b> " + form["dd"].ToString() + "<br/>" + "<b>Content:</b> " + form["rc"].ToString() + "<br/>" + "<b>Description:</b> " + form["dt"].ToString();
            if (form["st1"].Equals("6") || form["st1"].Equals("7") || form["st1"].Equals("66"))
            {
                if (rq.Send1(From, To, cc, Subject, Message, type, post, mailnetword, pass))
                {
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email"] = 1;
                }
                else
                    Session["email"] = 2;
            }
            else
            {
                if (rq.Send(From, To, Subject, Message, type, post, mailnetword, pass))
                {
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email"] = 1;
                }
                else
                    Session["email"] = 2;
            }
            //
            //rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
            return RedirectToAction("MyRequest10");

        }
        //
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult update23()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult update23(FormCollection form)
        {
            Config cf = dc.Configs.OrderByDescending(c => c.BuildDate).ToList().First();
            RequestModel rq = new RequestModel();
            RequestModel22 rq22 = new RequestModel22();
            Employee e = (Employee)Session["Employee"];
            Employee e1 = dc.Employees.Where(ee => ee.EmployeeNumber == e.RegistrationNumber).ToList().First();
            Employee e2 = dc.Employees.Where(ee => ee.EmployeeNumber == e.RegistrationNumber).ToList().First();
            ViewData["lst1"] = rq22.Listrq2().Where(r => (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("2")) || (e.EmployeeNumber.Equals(r.RNumber1) && r.Stte1.Equals("6") && r.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
            //
            string From = cf.MailName;
            string To = e1.Email;
            string cc = e2.Email;
            string type = cf.Type;
            int post = Convert.ToInt32(cf.Ports);
            string mailnetword = cf.MailNetwork;
            string pass = cf.Password;
            string Subject = "Sent To Director Request " + form["rname"].ToString();
            string Message = "<span><b>From:</b> " + e.FullName + "</span><br/>" + "<b>Date Dispatch:</b> " + form["dd"].ToString() + "<br/>" + "<b>Content:</b> " + form["rc"].ToString() + "<br/>" + "<b>Description:</b> " + form["dt"].ToString();
            if (rq.Send1(From, To,cc, Subject, Message, type, post, mailnetword, pass))
            {
                rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                Session["email"] = 1;
            }
            else
                Session["email"] = 2;
            //
            rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
            return RedirectToAction("MyRequest10");

        }
        //
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult update22()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult update22(FormCollection form)
        {
            Config cf = dc.Configs.OrderByDescending(c => c.BuildDate).ToList().First();
            RequestModel rq = new RequestModel();
            RequestModel22 rq22 = new RequestModel22();
            Employee e = (Employee)Session["Employee"];
            Employee e1 = dc.Employees.Where(ee => ee.EmployeeNumber == e.RegistrationNumber).ToList().First();
            Employee e2=dc.Employees.Where(ee=>ee.RoleId==1).ToList().First();
            ViewData["lst1"] = rq22.Listrq2().Where(r => (e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("2")) || (e.EmployeeNumber.Equals(r.RNumber1) && r.Stte1.Equals("6") && r.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
            //
            string From = cf.MailName;
            string To = e1.Email;
            string cc=e2.Email;
            string type = cf.Type;
            int post = Convert.ToInt32(cf.Ports);
            string mailnetword = cf.MailNetwork;
            string pass = cf.Password;
            string Subject = "Reject Request " + form["rname"].ToString();
            string Message = "<span><b>From:</b> " + e.FullName + "</span><br/>" + "<b>Date Dispatch:</b> " + form["dd"].ToString() + "<br/>" + "<b>Content:</b> " + form["rc"].ToString() + "<br/>" + "<b>Description:</b> " + form["dt"].ToString();
            if (form["st2"].Equals("6"))
            {
                if (rq.Send1(From, To, cc, Subject, Message, type, post, mailnetword, pass))
                {
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email"] = 3;
                }
                else
                    Session["email"] = 4;
            }
            else
            {
                if (rq.Send(From, To, Subject, Message, type, post, mailnetword, pass))
                 {
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email"] = 3;
                }
                else
                    Session["email"] = 4;
            }
            //
            //rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
            return RedirectToAction("MyRequest10");

        }
        //
        //3
        public ActionResult DetailRQ3(int id)
        {
            RequestModel rm = new RequestModel();
            Request_StationeryModel rm1 = new Request_StationeryModel();
            ViewData["if"] = rm.Infomation(id);
            ViewData["if1"] = rm1.ListR_S(id);

            return View();
        }
        //
        public ActionResult DetailRQ33(int id)
        {
            RequestModel rm = new RequestModel();
            Request_StationeryModel rm1 = new Request_StationeryModel();
            ViewData["if"] = rm.Infomation(id);
            ViewData["if1"] = rm1.ListR_S(id);

            return View();
        }
        //
        //
        public ActionResult DetailRQ333(int id)
        {
            RequestModel rm = new RequestModel();
            Request_StationeryModel rm1 = new Request_StationeryModel();
            ViewData["if"] = rm.Infomation(id);
            ViewData["if1"] = rm1.ListR_S(id);

            return View();
        }
        //
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult DeleteRQ3()
        {
            return View();
        }
        //
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteRQ3(FormCollection form)
        {
            
            Request_StationeryModel rs = new Request_StationeryModel();
            RequestModel rq = new RequestModel();
            List<Request_Stationery> rstm = dc.Request_Stationeries.ToList();
         
                foreach (Request_Stationery rst in rstm)
                {
                    if (Convert.ToInt32(form["requestid"]) == rst.RequestId)
                        rs.DeleteRQ_st(Convert.ToInt32(form["requestid"]));   
                }
                if (rq.DeleteRQ(Convert.ToInt32(form["requestid"])))
                {
                    Session["dlrequest"] = 1;
                }
                else
                {
                    Session["dlrequest"] = 2;
                }

                return RedirectToAction("Myrequest10/#tabs-7");
        }
        public ActionResult update3(int requestid, string rname, string st, DateTime dd, DateTime da, bool acc, string rc, string en, string dt, int ctid)
        {
            RequestModel rq = new RequestModel();
            Employee e = (Employee)Session["Employee"];

            ViewData["lst2"] = rq.ListRQ().Where(r => e.EmployeeNumber.Equals(r.ENumber1) && r.Stte1.Equals("4") && r.Acc1 == true).OrderByDescending(r => r.DDispatch1).ToList();
            rq.update(requestid, rname, st, dd, da, acc, rc, en, dt, ctid);
            return RedirectToAction("MyRequest10");

        }
        //
        //4
        public ActionResult DetailRQ4(int id)
        {
            Employee el = (Employee)Session["Employee"];
            RequestModel rm = new RequestModel();
            Request_StationeryModel rm1 = new Request_StationeryModel();
            ViewData["if"] = rm.Infomation(id);
            ViewData["if1"] = rm1.ListR_S(id);
            ViewData["role"] = dc.Roles.Where(r => r.RoleId == el.RoleId).ToList().First();
            Session["eplo"]=dc.Employees.Where(e=>e.EmployeeNumber==((RequestModel)ViewData["if"]).ENumber1).ToList().First();
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult update4()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult update4(FormCollection form)
        {
            Request_StationeryModel rm1 = new Request_StationeryModel();
            
            List<Stationery> lstr = dc.Stationeries.ToList();
            Config cf = dc.Configs.OrderByDescending(c => c.BuildDate).ToList().First();
            RequestModel rq = new RequestModel();
            StationeryModel stmd = new StationeryModel();
            Employee e = (Employee)Session["Employee"];
            Employee e1 = (Employee)Session["eplo"];
            Employee e2 = dc.Employees.Where(ee => ee.EmployeeNumber == e1.RegistrationNumber).ToList().First();
            RequestModel22 rq22 = new RequestModel22();
           // Employee e1 = dc.Employees.Where(ee => ee.EmployeeNumber == e.RegistrationNumber).ToList().First();
            ViewData["lst5"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == true) || (r1.Stte1.Equals("5") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList();
            //
            string From = cf.MailName;
            string To = e1.Email;
            string cc = e2.Email;
            string type = cf.Type;
            int post = Convert.ToInt32(cf.Ports);
            string mailnetword = cf.MailNetwork;
            string pass = cf.Password;
            string Subject = "Approved Request " + form["rname"].ToString();
            string Message = "<span><b>From:</b> " + e.FullName + "</span><br/>" + "<b>Date Dispatch:</b> " + form["dd"].ToString() + "<br/>" + "<b>Content:</b> " + form["rc"].ToString() + "<br/>" + "<b>Description:</b> " + form["dt"].ToString();
            //mail
            List<Request_Stationery> rqs = dc.Request_Stationeries.Where(s => s.RequestId == Convert.ToInt32(form["requestid"])).ToList();
            string str = " ";
            Session["result"] = true;
            //test
            foreach (Stationery st in lstr)
            {
                foreach (Request_Stationery rs in rqs)
                {
                   
                    if (st.ProductId == rs.ProductId && rs.Quantity > st.Quantity)
                    {
                        Session["result"] = false;
                        break;
                    }
                   
                }
               
            }
            //
            //print item
            if (Convert.ToBoolean(Session["result"]) == false)
            {
                foreach (Stationery st in lstr)
                {
                    foreach (Request_Stationery rs in rqs)
                    {
                        if (st.ProductId == rs.ProductId && rs.Quantity > st.Quantity)
                        {
                            str = str + st.ProductName.ToString() + "&nbsp_&nbsp";
                        }
                    }
                }
            }
            else if (Convert.ToBoolean(Session["result"]) == true)
            {
                if (form["st3"].Equals("5"))
                {
                    if (rq.Send1(From, To, cc, Subject, Message, type, post, mailnetword, pass))
                    {
                        //////
                        List<Stationery> stnr = dc.Stationeries.ToList();
                        List<Request_Stationery> listrq = dc.Request_Stationeries.Where(l => l.RequestId == Convert.ToInt32(form["requestid"])).ToList();
                        //
                        foreach (Stationery s in stnr)
                       {
                           foreach (Request_Stationery v in listrq)
                           {
                               if (s.ProductId == v.ProductId)
                                   stmd.EditST_RQ(v.ProductId, Convert.ToInt32(s.Quantity - v.Quantity));
                           }
                        }

                        
                      
                        //
                        rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                       
                        Session["email"] = 1;
                    }
                    else
                        Session["email"] = 2;
                    //

                }
                else
                {
                    if (rq.Send(From, To, Subject, Message, type, post, mailnetword, pass))
                    {
                        List<Stationery> stnr = dc.Stationeries.ToList();
                        List<Request_Stationery> listrq = dc.Request_Stationeries.Where(l => l.RequestId == Convert.ToInt32(form["requestid"])).ToList();
                        //
                        foreach (Stationery s in stnr)
                        {
                            foreach (Request_Stationery v in listrq)
                            {
                                if(s.ProductId==v.ProductId)
                                stmd.EditST_RQ(v.ProductId, Convert.ToInt32(s.Quantity-v.Quantity));
                            }
                        }

                        
                        rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                        Session["email"] = 1;
                    }
                    else
                        Session["email"] = 2;
                }
            }
            //mail
            Session["qty"] = str;
            //
            
            return RedirectToAction("MyRequest10");

        }
        //

        //
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult update44()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult update44(FormCollection form)
        {
            Config cf = dc.Configs.OrderByDescending(c => c.BuildDate).ToList().First();
            RequestModel rq = new RequestModel();
            Employee e = (Employee)Session["Employee"];
            RequestModel22 rq22 = new RequestModel22();
            Employee e1 = (Employee)Session["eplo"];
             Employee e2 = dc.Employees.Where(ee => ee.EmployeeNumber == e1.RegistrationNumber).ToList().First();
            ViewData["lst5"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("1") && r1.Acc1 == true) || (r1.Stte1.Equals("5") && r1.Acc1 == true)).OrderByDescending(r => r.DDispatch1).ToList(); 
            string From = cf.MailName;
            string To = e1.Email;
            string cc=e2.Email;
            string type = cf.Type;
            int post = Convert.ToInt32(cf.Ports);
            string mailnetword = cf.MailNetwork;
            string pass = cf.Password;
            string Subject = "No Approved Request " + form["rname"].ToString();
            string Message = "<span><b>From:</b> " + e.FullName + "</span><br/>" + "<b>Date Dispatch:</b> " + form["dd"].ToString() + "<br/>" + "<b>Content:</b> " + form["rc"].ToString() + "<br/>" + "<b>Description:</b> " + form["dt"].ToString();
            if (form["st4"].Equals("5"))
            {
                if (rq.Send1(From, To, cc, Subject, Message, type, post, mailnetword, pass))
                {
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email"] = 1;
                }
                else
                    Session["email"] = 2;
            }
            else
            {
                if (rq.Send(From, To, Subject, Message, type, post, mailnetword, pass))
                {
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email"] = 1;
                }
                else
                    Session["email"] = 2;
            }
            //requestid, rname, st, dd, DateTime.Now, acc, rc, en, dt, ctid
            
            return RedirectToAction("MyRequest10");

        }
        //
        //5
      
        public ActionResult DetailRQ5(int id)
        {
            RequestModel rm = new RequestModel();
            Request_StationeryModel rm1 = new Request_StationeryModel();
            ViewData["if"] = rm.Infomation(id);
            ViewData["if1"] = rm1.ListR_S(id);
            Session["eplo1"] = dc.Employees.Where(e => e.EmployeeNumber == ((RequestModel)ViewData["if"]).ENumber1).ToList().First();
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult update5()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult update5(FormCollection form)
        {
            Config cf = dc.Configs.OrderByDescending(c => c.BuildDate).ToList().First();
            RequestModel22 rq22 = new RequestModel22();
            RequestModel rq = new RequestModel();
            Employee e = (Employee)Session["Employee"];
            Employee e1 = (Employee)Session["eplo1"];//nb req
            Employee e2 = dc.Employees.Where(ee => ee.EmployeeNumber == e1.RegistrationNumber).ToList().First();
            ViewData["lst7"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("2") && r1.Acc1 == false) || (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("7") && r1.Acc1 == false)).OrderByDescending(r => r.DDispatch1).ToList();
            string From = cf.MailName;
            string To = e1.Email;
            string cc=e2.Email;
            string type = cf.Type;
            int post = Convert.ToInt32(cf.Ports);
            string mailnetword = cf.MailNetwork;
            string pass = cf.Password;
            string Subject = "Approved (Request Rject) " + form["rname"].ToString();
            string Message = "<span><b>From:</b> " + e.FullName + "</span><br/>" + "<b>Date Dispatch:</b> " + form["dd"].ToString() + "<br/>" + "<b>Content:</b> " + form["rc"].ToString() + "<br/>" + "<b>Description:</b> " + form["dt"].ToString();
            if (form["st5"].Equals("7"))
            {
                if (rq.Send1(From, To, cc, Subject, Message, type, post, mailnetword, pass))
                {
                    StationeryModel stmd = new StationeryModel();
                    List<Stationery> stnr = dc.Stationeries.ToList();
                    List<Request_Stationery> listrq = dc.Request_Stationeries.Where(l => l.RequestId == Convert.ToInt32(form["requestid"])).ToList();
                    //
                    foreach (Stationery s in stnr)
                    {
                        foreach (Request_Stationery v in listrq)
                        {
                            if (s.ProductId == v.ProductId)
                                stmd.EditST_RQ(v.ProductId, Convert.ToInt32(s.Quantity + v.Quantity));
                        }
                    }
                    //
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email"] = 1;
                    Session["email1"] = 1;

                }
                else
                    Session["email"] = 2;
               
            }
            else
            {
                if (rq.Send(From, To, Subject, Message, type, post, mailnetword, pass))
                {
                    //
                    StationeryModel stmd = new StationeryModel();
                    List<Stationery> stnr = dc.Stationeries.ToList();
                    List<Request_Stationery> listrq = dc.Request_Stationeries.Where(l => l.RequestId == Convert.ToInt32(form["requestid"])).ToList();
                    //
                    foreach (Stationery s in stnr)
                    {
                        foreach (Request_Stationery v in listrq)
                        {
                            if (s.ProductId == v.ProductId)
                                stmd.EditST_RQ(v.ProductId, Convert.ToInt32(s.Quantity + v.Quantity));
                           
                        }
                    }
                    //
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email1"] = 1;
                    Session["email"] = 1;
                }
                else
                    Session["email"] = 2;
               
            }
            return RedirectToAction("MyRequest10");

        }
        //
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult update55()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult update55(FormCollection form)
        {
            Config cf = dc.Configs.OrderByDescending(c => c.BuildDate).ToList().First();
            RequestModel22 rq22 = new RequestModel22();
            RequestModel rq = new RequestModel();
            Employee e = (Employee)Session["Employee"];
            Employee e1 = (Employee)Session["eplo1"];//nb req
            Employee e2 = dc.Employees.Where(ee => ee.EmployeeNumber == e1.RegistrationNumber).ToList().First();
            ViewData["lst7"] = rq22.Listrq2().Where(r1 => (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("2") && r1.Acc1 == false) || (e.EmployeeNumber.Equals(r1.RNumber1) && r1.Stte1.Equals("7") && r1.Acc1 == false)).OrderByDescending(r => r.DDispatch1).ToList();
            string From = cf.MailName;
            string To = e1.Email;
            string cc = e2.Email;
            string type = cf.Type;
            int post = Convert.ToInt32(cf.Ports);
            string mailnetword = cf.MailNetwork;
            string pass = cf.Password;
            string Subject = "No Approved (Request Rject) " + form["rname"].ToString();
            string Message = "<span><b>From:</b> " + e.FullName + "</span><br/>" + "<b>Date Dispatch:</b> " + form["dd"].ToString() + "<br/>" + "<b>Content:</b> " + form["rc"].ToString() + "<br/>" + "<b>Description:</b> " + form["dt"].ToString();
            if (form["st6"].Equals("7"))
            {
                if (rq.Send1(From, To, cc, Subject, Message, type, post, mailnetword, pass))
                {
                    
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email"] = 1;
                }
                else
                    Session["email"] = 2;
            }
            else
            {
                if (rq.Send(From, To, Subject, Message, type, post, mailnetword, pass))
                {
                    rq.update(Convert.ToInt32(form["requestid"]), form["rname"].ToString(), form["st"].ToString(), Convert.ToDateTime(form["dd"]), DateTime.Now, Convert.ToBoolean(form["acc"]), form["rc"].ToString(), form["en"].ToString(), form["dt"].ToString(), Convert.ToInt32(form["ctid"]));
                    Session["email"] = 1;
                }
                else
                    Session["email"] = 2;
            }
            return RedirectToAction("MyRequest10");

        }
       
        
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(FormCollection formvalue)
        {
            Employee el = new Employee();
            el = de.Login(formvalue["EmployeeNumber"].ToString(), formvalue["Password"].ToString());
            if(! ModelState.IsValid)
            {
                 return View();
            }

            if ( el == null)
           {
               ViewData["kq"] = "Not found account";
               return View();
           }
            Session["Employee"] = el;

            return RedirectToAction("myrequest10");

           
        }

        //logout
        public ActionResult logout()
        {
            Session.Remove("Employee");
            return RedirectToAction("MyRequest10");
        }

    }
}
