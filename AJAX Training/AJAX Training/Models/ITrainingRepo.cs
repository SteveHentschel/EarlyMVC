using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJAX_Training.Models
{
    public interface ITrainingRepo
    {
        IEnumerable<Training> GetTrainings();
        List<string> GetInstructor();
        Training GetTrainingByID(int id);
        void InsertTraining(Training training);
        void DeleteTraining(int id);
        void EditTraining(Training training);
    }
}