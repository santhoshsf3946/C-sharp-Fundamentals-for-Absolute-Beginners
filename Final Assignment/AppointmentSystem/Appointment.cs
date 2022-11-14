using System;

namespace AppointmentSystem
{
    public class Appointment
    {
        private static int s_appointmentID = 1;

        public int AppointmentID { get; set; }
        
        public int DoctorID { get; set; }
        
        public int PatientID { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Problem { get; set; }
        
        public Appointment(int doctorID, int patientID, DateTime date, string problem) 
        {
            AppointmentID = s_appointmentID++;
            DoctorID = doctorID;
            PatientID = patientID;
            Date = date;
            Problem = problem;
        }
    }
}