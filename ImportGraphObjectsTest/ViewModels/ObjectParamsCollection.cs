using ImportGraphObjectsTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportGraphObjectsTest.ViewModels
{
    public class ObjectParamsCollection : ObservableCollection<ObjectParams>
    {
        public ObjectParamsCollection() { }

        public ObjectParamsCollection(ObjectModelVM objectModel)
        {
            objectModel.PropertyChanged += (model, e) =>
            {
                Update(model as ObjectModelVM);
            };
            Update(objectModel);
        }

        private void Update(ObjectModelVM objectModel)
        {
            Clear();
            Add(new ObjectParams(nameof(objectModel.Name), objectModel.Name));
            Add(new ObjectParams(nameof(objectModel.Distance), objectModel.Distance.ToString()));
            Add(new ObjectParams(nameof(objectModel.Angle), objectModel.Angle.ToString()));
            Add(new ObjectParams(nameof(objectModel.Width), objectModel.Width.ToString()));
            Add(new ObjectParams(nameof(objectModel.Hegth), objectModel.Hegth.ToString()));
            Add(new ObjectParams(nameof(objectModel.IsDefect), objectModel.IsDefect ? "yes" : "no"));
        }

    }
}
