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

            param.Add("@attendance_date", attendanceModel.attendance_date);
            param.Add("@employee_code", attendanceModel.employee_code);
            param.Add("@attendance_status", attendanceModel.attendance_status);
            param.Add("@attendance_in", attendanceModel.attendance_in);
            param.Add("@attendance_out", attendanceModel.attendance_out);
            param.Add("@duty_shift", attendanceModel.duty_shift);
            param.Add("@gate_pass_time", attendanceModel.gate_pass_time);
            param.Add("@deducton_time", attendanceModel.deducton_time);
            param.Add("@night_duty_hours", attendanceModel.night_duty_hours);
            param.Add("@AddEditTag", AddEditTag);

            return reposGen.executeNonQuery("sp_EmployeeAttendance", param);
        }
    }
}