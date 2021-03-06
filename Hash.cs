﻿using Haszownie.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haszownie
{
    public class KeyAndValue
    {
        public int Key { get; set; }
        public object Value { get; set; }
    }
    
    public class Hash
    {

        private int size = 113;
        private LinkedList<KeyAndValue>[] items;

        public LinkedList<KeyAndValue>[] Items
        {
            get => items;
        }

        public Hash(int size)
        {
            this.size = size;
            items = new LinkedList<KeyAndValue>[size];

        }

        public int HashFunction(IHashValue s)
        {
            return HashFunction(s.GetHashValue());
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

        public int Add(object value)
        {
            int position = HashFunction(value as IHashValue);
            LinkedList<KeyAndValue> listLinked = GetLinkedList(position);
            KeyAndValue newItem = new KeyAndValue() { Key = position, Value = value };
            listLinked.AddLast(newItem);

            return position;
        }

        public object Find (string value)
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

        public int? FindAndReturnPosition(string value)
        {
            int position = HashFunction(value);
            LinkedList<KeyAndValue> linkedList = GetLinkedList(position);

            foreach (var item in linkedList)
            {
                if (item.Key.Equals(position))
                {
                    return position;
                }
            }

            return null;
        }

        public int? Remove(string value)
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
                return position;
            }

            return null;
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
