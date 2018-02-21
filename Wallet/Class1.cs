using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyLib;

namespace Wallet
{
    public class Class1
    {
        private MyWallet _MyWallet;
    }

    class MyWallet
    {
        private List<CirculatingMoney> _myMoney;

        public Money MyMoney
        {
            get
            {
                if (_myMoney.Count == 0)
                {
                    return null;
                }
                decimal tempTotal = 0;

                foreach (CirculatingMoney m in _myMoney)
                {
                    tempTotal += m.Value;
                }

                return new Money(_myMoney[0].Currency, tempTotal);
            }
        }

        public MyWallet()
        {
            _myMoney = new List<CirculatingMoney>();
        }

        public void AddMoney(CirculatingMoney newMoney)
        {
            _myMoney.Add(newMoney);
        }

        public void ThrowawayMoney(CirculatingMoney newMoney)
        {
            foreach (CirculatingMoney m in _myMoney)
            {
                if (m.GetType() == newMoney.GetType())
                {
                    _myMoney.Remove(m);
                    break;
                }


            }
        }

        public List<CirculatingMoney> GetMoney(decimal amount)
        {
            if (_myMoney.Count == 0)
            {
                return null;
            }

            List<CirculatingMoney> tempMoney = new List<CirculatingMoney>();

            decimal tempTotal = 0;
            _myMoney.Sort();
            _myMoney.Reverse();
            foreach (CirculatingMoney m in _myMoney)
            {
                if (m.Value > amount - tempTotal)
                {
                    tempMoney.Add(m);
                    tempTotal += m.Value;
                    Console.WriteLine("Added {0} to tempMoney", m.GetType());
                }
            }

            if (tempTotal == amount)
            {
                foreach (CirculatingMoney m in tempMoney)
                {
                    _myMoney.Remove(m);
                }

                return tempMoney;
            }
            else
            {
                tempMoney.Clear();
                return tempMoney;
            }
        }

    }
}
