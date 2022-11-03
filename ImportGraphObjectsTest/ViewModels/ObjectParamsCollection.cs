using ImportGraphObjectsTest.Models;
using System.Collections.ObjectModel;

namespace ImportGraphObjectsTest.ViewModels
{
    public class ObjectParamsCollection : ObservableCollection<ObjectParams>
    {
        public ObjectParamsCollection() { }

        public ObjectParamsCollection(ObjectModelVM objectModel)
        {
            if (objectModel == null)
                return;

            objectModel.PropertyChanged += (model, e) =>
            {
                Update(model as ObjectModelVM);
            };
            Update(objectModel);
        }

        private void Update(ObjectModelVM objectModel)
        {
            if (objectModel == null)
                return;

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
