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

		private string _pesel;

		public string Pesel
		{
			get { return _pesel; }
			set { _pesel = value; }
		}


		public string GetHashValue()
		{
			return Pesel;
		}

		public string GetContent()
		{
			if(string.IsNullOrWhiteSpace(Pesel))
			{
				return "EMPTY";
			}

			return $"Name: {Name}, Surname: {Surname}, Pesel: {Pesel}";
		}
	}
}
