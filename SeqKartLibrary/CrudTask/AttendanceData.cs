using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using SeqKartLibrary.Models;
using SeqKartLibrary.Repository;

namespace SeqKartLibrary.CrudTask
{
    public class AttendanceData
    {

        public string InsertUpdate(AttendanceModel attendanceModel, string AddEditTag)
        {
            RepGen reposGen = new RepGen();
            DynamicParameters param = new DynamicParameters();

            param.Add("@serial_id", attendanceModel.serial_id);
            param.Add("@attendance_date", attendanceModel.attendance_date);
            param.Add("@employee_code", attendanceModel.employee_code);
            param.Add("@status_id", attendanceModel.status_id);
            param.Add("@attendance_in", attendanceModel.attendance_in);
            param.Add("@attendance_out", attendanceModel.attendance_out);
            param.Add("@shift_id", attendanceModel.shift_id);
            param.Add("@attendance_source", attendanceModel.attendance_source);
            param.Add("@gate_pass_time", attendanceModel.gate_pass_time);
            param.Add("@ot_deducton_time", attendanceModel.ot_deducton_time);            
            param.Add("@AddEditTag", AddEditTag);

            return reposGen.executeNonQuery("sp_EmployeeAttendance", param);
        }

        public List<AttendanceStatus> GetAllAttendanceStatus()
        {
            //SEQKARTNewEntities db = new SEQKARTNewEntities();
            //List<AttendanceStatu> attendanceStatu_List = db.AttendanceStatus.OrderBy(s => s.status_id).ToList();

            RepList<AttendanceStatus> lista = new RepList<AttendanceStatus>();
            DynamicParameters param = new DynamicParameters();
            return lista.returnListClass("SELECT * FROM AttendanceStatus", param);

        }
        public List<DailyShift> GetAllDailyShifts()
        {
            RepList<DailyShift> lista = new RepList<DailyShift>();
            DynamicParameters param = new DynamicParameters();
            return lista.returnListClass("SELECT * FROM DailyShifts", param);

        }
    }
}