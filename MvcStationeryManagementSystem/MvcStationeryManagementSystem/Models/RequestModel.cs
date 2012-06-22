﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.UI.MobileControls;
using System.Collections.Generic;

namespace MvcStationeryManagementSystem.Models
{
    public class RequestModel
    {
        private DataClassesStationeryDataContext dc = new DataClassesStationeryDataContext();
        private string ENumber;

        public string ENumber1
        {
            get { return ENumber; }
            set { ENumber = value; }
        }
        private string RName;

        public string RName1
        {
            get { return RName; }
            set { RName = value; }
        }
        private string CRQName;

        public string CRQName1
        {
            get { return CRQName; }
            set { CRQName = value; }
        }
        private DateTime DDispatch;

        public DateTime DDispatch1
        {
            get { return DDispatch; }
            set { DDispatch = value; }
        }
        private DateTime DApprove;

        public DateTime DApprove1
        {
            get { return DApprove; }
            set { DApprove = value; }
        }
        private string RContent;

        public string RContent1
        {
            get { return RContent; }
            set { RContent = value; }
        }
        private string Dtion;

        public string Dtion1
        {
            get { return Dtion; }
            set { Dtion = value; }
        }
        private string Stte;

        public string Stte1
        {
            get { return Stte; }
            set { Stte = value; }
        }
        private bool Acc;

        public bool Acc1
        {
            get { return Acc; }
            set { Acc = value; }
        }

       
        public RequestModel()
        { }
        //chi duoc anh xa co so du lieu len thoi 
        public List<RequestModel> ListRQ()
        {
            List<RequestModel> Listr = new List<RequestModel>();
            var requests = from r in dc.Requests
                           join ca in dc.CatalogeRQs on r.CatalogRQId equals ca.CatalogRQId
                           
                          select new
                          {
                              EmployeeNumber=r.EmployeeNumber,
                              RequestName = r.RequestName,
                              CatalogRQName = ca.CatalogRQName,
                              DateDispatch = r.DateDispatch,
                              DateApprove = r.DateApprove,
                              RequestContent=r.RequestContent,
                              Description=r.Description,
                              State=r.State,
                              Accept=r.Accept
                          };
            foreach (var rr in requests)
            {
                RequestModel obrq = new RequestModel();
                obrq.ENumber = rr.EmployeeNumber;
                obrq.RName = rr.RequestName;
                obrq.CRQName = rr.CatalogRQName;
                obrq.DDispatch = Convert.ToDateTime(rr.DateDispatch);
                obrq.DApprove = Convert.ToDateTime(rr.DateApprove);
                obrq.RContent = rr.RequestContent;
                obrq.Dtion = rr.Description;
                obrq.Stte = rr.State;
                obrq.Acc = Convert.ToBoolean(rr.Accept);
                Listr.Add(obrq);
            }
            return Listr;
        }
    }
}
