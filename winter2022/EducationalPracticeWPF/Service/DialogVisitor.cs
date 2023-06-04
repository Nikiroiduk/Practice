using EducationalPracticeBL.Model;
using EducationalPracticeWPF.View;

namespace EducationalPracticeWPF.Service
{
    class DialogVisitor
    {
        public object DynamicVisit(object data) => Visit((dynamic)data);

        private ElectricityGeneration Visit(ElectricityGeneration a)
        {
            AddNewRecord win = new();
            win.DataContext = a;
            if ((bool)win.ShowDialog())
                return a;
            return null;
        }
    }
}
