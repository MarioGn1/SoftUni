using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    class UserAndCardsDTO
    {
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")]
        public string FullName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Range(3, 103)]
        public int Age { get; set; }

        public List<CardInputDTO> Cards { get; set; }
    }

    public class CardInputDTO
    {
        [Required]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]
        public string Number { get; set; }
        [Required]
        [RegularExpression("[0-9]{3}")]
        public string CVC { get; set; }
        [Required]
        [EnumDataType(typeof(CardType))]
        public string Type { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Username – text with length [3, 20] (required)
//•	FullName – text, which has two words, consisting of Latin letters. Both start with an upper letter and are followed by lower letters. The two words are separated by a single space (ex. "John Smith") (required)
//•	Email – text(required)
//•	Age – integer in the range[3, 103] (required)
//•	Cards – collection of type Card

//•	Id – integer, Primary Key
//•	Number – text, which consists of 4 pairs of 4 digits, separated by spaces (ex. “1234 5678 9012 3456”) (required)
//•	Cvc – text, which consists of 3 digits (ex. “123”) (required)
//•	Type – enumeration of type CardType, with possible values (“Debit”, “Credit”) (required)
//•	UserId – integer, foreign key(required)
//•	User – the card’s user (required)
//•	Purchases – collection of type Purchase

//{
//    "FullName": "Lorrie Silbert",
//    "Username": "lsilbert",
//    "Email": "lsilbert@yahoo.com",
//    "Age": 33,
//    "Cards": [
//      {
//        "Number": "1833 5024 0553 6211",
//        "CVC": "903",
//        "Type": "Debit"
//      },
//      {
//        "Number": "5625 0434 5999 6254",
//        "CVC": "570",
//        "Type": "Credit"
//      },
//      {
//        "Number": "4902 6975 5076 5316",
//        "CVC": "091",
//        "Type": "Debit"
//      }
//    ]
//  },

