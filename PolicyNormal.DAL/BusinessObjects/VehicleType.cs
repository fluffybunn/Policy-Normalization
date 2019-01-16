using DAL.BusinessObjects;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicyNormal.Module.BusinessObjects
{
    [DSDefaultClassOptions]
    public class VehicleType : DSEntityBase<VehicleType>
    {
        public VehicleType(Session session) : base(session) { }
        public string TypeName { get; set; }

        [Association]
        public XPCollection<VehicleModel> VehicleModels => GetCollection<VehicleModel>(nameof(VehicleModels));


        public IList<Car> Cars => VehicleModels.SelectMany(v => v.Cars).ToList();
        public IList<Policy> Policies => VehicleModels.SelectMany(v => v.Cars).SelectMany(c => c.Policies).ToList();
    }
}