using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Delus.Components
{
    partial class Agent
    {
        public double? asdas
        {
            get
            {
                double cost = this.ProductSale.Sum(x => x.ProductCount);
                return cost;
            }
        }
        public double? sunnn
        {
            get
            {
                double cost = this.ProductSale.Sum(x => x.ProductCount);
                double cin = (double)this.ProductSale.Sum(x => x.Product.MinCostForAgent);
                double sum = cost * cin;
                return sum;
            }
        }
        public string proc
        {
            get
            {
                string color;
                double cost = this.ProductSale.Sum(x => x.ProductCount);
                double cin = (double)this.ProductSale.Sum(x => x.Product.MinCostForAgent);
                double sum = cost * cin;
                if (sum >= 0 && sum <= 10000)
                {
                    color = "0%";
                    return $"скидка составляет {color}";
                }
                else if (sum > 10000 && sum <= 50000)
                {
                    color = "5%";
                    return $"скидка составляет {color}";
                }
                else if (sum > 50000 && sum <= 150000)
                {
                    color = "10%";
                    return $"скидка составляет {color}";
                }
                else if (sum > 150000 && sum <= 500000)
                {
                    color = "20%";
                    return $"скидка составляет {color}";
                }
                else if (sum > 500000)
                {
                    color = "25%";
                    return $"скидка составляет {color}";
                }
                else return "";
            }
        }
        public string Color
        {

            get
            {
                double cost = this.ProductSale.Sum(x => x.ProductCount);
                double cin = (double)this.ProductSale.Sum(x => x.Product.MinCostForAgent);
                double sum = cost * cin;
                if (sum > 150000 && sum <= 500000)
                {
                    return "#91E668";
                }

                else
                {
                     return "#FDFDFD";
                }
                   

            }
        }

        //public  string? bancmadc 
        // {
        //     get
        //     {
        //         if (Logo == null)
        //         {

        //             return Logo;
        //         }
        //         else return Logo;
        //     }
        // }
    }
}
