using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Partial_Class
{
    public partial class PersonUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (PersonDataContext context = new PersonDataContext())
            {
                var query = from person in context.GetTable<Person>()
                            select new
                            {
                                person.ID,
                                person.name,
                                person.birthDate,
                                person.Age
                            };
                var content = query.ToList();

                gridPerson.DataSource = content;
                gridPerson.DataBind();
            }
        }
    }
}