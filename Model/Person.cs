using Haszownie.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haszownie.Model
{
    public class Person : IHashValue
    {
		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _surname;

		public string Surname
		{
			get { return _surname; }
			set { _surname = value; }
		}

		private int _age;

		public int Age
		{
			get { return _age; }
			set { _age = value; }
		}

		public string GetHashValue()
		{
			return Name;
		}
	}
}
