using Business.DTOs.Course;
using Business.Services.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Services.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }
        public void Add(CourseAddDto courseDto)
        {

            Course course = new Course();


            course.InstructorId = courseDto.InstructorId;
            course.CategoryId = courseDto.CategoryId;
            course.Name = courseDto.Name;
            course.Description = courseDto.Description;
            course.Price = courseDto.Price;

            _courseDal.Add(course);

        }
        public void Delete(int courseId)
        {
            var deletedCourse = _courseDal.Get(c => c.Id.Equals(courseId));
            _courseDal.Delete(deletedCourse);
        }

        public CourseGetDto Get(int courseId)
        {

            CourseGetDto course = new CourseGetDto();
            var hasCourse = _courseDal.Get(c => c.Id.Equals(courseId));
            course.Id = hasCourse.Id;
            course.CategoryId = hasCourse.CategoryId;
            course.Name = hasCourse.Name;
            course.Description = hasCourse.Description;
            course.Price = hasCourse.Price;
            course.InstructorId = hasCourse.InstructorId;
            return course;
        }

        public List<CourseGetListDto> GetList()
        {

            var hasCourse = _courseDal.GetList();
            List<CourseGetListDto> courses = new List<CourseGetListDto>();

            foreach (var course in hasCourse)
            {
                CourseGetListDto courseGetListDto = new CourseGetListDto();
                courseGetListDto.Id = course.Id;
                courseGetListDto.InstructorId = course.InstructorId;
                courseGetListDto.CategoryId = course.CategoryId;
                courseGetListDto.Description = course.Description;
                courseGetListDto.Name = course.Name;
                courseGetListDto.Price = course.Price;

                courses.Add(courseGetListDto);
            }
            return courses;
        }

        public void Update(CourseUpdateDto course)
        {

            var hasCourse = _courseDal.Get(c => c.Id.Equals(course.Id));
            hasCourse.Name = course.Name;
            hasCourse.Description = course.Discription;
            hasCourse.Price = course.Price;
            hasCourse.Id = course.Id;
            hasCourse.InstructorId = course.InstructorId;
            hasCourse.CategoryId = course.CategoryId;

            _courseDal.Update(hasCourse);

        }
    }
}
