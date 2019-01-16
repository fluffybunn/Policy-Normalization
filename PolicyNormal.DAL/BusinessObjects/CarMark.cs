using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace PolicyNormal.Module.BusinessObjects
{
    [DefaultClassOptions]
    
    public class CarMark : BaseObject
    { 
        public CarMark(Session session)
            : base(session)
        {
        }


        [XafDisplayName("მანქანის მარკა")]

        public string CMark { get; set; }



        [Association] public XPCollection<Car> Cars => GetCollection<Car>(nameof(Cars));
    }
}