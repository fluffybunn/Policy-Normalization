using DAL.BusinessObjects;
using DevExpress.Xpo;

namespace PolicyNormal.Module.BusinessObjects
{
    [DSDefaultClassOptions]
    public class VehicleModel : DSEntityBase<VehicleModel>
    {
        public VehicleModel(Session session) : base(session) { }
        public string ModelName { get; set; }
        [Association]
        public VehicleMark VehicleMark { get; set; }
        [Association]
        public VehicleType VehicleType { get; set; }
        [Association]
        public XPCollection<Car> Cars => GetCollection<Car>(nameof(Cars));

    }
}