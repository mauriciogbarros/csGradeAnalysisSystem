using System;

class Program
{
	public static void Main()
	{
		// Student grades: [student][subject] format
		// Subjects: 0 = Math, 1 = Science, 2 = English, 3 = History, 4 = Art
		int[,] grades =
		{
			{85, 92, 78, 88, 94}, // Student 1: Alice
			{76, 88, 95, 82, 89}, // Student 2: Bob
			{94, 89, 87, 93, 91}, // Student 3: Carol
			{68, 75, 71, 79, 73}, // Student 4: David
			{91, 86, 90, 85, 88}  // Student 5: Emma
		};

		string[] studentNames =
		{
			"Alice",
			"Bob",
			"Carol",
			"David",
			"Emma"
		};

		string[] subjectNames =
		{
			"Math",
			"Science",
			"English",
			"History",
			"Art"
		};

		RunGradeAnalysis(grades, studentNames, subjectNames);
	}

	public static void RunGradeAnalysis
	(
		int[,] grades,
		string[] studentNames,
		string[] subjectNames
	)
	{
		Console.WriteLine("Students Grade Analysis");
		Console.WriteLine("=======================");
		for (int i = 0; i < studentNames.Length; i++)
		{
			Console.Write($"{studentNames[i]} => ");
			Console.Write($"Grade Average: {GetStudentAvg(grades, i):F1}, ");
			Console.Write($"Best: {GetStudentBestSubject(grades, i, subjectNames)}, ");
			Console.Write($"Worst: {GetStudentWorstSubject(grades, i, subjectNames)}");
			Console.Write("\n");
		}
		Console.WriteLine();

		Console.WriteLine("Subjects Grade Analysis");
		Console.WriteLine("=======================");
		for (int j = 0; j < subjectNames.Length; j++)
		{
			Console.Write($"{subjectNames[j]} => ");
			Console.Write($"Average: {GetSubjectAvg(grades, j):F1}, ");
			int i_bestStudent = GetBestStudentInSubject(grades, j);
			Console.Write($"Best: {studentNames[i_bestStudent]}({grades[i_bestStudent, j]}), ");
			int i_worstStudent = GetWorstStudentInSubject(grades, j);
			Console.Write($"Worst: {studentNames[i_worstStudent]}({grades[i_worstStudent, j]})");
			Console.Write("\n");
		}
	}

	public static double GetStudentAvg(int[,] grades, int i_student)
	{
		int sumGrades = 0;
		for (int j = 0; j < grades.GetLength(1); j++)
		{
			sumGrades += grades[i_student, j];
		}
		double avg = (double)sumGrades / grades.GetLength(1);

		return Math.Round(avg, 2);
	}

	public static string GetStudentBestSubject(int[,] grades, int i_student, string[] subjectNames)
	{
		int j_bestGrade = 0;
		for (int j = 1; j < grades.GetLength(1); j++)
		{
			if (grades[i_student, j] > grades[i_student, j_bestGrade])
			{
				j_bestGrade = j;
			}
		}

		return subjectNames[j_bestGrade];
	}

	public static string GetStudentWorstSubject(int[,] grades, int i_student, string[] subjectNames)
	{
		int j_worstGrade = 0;
		for (int j = 1; j < grades.GetLength(1); j++)
		{
			if (grades[i_student, j] < grades[i_student, j_worstGrade])
			{
				j_worstGrade = j;
			}
		}

		return subjectNames[j_worstGrade];
	}

	public static double GetSubjectAvg(int[,] grades, int j_subject)
	{
		int sumGrades = 0;
		for (int i = 0; i < grades.GetLength(0); i++)
		{
			sumGrades += grades[i, j_subject];
		}
		double avg = (double)sumGrades / grades.GetLength(0);
		return Math.Round(avg, 1);
	}

	public static int GetBestStudentInSubject(int[,] grades, int j_subject)
	{
		int i_bestStudent = 0;
		for (int i = 1; i < grades.GetLength(0); i++)
		{
			if (grades[i, j_subject] > grades[i_bestStudent, j_subject])
			{
				i_bestStudent = i;
			}
		}

		return i_bestStudent;
	}

	public static int GetWorstStudentInSubject(int[,] grades, int j_subject)
	{
		int i_worstStudent = 0;
		for (int i = 1; i < grades.GetLength(0); i++)
		{
			if (grades[i, j_subject] < grades[i_worstStudent, j_subject])
			{
				i_worstStudent = i;
			}
		}

		return i_worstStudent;
	}
}
