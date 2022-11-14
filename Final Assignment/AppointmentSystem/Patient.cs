namespace AppointmentSystem
{
    public enum Gender { Unknown, Male, Female }
    public class Patient
    {
        private static int s_patientID = 1;

        public int PatientID { get; set; }
        
        public string Password { get; set; }

        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public Gender Gender { get; set; }
        
        public Patient(string name, string password, int age, Gender gender)
        {
            PatientID = s_patientID++;
            Password = password;
            Name = name;
            Age = age;
            Gender = gender;
        }
    }
}