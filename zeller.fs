0 constant sunday
1 constant monday
2 constant tuesday
3 constant wednesday
4 constant thursday
5 constant friday
6 constant saturday

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