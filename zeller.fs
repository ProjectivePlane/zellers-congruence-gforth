0 constant saturday
1 constant sunday
2 constant monday
3 constant tuesday
4 constant wednesday
5 constant thursday
6 constant friday



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
13 constant january
14 constant february

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