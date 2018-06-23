using EducationInfo.Core;
namespace EducationInfo.Core.Services
{
    public abstract class Service
    {
        public IUnitOfWork UnitOfWork;

        protected Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}