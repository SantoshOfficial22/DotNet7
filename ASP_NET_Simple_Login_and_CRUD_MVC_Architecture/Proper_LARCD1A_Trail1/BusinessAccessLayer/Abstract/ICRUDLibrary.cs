using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstract
{
    public interface ICRUDLibrary
    {
        bool AddBookRecord(CRUDLibraryModel cRUDLibraryModel);
        List<CRUDLibraryModel> GetListLibrary();
        CRUDLibraryModel EditLibRecordView(int id);
        bool EditLibRecord(CRUDLibraryModel cRUDLibraryModel);
        CRUDLibraryModel LibDetails(int id);
        bool DeleteLibRecord(int id);
        int FindOrSearch(String Search_);

    }
}
