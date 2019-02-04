# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""

#from IPython.display import Math, display
import sympy as s
import sys

    
equation =sys.argv[1]
a =sys.argv[2].split(',')
nazwa_old =sys.argv[3]
nazwa=nazwa_old.replace("+", " ")
acc =sys.argv[4]
unit=''
pref=''
a_st=[]
for i, sth in enumerate(a) :
    a[i]=float(sth)
        
for e,i in enumerate(a):
    a_st.append(str(i))
       
a_s=s.symbols(nazwa)
expr=s.sympify(equation)
lista_1=[]
for e,i in enumerate(a_s):
    lista_1.append([i,a_st[e]])
        
wynik=expr.subs(lista_1)
lista_2=[]
for e,i in enumerate(a_s):
    lista_2.append([i,a[e]])
        
wynik_k=expr.subs(lista_2)
c=wynik_k.evalf(acc)
f=s.Eq(expr,wynik)
slowo=''
#slowo='$'
slowo+=pref
slowo+=s.latex(expr)
slowo+='='
slowo+=s.latex(wynik)
#slowo+=s.latex(f)
slowo+='='
slowo+=s.latex(c)
slowo+=unit
#slowo+=2*chr(92)
#slowo+='$'
print (slowo);
#display(Math(slowo))
        

    
        

    
