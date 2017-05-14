using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2_4
{
    class LibraryCards
    {
        public const int size = 8;
        CardAccountAdvanced[] library = new CardAccountAdvanced[size];

        public CardAccountAdvanced this[int index]
        {
            get
            {
                return (CardAccountAdvanced)library[index];
            }
            set
            {
                library[index] = value;
            }
        }

        public void setLibraryArray()
        {
            for(int i = 0; i < size; i++)
            {
                library[i] = new CardAccountAdvanced("Фамилия" + (i + 1), "Имя" + (i + 1), new Date(i * size % 28, (i + size) % 12, 2000 + i % 3),
                    new Date(29, 3, 2017), Education.IncompleteHigher, false);
            }
        }
        public void showLibraryArray()
        {
            CardAccount.topForDisplay();
            for(int i = 0; i < size; i++)
            {
                library[i].displayFields();
            }
        }
        public static explicit operator LibraryCards(CardAccountAdvanced v)
        {
            throw new NotImplementedException();
        }
    }
}
