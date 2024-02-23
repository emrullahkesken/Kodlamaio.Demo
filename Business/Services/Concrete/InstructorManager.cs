using Business.DTOs.Instructor;
using Business.Services.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Services.Concrete
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorDal _instructorDal;
        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public void Add(InstructorAddDto instructorAddDto)
        {
            Instructor instructor = new Instructor();

            instructor.FirstName = instructorAddDto.FirstName;
            instructor.LastName = instructorAddDto.LastName;
            instructor.Birthday = instructorAddDto.BirthDay;
            instructor.CategoryId = instructorAddDto.CategoryId;

            _instructorDal.Add(instructor);
        }

        public void Delete(int instructorId)
        {
            var deletedInstructor = _instructorDal.Get(i => i.Id.Equals(instructorId));

            _instructorDal.Delete(deletedInstructor);
        }
        public InstructorGetDto Get(int instructorId)
        {
            InstructorGetDto instructorGetDto = new InstructorGetDto();

            var hasInstructor = _instructorDal.Get(i => i.Id.Equals(instructorId));

            instructorGetDto.Id = instructorId;
            instructorGetDto.CategoryId = hasInstructor.CategoryId;
            instructorGetDto.FirstName = hasInstructor.FirstName;
            instructorGetDto.LastName = hasInstructor.LastName;

            return instructorGetDto;

        }

        public List<InstructorGetListDto> GetList()
        {
            var hasInstructors = _instructorDal.GetList();
            List<InstructorGetListDto> instructorsDto = new List<InstructorGetListDto>();

            foreach (var item in hasInstructors)
            {
                InstructorGetListDto instructorGetListDto = new InstructorGetListDto();

                instructorGetListDto.Id = item.Id;
                instructorGetListDto.FirstName = item.FirstName;
                instructorGetListDto.LastName = item.LastName;
                instructorGetListDto.BirthDay = item.Birthday;
                instructorGetListDto.CategoryId = item.CategoryId;

                instructorsDto.Add(instructorGetListDto);
            }

            return instructorsDto;

        }

        public void Update(InstructorUpdateDto instructor)
        {
            Instructor hasInstructor = _instructorDal.Get(i => i.Id.Equals(instructor.Id));

            hasInstructor.FirstName = instructor.FirstName;
            hasInstructor.LastName = instructor.LastName;
            hasInstructor.CategoryId = instructor.CategoryId;
            hasInstructor.Birthday = instructor.BirthDay;

            _instructorDal.Update(hasInstructor);

        }
    }
}
