using System;
using System.Collections.Generic;
using DevExpress.Xpo;

namespace DAL.BusinessObjects
{
    [NonPersistent]
    // ReSharper disable once InconsistentNaming
    public class DSEntityBaseId<T> : DSEntityBaseWithUser<T, int> where T : DSEntityBaseWithUser<T, int>
    {
        public DSEntityBaseId(Session session) : base(session) { }

    }

    [NonPersistent]
    // ReSharper disable once InconsistentNaming
    public class DSEntityBase<T> : DSEntityBaseWithUser<T, Guid> where T : DSEntityBaseWithUser<T, Guid>
    {
        public DSEntityBase(Session session) : base(session) { }
    }

    [NonPersistent]
    // ReSharper disable once InconsistentNaming
    public class DSEntityBaseWithUser<T, TKey> : DSEntityBaseNoUser<T, TKey> where T : DSEntityBaseNoUser<T, TKey>
    {
        public DSEntityBaseWithUser(Session session) : base(session) { }
        //public DoSoUser2 CreatedBy3 { get; set; }
    }

    [NonPersistent]
    [OptimisticLocking(true)]
    // ReSharper disable once InconsistentNaming
    public class DSEntityBaseNoUser<T, TKeyType> : XPLiteObject where T : DSEntityBaseNoUser<T, TKeyType>
    {
        [Key(true)]
        public TKeyType Oid { get; set; }
        public static event Action<T> OnSavingEvent;
        public static event Action<T, string, object, object> OnChangedEvent;

        //public List<ValueObject> ValueObjects = new List<ValueObject>();
        //public virtual void AddValueObject(ValueObject vo) => ValueObjects.Add(vo);
        //public virtual void ClearAndAddValueObject(ValueObject vo)
        //{
        //    ValueObjects.Clear();
        //    AddValueObject(vo);
        //}

        protected override void OnLoaded()
        {
            base.OnLoaded();

            SetValueObjects();
        }

        public virtual IEnumerable<string> ValueObjectNames { get; }

        public virtual void SetValueObjects() { }

        //public bool IsValid => ValueObjects.TrueForAll(o => o.IsValid);
        //public string InvalidReason => string.Join("\r\n", ValueObjects.Select(o => o));

        //public Guid CreatedByOid { get; set; }

        //public DoSoUser2 CreatedBy { get; set; }


        public DSEntityBaseNoUser(Session session) : base(session) { }

        protected override void OnSaving()
        {
            base.OnSaving();

            SetValueObjects();

            OnSavingEvent?.Invoke((T)this);

            //CreatedBy = GetCreatedByGuid();
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            SetValueObjects();

            OnChangedEvent?.Invoke((T)this, propertyName, oldValue, newValue);
        }
    }

    //[Persistent("public.SecuritySystemUser")]
    //public class DoSoUser2 : DSEntityBaseNoUser<DoSoUser2, Guid>
    //{
    //    public DoSoUser2(Session session) : base(session) { }

    //    public string UserName { get; set; }
    //}
}