using System;

namespace SeqKartLibrary.Models
{
    public class EmployeeMasterModel
    {
        public int ID { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string EmpDeptCode { get; set; }
        public string EmpDeptCodeSpl { get; set; }
        public string EmpDesgCode { get; set; }
        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public string EmpFHRelationTag { get; set; }
        public string EmpFHName { get; set; }
        public string EmpSex { get; set; }
        public string EmpAge { get; set; }
        public Nullable<System.DateTime> EmpDOJ { get; set; }
        public Nullable<System.DateTime> EmpDOL { get; set; }
        public string EmpShitCode { get; set; }
        public Nullable<double> EmpDutyHours { get; set; }
        public Nullable<double> EmpOTCalHours { get; set; }
        public string EmpPFDTag { get; set; }
        public string EmpFpfDTag { get; set; }
        public string EmpESIDTag { get; set; }
        public string EmpPFno { get; set; }
        public string EmpESIno { get; set; }
        public Nullable<double> EmpBasic { get; set; }
        public Nullable<double> EmpxBasic { get; set; }
        public Nullable<double> EmpHRA { get; set; }
        public Nullable<double> EmpxHRA { get; set; }
        public Nullable<double> EmpConv { get; set; }
        public Nullable<double> EmpxConv { get; set; }
        public Nullable<double> EmpPET { get; set; }
        public Nullable<double> EmpxPET { get; set; }
        public Nullable<double> EmpMscA1 { get; set; }
        public Nullable<double> EmpMscA2 { get; set; }
        public Nullable<double> EmpTDS { get; set; }
        public Nullable<double> EmpMscD1 { get; set; }
        public Nullable<int> EmpESIDespsCd { get; set; }
        public Nullable<System.DateTime> EmpIncDt { get; set; }
        public string EmptTemp { get; set; }
        public string EmpLeft { get; set; }
        public string EmpRemarks { get; set; }
        public string EmpMotherNm { get; set; }
        public string EmpOtherNm { get; set; }
        public string EmpPerAdd1 { get; set; }
        public string EmpPerAdd2 { get; set; }
        public string EmpPerAdd3 { get; set; }
        public string EmpPerAdd4 { get; set; }
        public string EmpPerAdd5 { get; set; }
        public string EmpCCAdd1 { get; set; }
        public string EmpCCAdd2 { get; set; }
        public string EmpCCAdd3 { get; set; }
        public string EmpCCAdd4 { get; set; }
        public string EmpCCAdd5 { get; set; }
        public string EmpPOBVlg { get; set; }
        public string EmpPOBcity { get; set; }
        public string EmpPerState { get; set; }
        public string EmpCCState { get; set; }
        public string EmpPerCountry { get; set; }
        public string EmpCCCountry { get; set; }
        public string EmpPOBCState { get; set; }
        public string EmpPOBCcountry { get; set; }
        public string EmpNationality { get; set; }
        public string EmpEmail { get; set; }
        public string EmpCategory { get; set; }
        public string EmppfdSplTag { get; set; }
        public string EmpRejoinTag { get; set; }
        public Nullable<int> empcodeN { get; set; }
        public Nullable<decimal> EmpBasicH { get; set; }
        public Nullable<decimal> EMPHRAH { get; set; }
        public Nullable<decimal> EmpPFDMaxSal { get; set; }
        public Nullable<System.DateTime> EmpDoB { get; set; }
        public Nullable<decimal> EmpcESIes { get; set; }
        public Nullable<System.DateTime> EmpDoJre { get; set; }
        public string EmpEsiRepTag { get; set; }
        public Nullable<decimal> EmpEsiNumN { get; set; }
        public string EmpELAELLCode { get; set; }
        public Nullable<int> EmpLunchHrs { get; set; }
        public string EmpEmplrCode { get; set; }
        public string EmpAreaLoctCode { get; set; }
        public string EmpSDrqd { get; set; }
        public string EmpSftPatCode { get; set; }
        public Nullable<System.DateTime> EmpSDsdt { get; set; }
        public Nullable<System.DateTime> EmpSDedt { get; set; }
        public string EmpFWSC { get; set; }
        public string EmpWOff { get; set; }
        public string EmpCardNO { get; set; }
        public string EmpDummy { get; set; }
        public Nullable<decimal> EmpNAlw1 { get; set; }
        public Nullable<decimal> EmpNAlw2 { get; set; }
        public Nullable<decimal> EmpNAlw3 { get; set; }
        public Nullable<decimal> EmpNAlw4 { get; set; }
        public string EMPLOC { get; set; }
        public string EmpHighestQlf { get; set; }
        public string EmpPOI { get; set; }
        public string EmpPanNo { get; set; }
        public string EmpPassportNo { get; set; }
        public string EmpRefernce { get; set; }
        public string EmpMWGrade { get; set; }
        public string EmpDeptN { get; set; }
        public Nullable<decimal> EmpCHstlAlw { get; set; }
        public Nullable<decimal> EmpProDevAlw { get; set; }
        public Nullable<decimal> EmpNewsPapAlw { get; set; }
        public Nullable<decimal> EmpMedAlw { get; set; }
        public Nullable<decimal> EmpUnformAlw { get; set; }
        public Nullable<decimal> EmpSplAlw { get; set; }
        public Nullable<decimal> EmpLTCalw { get; set; }
        public string EmpReligion { get; set; }
        public string EmpMaritalStatus { get; set; }
        public string EmpPymtMode { get; set; }
        public string EmpBankIFSCode { get; set; }
        public string EmpBankAcNo { get; set; }
        public string EmpBankName { get; set; }
        public string EmpNominee { get; set; }
        public string EmpNomineeRelation { get; set; }
        public Nullable<System.DateTime> EmpNomineeDOB { get; set; }
        public string EmpAdharCardNo { get; set; }
        public Nullable<decimal> EmpCEduAlw { get; set; }
        public Nullable<decimal> EmpGHISDed { get; set; }
        public string EmpAddress1 { get; set; }
        public string EmpAddress2 { get; set; }
        public string EmpAddress3 { get; set; }
        public string EmpDistCity { get; set; }
        public string EmpState { get; set; }
        public string EmpCountry { get; set; }
        public Nullable<decimal> EmpGrossPay { get; set; }
        public string EmpUANNo { get; set; }
        public string EmpPartyCode { get; set; }
        public string EmpBankBranchCode { get; set; }
        public Nullable<System.DateTime> SuncDate { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public Nullable<System.TimeSpan> TimeInFirst { get; set; }
        public Nullable<System.TimeSpan> TimeOutFirst { get; set; }
        public Nullable<System.TimeSpan> TimeInLast { get; set; }
        public Nullable<System.TimeSpan> TimeOutLast { get; set; }

        public int WorkingHours { get; set; }

        public byte[] EmpImage { get; set; }
        /////////////////////
        public string CatgCode { get; set; }
        public string CatgDesc { get; set; }

        public string DeptCode { get; set; }
        public string DeptDesc { get; set; }

        public string DesgCode { get; set; }
        public string DesgDesc { get; set; }

        public bool DailyWage { get; set; }
        public Nullable<decimal> DailyWageRate { get; set; }
        public Nullable<int> DailyWageMinutes { get; set; }

        public int LunchBreak { get; set; }

        public int TeaBreak { get; set; }
        public Nullable<int> TeaBreakTime { get; set; }
        public int OT_Extra { get; set; }
    }
}