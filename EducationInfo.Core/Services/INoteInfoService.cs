using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationInfo.Core.Entities;

namespace EducationInfo.Core.Services
{
    public interface INoteInfoService
    {
        NoteInfo Add(NoteInfo product);
        void Delete(int Id);
        IEnumerable<NoteInfo> Get(Func<NoteInfo, bool> predicate = null);
        Task<IEnumerable<NoteInfo>> GetAll();
        NoteInfo GetById(int? Id);
        NoteInfo Update(NoteInfo product);
    }
}