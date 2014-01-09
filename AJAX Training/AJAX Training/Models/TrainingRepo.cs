using AJAX_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AJAX_Training.Models
{
        public class TrainingRepo : ITrainingRepo
        {
            private List<Training> allTrainings;
            private XDocument trainingData;

            public TrainingRepo()
            {
                allTrainings = new List<Training>();
                trainingData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Trainings.xml"));

                var trainings = from t in trainingData.Descendants("item")
                                select new Training(
                                    (int)t.Element("id"),
                                    t.Element("name").Value,
                                t.Element("instructor").Value,
                                (DateTime)t.Element("startDate"),
                                (DateTime)t.Element("endDate"),
                              (string)t.Element("time"),
                                (string)t.Element("duration"));
                allTrainings.AddRange(trainings.ToList<Training>());
            }

            public IEnumerable<Training> GetTrainings()
            {
                return allTrainings;
            }

            public Training GetTrainingByID(int id)
            {
                return allTrainings.Find(t => t.ID == id);
            }

            public void InsertTraining(Training training)
            {
                //Descendants method is used to get a collection of a particular child elements from a XML file. 

                training.ID = (int)(from b in trainingData.Descendants("item") orderby (int)b.Element("id") descending select (int)b.Element("id")).FirstOrDefault() + 1;

                trainingData.Root.Add(new XElement("item", new XElement("id", training.ID),
                    new XElement("name", training.Name),
                    new XElement("instructor", training.Instructor),
                    new XElement("startDate", training.StartDate.Date.ToShortDateString()),
                    new XElement("endDate", training.EndDate.Date.ToShortDateString()),
                    new XElement("time", training.Time),
                    new XElement("duration", training.Duration)));

                trainingData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Trainings.xml"));
            }

            public void DeleteTraining(int id)
            {
                trainingData.Root.Elements("item").Where(i => (int)i.Element("id") == id).Remove();

                trainingData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Trainings.xml"));
            }

            public void EditTraining(Training training)
            {
                XElement node = trainingData.Root.Elements("item").Where(i => (int)i.Element("id") == training.ID).FirstOrDefault();

                node.SetElementValue("name", training.Name);
                node.SetElementValue("instructor", training.Instructor);
                node.SetElementValue("startDate", training.StartDate.ToShortDateString());
                node.SetElementValue("endDate", training.EndDate.ToShortDateString());
                node.SetElementValue("time", training.Time);
                node.SetElementValue("duration", training.Duration);

                trainingData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Trainings.xml"));
            }

            public List<string> GetInstructor()
            {
                var mainItems = (from key in trainingData.Descendants("instructor") select key.Value).Distinct().ToList();
                return mainItems.ToList();
            }
        }
}