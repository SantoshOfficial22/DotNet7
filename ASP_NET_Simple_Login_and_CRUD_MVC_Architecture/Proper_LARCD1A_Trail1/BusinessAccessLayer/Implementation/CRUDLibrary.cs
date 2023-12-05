using BusinessAccessLayer.Abstract;
using DataAccessLayer.Entity_DB;
using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Implementation
{
    public class CRUDLibrary: ICRUDLibrary
    {
        private PracticeEntities db = new PracticeEntities();
        public bool AddBookRecord(CRUDLibraryModel cRUDLibraryModel)
        {
            Trail1CRUDLibrary trail1CRUDLibrary = new Trail1CRUDLibrary
            {
                BookName = cRUDLibraryModel.BookName,
                BookCode = cRUDLibraryModel.BookCode,
                Summary = cRUDLibraryModel.Summary,
            };                
            db.Trail1CRUDLibrary.Add(trail1CRUDLibrary);
            db.SaveChanges();
            return true;
        }      

        public List<CRUDLibraryModel> GetListLibrary()
        {
            List<Trail1CRUDLibrary> EntityList = db.Trail1CRUDLibrary.ToList();
            List<CRUDLibraryModel> ModelList = new List<CRUDLibraryModel>();
            foreach (var _EL in EntityList)
            {
                CRUDLibraryModel _LM = new CRUDLibraryModel
                {
                    Id = _EL.Id,
                    BookName = _EL.BookName,
                    BookCode = _EL.BookCode,
                    Summary = _EL.Summary,
                    
                };
                ModelList.Add(_LM);
            }
            return ModelList;
        }
        public CRUDLibraryModel EditLibRecordView(int id)
        {
            var LibEdit = db.Trail1CRUDLibrary.Where(x => x.Id == id).FirstOrDefault();
            CRUDLibraryModel MLibData = new CRUDLibraryModel
            {
                Id = LibEdit.Id,
                BookName = LibEdit.BookName,
                BookCode = LibEdit.BookCode,
                Summary = LibEdit.Summary,                
            };
            return MLibData;
        }

        public bool EditLibRecord(CRUDLibraryModel cRUDLibraryModel)
        {
            Trail1CRUDLibrary trail1CRUDLibrary = new Trail1CRUDLibrary
            {
                Id = cRUDLibraryModel.Id,
                BookName = cRUDLibraryModel.BookName,
                BookCode = cRUDLibraryModel.BookCode,
                Summary = cRUDLibraryModel.Summary,
                
            };
            db.Entry(trail1CRUDLibrary).State = EntityState.Modified;
            var result = db.SaveChanges();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CRUDLibraryModel LibDetails(int id)
        {
            var ELibData = db.Trail1CRUDLibrary.Where(x => x.Id == id).FirstOrDefault();
            CRUDLibraryModel MLibData = new CRUDLibraryModel
            {
                Id = ELibData.Id,
                BookName = ELibData.BookName,
                BookCode = ELibData.BookCode,
                Summary = ELibData.Summary,
            };
            return MLibData;
        }

        public bool DeleteLibRecord(int id)
        {
            var DelLib = db.Trail1CRUDLibrary.Where(x => x.Id == id).First();
            db.Trail1CRUDLibrary.Remove(DelLib);
            var Result = db.SaveChanges();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int FindOrSearch(String Search_)
        {           

            var Temp = (from userlist in db.Trail1CRUDLibrary
                      where userlist.BookName == Search_ || userlist.BookCode == Search_
                      select userlist.Id).FirstOrDefault();
            int Result = Temp;

            return Result;
            
        }
    }
}
