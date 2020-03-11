using DataAccess.Model;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class SubjectManager : IDisposable
    {
        private SubjectRepository subjectRepository;

        public SubjectManager()
        {
            subjectRepository = new SubjectRepository();
        }

        public IQueryable<Subject> GetAllSubjects()
        {
            return subjectRepository.GetAll();
        }
        public void Dispose()
        {
            if (subjectRepository == null)
            {
                Dispose();
            }
        }
    }
}
