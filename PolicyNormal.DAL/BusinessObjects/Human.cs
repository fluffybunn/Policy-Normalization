using DAL.BusinessObjects;
using DevExpress.Xpo;

namespace PolicyNormal.Module.BusinessObjects
{
    [DSDefaultClassOptions]
    public class Human : DSEntityBase<Human>
    {
        public Human(Session session) : base(session) {}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pid { get; set; }
        [Association(nameof(InsuredPolicies))] public XPCollection<Policy> InsuredPolicies => GetCollection<Policy>(nameof(InsuredPolicies));
        [Association(nameof(InsurerPolicies))] public XPCollection<Policy> InsurerPolicies => GetCollection<Policy>(nameof(InsurerPolicies));
    }
}

