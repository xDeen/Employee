using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.DataLibrary;
using Employee.DataLibrary.Models;

namespace Employee.Extension
{
    public static class Handler
    {
        private const string EmployeeKey = "Employee";
        private const string EmployeeTypeKey = "EmployeeType";
        private const string EmployeeAttendanceKey = "EmployeeAttendance";

        public static List<EmployeeData> GetEmployees(this ISession session)
        {
            return session.GetObjectFromJson<List<EmployeeData>>(EmployeeKey) ?? new List<EmployeeData>();
        }
        public static List<EmployeeType> GetEmployeeTypes(this ISession session)
        {
            return session.GetObjectFromJson<List<EmployeeType>>(EmployeeTypeKey) ?? new List<EmployeeType>();
        }

        public static List<EmployeeAttendance> GetEmployeeAttendance(this ISession session)
        {
            return session.GetObjectFromJson<List<EmployeeAttendance>>(EmployeeAttendanceKey) ?? new List<EmployeeAttendance>();
        }

        public static void SaveEmployee(this ISession session, List<EmployeeData> list)
        {
            session.SetObjectAsJson(EmployeeKey, list);
        }
        public static void SaveEmployeeType(this ISession session, List<EmployeeType> list)
        {
            session.SetObjectAsJson(EmployeeTypeKey, list);
        }
        public static void SaveEmployeeAttendance(this ISession session, List<EmployeeAttendance> list)
        {
            session.SetObjectAsJson(EmployeeAttendanceKey, list);
        }
    }
}
