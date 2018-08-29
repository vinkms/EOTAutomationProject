using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOTAutomation
{
    public class WebElements
    {
        public static ArrayList dayStart = new ArrayList(new string[] {"day1_shift_start",
                                                            "day2_shift_start",
                                                            "day3_shift_start",
                                                            "day4_shift_start",
                                                            "day5_shift_start"});


       public static ArrayList dayEnd = new ArrayList(new string[] { "day1_shift",
                                                            "day2_shift",
                                                            "day3_shift",
                                                            "day4_shift",
                                                            "day5_shift"});

       public static ArrayList hours = new ArrayList(new string[] {  "day1_hours",
                                                            "day2_hours",
                                                            "day3_hours",
                                                            "day4_hours",
                                                            "day5_hours"});

        

    }
}
