using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using PolicyNormal.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyNormal.Module.Controllers
{
    public class PolicyValidationController : ObjectViewController<DetailView, Policy>
    {
        public PolicyValidationController()
        {
            var validateAction = new SimpleAction(this, "ValidateAction", PredefinedCategory.ObjectsCreation);
            validateAction.Execute += ValidateActionOnExecute;
        }

        private void ValidateActionOnExecute(object sender, SimpleActionExecuteEventArgs e)
        {
            ViewCurrentObject.ValidateAction();
        }
    }
}
