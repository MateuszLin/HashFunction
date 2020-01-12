using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haszownie
{
    public struct KeyAndValue
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
    
    public class Hash
    {

        private int size = 113;
        private LinkedList<KeyAndValue>[] items;

        public Hash(int size)
        {
            this.size = size;
            items = new LinkedList<KeyAndValue>[size];

        }


        public int HashFunction(string s)
        {
            int total = 0;
            var charrArray = s.ToCharArray();

            for (int i = 0; i < charrArray.Length; i++)
            {
                total += (int)charrArray[i] * i + 1;
            }

            return total % size;
        }

        public void Add(string value)
        {
            int position = HashFunction(value);
            LinkedList<KeyAndValue> listLinked = GetLinkedList(position);
            KeyAndValue newItem = new KeyAndValue() { Key = position, Value = value };
            listLinked.AddLast(newItem);
        }

        public string Find (string value)
        {
            int position = HashFunction(value);
            LinkedList<KeyAndValue> linkedList = GetLinkedList(position);

            foreach (var item in linkedList)
            {
                if(item.Key.Equals(position))
                {
                    return item.Value;
                }
            }

            return string.Empty;
        }

        public void Remove(string value)
        {
            int position = HashFunction(value);

            var linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyAndValue foundItem = default;

            foreach (var item in linkedList)
            {
                if(item.Key.Equals(position))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if(itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        private LinkedList<KeyAndValue> GetLinkedList(int position)
        {
            LinkedList<KeyAndValue> linkedList = items[position];

            if(linkedList == null)
            {
                linkedList = new LinkedList<KeyAndValue>();
                items[position] = linkedList;
            }

            return linkedList;
        }
    }
}
