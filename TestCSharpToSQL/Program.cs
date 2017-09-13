using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CSharpToSQL;

namespace TestCSharpToSQL {
	class Program {
		static void Main(string[] args) {
			new Program().Run();
		}

		void Run() {
			//This string sets up the Server, Database, and whether this is considered to be
			//trusted connection or not.
			string connStr = @"Server=STUDENT05;Database=DotNetDatabase;Trusted_Connection=yes";
			SqlConnection connection = new SqlConnection(connStr);
			connection.Open();
			if (connection.State != System.Data.ConnectionState.Open) {
				Console.WriteLine("SQL Connection did not open.");
				return;
			}
			//The command that we have used to show everything on the Student table, that 
			//we will be using here in C#.
			var sql = "select * from Student";
			//When the connection is open, we want to know that.
			Console.WriteLine("SQL connection opened successfully.");
			
			//When setting up a command, what is it, and where is it going?
			//("select * from Student", and @"Server=STUDENT05;Database=DotNetDatabase;Trusted_Connection=yes")
			SqlCommand cmd = new SqlCommand(sql, connection);
			SqlDataReader reader = cmd.ExecuteReader();


			List<Student> students = new List<Student>();
			
			//The condition in the while loop, reader.Read(), returns true, so long as there are
			//additional rows in the table.
			//This particular loop reads the Id (primary key), FirstName, LastName, Address, City,
			//State, and Birthday fields for the row that it is currently looking at.  That information
			//is then printed to the Console.
			while (reader.Read()) {
				//reader.GetOrdinal() allows us to not need to know which column # a column uses, so long
				//as we know what the column is called.
				var id = reader.GetInt32(reader.GetOrdinal("Id")); //This uses an int, so we need to GetInt32
				var firstname = reader.GetString(reader.GetOrdinal("FirstName")); //Uses string, so GetString
				var lastname = reader.GetString(reader.GetOrdinal("LastName"));
				var address = reader.GetString(reader.GetOrdinal("Address"));
				var city = reader.GetString(reader.GetOrdinal("City"));
				var state = reader.GetString(reader.GetOrdinal("State"));
				var zipcode = reader.GetString(reader.GetOrdinal("Zipcode"));
				var phone = reader.GetString(reader.GetOrdinal("PhoneNumber"));
				var email = reader.GetString(reader.GetOrdinal("Email"));
				var birthday = reader.GetDateTime(reader.GetOrdinal("Birthday")); //Time to GetDateTime
				
				//We need to initiall set majorid to 0 here, because in the SQL table that this code pulls from,
				//majorid is allowed to be null.  It represents which field of study a student has selected,
				//so if a major has yet to be declared, this will be null.  Not good to have in C#, so the second
				//thing that we do is to check if the Value is not null, as designated by the ! at the front
				//of the condition below.  So long as it does have a value, we can set majorid to the int in
				//that field.
				var majorid = 0;
				if (!reader.GetValue(reader.GetOrdinal("MajorId")).Equals(DBNull.Value)){
					majorid = reader.GetInt32(reader.GetOrdinal("MajorId"));
				}

				var sat = reader.GetInt32(reader.GetOrdinal("SAT"));
				var gpa = reader.GetDouble(reader.GetOrdinal("GPA"));
				Console.WriteLine("");
				Console.WriteLine($"{id}:{firstname} {lastname} lives at {address}, {city}, {state} {zipcode}.");
				Console.WriteLine($"Their birthday is {birthday}.");
				Console.WriteLine($"{firstname}'s phone # is {phone}, and their email is {email}.");
				Console.WriteLine($"Their SAT score is {sat}, GPA is {gpa}, and major is {majorid}.");

				Student student = new Student();
				//During the first build of this Program, the below items were some variation of 
				//student.Get***, which was the relevant method in the Student class.  Because the
				//properties of the student class are "public" in this build, we are able to directly
				//say that student.*** = "whatever we want"
				student.id = id;
				student.firstname = firstname;
				student.lastname = lastname;
				student.address = address;
				student.city = city;
				student.state = state;
				student.zipcode = zipcode;
				student.birthday = birthday;
				student.phone = phone;
				student.email = email;
				student.majorid = majorid;
				student.sat = sat;
				student.gpa = gpa;

				//Now that the student class has been used to set the data, the student is ready to be
				//added to the "students" list.
				students.Add(student);
			}
			Console.WriteLine("");

			//Close the connection when finished!
			reader.Close();
			connection.Close();
			Console.WriteLine("SQL connection and reader closed.");
		}
	}
}
