LDR R0, 1
CMP R1, #2
BGT other

CMP R1, #1
BEQ first

secondOrThrid:
MOV R1, #1
STR R1, 0
B end

first:
MOV R1, #0
STR R1, 0
B end

other:
MOV R1, #1
MOV R2, #1
MOV R3, #3
MOV R10, #2

inner:
CMP R3, R0
BEQ done
CMP R10, #1
BEQ modfirst

modsecond:
ADD R3, R3, #1
ADD R2, R2, R1
ADD R10, R10, #1
B inner


modfirst:
ADD R3, R3, #1
ADD R1, R2, R1
ADD R10, R10, #1
B inner

done:
CMP R10, #1
BEQ storedFirst
STR R2, 0
B end

storedFirst:
STR R1, 0


end:
HALT




