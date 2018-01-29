using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


/* 
The following is a list of changes I would like to make to this class
-lot to include annotations on sets of rolls (create a log entry struct and have the log as a list of that)





*/

namespace Dicebag
{

    public class Dicebag
    {

        /// <summary>
        /// This is a log of all sets of rolls made  by the bag
        /// </summary>
        List<List<int>> log = new List<List<int>>();

        /// <summary>
        /// rollBuild creates a string built by the dice roller, for situations where the string is not already built
        /// in the form of ndm where n is number of dice and m is number of sides
        /// </summary>
        /// <param name="sides">sides on the die</param>
        /// <param name="dice">number of dice</param>
        /// <returns>string</returns>
        public string rollBuild(int sides, int dice=1) {
            return dice + "d" + sides;
        }



        /// <summary>
        /// roll takes a string, delimited by a 'd' and rolls dice based on the argument. it returns a list containing the rolls
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<int> roll(string value)
        {
            int d = 0;                                                      //this is the location of 'D'
            int die = 0;                                                    //this is the numer of die
            int sides = 0;                                                  //this is the number of sides
            string temp = "";                                               //this is a temporary string
            List<int> rolls = new List<int>();                              //this is a list of our rolls
            Random random = new Random();                                   //this is our random number generator                    

            //this here loop locates the index of our delimiter 'd'
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == 'd')
                    d = i;
            }
            //this here loop creates a temporary string from the all the characters up to the 'd' and parses it into our die variable
            for (int i = 0; i < d; i++)
            {
                temp += value[i];

            }
            die = int.Parse(temp);
            //this resets our temp variable to be empty, we dont want the other data hanging around or our die rolling will be muffed up
            temp = "";

            //this here loop creates a temporary string from the all the characters after the 'd' and parses it into our sides variable
            for (int i = d + 1; i < value.Length; i++)
            {
                temp += value[i];

            }
            sides = int.Parse(temp);

            //this populates our list full of rolls
            for (int i = 0; i < die; i++)
            {
                rolls.Add(random.Next(1, sides));

            }
            log.Add(rolls);         //since roll is being invoked by ALL funtions of dicebag, everything will be added to the log
            return rolls;

        }



        /// <summary>
        /// sum_roll takes a string of numbers, delimited by 'd', rolls dice based on the arguments and returns a sum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int sum_roll(string value)
        {

            List<int> rolls = roll(value);
            return rolls.Sum();
        }



      
        /// <summary>
        /// top_roll_sum takes a String of values delimited  by a 'd' and sums the top "top_num" of them
        /// </summary>
        /// <param name="value"></param>
        /// <param name="top_num"></param>
        /// <returns></returns>
        public int top_roll_sum(string value, int top_num)
        {
            List<int> rolls = roll(value);
            rolls.Sort();
            return rolls.GetRange(rolls.Count - 1 - top_num, top_num - 1).Sum();
        }





        /// <summary>
        /// THis takes a string delimited by a 'd' and returns the sum of the "bottom_num" lowest elements in the list
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bottom_num"></param>
        /// <returns></returns>
        public int bottom_roll_sum(string value, int bottom_num)
        {
            List<int> rolls = roll(value);
            rolls.Sort();
            return rolls.GetRange(0, bottom_num).Sum();

        }



    }
}


