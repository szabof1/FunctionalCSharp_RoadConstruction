# FunctionalCSharp_RoadConstruction

**A C# test excercise for grammar schools - solved in a functional way using lots of LINQ**

My 18 year son is learning basic level C# programming in the grammar school.
This excercise was his very last homework (for the winter hollydays of 2016) and he asked for some help.

I have never did C#, never wrote a single line of code in this language. So I started to grab the basics (from Learn X in Y minutes, and Stackoverflow) and 
created a basic imperative version (using if-else, for and while loops, and structs, these are the elements 
that are tought in the school of my son). It took me about 2 days. 
My program worked and based on this I was able to help my son who managed to finish this excercise by himself with some guidence from me.

I was not happy with that solution of mine. Lately _I am a big fan of functional programming_. 
So I started to rewrite my program, I converted structs into classes, arrays into lists, and get rid of for and while loops,
instead I used ForEach loops and as many as possible LINQ features. During this process I become a big fan of LINQ.

I'd never have thought that I would like writing C# code. I have really enjoyed this challange.


## Specification of the excercise
There are two cities connected with a road. A 1000 meter long section of this road is under construction,
so overtaking is prohibited there.
One day the cars crossing this road-section were registered, data such as 
- time (hours minutes seconds) when they reached the road-section, 
- the time (in seconds) that they would require to pass the road-section if there wouldn't be prohibition to overtake,
- the code of the city the car was coming from ('U' for **_Upper_**, 'L' for **_Lower_** city).

These data are separated by a single space, and every record is stored in a new line.
However the very first line of the file has only one number, that is the number of records in the file.
(We know that this record number cannot be more than 2000.)
The file is called **_traffic.txt_**.

### Task #1
**Read the traffic data from the text file.**

### Task #2
**Based on data from user input ('n'), find out what city was the 'n'th car (reaching the restricted route-section) going toward?**

### Task #3
**Calculate the difference of the entering time (when reaching the road-section) in seconds of the last two cars
going toward _Upper_ city.**

### Task #4
**Show the sum of cars in both direction grouped by hours when entering the road-section (hour sumFromLower sumFromUpper).**

### Task #5
**Find the 10 fastest cars regarding their speed when reaching the road-section. 
Show for these 10 cars their entering time (hours minutes seconds), the city they are going toward, 
and the speed at the moment of entering the road-section (in m/s).**

### Task #6
**Calculate the real leaving time (when cars pass the road-section) toward _Lower_ city and save the data in a text file.**

**If a car is blocked by a slower car (beware, there is a prohibition of overtaking)
then the second car leaves the road-section in the same time when the provious one does.**

**Save these data into a text file called _lower.txt_
having formatted as 'HH mm ss' (hours minutes seconds), the three fields must be separated by a single space.**


That's all.


The solution must be a console application.