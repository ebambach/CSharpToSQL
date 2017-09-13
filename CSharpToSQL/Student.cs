using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpToSQL {
	public class Student {
		//During the first build of the Student class, all of these properties were set to "private."
		//This meant that the commented out Gets and Sets methods below were needed.  Now... not so much.
		public int id { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string address { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zipcode { get; set; }
		public DateTime birthday { get; set; }
		public string phone { get; set; }
		public string email { get; set; }
		public int majorid { get; set; }
		public int sat { get; set; }
		public double gpa { get; set; }

		//public int GetId() {
		//	return id;
		//}
		//public void SetId(int ID) {
		//	id = ID;
		//}
		//public string GetFirstName() {
		//	return firstname;
		//}
		//public void SetFirstName(string FirstName) {
		//	firstname = FirstName;
		//}
		//public string GetLastName() {
		//	return lastname;
		//}
		//public void SetLastName(string LastName) {
		//	lastname = LastName;
		//}
		//public string GetAddress() {
		//	return address;
		//}
		//public void SetAddress(string Address) {
		//	address = Address;
		//}
		//public string GetCity() {
		//	return city;
		//}
		//public void SetCity(string City) {
		//	city = City;
		//}
		//public string GetState() {
		//	return state;
		//}
		//public void SetState(string State) {
		//	state = State;
		//}
		//public DateTime GetBirthday() {
		//	return birthday;
		//}
		//public void SetBirthday(DateTime Birthday) {
		//	birthday = Birthday;
		//}
	}
}
