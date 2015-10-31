0 constant saturday
1 constant sunday
2 constant monday
3 constant tuesday
4 constant wednesday
5 constant thursday
6 constant friday

1 constant january
2 constant february
3 constant march
4 constant april
5 constant may
6 constant june
7 constant july
8 constant august
9 constant september
10 constant october
11 constant november
12 constant december

3 constant modified-march
4 constant modified-april
5 constant modified-may
6 constant modified-june
7 constant modified-july
8 constant modified-august
9 constant modified-september
10 constant modified-october
11 constant modified-november
12 constant modified-december
13 constant modified-january
14 constant modified-february

: modified-date ( nyear nmonth nday -- nmodyear nmodmonth nday)
    >r
    dup 3 < if
	12 + >r
	1- r>
    then r> ;

: calculation-intermediates
    rot rot
    swap
    dup 100 mod swap
    100 / ;

: month-term
    1+ 13 * 5 / ;

: year-term
    dup 4 / + ;

: gregorian-century-term
    dup 4 / swap
    5 * + ;

: julian-century-term
    5 swap 6 * - ;

: gregorian-sum ( nq nm nK nJ -- nSum)
    gregorian-century-term
     >r
     year-term
     >r
     month-term
     +
     r>
     +
     r>
     + ;

: gregorian-day-of-week ( ny nm nd - ndow)
    modified-date
    calculation-intermediates
    gregorian-sum 7 mod ;

: julian-sum ( nq nm nK nJ -- nSum)
    julian-century-term >r
    year-term >r
    month-term +
    r> + r> + ;

: julian-day-of-week ( ny nm nd - ndow)
    modified-date
    calculation-intermediates
    julian-sum 7 mod ;

: print-month-name ( n --)
    case
	january of ." January" endof
	february of ." February" endof
	march of ." March" endof
	april of ." April" endof
	may of ." May" endof
	june of ." June" endof
	july of ." July" endof
	august of ." August" endof
	september of ." September" endof
	october of ." October" endof
	november of ." November" endof
	december of ." December" endof
	." Incorrect month value!"
    endcase ;

: print-date ( nyear nmonth nday -- nyear nmonth nday)
    dup . ." of " >r
    dup print-month-name >r
    dup ."  " . r> r> ;

: print-day ( n --)
    case
	saturday of ." Saturday" endof
	sunday of ." Sunday" endof
	monday of ." Monday" endof
	tuesday of ." Tuesday" endof
	wednesday of ." Wednesday" endof
	thursday of ." Thursday" endof
	friday of ." Friday" endof
	." Incorrect day value!"
    endcase ;

: print-gregorian-day-of-week ( nyear nmonth nday --)
    print-date
    ." is a "
    gregorian-day-of-week
    print-day ;

: print-julian-day-of-week ( nyear nmonth nday --)
    print-date
    ." is a "
    julian-day-of-week
    print-day ;