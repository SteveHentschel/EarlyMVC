Working thru the tutorial "Getting Started with EF5 using MVC4, Creating an Entity Framework Data Model" by
Tom Dykstra on MS' asp.net site.


Jan 24, Rev 1.7 - Finished Part 9 (Repository) today; should have done more, but got busy on other things.  
Created Repo interface and Repo class for the Student entity; with I/F, could potentially do unit test.
Created REpo classes for Course and Department entities, but no interface due to tutorial length.  slh

Jan 23, Rev 1.6 - Part 8, Inheritance today.  Created Person class and made Students/Instructors inherited via
TPH methodology (Table per Heirarchy) with discriminator to keep things 'DRY'.  slh

Jan 22, Rev 1.5 - What else, finished part 7.  Implemented concurrency exception checking in the Department tab.
Added the code for Edit and Delete functions, tested with 2 open tabs during edit/delete processes, nice.  slh

Jan 21, Rev 1.4 - Worked on Part 6 today.  Mainly CRUD update and view stuff for Instructor and Courses.
Did good stuff with DropDownLists for Departments and CheckBox grids for Courses using HashSets.  slh

Jan 20, Rev 1.3 - Did Section 5 today. Excellent study on lazy/eager/explicit loading of nav properties.
I spent a lot of time trying to replace the generic 'Selected Instructor' & 'Course' with the specific names.
Finally used ViewBag for Course and some view code for the Professor.  Learned a little.  slh

Jan 18, Rev 1.2 - Only Section 4 today, but learned a lot.  Great info on updating/creating data models and
how they inter-relate.  Dykstra does a great job of explaining the relationships (ie: 1:1, 1:many) and their 
associated keys.  slh

Jan 17, Rev 1.1 - Sections 2 and 3 today.  This tutorial is very comprehensive, covers a lot of topics. 
Learned more about ViewModels in Sect 3, will have to try again with those in FunWithDBs.  slh

Jan 16, Rev 1.0 - Just did section 1 of 10 today.  Had to start over as I inadvertently created the project with 
.NET 4.0 instead of 4.5 or 4.5.1, and the IEnumerable Grade in Enrollments was not being written to the DB.  Fun.  slh