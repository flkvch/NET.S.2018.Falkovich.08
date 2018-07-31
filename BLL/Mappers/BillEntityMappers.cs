using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        //public static AccountHolder ToAccBll(this AccountHolderDTO userEntity)
        //{
        //    //return new AccountHolder()
        //    //{
        //        //TO DO
        //    //};
        //}

        public static BankAccountDTO ToAccDTO(this BankAccount dalAcc)
        {
            return new BankAccountDTO()
            {
                Id = dalAcc.Id,
                Status = dalAcc.Status,
                BonusPoints = dalAcc.BonusPoints,
                Person = dalAcc.Person
            };
        }

    }
}
