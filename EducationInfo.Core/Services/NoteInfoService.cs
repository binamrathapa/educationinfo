using EducationInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationInfo.Core.Services
{
    public class NoteInfoService : INoteInfoService
    {        
        private readonly IUnitOfWork uow;

        public NoteInfoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        #region Web Methods

        public NoteInfo GetById(int? Id)
        {
            return uow.Repository<NoteInfo>().GetById(Id);
        }
        public Task<IEnumerable<NoteInfo>> GetAll()
        {
            return uow.Repository<NoteInfo>().Query().Include(c => c.Course).GetAsync();//GetAll();
        }

        public IEnumerable<NoteInfo> Get(Func<NoteInfo, bool> predicate = null)
        {
            return uow.Repository<NoteInfo>().GetBy(predicate);
        }

        public NoteInfo Add(NoteInfo noteInfo)
        {
            uow.Repository<NoteInfo>().Add(noteInfo);            
            return noteInfo;
        }

        public NoteInfo Update(NoteInfo noteInfo)
        {
            uow.Repository<NoteInfo>().Update(noteInfo);
            return noteInfo;
        }

        public void Delete(int Id)
        {
            uow.Repository<NoteInfo>().Delete(Id);
        }

        #endregion
        
    }
}
