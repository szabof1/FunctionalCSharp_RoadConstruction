# FunctionalCSharp_RoadConstruction

**A C# test excercise for grammar schools - solved in a functional way using lots of LINQ**

My 18 year son is learning basic level C# programming in the grammar school.
This excercise was his very last homework and he asked for some help.

I have never did C#, never wrote a single line of code in this language. So I started to grab the basics and 
created a basic imperative version (using if-else, for and while loops, and structs, these are the elements 
that are tought in the school of my son). 
It worked and based on this I was able to help my son who managed to finish this excercise.

I was not happy with that solution of mine. Lately I am a big fan of functional programming. 
So I started to rewrite my program, I converted structs into classes, and get rid of for and while loops,
instead I used ForEach loops and as many as possible LINQ features. During this process I become a big fan of LINQ.

I'd never have thought that I would like writing C# code. I have really enjoyed this challange.


## Specification of the excercise
There are two cities connected with a road. A 1000 meter long section of this road is under construction,
so overtaking is prohibited there.
One day the cars crossing this road-section were registered. Data such as 
- time (hours minutes seconds) when they reached the road-section, 
- the time (in seconds) that they would require to pass the road-sectionif there wouldn't be prohibition to overtake,
- the code of the city the car was coming from ('U' for Upper, 'L' for Lower city),
These data are separated by a single space, and every record is stored in a new line.
However the very first line of the file has only one number, that is the number of records in the file.
The file is called 'traffic.txt'.

### Task #1
**Read the traffic data from the text file.**

### Task #2
**Based on data from user input, find out what city was the 'n'th car (reaching the restricted route-section) going toward?**

### Task #3
**Calculate the difference of the entering time (when reaching the road-section) in seconds of the last two cars
going toward 'Upper' city.**

### Task #4
**Show the sum of cars in both direction grouped by hours (hour sumFromLower sumFromUpper).**

### Task #5
**Find the 10 fastest cars regarding their speed when reaching the road-section.**

### Task #6
**Calculate the real leaving time (when cars pass the road-section) toward 'Lower' city. Save these data into a text file called 'lower.txt'
having formatted as 'HH mm ss' (hours minutes seconds), the three fields must be separated by a single space.**
