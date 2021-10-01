# LAB1_Compiladores_JorgeGac-a_1220019
Laboratorio 1 del curso de Compiladores - Segundo Ciclo Tercer Año
El archivo ejecutable se encuentra en la carpeta NET.

Gramática:
A -> BA'
A'-> +BA'|-BA'|e
B -> CB'
B'-> *CB'|/CB'|e
C -> -C|D
D -> numD'|(A)
D'-> numD'|e

A -> BA'
First(A) = First(B) = First(C) = (-,num,()

A'-> +BA'|-BA'|e
First(A') = (+,-,e)

B -> CB'
First(B) = First(C) = (-,num,()

B'-> *CB'|/CB'|e
First(B') = (*,/,e)

C -> -C|D
First(C) = (-,num,()

D -> numD'|(A)
First(D) = (num,()

D'-> numD'|e
First(D') = (num,e)
