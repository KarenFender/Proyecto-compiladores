import sys

#afd=[['A','a','B'],['A','b','C'],['B','a','B'],['B','b','E'],['C','a','B'],['C','b','C'],['E','a','B'],['E','b','F'],['F','a','B'],['F','b','C']]
afd = sys.argv[1]

#edo_final=['F']
edo_final = sys.argv[2]
edo=[]

cad = sys.argv[3]
#cad = sys.argv[2]

#Realizamos las trancisiones
def ver_trans(cadena, cadena2):
	cont=0
	actual=cadena2[0][0]
    #Usamos un while para que pueda realizar todas las trancisiones, y no se quede corto 	
	while cont<len(cadena):
		#usamos un for para ir recorriendo la lista de transiciones
		for j in cadena2:
			trans=cadena[cont]
			#Verificamos si el estado actual y el primer elemento de la cadena a evaluar existen en las transiciones
			if j[0]==actual and j[1]==trans:
				actual=j[2]
				cont=cont+1
				#print "trancision:", trans
				#print "estado siguiente:", actual
				#verifica si el contador es igual al tamano de cadena
		        if(cont==len(cadena)):
					edo.append(actual)
					#print "edo final",edo
					break

def val_cad(pila,edo_final):
	temp=pila.pop()
	for i in edo_final:
		if(i==temp):
		#Cadena Valida
			print "VALIDA"
		else:
		#Cadena Invalida
			print "INVALIDA"
				
				

			
				
ver_trans(cad, afd)
val_cad(edo, edo_final)
print "\n"
