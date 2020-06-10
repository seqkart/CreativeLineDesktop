using SeqKartLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeqKartLibrary.Interfaces
{
    public interface IFrmTransaction
    {
        List<ChallanOutMain_Model> GetChallanOutMain_List();//Read
    }
}
