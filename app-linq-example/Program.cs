using System.Runtime.Intrinsics.Arm;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityManager um = new UniversityManager();
            um.MaleStudents();
            um.FemaleStudents();
            um.SortStudentsByAge();
            um.AllStudentsFromBeilingTect();
            um.StudentAndUniversityCollection();

            int[] someInts = {30, 12, 4, 3, 12};
            IEnumerable<int> sortedInts = from i in someInts orderby i select i; // 3,4,12,12,30
            IEnumerable<int> reversedInts = sortedInts.Reverse(); // 30,12,12,4,3

            // sort and reverse in one line
            IEnumerable<int> reversedSortedInts = from i in someInts orderby i descending select i; // 30,12,12,4,3

            // we enter a integer and displays all students from that university id
            string input = Console.ReadLine();

            try
            {
                int inputAsInt = Convert.ToInt32(input);
                um.AllStudentsFromThatUni(inputAsInt);   
            }
            catch (System.Exception)
            {
                Console.WriteLine("Wrong value");
            }
        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University {Id = 1, Name = "Yale"});
            universities.Add(new University {Id = 2, Name = "Beijing Tech"});

            students.Add(new Student {Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1});
            students.Add(new Student {Id = 2, Name = "Toni", Gender = "male", Age = 21, UniversityId = 1});
            students.Add(new Student {Id = 3, Name = "Frank", Gender = "male", Age = 22, UniversityId = 2});
            students.Add(new Student {Id = 4, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2});
            students.Add(new Student {Id = 5, Name = "James", Gender = "trans-gender", Age = 25, UniversityId = 2});
            students.Add(new Student {Id = 6, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2});
        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = 
                from student in students where student.Gender == "male" select student;
            Console.WriteLine("Male student: ");
            foreach (Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = 
                from student in students where student.Gender == "female" select student;
            Console.WriteLine("Female student: ");
            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }

        public void SortStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age select student;
            Console.WriteLine("Students sorted by Age: ");
            foreach (Student student in sortedStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromBeilingTect()
        {
           IEnumerable<Student> bjtStudents = from student in students
                                              join university in universities 
                                              on student.UniversityId equals university.Id
                                              where university.Name == "Beijing Tech"
                                              select student; 
            Console.WriteLine("Students from Beijing Tech: ");
            foreach (Student student in bjtStudents)
            {
                student.Print();
            }
        } 

        public void AllStudentsFromThatUni(int Id)
        {
           IEnumerable<Student> myStudents = from student in students
                                              join university in universities 
                                              on student.UniversityId equals university.Id
                                              where university.Id == Id
                                              select student; 
            Console.WriteLine("Students from uni {0}", Id);
            foreach (Student student in myStudents)
            {
                student.Print();
            }
        } 

        // creates new collection from two others collections
        public void StudentAndUniversityCollection()
        {
            var newCollection = from student in students
                                join university in universities
                                on student.UniversityId equals university.Id 
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };
            Console.WriteLine("New Collection: ");
            foreach (var col in newCollection)
            {
                Console.WriteLine("Student {0} from University {1}", col.StudentName, col.UniversityName);
            }
        }

    }

    class University 
    {
        public int Id {get; set;}
        public string Name {get; set;}

        public void Print() 
        {
            Console.WriteLine("University {0} with id {1}", Name, Id);
        }
    }

    class Student 
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Gender {get; set;}
        public int Age {get; set;}

        // Foreign key
        public int UniversityId {get; set;}
        public void Print() 
        {
            Console.WriteLine("Student {0} with id {1}, Gender {2} and Age {3} from University with Id {4}",
                 Name, Id, Gender, Age, UniversityId);
        }
    }
}