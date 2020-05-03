using InTheHand.Net.Sockets;
using Microsoft.AspNet.Identity;
using NetBluSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetBluSchool.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        public TeacherController()
        {
        }

        public TeacherController(ApplicationDbContext _ctx)
        {
            this._ctx = _ctx;
        }
        public ActionResult Index()
        {
            var lessonList = _ctx.Lessons.ToList();
            ViewData["lessonList"] = lessonList;
            return View(lessonList);
        }
        public ActionResult CreateLesson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateLesson(string lessonName_frm_input, string ClassRoom, string Department, string Degree, int Credit, int StudentCount)
        {
            var userId = User.Identity.GetUserId();
            var newLesson = new LessonModel();
            newLesson.ClassRoom = ClassRoom;
            newLesson.Credit = Credit;
            newLesson.Degree = Degree;
            newLesson.Department = Department;
            newLesson.LessonName = lessonName_frm_input;
            newLesson.StudentCount = StudentCount;
            newLesson.TeacherId = userId;
            _ctx.Lessons.Add(newLesson);
            _ctx.SaveChanges();
            return RedirectToAction("Index"); //ders ekledikten sonra index'e yönlendir
        }

        public ActionResult DeleteLesson(int id)
        {
            var delete_lesson = new LessonModel();
            delete_lesson.Id = id;
            _ctx.Lessons.Attach(delete_lesson);
            _ctx.Lessons.Remove(delete_lesson);
            _ctx.SaveChanges();
            return RedirectToAction("Index"); //ders silindikten sonra index'e yönlendir.
        }
        public ActionResult UpdateLesson(int id)
        {
            //ID ALIYORUM
            var updatedLesson = _ctx.Lessons.Where(x => x.Id == id).FirstOrDefault();
            //veritabanindan buldum simdi onu html e gonderecegim
            return View(updatedLesson);
        }


        [HttpPost]
        public ActionResult UpdateLesson(int id, string lessonName_frm_input, string ClassRoom, string Department, string Degree, int Credit, int StudentCount)
        {

            var update_lesson = new LessonModel();
            update_lesson = _ctx.Lessons.Where(x => x.Id == id).FirstOrDefault();
            update_lesson.LessonName = lessonName_frm_input;
            update_lesson.ClassRoom = ClassRoom;
            update_lesson.Department = Department;
            update_lesson.Degree = Degree;
            update_lesson.Credit = Credit;
            update_lesson.StudentCount = StudentCount;
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SearchStudent()
        {
            BluethoothSearchView newDeviceObj = new BluethoothSearchView();
            newDeviceObj.BluList = new List<BluethoothDevice>();
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevicesInRange();
            int i = 1;
            foreach (BluetoothDeviceInfo d in devices)
            {
                BluethoothDevice newDevice = new BluethoothDevice();
                newDevice.Id = i;
                newDevice.Name = d.DeviceName;
                newDeviceObj.BluList.Add(newDevice);
                i += 1;
            }
            ViewData["items"] = newDeviceObj.BluList;
            return View(newDeviceObj);
        }

    }
}
