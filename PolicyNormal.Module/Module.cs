using DAL.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using PolicyNormal.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using DSXafDisplayNameAttribute = DAL.BusinessObjects.DSXafDisplayNameAttribute;

namespace PolicyNormal.Module
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class PolicyNormalModule : ModuleBase {
        public PolicyNormalModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
            AdditionalExportedTypes.AddRange(ModuleHelper.CollectExportedTypesFromAssembly(typeof(Human).Assembly, t => !t.ContainsGenericParameters));

        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);

            var dsDefaultClassOptionsTypes =
                typesInfo.PersistentTypes.Where(t => t.Attributes.Any(a => a.GetType().Name.StartsWith("DS")));

            foreach (var dsDefaultClassOptionsType in dsDefaultClassOptionsTypes)
            {
                dsDefaultClassOptionsType.AddAttribute(new DefaultClassOptionsAttribute());

                var dataSourcePropertyAttributeMembers =
                    dsDefaultClassOptionsType.Members.Where(m =>
                        m.Attributes.Any(a => a is DSDataSourcePropertyAttribute));

                foreach (var dataSourcePropertyAttributeMember in dataSourcePropertyAttributeMembers)
                {
                    var dsPropertyAttributePropertyName = dataSourcePropertyAttributeMember
                        .FindAttribute<DSDataSourcePropertyAttribute>().PropertyName;

                    dataSourcePropertyAttributeMember.AddAttribute(new DataSourcePropertyAttribute(dsPropertyAttributePropertyName));
                }

                var immediatePostDataAttributeMembers = 
                    dsDefaultClassOptionsType.Members.Where(m =>
                        m.Attributes.Any(a => a is DSImmediatePostDataAttribute));

                foreach (var immediatePostDataAttributeMember in immediatePostDataAttributeMembers)
                {
                    immediatePostDataAttributeMember.AddAttribute(new ImmediatePostDataAttribute());
                }

                var xafDisplayNameAttributeMembers =
                    dsDefaultClassOptionsType.Members.Where(m => m.Attributes.Any(a => a is DSXafDisplayNameAttribute));


                foreach (var xafDisplayNameAttributeMember in xafDisplayNameAttributeMembers)
                {
                    var xafDisplayNamePropertyDisplayName = xafDisplayNameAttributeMember
                        .FindAttribute<DSXafDisplayNameAttribute>().DisplayName;

                    xafDisplayNameAttributeMember.AddAttribute(
                        new XafDisplayNameAttribute(xafDisplayNamePropertyDisplayName));
                }

                var dsActionAttributeMembers =
                    dsDefaultClassOptionsType.Members.Where(m => m.Attributes.Any(a => a is ActionAttribute));

                foreach (var dsActionAttributeMember in dsActionAttributeMembers)
                {
                    dsActionAttributeMember.AddAttribute(new ActionAttribute());
                }
            }

           

        }
    }
}
