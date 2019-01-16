using System;

namespace DAL.BusinessObjects
{

    //Created Attributes => DSAction, DSXafDisplayName;
    public class DSDefaultClassOptionsAttribute : Attribute { }
    public class DSტრუხა : Attribute { }

    public class DSImmediatePostDataAttribute : Attribute { }

    public class DSDataSourcePropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public DSDataSourcePropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }

    public class DSXafDisplayNameAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public DSXafDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }

    public class DSAction : Attribute {}
}