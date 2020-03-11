using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Linq;

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
            if (subjectRepository != null)
                subjectRepository.Dispose();
        }
    }
}