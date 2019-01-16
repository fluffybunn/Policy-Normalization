using DAL.BusinessObjects;
using DevExpress.Xpo;
using System.ComponentModel;

namespace PolicyNormal.Module.BusinessObjects
{
    [DSDefaultClassOptions]
    [DefaultProperty(nameof(TypeMark))]
    public class VehicleMark : DSEntityBase<VehicleMark>
    {
        public VehicleMark(Session session) : base(session) { }
        public string TypeMark { get; set; }
        [Association] public XPCollection<VehicleModel> Models => GetCollection<VehicleModel>(nameof(Models));
    }
}
