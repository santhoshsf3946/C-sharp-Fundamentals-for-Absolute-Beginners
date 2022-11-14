using System;
using System.Collections.Generic;
using System.Linq;
namespace AppointmentSystem;

class Program
{
    static Patient currentPatient;

    public static void Main(string[] args)
    {
        Console.WriteLine("\n================= Doctor, Patient - Appointment System =================");

        SampleDetails();    

        MainMenu();
    }

    public static void MainMenu()
    {
        string choice;
        do
        {
            Console.WriteLine("\nMain Menu\n---------");
            Console.WriteLine("\t1. Login\n\t2. Register\n\t3. Exit");

            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                {
                    Login();
                    break;
                }
                case "2":
                {
                    PatientRegistration();
                    break;
                }
                case "3":
                {
                    Console.WriteLine("\nExitting...\n");
                    break;
                }
                default:
                {
                    Console.WriteLine("\nInvalid Choice\n");
                    break;
                }
            }
        } while (choice != "3");
    }

    public static void PatientRegistration()
    {
        Console.WriteLine("\nPatient registration\n--------------------");

        string name;
        do
        {
            Console.Write("\nEnter your Name: ");
            name = Console.ReadLine().Trim();

            if (name.Length == 0)
            {
                Console.WriteLine("Name should not be empty");
            }
        } while (name.Length == 0);

        string password;
        do
        {
            Console.Write("Enter Password: ");
            password = Console.ReadLine().Trim();

            if (password.Length < 8)
            {
                Console.WriteLine("Password length must be greater than or equal to 8");
            }
        } while (password.Length < 8);
        
        int age;
        bool ageIsValid = false;
        do
        {
            Console.Write("Enter Age: ");
            ageIsValid = int.TryParse(Console.ReadLine().Trim(), out age);

            if (age < 1 || !ageIsValid)
            {
                Console.WriteLine("Enter a valid Age");
            }
        } while (age < 1 || !ageIsValid);

        Gender gender;
        bool genderIsValid = false;
        do
        {
            Console.Write("Enter Gender: ");
            genderIsValid = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);

            if (!genderIsValid)
            {
                Console.WriteLine("Enter a valid Gender");
            }
        } while (!genderIsValid);

        AppointmentManager.PatientList.Add(new Patient(name, password, age, gender));

        Console.WriteLine("\nPatient registered successfully !");
    }

    public static void Login()
    {
        Console.WriteLine("\nPatient Login\n-------------");

        Console.Write("\nEnter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        currentPatient = AppointmentManager.PatientList.FirstOrDefault(p => p.Name == name && p.Password == password);

        if (currentPatient != null)
        {
            Console.WriteLine($"\nLogged in successfully !\t Welcome {currentPatient.Name}");
            SubMenu();
        }
        else
        {
            Console.WriteLine("\nSorry, your record is invalid. Please register your profile and log in again.");
        }
    }

    public static void SubMenu()
    {
        string choice;
        do
        {
            Console.WriteLine("\nSub Menu\n---------");
            Console.WriteLine("\t1. Book Appointment\n\t2. View Appointment details\n\t3. Edit My Profile\n\t4. Logout");

            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                {
                    BookAppointment();
                    break;
                }
                case "2":
                {
                    ViewAppointmentdetails();
                    break;
                }
                case "3":
                {
                    EditProfile();
                    break;
                }
                case "4":
                {
                    Console.WriteLine("\nLogged out successfully !");
                    break;
                }
                default:
                {
                    Console.WriteLine("\nInvalid Choice");
                    break;
                }
            }
        } while (choice != "4");
    }

    public static void BookAppointment()
    {
        Console.WriteLine("\nBook Appointment\n----------------\n");

        Console.WriteLine("Select the department from the below List:");
        
        AppointmentManager.DoctorList.ForEach(d => Console.WriteLine("\t" + d.DoctorID + ". " + d.Department));

        Console.Write("\nEnter Department ID to chose: ");
        
        int selectedDepartmentDoctorID;

        Doctor selectedDoctor;
        
        if (int.TryParse(Console.ReadLine(), out selectedDepartmentDoctorID))
        {
            selectedDoctor = AppointmentManager.DoctorList.FirstOrDefault(d => d.DoctorID == selectedDepartmentDoctorID);

            if (AppointmentManager.AppointmentList.Where(a => a.DoctorID == selectedDoctor.DoctorID).ToList().Count < 2)
            {
                if (selectedDoctor != null)
                {
                    Console.Write("Enter your problem: ");
                    Appointment newAppointment = new Appointment(selectedDoctor.DoctorID, currentPatient.PatientID, DateTime.Now, Console.ReadLine());

                    Console.Write($"\nAppointment is confirmed for the date - {newAppointment.Date.ToString("MM/dd/yyyy")}. To book press “Y”, to cancel press “N”");

                    ConsoleKeyInfo keyChar = Console.ReadKey(true);
                    if (keyChar.KeyChar == 'Y' || keyChar.KeyChar == 'y')
                    {
                        AppointmentManager.AppointmentList.Add(newAppointment);
                        Console.WriteLine("\n\nAppointment booked successfully !");
                    }
                    else
                    {
                        Console.WriteLine("\n\nAppointment cancelled");
                    }
                }
                else
                {
                    Console.WriteLine("\nDepartment ID not found");
                }
            }
            else
            {
                Console.WriteLine("\nAppointment list is full. Try again later");
            }
        }
        else
        {
            Console.WriteLine("\nInavlid Deaprtment ID");
        }
    }

    public static void ViewAppointmentdetails()
    {
        Console.WriteLine("\nAppointment Details\n-------------------");
        List<Appointment> currentPatientAppointmentList = AppointmentManager.AppointmentList.Where(a => a.PatientID == currentPatient.PatientID).ToList();
        if (currentPatientAppointmentList.Count != 0)
        {
            Console.WriteLine("Appointment ID\tDoctor ID\tPatient ID\tDate\t\tProblem");
            currentPatientAppointmentList.ForEach(a => {
                Console.WriteLine($"{a.AppointmentID}\t\t{a.DoctorID}\t\t{a.PatientID}\t\t{a.Date.ToString("MM/dd/yyyy")}\t{a.Problem}");
            }); 
        }
        else
        {
            Console.WriteLine("\nAppointment list empty");
        }
    }

    public static void EditProfile()
    {
        Console.WriteLine("\nEdit My Profile\n---------------");

        Console.WriteLine("Select one of below option to edit: ");
        Console.WriteLine("\t1. Name\n\t2. Password\n\t3. Age\n\t4. Gender");
        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
            {
                
                string name;
                do
                {
                    Console.Write("\nEnter new Name: ");
                    name = Console.ReadLine().Trim();

                    if (name.Length == 0)
                    {
                        Console.WriteLine("Name should not be empty");
                    }
                    else
                    {
                        currentPatient.Name = name;
                        Console.WriteLine("\nName changed successfully !");
                    }
                } while (name.Length == 0);
                break;
            }
            case "2":
            {
                string password;
                do
                {
                    Console.Write("\nEnter new Password: ");
                    password = Console.ReadLine().Trim();

                    if (password.Length < 8)
                    {
                        Console.WriteLine("Password length must be greater than or equal to 8");
                    }
                    else
                    {
                        currentPatient.Password = password;
                        Console.WriteLine("\nPassword changed successfully !");
                    }
                } while (password.Length < 8);
                break;
            }
            case "3":
            {
                int age;
                bool ageIsValid = false;
                do
                {
                    Console.Write("\nEnter Age: ");
                    ageIsValid = int.TryParse(Console.ReadLine().Trim(), out age);

                    if (age < 1 || !ageIsValid)
                    {
                        Console.WriteLine("Enter a valid Age");
                    }
                    else
                    {
                        currentPatient.Age = age;
                        Console.WriteLine("\nAge changed successfully !");
                    }
                } while (age < 1 || !ageIsValid);
                break;
            }
            case "4":
            {
                Gender gender;
                bool genderIsValid = false;
                do
                {
                    Console.Write("\nEnter Gender: ");
                    genderIsValid = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);

                    if (!genderIsValid)
                    {
                        Console.WriteLine("Enter a valid Gender");
                    }
                    else
                    {
                        currentPatient.Gender = gender;
                        Console.WriteLine("\nGender changed successfully !");
                    }
                } while (!genderIsValid);
                break;
            }
            default:
            {
                Console.WriteLine("\nInvalid Choice\n");
                break;
            }
        }
    }

    public static void SampleDetails()
    {
        SampleDoctorDetails();
        SamplePatientDetails();
        SampleAppointmentData();
    }

    public static void SampleDoctorDetails()
    {
        AppointmentManager.DoctorList.Add(new Doctor("Nancy", "Anaesthesiology"));
        AppointmentManager.DoctorList.Add(new Doctor("Andrew", "Cardiology"));
        AppointmentManager.DoctorList.Add(new Doctor("Janet", "Diabetology"));
        AppointmentManager.DoctorList.Add(new Doctor("Margaret", "Neonatology"));
        AppointmentManager.DoctorList.Add(new Doctor("Steven", "Nephrology"));
    }

    public static void SamplePatientDetails()
    {
        AppointmentManager.PatientList.Add(new Patient("Robert", "welcome", 40, Gender.Male));
        AppointmentManager.PatientList.Add(new Patient("Laura", "welcome", 36, Gender.Female));
        AppointmentManager.PatientList.Add(new Patient("Anne", "welcome", 42, Gender.Female));
    }

    public static void SampleAppointmentData()
    {
        AppointmentManager.AppointmentList.Add(new Appointment(1, 2, new DateTime(2012, 8, 3), "Heart problem"));
        AppointmentManager.AppointmentList.Add(new Appointment(1, 3, new DateTime(2012, 8, 3), "Spinal cord injury"));
        AppointmentManager.AppointmentList.Add(new Appointment(2, 2, new DateTime(2012, 8, 3), "Heart attack"));
    }
}
