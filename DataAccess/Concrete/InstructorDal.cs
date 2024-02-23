﻿using Core.DataAccess.Repositories.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class InstructorDal : EntityRepositoryBase<Instructor, AppDbContext>, IInstructorDal
    {

    }
}
