using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static List<TraineeDetails> traineeDetails = new TraineeData().GetTraineeDetails();
        public static void Main(string[] args)
        {
            Console.WriteLine("\n================== Performing all LINQ operations ==================\n");
            
            Console.WriteLine("Press 1 to Show the list of Trainee Id\nPress 2 to Show the first 3 Trainee Id using Take\nPress 3 to show the last 2 Trainee Id using Skip\nPress 4 to show the count of Trainee\nPress 5 to show the Trainee Name who are all passed out 2019 or later\nPress 6 to show the Trainee Id and Trainee Name by alphabetic order of the trainee name.\nPress 7 to show the Trainee Id, Trainee Name, Topic Name, Exercise Name and Mark who are all scores the more than or equal to 4 mark\nPress 8 to show the unique passed out year using distinct\nPress 9 to show the total marks of single user (get the Trainee Id from User), if Trainee Id does not exist, show the invalid message\nPress 10 to show the first Trainee Id and Trainee Name\nPress 11 to show the last Trainee Id and Trainee Name\nPress 12 to print the total score of each trainee\nPress 13 to show the maximum total score\nPress 14 to show the minimum total score\nPress 15 to show the average of total score\nPress 16 to show true or false if any one has the more than 40 score using any()\nPress 17 to show true of false if all of them has the more than 20 using all()\nPress 18 to show the Trainee Id, Trainee Name, Topic Name, Exercise Name and Mark by show the Trainee Name as descending order and then show the Mark as descending order.");

            Console.Write("\nPlease Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                {
                    Console.WriteLine("\nList of Trainee Ids");
                    traineeDetails.ForEach(t => Console.WriteLine(t.TraineeId));
                    Console.WriteLine();
                    break;
                }
                case "2":
                {
                    Console.WriteLine("\nFirst 3 Trainee Ids");
                    traineeDetails.Take(3).ToList().ForEach(t => Console.WriteLine(t.TraineeId));
                    Console.WriteLine();
                    break;
                }
                case "3":
                {
                    Console.WriteLine("\nLast 2 Trainee Ids");
                    traineeDetails.Skip(3).ToList().ForEach(t => Console.WriteLine(t.TraineeId));
                    Console.WriteLine();
                    break;
                }
                case "4":
                {
                    Console.WriteLine("\nNumber of trainees: " + traineeDetails.Count + "\n");
                    break;
                }
                case "5":
                {
                    Console.WriteLine("\nTrainee Name who are all passed out 2019 or later");
                    traineeDetails.Where(t => t.YearPassedOut >= 2019).ToList().ForEach(t => Console.WriteLine(t.TraineeName));
                    Console.WriteLine();
                    break;
                }
                case "6":
                {
                    Console.WriteLine("\nTrainee Id and Trainee Name by alphabetic order of the trainee name");
                    traineeDetails.OrderBy(t => t.TraineeName).ToList().ForEach(t => Console.WriteLine("Trainee ID: " + t.TraineeId + ", Trainee Name: " + t.TraineeName));
                    Console.WriteLine();
                    break;
                }
                case "7":
                {
                    Console.WriteLine("\nTrainee Id, Trainee Name, Topic Name, Exercise Name and Mark who are all scores the more than or equal to 4 mark");
                    traineeDetails.ForEach(t => t.ScoreDetails.Where(score => score.Mark >= 4).ToList().ForEach(score => Console.WriteLine($"Trainee ID: {t.TraineeId}, TraineeName: {t.TraineeName}, Topic Name: {score.TopicName}, Exercise name: {score.ExerciseName}, Mark: {score.Mark}")));
                    Console.WriteLine();
                    break;
                }
                case "8":
                {
                    Console.WriteLine("\nUnique passed out year ");
                    List<int> year = new List<int>();
                    traineeDetails.ForEach(t => year.Add(t.YearPassedOut));
                    year.Distinct().ToList().ForEach(t => Console.WriteLine(t));
                    Console.WriteLine();
                    break;
                }
                case "9":
                {
                    Console.WriteLine("\nTotal marks of a single trainee");
                    Console.Write("Enter trainee ID: ");
                    var enteredTraineeId = Console.ReadLine().Trim().ToUpper();
                    TraineeDetails trainee = null;
                    traineeDetails.ForEach(t => {
                        if (t.TraineeId == enteredTraineeId)
                        {
                            trainee = t;
                        }
                    });
                    if (trainee != null)
                    {
                        var totalMark = 0;
                        trainee.ScoreDetails.ForEach(s => totalMark += s.Mark);
                        Console.WriteLine("Total mark is: " + totalMark + "\n");
                    } 
                    else {
                        Console.WriteLine("\nInvalid Trainee ID\n");
                    }
                    break;
                }
                case "10":
                {
                    Console.WriteLine("\nFirst Trainee Id and Trainee Name");
                    var trainee = traineeDetails.First();
                    Console.WriteLine("\nTrainee ID: " + trainee.TraineeId + ", Trainee Name: " + trainee.TraineeName + "\n");
                    break;
                }
                case "11":
                {
                    Console.WriteLine("\nLast Trainee Id and Trainee Name");
                    var trainee = traineeDetails.Last();
                    Console.WriteLine("\nTrainee ID: " + trainee.TraineeId + ", Trainee Name: " + trainee.TraineeName + "\n");
                    break;
                }
                case "12":
                {
                    Console.WriteLine("\nTotal score of each trainee");
                    traineeDetails.ForEach(t => {
                        var totalMark = 0;
                        t.ScoreDetails.ForEach(s => {
                            totalMark += s.Mark;
                        });
                        Console.WriteLine("Trainee Name: " + t.TraineeName + ", Total Mark: " + totalMark);
                    });
                    Console.WriteLine();
                    break;
                }
                case "13":
                {
                    Console.WriteLine("\nMaximum total score");
                    var maxMark = int.MinValue;
                    TraineeDetails trainee = traineeDetails.First();
                    traineeDetails.ForEach(t => {
                        var totalMark = 0;
                        t.ScoreDetails.ForEach(s => {
                            totalMark += s.Mark;
                        });
                        if (totalMark > maxMark)
                        {
                            maxMark = totalMark;
                            trainee = t;
                        }
                    });
                    Console.WriteLine("\nTrainee Name: " + trainee.TraineeName + ", Total Mark: " + maxMark +"\n");
                    break;
                }
                case "14":
                {
                    Console.WriteLine("\nMaximum total score");
                    var maxMark = int.MaxValue;
                    TraineeDetails trainee = traineeDetails.First();
                    traineeDetails.ForEach(t => {
                        var totalMark = 0;
                        t.ScoreDetails.ForEach(s => {
                            totalMark += s.Mark;
                            Console.WriteLine(totalMark);
                        });
                        Console.WriteLine(totalMark + " < " + maxMark + " = " + (totalMark < maxMark));
                        if (totalMark < maxMark)
                        {
                            maxMark = totalMark;
                            trainee = t;
                        }
                    });
                    Console.WriteLine("\nTrainee Name: " + trainee.TraineeName + ", Total Mark: " + maxMark +"\n");
                    break;
                }
                case "15":
                {
                    var totalMark = 0;
                    traineeDetails.ForEach(t => {
                        t.ScoreDetails.ForEach(s => {
                            totalMark += s.Mark;
                        });
                    });
                    Console.WriteLine("\nAverage of total score is: " + totalMark / (double) traineeDetails.Count + "\n");
                    break;
                }
                case "16":
                {
                    List<int> totalMarkList = new List<int>();
                    traineeDetails.ForEach(t => {
                        var totalMark = 0;
                        t.ScoreDetails.ForEach(s => {
                            totalMark += s.Mark;
                        });
                        totalMarkList.Add(totalMark);
                    });
                    Console.WriteLine("\nAny one has more than 40 totalScore: " + totalMarkList.Any(mark => mark >= 40));
                    break;
                }
                case "17":
                {
                    List<int> totalMarkList = new List<int>();
                    traineeDetails.ForEach(t => {
                        var totalMark = 0;
                        t.ScoreDetails.ForEach(s => {
                            totalMark += s.Mark;
                        });
                        totalMarkList.Add(totalMark);
                    });
                    Console.WriteLine("\nAll of them has more than 20 totalScore: " + totalMarkList.All(mark => mark >= 20));
                    break;
                }
                case "18":
                {
                    Console.WriteLine("\nTrainee Id, Trainee Name, Topic Name, Exercise Name and Mark by show the Trainee Name as descending order and then show the Mark as descending order");
                    traineeDetails.OrderByDescending(t => t.TraineeName).ToList().ForEach(t => {
                        Console.WriteLine($"\nTrainee ID: {t.TraineeId}  Trainee Name: {t.TraineeName}  ");
                        t.ScoreDetails.OrderByDescending(s => s.Mark).ToList().ForEach(s => Console.WriteLine($"\tTopic Name: {s.TopicName}  Exercize Name: {s.ExerciseName}  Mark: {s.Mark}"));
                    });
                    Console.WriteLine();
                    break;
                }
                default:
                {
                    Console.WriteLine("\nInvalid Input\n");
                    break;
                }
            }
        }
    }
}
