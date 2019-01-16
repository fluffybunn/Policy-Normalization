using DAL.BusinessObjects;
using DevExpress.Xpo;

namespace PolicyNormal.Module.BusinessObjects
{
    [DSDefaultClassOptions]
    public class Car : DSEntityBase<Car>
    {
        public Car(Session session) : base(session) { }
        [DSAction]
        public string RegistrationNumber { get; set; }
        [Association] public VehicleModel VehicleModel { get; set; }

        public int VehicleYear { get; set; }
        [Association] public XPCollection<Policy> Policies => GetCollection<Policy>(nameof(Policies));
    }
}