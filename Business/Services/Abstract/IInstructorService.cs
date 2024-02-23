﻿using Business.DTOs.Instructor;

namespace Business.Services.Abstract
{
    public interface IInstructorService
    {
        InstructorGetDto Get(int instructorId);
        List<InstructorGetListDto> GetList();
        void Add(InstructorAddDto instructorAddDto);
        void Update(InstructorUpdateDto instructor);
        void Delete(int instructorId);
    }
}
