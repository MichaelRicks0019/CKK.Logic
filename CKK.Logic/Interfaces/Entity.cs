using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        private int id;
        public string Name { get; set; }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id < 0)
                {
                    throw new InvalidIdException($"Id must be more than 0");
                }
                else
                {
                    id = value;
                }
            }
        }

        public int SetId(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException($"Id must be more than 0");
            }
            this.id = id;
            return id;
        }
    }
}
