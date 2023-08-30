using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technical_Task_1_Review.Models;

namespace Technical_Task_1_Review.Controllers
{
    public class HomeController : Controller
    {
        DataLayer db = new DataLayer();
        public ActionResult Index()
        {
            SqlParameter[] sqls = new SqlParameter[]
            {
                new SqlParameter("@action",3)
            };
            DataTable dt = db.GetTables("sp_student", sqls);
            ViewBag.teacher = dt;
           
            return View();
        }
       [HttpPost]
       public ActionResult index(StudentModel st)
        {
            SqlParameter[] parameters;
            if (st.id==0)
            {
                
            parameters = new SqlParameter[]
               {
                new SqlParameter("@action",1),
                new SqlParameter("@FirstName",st.fname),
                new SqlParameter("@LastName",st.lname),
                new SqlParameter("@DateOfBirth",st.dob),
                new SqlParameter("@Gender",st.gender),
                new SqlParameter("@TeacherId",st.teacher)

               };




            var r = db.ExecutedbQuery("sp_student", parameters);
            //int a = db.ExecutedbQuery("sp_student", parameters);
                if (r > 0)
                 {
                return Json("Data Inserted", JsonRequestBehavior.AllowGet);
                }
                else
                {

                return Json("Data not Inserted", JsonRequestBehavior.AllowGet);
                }


            }else
            {
                parameters = new SqlParameter[]
               {
                new SqlParameter("@action",5),
                new SqlParameter("@Id",st.id),
                new SqlParameter("@FirstName",st.fname),
                new SqlParameter("@LastName",st.lname),
                new SqlParameter("@DateOfBirth",st.dob),
                new SqlParameter("@Gender",st.gender),
                new SqlParameter("@TeacherId",st.teacher)

               };




                var r = db.ExecutedbQuery("sp_student", parameters);
                //int a = db.ExecutedbQuery("sp_student", parameters);
                if (r > 0)
                {
                    return Json("Data Updated", JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json("Data is not Updated", JsonRequestBehavior.AllowGet);
                }
            }


            //return Json("Data Inserted Successfully",JsonRequestBehavior.AllowGet);
        }

        public ActionResult gettable()
        {
            SqlParameter[] sqls1 = new SqlParameter[]
          {
                new SqlParameter("@action",2)
          };
            DataTable data = db.GetTables("sp_student", sqls1);
            ViewBag.data = data;
            List<StudentModel> list = new List<StudentModel>();

            foreach (DataRow item in data.Rows)
            {
                list.Add(new StudentModel()
                {
                    id = Convert.ToInt32(item["Id"]),
                    fname = Convert.ToString(item["StudentName"]),
                    dob = Convert.ToString(item["DateOfBirth"]),
                   // dob = Convert.ToDateTime(item["DateOfBirth"]),
                    gender = Convert.ToString(item["Gender"]),
                    lname = Convert.ToString(item["TeacherName"])

                });
                
            }

            return Json(list,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult delete1(int id)
        {
            
            SqlParameter[] parameter = new SqlParameter[] {
            new SqlParameter("@action",4),
            new SqlParameter("@id",id)            
            };

            var r = db.ExecutedbQuery("sp_student", parameter);
            //int a = db.ExecutedbQuery("sp_student", parameters);
            if (r > 0)
            {
                return Json("Data is Deleted", JsonRequestBehavior.AllowGet);
            }
            else
            {

                return Json("Data  is not deleted", JsonRequestBehavior.AllowGet);
            }



            //return Json("Data deleted successfully",JsonRequestBehavior.AllowGet);
        }

        public ActionResult editdata(int id)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@action",6),
                new SqlParameter("@Id",id)
            };
            DataTable dt = db.GetTables("sp_student", parameter);

            List<StudentModel> list1 = new List<StudentModel>();
            

            foreach (DataRow item in dt.Rows)
            {
                list1.Add(new StudentModel()
                {
                    id = Convert.ToInt32(item["Id"]),
                    teacher = Convert.ToInt32(item["TeacherId"]),
                    fname = Convert.ToString(item["FirstName"]),
                    lname = Convert.ToString(item["LastName"]),
                    dob = Convert.ToString(item["DateOfBirth"]),
                    //dob = Convert.ToDateTime(item["DateOfBirth"]),
                    //dob = DateTime.Parse(item["DateOfBirth"]),
                    

                    gender = Convert.ToString(item["Gender"]),

                });

            }

            return Json(list1, JsonRequestBehavior.AllowGet);
        }
    }
}