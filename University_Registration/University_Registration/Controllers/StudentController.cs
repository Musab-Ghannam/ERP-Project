using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using University_Registration.Models;

namespace University_Registration.Controllers
{
   
    public class StudentController : Controller
    {
        ERP_SystemEntities university = new ERP_SystemEntities();
        // GET: Student
     
        public ActionResult StudentDashBoard()

           
        {
           


            var courses = university.Subjects.Where(c=>c.Major_ID==2).ToList();
            var info = university.SubjectRegistrations.Where(c => c.Student_ID == 5).ToList();
            ViewBag.STUDENTID = 5;
            return View(Tuple.Create(courses, info));
        }
        public ActionResult table()
        {
            return View();
        }

        public ActionResult sections()
        { Subject sub1 = new Subject();
            
            var courses = university.Subjects.Where(c => c.Major_ID == 2).ToList();
            //var sub = university.Majors.Where(c => c.Major_ID == sub1.Major_ID);
            var section = university.Sections.Where(c => c.Subject.Major_ID==2  ).ToList();
            return View(Tuple.Create(section, courses));
        }
        
        public ActionResult Add(int ADD)
        {
            SubjectRegistration subject = new SubjectRegistration();
            int studID = 5;
            int subjectID =Convert.ToInt32(university.Sections.Find(ADD).Subject_ID);
            string day =university.Sections.Find(ADD).SectionDay;

            int sectionTime = Convert.ToInt32(university.Sections.Find(ADD).SectionTime);
            var sss = university.SubjectRegistrations.Find(ADD);
            bool f = true;
            if (ModelState.IsValid)
            {
                foreach (var x in university.SubjectRegistrations.ToList())
                {
                  
                    if (studID == x.Student_ID && subjectID == x.Subject_ID)
                    {
                        

                        f = false;
                      
                        break;
                    }
                    else if (studID == x.Student_ID && sectionTime == x.Section.SectionTime && day== x.Section.SectionDay)
                    {
                       
                        Console.WriteLine("Hello, world22!");
                        f = false;
                        break;
                    }
                }

                if (f == true) { 
                subject.PaymentStatus = true;
                subject.Subject_ID = subjectID;
                subject.Student_ID = studID;
                subject.Section_ID = ADD;
                university.SubjectRegistrations.Add(subject);
                university.SaveChanges();
                }

                return RedirectToAction("StudentDashBoard");

            }
            return View(subject);


        }

        public ActionResult del(int ID)
        {
            if (ID != null)
            {
                SubjectRegistration registration = university.SubjectRegistrations.Find(ID);
                university.SubjectRegistrations.Remove(registration);
                university.SaveChanges();
                return RedirectToAction("StudentDashBoard");
            }
            return RedirectToAction("StudentDashBoard");

        }


        public PartialViewResult _Oprofileuser()
        {
            var info = university.Students.Where(c => c.Major_ID == 2).ToList();
            return PartialView("_Oprofileuser", info);
        }
    }
}